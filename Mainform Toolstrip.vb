Partial Friend Class MainForm

    '====================================== Tool Strip Options =====================================
    Private Sub RunToolStripMenuItem_Click() Handles RunToolStripMenuItem.Click
        'Precondition:  Excel started
        'Postcondition: Inputs error checked
        '               Results file created
        '               Simulation started

        Dim Subarea As New MainClass
        Dim timer As System.Diagnostics.Stopwatch
        Dim totalTime As Double
        Dim missingField As String = Nothing

        Dim myWorkbook As Excel.Workbook = Nothing
        Dim startSheet As Excel.Worksheet = Nothing

        System.Windows.Forms.Application.DoEvents()

        Me.EditLog("Conversion started", True)
        Me.Cursor = Cursors.WaitCursor

        If RequiredEntriesFilled(missingField) Then
            Me.RuntimeStatus("Creating results file")

            'create new output file for results
            If Me.CreateOutFile(myExcel, myWorkbook) Then

                timer = System.Diagnostics.Stopwatch.StartNew
                startSheet = myWorkbook.Worksheets.Item(1)

                Call Subarea.Main(myExcel, myWorkbook)

                startSheet.Activate()
                myWorkbook.Close(SaveChanges:=True)

                timer.Stop() : totalTime = timer.Elapsed.TotalSeconds.ToString
                Me.EditLog("Conversion finished: " & Format(totalTime, "0.00") & " seconds", True)
            Else
                Me.EditLog("Conversion aborted: Results unable to be written", True)
            End If
        Else
            Me.EditLog("Conversion aborted: Required fields missing", True)
            Me.RuntimeStatus(missingField & " is missing required data.")
        End If

        Me.Cursor = Cursors.Default
        Subarea = Nothing
        System.Windows.Forms.Application.DoEvents()
    End Sub
    Private Sub ExitToolStripMenuItem_Click() Handles ExitToolStripMenuItem.Click
        'Precondition:  None
        'Postcondition: If running, Excel is stopped
        '               Program terminated
        '               Existing fields stored to file if user requests

        Dim ans As Integer
        Dim myWorkbook As Excel.Workbook
        Dim curSettings As String = lclDir & Me.ProductName & " Working Setup.xls"

        ans = MsgBox("Save current settings?", MsgBoxStyle.YesNoCancel, Me.ProductName)

        System.Windows.Forms.Application.DoEvents() 'clears out popups from display cache

        If ans <> vbCancel Then
            If ans = vbYes Then
                Try
                    myWorkbook = myExcel.Workbooks.Add
                Catch ex As Exception
                    MsgBox(Err.Description, MsgBoxStyle.Critical, Me.ProductName)
                    Exit Sub
                End Try

                Call FileOps.CreateMandatorySheets(myWorkbook)
                Call Me.ExportSettings(myWorkbook)

                If System.IO.File.Exists(curSettings) Then System.IO.File.Delete(curSettings)
                myWorkbook.Close(Filename:=curSettings, SaveChanges:=True)
            End If

            PostMessage(myExcel.Hwnd, WM_QUIT, 0, 0)
            myExcel = Nothing
            Me.Close()
        End If
    End Sub
    Private Sub AltRun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AltRun.Click
        'Precondition:  Excel started
        'Postcondition: Results file created
        '               Simulation started

        Dim Subarea As New MainClass
        Dim timer As System.Diagnostics.Stopwatch
        Dim totalTime As Double

        Dim myWorkbook As Excel.Workbook = Nothing
        Dim startSheet As Excel.Worksheet = Nothing

        System.Windows.Forms.Application.DoEvents()

        Call EditLog("Simulation started", True)
        Me.Cursor = Cursors.WaitCursor

        Me.RuntimeStatus("Creating results file")

        'create new output file for results
        If Me.CreateOutFile(myExcel, myWorkbook) Then

            timer = System.Diagnostics.Stopwatch.StartNew
            startSheet = myWorkbook.Worksheets.Item(1)

            Call Subarea.Main(myExcel, myWorkbook, lclDir & Me.ProductName & " Settings.xls")

            startSheet.Activate()
            myWorkbook.Close(SaveChanges:=True)

            timer.Stop() : totalTime = timer.Elapsed.TotalSeconds.ToString
            Me.EditLog("Simulation finished: " & Format(totalTime, "0.00") & " seconds", True)
        Else
            EditLog("Simulation aborted: Results unable to be written", True)
        End If

        Me.Cursor = Cursors.Default
        Subarea = Nothing
        System.Windows.Forms.Application.DoEvents()
    End Sub

    Private Sub ImportToolStripMenuItem_Click() Handles ImportToolStripMenuItem.Click
        'Precondition:  Excel started
        'Postcondition: Settings copied from file and written to the interface

        Dim settingsFile As String = Nothing

        If SelectFile("Project X: Please select a file to import from", settingsFile) Then
            If FileOps.FileExists(settingsFile) Then
                Call Me.ImportSettings(settingsFile)
                Call Me.EditLog("Settings imported: " & settingsFile, False)
            End If
        End If
    End Sub
    Private Sub ExportToolStripMenuItem_Click() Handles ExportToolStripMenuItem.Click
        'Precondition:  Excel started
        'Postcondition: Excel file created and all interface settings copied to it

        Dim myWorkbook As Excel.Workbook = Nothing
        Dim fileReplaced As Boolean = False
        Dim fileName As String = "Project X Settings"

        If FileOps.CreateFile_GUI("Select Settings File", fileName, fileReplaced, myExcel, myWorkbook) Then
            Call Me.ExportSettings(myWorkbook)

            myWorkbook.Close(SaveChanges:=True)

            If fileReplaced Then
                Call EditLog("Settings overwritten: " & fileName, False)
            Else
                Call EditLog("Settings exported: " & fileName, False)
            End If
        End If

    End Sub

    Private Sub SimulationControlsToolStripMenuItem_Click() Handles SimulationControlsToolStripMenuItem.Click
        'Precondition:  None
        'Postcondition: Tab cleared and set to default state

        Call DeleteSimulationControls()
        Call EditLog("Simulation Controls cleared", False)
    End Sub
    Private Sub SoilDescriptionToolStripMenuItem_Click() Handles SoilDescriptionToolStripMenuItem.Click
        'Precondition:  None
        'Postcondition: Tab cleared and set to default state

        Call DeleteSoilInputs()
        Call EditLog("Soil descriptions cleared", False)
    End Sub
    Private Sub CropDescriptionsToolStripMenuItem_Click() Handles CropDescriptionsToolStripMenuItem.Click
        'Precondition:  None
        'Postcondition: Tab cleared and set to default state

        Call DeleteCropDescriptions()
        Call EditLog("Crop descriptions cleared", False)
    End Sub
    Private Sub PlantingOrderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PlantingOrderToolStripMenuItem.Click
        'Precondition:  None
        'Postcondition: Tab cleared and set to default state

        Call DeletePlantingInputs()
        Call EditLog("Planting operations cleared", False)
    End Sub
    Private Sub TillageToolStripMenuItem_Click() Handles TillageToolStripMenuItem.Click
        'Precondition:  None
        'Postcondition: Tab cleared and set to default state

        Call DeleteTillageInputs()
        Call EditLog("Tillage operations cleared", False)
    End Sub
    Private Sub FixedIrrigationToolStripMenuItem_Click() Handles FixedIrrigationToolStripMenuItem.Click
        'Precondition:  None
        'Postcondition: Tab cleared and set to default state

        Call DeleteFixedIrrigationInputs()
        Call EditLog("Fixed Irrigation operations cleared", False)
    End Sub
    Private Sub AutomaticIrrigationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AutomaticIrrigationToolStripMenuItem.Click
        'Precondition:  None
        'Postcondition: Tab cleared and set to default state

        Call DeleteAutoIrrigationInputs()
        Call EditLog("Automatic Irrigation operations cleared", False)
    End Sub
    Private Sub FixedFertilizationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FixedFertilizationToolStripMenuItem.Click
        'Precondition:  None
        'Postcondition: Tab cleared and set to default state

        Call DeleteFixedFertilizationInputs()
        Call EditLog("Fixed Fertilization operations cleared", False)
    End Sub
    Private Sub AutomaticFertilizationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AutomaticFertilizationToolStripMenuItem.Click
        'Precondition:  None
        'Postcondition: Tab cleared and set to default state

        Call DeleteAutoFertilizationInputs()
        Call EditLog("Automatic Fertilization operations cleared", False)
    End Sub
    Private Sub AllToolStripMenuItem_Click() Handles AllToolStripMenuItem.Click
        'Precondition:  None
        'Postcondition: All tabs cleared and set to default state

        Call DeleteAllInputs()
        Call EditLog("User interface cleared", False)
    End Sub

    Private Sub DeleteSimulationControls()
        'Precondition:  None
        'Postcondition: Tab cleared and set to default state
        '               Lists originating from different tabs are not altered
        '               optional outputs booleans set to false

        'results
        Me.resultsFile_Path.Text = Nothing
        Me.resultsFile_Overwrite.Checked = False

        'weather
        Me.weatherFile_Path.Text = Nothing

        'duration
        Me.duration_StartYear.Text = Nothing
        Me.duration_StopYear.Text = Nothing
        Me.duration_RotationSize.Text = Nothing
        Me.duration_TotalYears.Text = Nothing
        Me.duration_TotalRotations.Text = Nothing
        Me.duration_StartYear.Items.Clear()
        Me.duration_StopYear.Items.Clear()

        'calculation options
        Me.calcOptions_adjustedYields.Checked = False
        Me.calcOptions_waterInfiltration.Checked = False

        'optional outputs
        Me.DailyCropReporting.Checked = False
        Me.DailySoilReporting.Checked = False
        Me.DailyNitrogenReporting.Checked = False
        Me.DailyWaterReporting.Checked = False
        Me.DailyWeatherReporting.Checked = False
        Me.AnnualSoilReporting.Checked = False
        Me.AnnualSoilProfileReporting.Checked = False
        Me.SeasonReporting.Checked = False

    End Sub
    Private Sub DeleteSoilInputs()
        'Precondition:  None
        'Postcondition: Tab cleared and set to default state
        '               Lists originating from different tabs are not altered

        Me.soil_maxLayer.Text = Nothing
        Me.soil_maxLayer.Text = 1

        Me.Manual_BD_ckbx.Checked = False
        Me.Manual_FC_ckbx.Checked = False
        Me.Manual_PWP_ckbx.Checked = False

        Me.soil_curve.Text = Nothing
        Me.soil_slope.Text = Nothing
    End Sub
    Private Sub DeleteCropDescriptions()
        'Precondition:  None
        'Postcondition: Tab cleared and set to default state
        '               Lists originating from different tabs are not altered
        '               Crops lists dependent on described crops list set to default state

        Call Me.PopulateUndescribedCropsList()

        For i As Integer = 1 To UBound(Me.ctlCropDescrip)
            ctlCropDescrip(i).Text = Nothing
        Next

        Me.lv_DescribedCrops.Items.Clear()
        Me.grp_DescribedCrops.Text = Me.ActiveListviewOperations(Me.lv_DescribedCrops)

        Me.Chkbx_UseAdvancedDescrip.Checked = False
        Me.plantingSetup_cropName.Items.Clear()
    End Sub
    Private Sub DeletePlantingInputs()
        'Precondition:  None
        'Postcondition: Tab cleared and set to default state
        '               Lists originating from different tabs are not altered
        '               Dependent lists as modified as needed

        Call Me.PerformOperationsStatusChanged(Me.lv_PlantedCrops, cropType, False)

        Me.plantingSetup_cropName.Text = Nothing
        Me.plantingSetup_Year.Text = Nothing
        Me.plantingSetup_Day.Text = Nothing
        Me.plantingSetup_defaultDay.Text = Nothing
        Me.lv_PlantedCrops.Items.Clear()
        Me.grp_PlantedCrops.Text = Me.ActiveListviewOperations(Me.lv_PlantedCrops)
    End Sub
    Private Sub DeleteTillageInputs()
        'Precondition:  None
        'Postcondition: Tab cleared and set to default state
        '               Lists originating from different tabs are not altered

        Me.tillSetup_PerformOperations.Checked = False

        Me.tillSetup_Year.Text = Nothing
        Me.tillSetup_Day.Text = Nothing
        Me.tillSetup_Tool.Text = Nothing
        Me.tillSetup_Depth.Text = Nothing
        Me.tillSetup_DefaultDepth.Text = Nothing
        Me.lv_Tillage.Items.Clear()
        Me.grp_Tillage.Text = Me.ActiveListviewOperations(Me.lv_Tillage)
    End Sub
    Private Sub DeleteFixedIrrigationInputs()
        'Precondition:  None
        'Postcondition: Tab cleared and set to default state
        '               Lists originating from different tabs are not altered

        Me.fixedIrrSetup_PerformOperations.CheckState = False

        Me.fixedIrrSetup_Year.Text = Nothing
        Me.fixedIrrSetup_Day.Text = Nothing
        Me.fixedIrrSetup_Volume.Text = Nothing
        Me.lv_FixedIrrigation.Items.Clear()
        Me.grp_FixedIrrigation.Text = Me.ActiveListviewOperations(Me.lv_FixedIrrigation)
    End Sub
    Private Sub DeleteAutoIrrigationInputs()
        'Precondition:  None
        'Postcondition: Tab cleared and set to default state
        '               Lists originating from different tabs are not altered

        Me.autoIrrSetup_PerformOperations.CheckState = False

        Me.autoIrrSetup_Name.Text = Nothing
        Me.autoIrrSetup_StartDay.Text = Nothing
        Me.autoIrrSetup_StopDay.Text = Nothing
        Me.autoIrrSetup_WaterDepletion.Text = Nothing
        Me.autoIrrSetup_LastSoilLayer.Text = Nothing
        Me.lv_AutomaticIrrigation.Items.Clear()
        Me.grp_AutomaticIrrigation.Text = Me.ActiveListviewOperations(Me.lv_AutomaticIrrigation)

        Call Me.IrrigationPlantAvailableListChanged()
    End Sub
    Private Sub DeleteFixedFertilizationInputs()
        'Precondition:  None
        'Postcondition: Tab cleared and set to default state
        '               Lists originating from different tabs are not altered

        Me.fixedFertSetup_PerformOperations.CheckState = False

        Me.fixedFertSetup_Year.Text = Nothing
        Me.fixedFertSetup_Day.Text = Nothing
        Me.fixedFertSetup_Mass.Text = Nothing
        Me.fixedFertSetup_Source.Text = Nothing
        Me.fixedFertSetup_Form.Text = Nothing
        Me.lv_FixedFertilization.Items.Clear()
        Me.grp_FixedFertilization.Text = Me.ActiveListviewOperations(Me.lv_FixedFertilization)
    End Sub
    Private Sub DeleteAutoFertilizationInputs()
        'Precondition:  None
        'Postcondition: Tab cleared and set to default state
        '               Lists originating from different tabs are not altered

        Me.autoFertSetup_PerformOperations.CheckState = False

        Me.autoFertSetup_StartDay.Text = Nothing
        Me.autoFertSetup_EndDay.Text = Nothing
        Me.autoFertSetup_Mass.Text = Nothing
        Me.autoFertSetup_Source.Text = Nothing
        Me.autoFertSetup_Form.Text = Nothing
        Me.autoFertSetup_Method.Text = Nothing
        Me.lv_AutoFertilization.Items.Clear()
        Me.grp_AutoFertilization.Text = Me.ActiveListviewOperations(Me.lv_AutoFertilization)

        Call Me.FertilizationPlantAvailableListChanged()
    End Sub
    Private Sub DeleteAllInputs()
        'Precondition:  none
        'Postcondition: All fields cleared

        Call Me.DeleteSimulationControls()
        Call Me.DeleteSoilInputs()
        Call Me.DeleteCropDescriptions()
        Call Me.DeletePlantingInputs()
        Call Me.DeleteTillageInputs()
        Call Me.DeleteFixedIrrigationInputs()
        Call Me.DeleteAutoIrrigationInputs()
        Call Me.DeleteFixedFertilizationInputs()
        Call Me.DeleteAutoFertilizationInputs()
    End Sub

    Private Sub ContactInformationToolStripMenuItem_Click() Handles ContactInformationToolStripMenuItem.Click
        Call SideSubs.CopyrightInfo()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        AboutForm.Show()
    End Sub

    Private Sub ImportSettings(ByVal settingsFile As String)
        'Precondition:  Excel started
        '               Settings file is formatted properly
        'Postcondition: settings stored to the user interface

        Dim FillForm As New MainForm.formWrite()
        Dim Import As New ImportExport.xlsRead(MainClass.VERSION)

        Dim usingOps, manualBD, manualFC, manualPWP, adjustedYields, hourlyInfiltration, autoNitrogen, _
            autoPhosphorus, autoSulfur, dailyCropOut, dailySoilOut, dailyNitrogenOut, dailyWaterOut, _
            dailyWeatherOut, dailyResidueOut, dailySoilCarbonOut, annualSoilOut, soilProfileOut, seasonOut As Boolean
        Dim rotationSize, startYear, endYear, totalLayers, selectedLayer As Integer
        Dim weatherFile As String = Nothing
        Dim curve, slope As Double
        Dim fieldOps(,) As Object = Nothing
        Dim LT() As Double = Nothing
        Dim Clay() As Double = Nothing
        Dim Sand() As Double = Nothing
        Dim IOM() As Double = Nothing
        Dim NO3() As Double = Nothing
        Dim NH4() As Double = Nothing
        Dim BD() As Double = Nothing
        Dim FC() As Double = Nothing
        Dim PWP() As Double = Nothing

        Call Me.DeleteAllInputs()

        If Import.OpenSource(myExcel, settingsFile) Then
            Call Import.SimulationControls(weatherFile, startYear, endYear, rotationSize, adjustedYields, hourlyInfiltration, autoNitrogen, _
                                           autoPhosphorus, autoSulfur, dailyCropOut, dailySoilOut, dailyNitrogenOut, dailyWaterOut, _
                                           dailyWeatherOut, dailyResidueOut, dailySoilCarbonOut, annualSoilOut, soilProfileOut, seasonOut)
            Call FillForm.SimulationControls(weatherFile, startYear, endYear, rotationSize, adjustedYields, hourlyInfiltration, autoNitrogen, _
                                             autoPhosphorus, autoSulfur, dailyCropOut, dailySoilOut, dailyNitrogenOut, dailyWaterOut, _
                                             dailyWeatherOut, dailyResidueOut, dailySoilCarbonOut, annualSoilOut, soilProfileOut, seasonOut)

            Call Import.SoilDescription(manualBD, manualFC, manualPWP, LT, Clay, Sand, IOM, NO3, NH4, BD, FC, PWP, totalLayers, selectedLayer, slope, curve)
            Call FillForm.SoilDescription(manualBD, manualFC, manualPWP, LT, Clay, Sand, IOM, NO3, NH4, BD, FC, PWP, totalLayers, selectedLayer, curve, slope)

            Call Import.CropDescriptions(fieldOps)
            Call FillForm.CropDescriptions(fieldOps)

            Call Import.PlantingOrder(fieldOps)
            Call FillForm.PlantingOrder(fieldOps)

            Call Import.Tillage(fieldOps, usingOps)
            Call FillForm.Tillage(fieldOps, usingOps)

            Call Import.FixedIrrigation(fieldOps, usingOps)
            Call FillForm.FixedIrrigation(fieldOps, usingOps)

            Call Import.AutoIrrigation(fieldOps, usingOps)
            Call FillForm.AutoIrrigation(fieldOps, usingOps)

            Call Import.FixedFertilization(fieldOps, usingOps)
            Call FillForm.FixedFertilization(fieldOps, usingOps)

            Call Import.AutoFertilization(fieldOps, usingOps)
            Call FillForm.AutoFertilization(fieldOps, usingOps)

            Call Import.CloseSource()
        End If

        Import = Nothing
        FillForm = Nothing
    End Sub
    Private Sub ExportSettings(ByRef myWorkbook As Excel.Workbook)
        'Precondition:  Excel started
        '               passed workbook has all required tab
        'Postcondition: user interface fields stored to workbook 

        Dim ReadForm As New MainForm.formRead
        Dim Export As New ImportExport.xlsWrite(MainClass.VERSION)

        Dim usingOps, manualBD, manualFC, manualPWP, adjustedYields, hourlyInfiltration, autoNitrogen, autoPhosphorus, _
            autoSulfur, dailyCropOut, dailySoilOut, dailyNitrogenOut, dailyWaterOut, dailyWeatherOut, dailyResidueOut, _
            dailySoilCarbonOut, annualSoilOut, soilProfileOut, seasonOut As Boolean
        Dim rotationSize, startYear, endYear, totalLayers, selectedLayer As Integer
        Dim weatherFile As String = Nothing
        Dim curve, slope As Double
        Dim fieldOps(,) As Object = Nothing
        Dim LT() As Double = Nothing
        Dim clay() As Double = Nothing
        Dim sand() As Double = Nothing
        Dim IOM() As Double = Nothing
        Dim NO3() As Double = Nothing
        Dim NH4() As Double = Nothing
        Dim BD() As Double = Nothing
        Dim FC() As Double = Nothing
        Dim PWP() As Double = Nothing

        Call ReadForm.SimulationControls(weatherFile, startYear, endYear, rotationSize, adjustedYields, hourlyInfiltration, autoNitrogen, _
                                         autoPhosphorus, autoSulfur, dailyCropOut, dailySoilOut, dailyNitrogenOut, dailyWaterOut, _
                                         dailyWeatherOut, dailyResidueOut, dailySoilCarbonOut, annualSoilOut, soilProfileOut, seasonOut)
        Call Export.SimulationControls(myWorkbook, weatherFile, startYear, endYear, rotationSize, adjustedYields, hourlyInfiltration, _
                                       autoNitrogen, autoPhosphorus, autoSulfur, dailyCropOut, dailySoilOut, dailyNitrogenOut, dailyWaterOut, _
                                       dailyWeatherOut, dailyResidueOut, dailySoilCarbonOut, annualSoilOut, soilProfileOut, seasonOut)

        Call ReadForm.SoilDescription(manualBD, manualFC, manualPWP, LT, clay, sand, IOM, NO3, NH4, BD, FC, PWP, totalLayers, selectedLayer, slope, curve)
        Call Export.SoilDescription(myWorkbook, manualBD, manualFC, manualPWP, LT, clay, sand, IOM, NO3, NH4, BD, FC, PWP, totalLayers, selectedLayer, slope, curve)

        Call ReadForm.CropDescriptions(fieldOps)
        Call Export.CropDescriptions(myWorkbook, fieldOps)

        Call ReadForm.PlantingOrder(fieldOps)
        Call Export.PlantingOrder(myWorkbook, fieldOps)

        Call ReadForm.Tillage(fieldOps, usingOps)
        Call Export.Tillage(myWorkbook, fieldOps, usingOps)

        Call ReadForm.FixedIrrigation(fieldOps, usingOps)
        Call Export.FixedIrrigation(myWorkbook, fieldOps, usingOps)

        Call ReadForm.AutoIrrigation(fieldOps, usingOps)
        Call Export.AutoIrrigation(myWorkbook, fieldOps, usingOps)

        Call ReadForm.FixedFertilization(fieldOps, usingOps)
        Call Export.FixedFertilization(myWorkbook, fieldOps, usingOps)

        Call ReadForm.AutoFertilization(fieldOps, usingOps)
        Call Export.AutoFertilization(myWorkbook, fieldOps, usingOps)

        ReadForm = Nothing
        Export = Nothing
    End Sub

End Class
