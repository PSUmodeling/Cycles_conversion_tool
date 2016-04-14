Option Explicit On
Imports System.Threading

Friend Class MainClass
    '               Author & Programmer: Armen R. Kemanian - Penn State University
    '               Author & Programmer: Claudio O. Stockle - Washington State University
    '               Programmer: Shawn Quisenberry - AgriLIFE Research (Dec/2009)

    Friend Const VERSION As String = "BETA 4.0.0"               'year, month, day, daily revision 

    Private AutoFertilization As AutoFertilizationClass
    Private AutoIrrigation As AutoIrrigationClass
    Private Crop As CropClass
    'Private CropHarvest As CropHarvestClass
    Private FixedFertilization As FixedFertilizationClass
    Private FixedIrrigation As FixedIrrigationClass
    'Private RealizedCrop As RealizedCropClass
    'Private Residue As ResidueClass
    Private SimControl As SimControlClass
    'Private Snow As SnowClass
    Private Soil As SoilClass
    'Private SoilCarbon As SoilCarbonClass
    'Private SoilTemperature As SoilTemperatureClass
    Private ThermalTime As CropThermalTimeClass
    Private Tillage As TillageClass
    Private Weather As WeatherClass
    'Private Outputs As OutputsClass


    Friend Sub Main(ByVal myExcel As Excel.Application, ByVal myWorkbook As Excel.Workbook, Optional ByVal importedFile As String = Nothing)
        'Precondition:  Excel has been started
        '               Results workbook created
        '               Inputs are within expected value ranges

        'Dim Daily As New DailyClass
        Dim backWorker As Thread = Nothing
        'Dim rotationYear, nextSeedingDate, nextSeedingYear As Integer

        MainForm.RuntimeStatus("Initializing")
        Initialize(myExcel, myWorkbook, importedFile)
        'If  Then


        'Crops.SelectCropInitialPosition()

        'If Crops.CropsPerRotation > 0 Then
        ' nextSeedingYear = Crops.Peek_CropSeedingYear
        ' nextSeedingDate = Crops.Peek_CropSeedingDate
        ' Else
        ' nextSeedingYear = 0
        ' nextSeedingDate = 0
        ' End If

        ' rotationYear = 0
        ' MainForm.RuntimeStatus("Simulation running    ")
        ' MainForm.startProgressBar(SimControl.totalYears)

        'For y As Integer = 1 To SimControl.totalYears
        'If rotationYear < SimControl.yearsInRotation Then
        'rotationYear += 1
        'Else
        '   rotationYear = 1
        'End If

        'Call Tillage.SelectOperationYear(rotationYear)
        'Call FixedIrrigation.SelectOperationYear(rotationYear)
        'Call FixedFertilization.SelectOperationYear(rotationYear)

        'For i As Integer = 1 To Soil.totalLayers
        ' SoilCarbon.carbonMassInitial(y, i) = Soil.SOC_Mass(i)
        ' SoilCarbon.carbonMassFinal(y, i) = 0
        ' SoilCarbon.annualHumifiedCarbonMass(y, i) = 0
        ' SoilCarbon.annualRespiredCarbonMass(y, i) = 0
        ' Next

        'For doy As Integer = 1 To SimControl.yearSpecificLastDOY(y)
        'Call Daily.DailyOperations(rotationYear, y, doy, nextSeedingYear, nextSeedingDate, AutoIrrigation, Crop, FixedFertilization, FixedIrrigation, RealizedCrop, Residue, SimControl, Snow, Soil, SoilCarbon, SoilTemperature, Tillage, Weather)
        'Call Outputs.StoreDailyOutputs(y, doy, SimControl.yearSpecificLastDOY(y), Crop, Soil, Residue, Weather, SoilCarbon, Snow)
        'Next

        'Call SoilCarbon.StoreOutput(y, Soil.totalLayers, Soil.SOC_Mass)
        'Call Outputs.StoreAnnualSoilOutput(y, Soil, SoilCarbon)
        'C() all Outputs.StoreCarbonEvolutionOutput(y, Soil, SoilCarbon, Residue)
        '
        'C() all Delay(backWorker) 'this delay let's the backworker finish the printing before starting another printing batch
        '
        '             Call Outputs.CopyForPrinting()
        '              backWorker = New Thread(AddressOf Outputs.PrintAnnualResults) : backWorker.Start()
        '               Call MainForm.updateProgressBar()
        '            Next y

        'Call Delay(backWorker)

        'Call RealizedCrop.msgboxOpList()

        Call MainForm.stopProgressBar()
        MainForm.RuntimeStatus("Writing results to file")

        'Call CropHarvest.SimulatedAverageYields(Crop, RealizedCrop, Residue)
        'Call Outputs.PrintSummaryResults(SimControl, SoilCarbon, Residue, Soil, RealizedCrop)
        'End If

        AutoFertilization = Nothing
        AutoIrrigation = Nothing
        Crop = Nothing
        'CropHarvest = Nothing
        'Daily = Nothing
        FixedFertilization = Nothing
        FixedIrrigation = Nothing
        'Outputs = Nothing
        'RealizedCrop = Nothing
        'Residue = Nothing
        SimControl = Nothing
        'Snow = Nothing
        Soil = Nothing
        ' SoilCarbon = Nothing
        'SoilTemperature = Nothing
        ThermalTime = Nothing
        Tillage = Nothing
        Weather = Nothing
    End Sub

    Private Function Initialize(ByVal myExcel As Excel.Application, ByRef myWorkbook As Excel.Workbook, ByVal importedFile As String) As Boolean
        'Precondition:  Source information formatted and located properly
        '               Classes are declared
        'Postcondition: Classes initialized
        '               Source information read and stored in appropriate classes
        '               Weather file read

        Dim PMET As New ReferenceETClass

        Dim tillList(,) As Object = Nothing
        Dim fixedFertList(,) As Object = Nothing
        Dim autoFertList(,) As Object = Nothing
        Dim fixedIrrList(,) As Object = Nothing
        Dim autoIrrList(,) As Object = Nothing
        Dim plantingOrder(,) As Object = Nothing
        Dim cropDescriptions(,) As Object = Nothing
        Dim weatherFile As String = Nothing
        Dim layerThickness() As Double = Nothing
        Dim Clay() As Double = Nothing
        Dim Sand() As Double = Nothing
        Dim IOM() As Double = Nothing
        Dim NO3() As Double = Nothing
        Dim NH4() As Double = Nothing
        Dim bulkDensity() As Double = Nothing
        Dim FC() As Double = Nothing
        Dim PWP() As Double = Nothing
        Dim usingTill, usingFixedFert, usingAutoFert, usingFixedIrr, usingAutoIrr, dailyCrop, _
            dailyWater, dailySoil, dailyNitrogen, dailyWeather, dailyResidue, dailySoilCarbon, _
            annualSoil, annualProfile, seasonOuts, adjustedYields, hourlyInfil, autoNitrogen, _
            autoPhosphorus, autoSulfur, manualBD, manualFC, manualPWP As Boolean
        Dim startYear, endYear, rotationSize, totalYears, totalLayers, selectedLayer As Integer
        Dim slope, curve As Double

        'arrays are zero based
        If importedFile = Nothing Then
            Dim Import As New MainForm.formRead
            Dim Export As New ImportExport.xlsWrite(VERSION)

            Import.SimulationControls(weatherFile, startYear, endYear, rotationSize, adjustedYields, hourlyInfil, _
                                      autoNitrogen, autoPhosphorus, autoSulfur, dailyCrop, dailySoil, dailyNitrogen, _
                                      dailyWater, dailyWeather, dailyResidue, dailySoilCarbon, annualSoil, annualProfile, seasonOuts)
            Import.SoilDescription(manualBD, manualFC, manualPWP, layerThickness, Clay, Sand, IOM, NO3, NH4, _
                                   bulkDensity, FC, PWP, totalLayers, selectedLayer, slope, curve)
            Import.CropDescriptions(cropDescriptions)
            Import.PlantingOrder(plantingOrder)
            Import.Tillage(tillList, usingTill)
            Import.FixedIrrigation(fixedIrrList, usingFixedIrr)
            Import.AutoIrrigation(autoIrrList, usingAutoIrr)
            Import.FixedFertilization(fixedFertList, usingFixedFert)
            Import.AutoFertilization(autoFertList, usingAutoFert)

            Export.SimulationControls(myWorkbook, weatherFile, startYear, endYear, rotationSize, adjustedYields, hourlyInfil, _
                                      autoNitrogen, autoPhosphorus, autoSulfur, dailyCrop, dailySoil, dailyNitrogen, dailyWater, _
                                      dailyWeather, dailyResidue, dailySoilCarbon, annualSoil, annualProfile, seasonOuts)
            Export.SoilDescription(myWorkbook, manualBD, manualFC, manualPWP, layerThickness, Clay, Sand, IOM, NO3, NH4, _
                                   bulkDensity, FC, PWP, totalLayers, selectedLayer, slope, curve)
            Export.CropDescriptions(myWorkbook, cropDescriptions)
            Export.PlantingOrder(myWorkbook, plantingOrder)
            Export.Tillage(myWorkbook, tillList, usingTill)
            Export.FixedIrrigation(myWorkbook, fixedIrrList, usingFixedIrr)
            Export.AutoIrrigation(myWorkbook, autoIrrList, usingAutoIrr)
            Export.FixedFertilization(myWorkbook, fixedFertList, usingFixedFert)
            Export.AutoFertilization(myWorkbook, autoFertList, usingAutoFert)

            Import = Nothing
            Export = Nothing
        Else
            Dim Import As New ArmenCustomIO.xlsRead
            Dim Export As New ArmenCustomIO.xlsWrite(VERSION)

            If Not Import.OpenSource(myExcel, importedFile) Then
                Import = Nothing
                Export = Nothing
                Return False
            End If

            Import.SimulationControls(weatherFile, startYear, endYear, rotationSize, adjustedYields, hourlyInfil, autoNitrogen, _
                                      autoPhosphorus, autoSulfur, dailyCrop, dailySoil, dailyNitrogen, dailyWater, dailyWeather, _
                                      dailyResidue, dailySoilCarbon, annualSoil, annualProfile, seasonOuts)
            Import.SoilDescription(manualBD, manualFC, manualPWP, layerThickness, Clay, Sand, IOM, NO3, NH4, _
                                   bulkDensity, FC, PWP, totalLayers, selectedLayer, slope, curve)
            Import.CropDescriptions(cropDescriptions)
            Import.PlantingOrder(plantingOrder)
            Import.Tillage(tillList, usingTill)
            Import.FixedIrrigation(fixedIrrList, usingFixedIrr)
            Import.AutoIrrigation(autoIrrList, usingAutoIrr)
            Import.FixedFertilization(fixedFertList, usingFixedFert)
            Import.AutoFertilization(autoFertList, usingAutoFert)
            Import.CloseSource()

            Export.SimulationControls(myWorkbook, weatherFile, startYear, endYear, rotationSize, adjustedYields, hourlyInfil, _
                                      autoNitrogen, autoPhosphorus, autoSulfur, dailyCrop, dailySoil, dailyNitrogen, dailyWater, _
                                      dailyWeather, dailyResidue, dailySoilCarbon, annualSoil, annualProfile, seasonOuts)
            Export.SoilDescription(myWorkbook, manualBD, manualFC, manualPWP, layerThickness, Clay, Sand, IOM, NO3, NH4, _
                                   bulkDensity, FC, PWP, totalLayers, selectedLayer, slope, curve)
            Export.CropDescriptions(myWorkbook, cropDescriptions)
            Export.PlantingOrder(myWorkbook, plantingOrder)
            Export.Tillage(myWorkbook, tillList, usingTill)
            Export.FixedIrrigation(myWorkbook, fixedIrrList, usingFixedIrr)
            Export.AutoIrrigation(myWorkbook, autoIrrList, usingAutoIrr)
            Export.FixedFertilization(myWorkbook, fixedFertList, usingFixedFert)
            Export.AutoFertilization(myWorkbook, autoFertList, usingAutoFert)

            Import = Nothing
            Export = Nothing
        End If

        CreateResultSheets(myWorkbook, dailyCrop, dailySoil, dailyNitrogen, dailyWater, dailyWeather, dailyResidue, dailySoilCarbon, annualSoil, annualProfile, seasonOuts)

        totalYears = endYear - startYear + 1

        AutoFertilization = New AutoFertilizationClass
        AutoIrrigation = New AutoIrrigationClass
        Crop = New CropClass
        'CropHarvest = New CropHarvestClass
        FixedFertilization = New FixedFertilizationClass()
        FixedIrrigation = New FixedIrrigationClass()
        'RealizedCrop = New RealizedCropClass
        'Residue = New ResidueClass(totalYears, selectedLayer + 1)
        SimControl = New SimControlClass(weatherFile, startYear, endYear, totalYears, rotationSize, adjustedYields, hourlyInfil, _
                                         autoNitrogen, autoPhosphorus, autoSulfur, dailyCrop, dailySoil, dailyNitrogen, dailyWater, _
                                         dailyWeather, dailyResidue, dailySoilCarbon, annualSoil, annualProfile, seasonOuts)
        'Snow = New SnowClass
        Soil = New SoilClass(selectedLayer)
        'SoilCarbon = New SoilCarbonClass(totalYears, selectedLayer + 1)
        'SoilTemperature = New SoilTemperatureClass
        ThermalTime = New CropThermalTimeClass
        Tillage = New TillageClass(selectedLayer)
        Weather = New WeatherClass(totalYears)
        'Outputs = New OutputsClass(totalYears, selectedLayer, startYear, dailyCrop, dailySoil, dailyNitrogen, dailyWater, _
        '                           dailyWeather, dailyResidue, dailySoilCarbon, annualSoil, annualProfile, seasonOuts, myWorkbook)

        '========== Store parameters ==========
        Call Soil.StoreInputData(manualBD, manualFC, manualPWP, layerThickness, Clay, Sand, IOM, NO3, NH4, bulkDensity, FC, PWP, slope, curve)
        Crops.StoreInputData(plantingOrder, cropDescriptions, rotationSize, autoIrrList, usingAutoIrr, autoFertList, usingAutoFert)

        If usingTill Then
            For i As Integer = 0 To tillList.GetUpperBound(0)
                Tillage.AddTillageOperation(tillList(i, 0), tillList(i, 1), tillList(i, 2), tillList(i, 3), tillList(i, 4), tillList(i, 5))
            Next
        End If

        If usingFixedIrr Then
            For i As Integer = 0 To fixedIrrList.GetUpperBound(0)
                FixedIrrigation.AddIrrigationOperation(fixedIrrList(i, 0), fixedIrrList(i, 1), fixedIrrList(i, 2))
            Next
        End If

        If usingFixedFert Then
            For i As Integer = 0 To fixedFertList.GetUpperBound(0)
                FixedFertilization.AddFertilizerOperation(fixedFertList(i, 0), fixedFertList(i, 1), fixedFertList(i, 2), fixedFertList(i, 3), _
                                                          fixedFertList(i, 4), fixedFertList(i, 5), Math.Min(CInt(fixedFertList(i, 6)), selectedLayer), _
                                                          fixedFertList(i, 7), fixedFertList(i, 8), fixedFertList(i, 9), fixedFertList(i, 10), _
                                                          fixedFertList(i, 11), fixedFertList(i, 12), fixedFertList(i, 13), fixedFertList(i, 14), _
                                                          fixedFertList(i, 15), fixedFertList(i, 16), fixedFertList(i, 17))
            Next
        End If

        Weather.ReadExcelWeatherFile(myExcel, weatherFile, totalYears, rotationSize, startYear, endYear, SimControl.yearSpecificLastDOY)
        Weather.CalculateDerivedWeather(PMET, SimControl)

        Soil.dampingDepth = 2

        'If Weather.siteLatitude >= 0 Then
        'Soil.annualTemperaturePhase = 100
        ' Else
        'Soil.annualTemperaturePhase = 280
        'End If

        Weather.SelectActiveWeatherDate(1, 1)

        'initializes soil temperature in first day of simulation
        'For i As Integer = 1 To (Soil.totalLayers + 1)
        'Soil.soilTemperature(i) = SoilTemperature.EstimatedSoilTemperature(Soil.nodeDepth(i), 1, Weather.annualAvgTemperature, _
        '                          Weather.annualAmplitude, Soil.annualTemperaturePhase, Soil.dampingDepth)
        ' Next

        PMET = Nothing

        ThermalTime.ComputeThermalTime(SimControl.yearSpecificLastDOY, SimControl.totalYears, Crop, Weather)

        ' Convert to C input files (Y. Shi)
        Dim utf8WithoutBom As New System.Text.UTF8Encoding(False)

        ' Convert simulation control
        Using sim_file As New System.IO.StreamWriter(myWorkbook.Path + "/" + Microsoft.VisualBasic.Left(myWorkbook.Name, InStrRev(myWorkbook.Name, ".")) + "ctrl", False, utf8WithoutBom)
            sim_file.WriteLine("{0,-24}{1,-4}", "SIMULATION_START_YEAR", startYear)
            sim_file.WriteLine("{0,-24}{1,-4}", "SIMULATION_END_YEAR", endYear)
            sim_file.WriteLine("{0,-24}{1,-4}", "ROTATION_SIZE", rotationSize)
            sim_file.WriteLine("{0,-24}{1,-4:D}", "ADJUSTED_YIELDS", Convert.ToInt32(adjustedYields))
            sim_file.WriteLine("{0,-24}{1,-4:D}", "HOURLY_INFILTRATION", Convert.ToInt32(hourlyInfil))
            sim_file.WriteLine("{0,-24}{1,-4:D}", "AUTOMATIC_NITROGEN", Convert.ToInt32(autoNitrogen))
            sim_file.WriteLine("{0,-24}{1,-4:D}", "AUTOMATIC_PHOSPHORUS", Convert.ToInt32(autoPhosphorus))
            sim_file.WriteLine("{0,-24}{1,-4:D}", "AUTOMATIC_SULFUR", Convert.ToInt32(autoSulfur))
            sim_file.WriteLine("{0,-24}{1,-4:D}", "DAILY_WEATHER_OUT", Convert.ToInt32(dailyWeather))
            sim_file.WriteLine("{0,-24}{1,-4:D}", "DAILY_CROP_OUT", Convert.ToInt32(dailyCrop))
            sim_file.WriteLine("{0,-24}{1,-4:D}", "DAILY_RESIDUE", Convert.ToInt32(dailyResidue))
            sim_file.WriteLine("{0,-24}{1,-4:D}", "DAILY_WATER_OUT", Convert.ToInt32(dailyWater))
            sim_file.WriteLine("{0,-24}{1,-4:D}", "DAILY_NITROGEN_OUT", Convert.ToInt32(dailyNitrogen))
            sim_file.WriteLine("{0,-24}{1,-4:D}", "DAILY_SOIL_CARBON", Convert.ToInt32(dailySoilCarbon))
            sim_file.WriteLine("{0,-24}{1,-4:D}", "DAILY_SOIL_OUT", Convert.ToInt32(dailySoil))
            sim_file.WriteLine("{0,-24}{1,-4:D}", "ANNUAL_SOIL_OUT", Convert.ToInt32(annualSoil))
            sim_file.WriteLine("{0,-24}{1,-4:D}", "ANNUAL_PROFILE_OUT", Convert.ToInt32(annualProfile))
            sim_file.WriteLine("{0,-24}{1,-4:D}", "SEASON_OUT", Convert.ToInt32(seasonOuts))
            sim_file.WriteLine("{0,-24}{1}", "CROP_FILE", Left(myWorkbook.Name, InStrRev(myWorkbook.Name, ".")) + "crop")
            sim_file.WriteLine("{0,-24}{1}", "OPERATION_FILE", Left(myWorkbook.Name, InStrRev(myWorkbook.Name, ".")) + "operation")
            sim_file.WriteLine("{0,-24}{1}", "SOIL_FILE", Left(myWorkbook.Name, InStrRev(myWorkbook.Name, ".")) + "soil")
            Dim weather_fn As String = Right(weatherFile, weatherFile.Length - InStrRev(weatherFile, "\"))
            sim_file.WriteLine("{0,-24}{1}", "WEATHER_FILE", Left(weather_fn, InStrRev(weather_fn, ".")) + "weather")
        End Using

        'Convert soil input
        Using soil_file As New System.IO.StreamWriter(myWorkbook.Path + "/" + Microsoft.VisualBasic.Left(myWorkbook.Name, InStrRev(myWorkbook.Name, ".")) + "soil", False, utf8WithoutBom)
            soil_file.WriteLine("{0,-20}{1,-8}", "CURVE_NUMBER", curve)
            soil_file.WriteLine("{0,-20}{1,-8}", "SLOPE", slope)
            soil_file.WriteLine("{0,-20}{1,-8}", "TOTAL_LAYERS", totalLayers)
            soil_file.WriteLine("{0,-8}{1,-8}{2,-8}{3,-8}{4,-8}{5,-8}{6,-8}{7,-8}{8,-8}{9,-8}", "LAYER", "THICK", "CLAY", "SAND", "ORGANIC", "BD", "FC", "PWP", "NO3", "NH4")
            For i = 0 To selectedLayer - 1
                If Not manualBD Then
                    bulkDensity(i) = -999.0
                End If
                If Not manualFC Then
                    FC(i) = -999.0
                End If
                If Not manualPWP Then
                    PWP(i) = -999.0
                End If
                soil_file.WriteLine("{0,-8:D}{1,-8:F2}{2,-8:F2}{3,-8:F2}{4,-8:F2}{5,-8:F2}{6,-8:F2}{7,-8:F2}{8,-8:G}{9,-8:G}", _
                               i + 1, layerThickness(i), Clay(i), Sand(i), IOM(i), bulkDensity(i), FC(i), PWP(i), NO3(i), NH4(i))
            Next
        End Using

        'Convert crop input
        Using crop_file As New System.IO.StreamWriter(myWorkbook.Path + "/" + Microsoft.VisualBasic.Left(myWorkbook.Name, InStrRev(myWorkbook.Name, ".")) + "crop", False, utf8WithoutBom)
            Crops.SelectCropInitialPosition()
            For i = 0 To cropDescriptions.GetUpperBound(0)

                Crops.SelectNextCrop()

                crop_file.WriteLine("####################################################")
                crop_file.WriteLine("# CROP DESCRIPTION                                 #")
                crop_file.WriteLine("####################################################")
                crop_file.WriteLine("{0,-44}{1}", "NAME", Replace(cropDescriptions(i, 0), " ", ""))
                crop_file.WriteLine("{0,-44}{1,-7:F2}", "FLOWERING_TT", Crops.calculatedFloweringTT)
                crop_file.WriteLine("{0,-44}{1,-7:F2}", "MATURITY_TT", Crops.calculatedMaturityTT)
                crop_file.WriteLine("{0,-44}{1,-3:D}", "MAXIMUM_SOIL_COVERAGE", CInt(cropDescriptions(i, 4)))
                crop_file.WriteLine("{0,-44}{1,-6:F2}", "MAXIMUM_ROOTING_DEPTH", CDbl(cropDescriptions(i, 5)))
                crop_file.WriteLine("{0,-44}{1,-6:F2}", "AVERAGE_EXPECTED_YIELD", CDbl(cropDescriptions(i, 6)))
                crop_file.WriteLine("{0,-44}{1,-6:F2}", "MAXIMUM_EXPECTED_YIELD", CDbl(cropDescriptions(i, 7)))
                crop_file.WriteLine("{0,-44}{1,-6:F2}", "MINIMUM_EXPECTED_YIELD", CDbl(cropDescriptions(i, 8)))
                crop_file.WriteLine("{0,-44}{1,-6:F2}", "COMMERCIAL_YIELD_MOISTURE", CDbl(cropDescriptions(i, 9)))
                crop_file.WriteLine("{0,-44}{1,-6:F2}", "STANDING_RESIDUE_AT_HARVEST", CDbl(cropDescriptions(i, 10)))
                crop_file.WriteLine("{0,-44}{1,-6:F2}", "RESIDUE_REMOVED", CDbl(cropDescriptions(i, 11)))
                crop_file.WriteLine("{0,-44}{1,-6:F2}", "CLIPPING_BIOMASS_THRESHOLD_UPPER", 5.0)
                crop_file.WriteLine("{0,-44}{1,-6:F2}", "CLIPPING_BIOMASS_THRESHOLD_LOWER", 0.5)
                If (cropDescriptions(i, 12) <> Nothing) Then
                    crop_file.WriteLine("{0,-44}{1,-6:F2}", "HARVEST_TIMING", CDbl(cropDescriptions(i, 12)))
                Else
                    crop_file.WriteLine("{0,-44}{1,-6:D}", "HARVEST_TIMING", -999)
                End If
                crop_file.WriteLine("{0,-44}{1}", "CLIPPING_BIOMASS_DESTINY", "REMOVE")
                crop_file.WriteLine("{0,-44}{1,-6:F2}", "MIN_TEMPERATURE_FOR_TRANSPIRATION", CDbl(cropDescriptions(i, 13)))
                crop_file.WriteLine("{0,-44}{1,-6:F2}", "THRESHOLD_TEMPERATURE_FOR_TRANPIRATION", CDbl(cropDescriptions(i, 14)))
                crop_file.WriteLine("{0,-44}{1,-6:F2}", "MIN_TEMPERATURE_FOR_COLD_DAMAGE", CDbl(cropDescriptions(i, 15)))
                crop_file.WriteLine("{0,-44}{1,-6:F2}", "THRESHOLD_TEMPERATURE_FOR_COLD_DAMAGE", CDbl(cropDescriptions(i, 16)))
                crop_file.WriteLine("{0,-44}{1,-6:F2}", "BASE_TEMPERATURE_FOR_DEVELOPMENT", CDbl(cropDescriptions(i, 17)))
                crop_file.WriteLine("{0,-44}{1,-6:F}", "OPTIMUM_TEMPERATURE_FOR_DEVELOPEMENT", CDbl(cropDescriptions(i, 18)))
                crop_file.WriteLine("{0,-44}{1,-6:F}", "MAX_TEMPERATURE_FOR_DEVELOPMENT", CDbl(cropDescriptions(i, 19)))
                crop_file.WriteLine("{0,-44}{1,-6:F}", "INITIAL_PARTITIONING_TO_SHOOT", CDbl(cropDescriptions(i, 20)))
                crop_file.WriteLine("{0,-44}{1,-6:F}", "FINAL_PARTITIONING_TO_SHOOT", CDbl(cropDescriptions(i, 21)))
                crop_file.WriteLine("{0,-44}{1,-6:F}", "RADIATION_USE_EFFICIENCY", CDbl(cropDescriptions(i, 22)))
                crop_file.WriteLine("{0,-44}{1,-6:F}", "TRANSPIRATION_USE_EFFICIENCY", CDbl(cropDescriptions(i, 23)))
                crop_file.WriteLine("{0,-44}{1,-6:F}", "MAXIMUM_HARVEST_INDEX", CDbl(cropDescriptions(i, 24)))
                crop_file.WriteLine("{0,-44}{1,-6:F}", "MINIMUM_HARVEST_INDEX", CDbl(cropDescriptions(i, 25)))
                crop_file.WriteLine("{0,-44}{1,-6:F}", "HARVEST_INDEX", CDbl(cropDescriptions(i, 26)))
                crop_file.WriteLine("{0,-44}{1,-6:F}", "THERMAL_TIME_TO_EMERGENCE", CDbl(cropDescriptions(i, 27)))
                crop_file.WriteLine("{0,-44}{1,-6:F3}", "N_MAX_CONCENTRATION", CDbl(cropDescriptions(i, 28)))
                crop_file.WriteLine("{0,-44}{1,-6:F}", "N_DILUTION_SLOPE", CDbl(cropDescriptions(i, 29)))
                crop_file.WriteLine("{0,-44}{1,-6:F}", "KC", CDbl(cropDescriptions(i, 30)))
                If cropDescriptions(i, 31) = "Annual" Then
                    crop_file.WriteLine("{0,-44}{1}", "ANNUAL", 1)
                Else
                    crop_file.WriteLine("{0,-44}{1}", "ANNUAL", 0)
                End If
                If cropDescriptions(i, 32) = "True" Then
                    crop_file.WriteLine("{0,-44}{1}", "LEGUME", 1)
                Else
                    crop_file.WriteLine("{0,-44}{1}", "LEGUME", 0)
                End If
                If cropDescriptions(i, 33) = "C3" Then
                    crop_file.WriteLine("{0,-44}{1}", "C3", 1)
                Else
                    crop_file.WriteLine("{0,-44}{1}", "C3", 0)
                End If
                crop_file.WriteLine("{0,-44}{1}", "LWP_STRESS_ONSET", -1100.0)
                crop_file.WriteLine("{0,-44}{1}", "LWP_WILTING_POINT", -2000.0)
                crop_file.WriteLine("{0,-44}{1}", "TRANSPIRATION_MAX", 15.0)
                crop_file.WriteLine()
            Next
        End Using

        ' Convert operation input
        Using op_file As New System.IO.StreamWriter(myWorkbook.Path + "/" + Microsoft.VisualBasic.Left(myWorkbook.Name, InStrRev(myWorkbook.Name, ".")) + "operation", False, utf8WithoutBom)
            For y As Integer = 1 To rotationSize
                For d As Integer = 1 To 366
                    For i = 0 To plantingOrder.GetUpperBound(0)
                        If plantingOrder(i, 0) <> Nothing Then
                            If plantingOrder(i, 0) = y And plantingOrder(i, 1) = d Then
                                op_file.WriteLine("PLANTING")
                                op_file.WriteLine("{0,-20}{1,-4:D}", "YEAR", plantingOrder(i, 0))
                                op_file.WriteLine("{0,-20}{1,-3:D}", "DOY", plantingOrder(i, 1))
                                op_file.WriteLine("{0,-20}{1}", "CROP", Replace(plantingOrder(i, 2), " ", ""))
                                If plantingOrder(i, 3) = "True" Then
                                    op_file.WriteLine("{0,-20}{1}", "USE_AUTO_IRR", 1)
                                Else
                                    op_file.WriteLine("{0,-20}{1}", "USE_AUTO_IRR", 0)
                                End If
                                If plantingOrder(i, 4) = "True" Then
                                    op_file.WriteLine("{0,-20}{1}", "USE_AUTO_FERT", 1)
                                Else
                                    op_file.WriteLine("{0,-20}{1}", "USE_AUTO_FERT", 0)
                                End If
                                op_file.WriteLine("{0,-20}{1}", "FRACTION", 1)
                                op_file.WriteLine("{0,-20}{1}", "CLIPPING_START", 1)
                                op_file.WriteLine("{0,-20}{1}", "CLIPPING_END", 366)
                                op_file.WriteLine()
                            End If
                        End If
                    Next

                    For i = 0 To fixedFertList.GetUpperBound(0)
                        If fixedFertList(i, 0) <> Nothing Then
                            If fixedFertList(i, 0) = y And fixedFertList(i, 1) = d Then
                                op_file.WriteLine("FIXED_FERTILIZATION")
                                op_file.WriteLine("{0,-20}{1,-4:D}", "YEAR", fixedFertList(i, 0))
                                op_file.WriteLine("{0,-20}{1,-3:D}", "DOY", fixedFertList(i, 1))
                                op_file.WriteLine("{0,-20}{1}", "SOURCE", Replace(Replace(Replace(fixedFertList(i, 2), " ", "_"), ",", "_"), ".", "_"))
                                op_file.WriteLine("{0,-20}{1,-6:F}", "MASS", fixedFertList(i, 3))
                                op_file.WriteLine("{0,-20}{1}", "FORM", Replace(Replace(Replace(fixedFertList(i, 4), " ", "_"), ",", "_"), ".", "_"))
                                op_file.WriteLine("{0,-20}{1}", "METHOD", Replace(Replace(Replace(fixedFertList(i, 5), " ", "_"), ",", "_"), ".", "_"))
                                op_file.WriteLine("{0,-20}{1,-6:D}", "LAYER", Math.Min(CInt(fixedFertList(i, 6)), selectedLayer))
                                op_file.WriteLine("{0,-20}{1,-6:F}", "C_Organic", fixedFertList(i, 7))
                                op_file.WriteLine("{0,-20}{1,-6:F}", "C_Charcoal", fixedFertList(i, 8))
                                op_file.WriteLine("{0,-20}{1,-6:F}", "N_Organic", fixedFertList(i, 9))
                                op_file.WriteLine("{0,-20}{1,-6:F}", "N_Charcoal", fixedFertList(i, 10))
                                op_file.WriteLine("{0,-20}{1,-6:F}", "N_NH4", fixedFertList(i, 11))
                                op_file.WriteLine("{0,-20}{1,-6:F}", "N_NO3", fixedFertList(i, 12))
                                op_file.WriteLine("{0,-20}{1,-6:F}", "P_Organic", fixedFertList(i, 13))
                                op_file.WriteLine("{0,-20}{1,-6:F}", "P_CHARCOAL", fixedFertList(i, 14))
                                op_file.WriteLine("{0,-20}{1,-6:F}", "P_INORGANIC", fixedFertList(i, 15))
                                op_file.WriteLine("{0,-20}{1,-6:F}", "K", fixedFertList(i, 16))
                                op_file.WriteLine("{0,-20}{1,-6:F}", "S", fixedFertList(i, 17))
                                op_file.WriteLine()
                            End If
                        End If
                    Next

                    For i = 0 To tillList.GetUpperBound(0)
                        If tillList(i, 0) <> Nothing Then
                            If tillList(i, 0) = y And tillList(i, 1) = d Then
                                op_file.WriteLine("TILLAGE")
                                op_file.WriteLine("{0,-20}{1,-4:D}", "YEAR", tillList(i, 0))
                                op_file.WriteLine("{0,-20}{1,-3:D}", "DOY", tillList(i, 1))
                                op_file.WriteLine("{0,-20}{1}", "TOOL", Replace(Replace(Replace(tillList(i, 2), " ", "_"), ",", ""), ".", ""))
                                op_file.WriteLine("{0,-20}{1,-4:F}", "DEPTH", tillList(i, 3))
                                op_file.WriteLine("{0,-20}{1,-4:F}", "SOIL_DISTURB_RATIO", tillList(i, 4))
                                op_file.WriteLine("{0,-20}{1,-4:F}", "MIXING_EFFICIENCY", tillList(i, 5))
                                op_file.WriteLine("{0,-20}{1}", "CROP_NAME", "N/A")
                                op_file.WriteLine("{0,-20}{1}", "FRAC_THERMAL_TIME", 0)
                                op_file.WriteLine("{0,-20}{1}", "KILL_EFFICIENCY", 0.0)
                                op_file.WriteLine("{0,-20}{1}", "GRAIN_HARVEST", 0)
                                op_file.WriteLine("{0,-20}{1}", "FORAGE_HARVEST", 0)
                                op_file.WriteLine()
                            End If
                        End If
                    Next


                    For i = 0 To fixedIrrList.GetUpperBound(0)
                        If fixedIrrList(i, 0) <> Nothing Then
                            If fixedIrrList(i, 0) = y And fixedIrrList(i, 1) = d Then
                                op_file.WriteLine("FIXED_IRRIGATION")
                                op_file.WriteLine("{0,-20}{1,-4:D}", "YEAR", fixedIrrList(i, 0))
                                op_file.WriteLine("{0,-20}{1,-3:D}", "DOY", fixedIrrList(i, 1))
                                op_file.WriteLine("{0,-20}{1,-6:F2}", "VOLUME", fixedIrrList(i, 2))
                                op_file.WriteLine()
                            End If
                        End If
                    Next

                Next
            Next

            For i = 0 To autoIrrList.GetUpperBound(0)
                If autoIrrList(i, 0) <> Nothing Then
                    op_file.WriteLine("AUTO_IRRIGATION")
                    op_file.WriteLine("{0,-20}{1,-3:D}", "START_DOY", autoIrrList(i, 0))
                    op_file.WriteLine("{0,-20}{1,-3:D}", "STOP_DOY", autoIrrList(i, 1))
                    op_file.WriteLine("{0,-20}{1,-6:F}", "WATER_DEPLETION", autoIrrList(i, 2))
                    op_file.WriteLine("{0,-20}{1,-3:D}", "LAST_SOIL_LAYER", Math.Min(CInt(autoIrrList(i, 3)), selectedLayer))
                    op_file.WriteLine()
                End If
            Next
        End Using

        Return True
    End Function

    Private Sub Delay(ByVal backworker As Thread)
        Dim dblWaitTil As Date
        Const delayTime As Double = 10

        If backworker IsNot Nothing Then
            Do While backworker.ThreadState = ThreadState.Running
                dblWaitTil = Now.AddMilliseconds(delayTime)
                Do Until Now > dblWaitTil
                    System.Windows.Forms.Application.DoEvents()
                Loop
            Loop
        End If
    End Sub

End Class
