Friend Module ArmenCustomIO
    Private localDirectory As String
    Private Const cropParameters As Integer = 34
    Private Const plantingOrderParameters As Integer = 5
    Private Const tillParameters As Integer = 6
    Private Const fixedIrrParameters As Integer = 3
    Private Const autoIrrParameters As Integer = 5
    Private Const fixedFertParameters As Integer = 18
    Private Const autoFertParameters As Integer = 7
    Private Const soilParameters As Integer = 11

    Public Class xlsRead
        Private myWorkbook As Excel.Workbook

        Public Function OpenSource(ByVal myExcel As Excel.Application, ByVal filePath As String) As Boolean
            Try
                myWorkbook = myExcel.Workbooks.Open(filePath)
            Catch ex As Exception
                MsgBox(Err.Description, MsgBoxStyle.Exclamation, MainForm.ProductName & ": Developer Mode IO Error")
                Return False
            End Try

            Return True
        End Function

        Public Sub CloseSource()
            Try
                myWorkbook.Close(SaveChanges:=False)
                myWorkbook = Nothing
            Catch ex As Exception
                MsgBox(Err.Description, MsgBoxStyle.Exclamation, MainForm.ProductName & ": Developer Mode IO Error")
            End Try
        End Sub

        Public Sub SimulationControls(ByRef weatherFile As String, ByRef startYear As Integer, ByRef endYear As Integer, _
                                      ByRef rotationSize As Integer, ByRef adjustedYields As Boolean, ByRef hourlyInfiltration As Boolean, _
                                      ByRef autoNitrogen As Boolean, ByRef autoPhosphorus As Boolean, ByRef autoSulfur As Boolean, _
                                      ByRef dailyCropOut As Boolean, ByRef dailySoilOut As Boolean, ByRef dailyNitrogenOut As Boolean, _
                                      ByRef dailyWaterOut As Boolean, ByRef dailyWeatherOut As Boolean, ByRef dailyResidueOut As Boolean, _
                                      ByRef dailySoilCarbonOut As Boolean, ByRef annualSoilOut As Boolean, ByRef soilProfileOut As Boolean, _
                                      ByRef seasonOut As Boolean)

            Dim Sheet As Excel.Worksheet
            Dim curSheet As String = "Simulation Controls"
            Dim importedRevision As String
            Dim tempArray(,) As Object

            If FileOps.WorksheetExists(curSheet, myWorkbook) Then
                Sheet = myWorkbook.Worksheets.Item(curSheet)
                importedRevision = Sheet.Range("G1").Value

                If importedRevision <> MainClass.VERSION Then MsgBox("Model revision has changed.  Ensure settings are correct", MsgBoxStyle.Exclamation, MainForm.ProductName)

                weatherFile = Sheet.Range("C3").Value
                startYear = Sheet.Range("C5").Value
                endYear = Sheet.Range("C6").Value
                rotationSize = Sheet.Range("C7").Value

                tempArray = Sheet.Range("C9").Resize(5, 1).Value
                adjustedYields = tempArray(1, 1)
                hourlyInfiltration = tempArray(2, 1)
                autoNitrogen = tempArray(3, 1)
                autoPhosphorus = tempArray(4, 1)
                autoSulfur = tempArray(5, 1)

                tempArray = Sheet.Range("C15").Resize(10, 1).Value
                dailyWeatherOut = tempArray(1, 1)
                dailyCropOut = tempArray(2, 1)
                dailyResidueOut = tempArray(3, 1)
                dailyWaterOut = tempArray(4, 1)
                dailyNitrogenOut = tempArray(5, 1)
                dailySoilCarbonOut = tempArray(6, 1)
                dailySoilOut = tempArray(7, 1)
                annualSoilOut = tempArray(8, 1)
                soilProfileOut = tempArray(9, 1)
                seasonOut = tempArray(10, 1)
            End If
        End Sub

        Public Sub CropDescriptions(ByRef opList(,) As Object)
            Dim curSheet As String = "Crop Descriptions"
            ReDim opList(0, cropParameters - 1)

            Call Me.ReadFieldOps(curSheet, opList, Nothing)
        End Sub

        Public Sub PlantingOrder(ByRef opList(,) As Object)
            Dim curSheet As String = "Planting Order"
            ReDim opList(0, plantingOrderParameters)

            Call Me.ReadFieldOps(curSheet, opList, Nothing)
        End Sub

        Public Sub Tillage(ByRef opList(,) As Object, ByRef usingOps As Boolean)
            Dim curSheet As String = "Tillage"
            ReDim opList(0, tillParameters)

            Call Me.ReadFieldOps(curSheet, opList, usingOps)
        End Sub

        Public Sub FixedIrrigation(ByRef opList(,) As Object, ByRef usingOps As Boolean)
            Dim curSheet As String = "Fixed Irrigation"
            ReDim opList(0, fixedIrrParameters)

            Call Me.ReadFieldOps(curSheet, opList, usingOps)
        End Sub

        Public Sub AutoIrrigation(ByRef opList(,) As Object, ByRef usingOps As Boolean)
            Dim curSheet As String = "Automatic Irrigation"
            ReDim opList(0, autoIrrParameters)

            Call Me.ReadFieldOps(curSheet, opList, usingOps)
        End Sub

        Public Sub FixedFertilization(ByRef opList(,) As Object, ByRef usingOps As Boolean)
            Dim curSheet As String = "Fixed Fertilization"
            ReDim opList(0, fixedFertParameters)

            Call Me.ReadFieldOps(curSheet, opList, usingOps)
        End Sub

        Public Sub AutoFertilization(ByRef opList(,) As Object, ByRef usingOps As Boolean)
            Dim curSheet As String = "Automatic Fertilization"
            ReDim opList(0, autoFertParameters)

            Call Me.ReadFieldOps(curSheet, opList, usingOps)
        End Sub

        Public Sub SoilDescription(ByRef manualBD As Boolean, ByRef manualFC As Boolean, ByRef manualPWP As Boolean, _
                                   ByRef LT() As Double, ByRef clay() As Double, ByRef sand() As Double, ByRef IOM() As Double, _
                                   ByRef NO3() As Double, ByRef NH4() As Double, ByRef BD() As Double, ByRef FC() As Double, _
                                   ByRef PWP() As Double, ByRef totalLayers As Integer, ByRef selectedLayer As Integer, _
                                   ByRef slope As Double, ByRef curve As Double)

            Dim Sheet As Excel.Worksheet
            Dim tempArray(,) As Object
            Dim startRow As Integer = 10
            Dim curSheet As String = "Soil"

            If FileOps.WorksheetExists(curSheet, myWorkbook) Then
                Sheet = myWorkbook.Worksheets.Item(curSheet)

                tempArray = Sheet.Range("C3").Resize(3, 2).Value
                curve = tempArray(1, 1)
                slope = tempArray(2, 1)
                totalLayers = tempArray(3, 2)
                selectedLayer = tempArray(3, 1)

                ReDim LT(totalLayers)
                ReDim clay(totalLayers)
                ReDim sand(totalLayers)
                ReDim IOM(totalLayers)
                ReDim BD(totalLayers)
                ReDim FC(totalLayers)
                ReDim PWP(totalLayers)
                ReDim NO3(totalLayers)
                ReDim NH4(totalLayers)

                tempArray = Sheet.Range("G6").Resize(1, 3).Value

                manualBD = tempArray(1, 1)
                manualFC = tempArray(1, 2)
                manualPWP = tempArray(1, 3)

                If totalLayers > 0 Then
                    tempArray = Sheet.Range("A10").Resize(totalLayers, 11).Value

                    For i As Integer = 1 To totalLayers
                        If IsNumeric(tempArray(i, 2)) Then LT(i - 1) = tempArray(i, 2)
                        If IsNumeric(tempArray(i, 4)) Then clay(i - 1) = tempArray(i, 4)
                        If IsNumeric(tempArray(i, 5)) Then sand(i - 1) = tempArray(i, 5)
                        If IsNumeric(tempArray(i, 6)) Then IOM(i - 1) = tempArray(i, 6)
                        If IsNumeric(tempArray(i, 7)) Then BD(i - 1) = tempArray(i, 7)
                        If IsNumeric(tempArray(i, 8)) Then FC(i - 1) = tempArray(i, 8)
                        If IsNumeric(tempArray(i, 9)) Then PWP(i - 1) = tempArray(i, 9)
                        If IsNumeric(tempArray(i, 10)) Then NO3(i - 1) = tempArray(i, 10)
                        If IsNumeric(tempArray(i, 11)) Then NH4(i - 1) = tempArray(i, 11)
                    Next
                End If
            End If
        End Sub

        Private Function ReadFieldOps(ByVal curSheet As String, ByRef oplist(,) As Object, ByRef usingOps As Boolean) As Boolean
            Dim Sheet As Excel.Worksheet
            Dim tempVal As String
            Dim max As Integer = 0
            Dim tempOpList(,) As Object

            If FileOps.WorksheetExists(curSheet, myWorkbook) Then
                Sheet = myWorkbook.Worksheets.Item(curSheet)

                If Trim(Sheet.Range("C3").Value) <> Nothing Then
                    usingOps = Sheet.Range("C3").Value
                Else
                    usingOps = True
                End If

                Do
                    tempVal = Sheet.Cells(max + 6, 1).Value

                    If Trim(tempVal) <> Nothing Then
                        max += 1
                    Else
                        Exit Do
                    End If
                Loop

                If max > 0 Then
                    tempOpList = Sheet.Range("A6").Resize(max, UBound(oplist, Rank:=2) + 1).Value
                    ReDim oplist(tempOpList.GetUpperBound(0) - 1, oplist.GetUpperBound(1))

                    For i As Integer = 1 To tempOpList.GetUpperBound(0)
                        For j As Integer = 1 To tempOpList.GetUpperBound(1)
                            oplist(i - 1, j - 1) = tempOpList(i, j)
                        Next
                    Next
                End If

                Return True
            Else
                Return False
            End If
        End Function

    End Class

    Public Class xlsWrite
        Private revision As String

        Public Sub New(ByVal modelVersion As String)
            revision = modelVersion
        End Sub

        Public Sub SimulationControls(ByRef myWorkbook As Excel.Workbook, ByVal weatherFile As String, ByVal startYear As Integer, _
                                      ByVal endYear As Integer, ByVal rotationSize As Integer, ByVal adjustedYields As Boolean, _
                                      ByVal hourlyInfiltration As Boolean, ByVal autoNitrogen As Boolean, ByVal autoPhosphorus As Boolean, _
                                      ByVal autoSulfur As Boolean, ByVal dailyCropOut As Boolean, ByVal dailySoilOut As Boolean, _
                                      ByVal dailyNitrogenOut As Boolean, ByVal dailyWaterOut As Boolean, ByVal dailyWeatherOut As Boolean, _
                                      ByVal dailyResidueOut As Boolean, ByVal dailySoilCarbonOut As Boolean, ByVal annualSoilOut As Boolean, _
                                      ByVal soilProfileOut As Boolean, ByVal seasonOut As Boolean)

            Dim curSheet As String = "Simulation Controls"
            Dim Sheet As Excel.Worksheet = myWorkbook.Worksheets.Item(curSheet)
            Dim tempArray(,) As Object

            Call HeadersSimulationControls(Sheet, curSheet)

            Sheet.Range("G1").Value = revision
            Sheet.Range("J1").Value = System.DateTime.Now
            Sheet.Range("C3").Value = weatherFile
            Sheet.Range("C5").Value = startYear
            Sheet.Range("C6").Value = endYear
            Sheet.Range("C7").Value = rotationSize

            ReDim tempArray(4, 0)
            tempArray(0, 0) = adjustedYields
            tempArray(1, 0) = hourlyInfiltration
            tempArray(2, 0) = autoNitrogen
            tempArray(3, 0) = autoPhosphorus
            tempArray(4, 0) = autoSulfur
            Sheet.Range("C9").Resize(5, 1).Value = tempArray

            ReDim tempArray(9, 0)
            tempArray(0, 0) = dailyWeatherOut
            tempArray(1, 0) = dailyCropOut
            tempArray(2, 0) = dailyResidueOut
            tempArray(3, 0) = dailyWaterOut
            tempArray(4, 0) = dailyNitrogenOut
            tempArray(5, 0) = dailySoilCarbonOut
            tempArray(6, 0) = dailySoilOut
            tempArray(7, 0) = annualSoilOut
            tempArray(8, 0) = soilProfileOut
            tempArray(9, 0) = seasonOut
            Sheet.Range("C15").Resize(10, 1).Value = tempArray
        End Sub
        Private Sub HeadersSimulationControls(ByRef Sheet As Excel.Worksheet, ByVal curSheet As String)
            Dim xlsRange As Excel.Range = Nothing
            Dim tempArray(,) As String

            xlsRange = Sheet.Range("A1").Resize(1, 3)
            Call SideSubs.TitleSettings(xlsRange)
            Sheet.Range("A1").Value = curSheet

            Call SideSubs.HeaderSettings(Sheet.Range("F1"), "right")
            Sheet.Range("F1").Value = "Revision:"

            Call SideSubs.HeaderSettings(Sheet.Range("I1"), "right")
            Sheet.Range("I1").Value = "Created:"

            ReDim tempArray(0, 1)
            xlsRange = Sheet.Range("A3").Resize(1, 2)
            Call SideSubs.HeaderSettings(xlsRange, "right")
            tempArray(0, 1) = "Weatherfile"
            xlsRange.Value = tempArray

            ReDim tempArray(2, 1)
            xlsRange = Sheet.Range("A5").Resize(3, 2)
            Call SideSubs.HeaderSettings(xlsRange, "right")
            tempArray(0, 1) = "Simulation Start Year"
            tempArray(1, 1) = "Simulation End Year"
            tempArray(2, 1) = "Rotation Size"
            xlsRange.Value = tempArray

            ReDim tempArray(4, 1)
            xlsRange = Sheet.Range("A9").Resize(5, 2)
            Call SideSubs.HeaderSettings(xlsRange, "right")
            tempArray(0, 1) = "Adjusted Yields"
            tempArray(1, 1) = "Hourly Water Infiltration"
            tempArray(2, 1) = "Automatic Nitrogen"
            tempArray(3, 1) = "Automatic Phosphorus"
            tempArray(4, 1) = "Automatic Sulfur"
            xlsRange.Value = tempArray

            ReDim tempArray(9, 1)
            xlsRange = Sheet.Range("A15").Resize(10, 2)
            Call SideSubs.HeaderSettings(xlsRange, "right")
            tempArray(0, 1) = "Daily Weather Out"
            tempArray(1, 1) = "Daily Crop Out"
            tempArray(2, 1) = "Daily Residue"
            tempArray(3, 1) = "Daily Water Out"
            tempArray(4, 1) = "Daily Nitrogen Out"
            tempArray(5, 1) = "Daily Soil Carbon Out"
            tempArray(6, 1) = "Daily Soil Out"
            tempArray(7, 1) = "Annual Soil Out"
            tempArray(8, 1) = "Annual Profile Out"
            tempArray(9, 1) = "Season Out"
            xlsRange.Value = tempArray
        End Sub

        Public Sub CropDescriptions(ByRef myWorkbook As Excel.Workbook, ByVal opList(,) As Object)
            Dim curSheet As String = "Crop Descriptions"
            Dim Sheet As Excel.Worksheet

            If Me.WriteFieldOps(myWorkbook, curSheet, opList, True) Then
                Sheet = myWorkbook.Worksheets.Item(curSheet)
                Call HeadersCropDescriptions(Sheet, curSheet)
            End If
        End Sub
        Private Sub HeadersCropDescriptions(ByRef Sheet As Excel.Worksheet, ByVal curSheet As String)
            Dim xlsRange As Excel.Range = Nothing
            Dim tempArray(,) As String
            Dim i As Integer = -1

            Sheet.Range("A1").Value = curSheet
            xlsRange = Sheet.Range("A1").Resize(1, 3)
            Call SideSubs.TitleSettings(xlsRange)

            ReDim tempArray(1, cropParameters - 1)
            xlsRange = Sheet.Range("A4").Resize(2, cropParameters)
            Call SideSubs.HeaderSettings(xlsRange, "center")

            i += 1
            tempArray(0, i) = "Crop"
            tempArray(1, i) = "Name"
            i += 1
            tempArray(0, i) = "Average"
            tempArray(1, i) = "Seeding Date"
            i += 1
            tempArray(0, i) = "Average 50%"
            tempArray(1, i) = "Flowering Date"
            i += 1
            tempArray(0, i) = "Average"
            tempArray(1, i) = "Maturity Date"
            i += 1
            tempArray(0, i) = "Maximum"
            tempArray(1, i) = "Soil Coverage"
            i += 1
            tempArray(0, i) = "Maximum"
            tempArray(1, i) = "Rooting Depth"
            i += 1
            tempArray(0, i) = "Average"
            tempArray(1, i) = "Expected Yield"
            i += 1
            tempArray(0, i) = "Maximum"
            tempArray(1, i) = "Expected Yield"
            i += 1
            tempArray(0, i) = "Minimum"
            tempArray(1, i) = "Expected Yield"
            i += 1
            tempArray(0, i) = "Commercial"
            tempArray(1, i) = "Yield Moisture"
            i += 1
            tempArray(0, i) = "Standing Residue"
            tempArray(1, i) = "at Harvest"
            i += 1
            tempArray(0, i) = "Residue"
            tempArray(1, i) = "Removed"
            i += 1
            tempArray(0, i) = "Harvest"
            tempArray(1, i) = "Timing"
            i += 1
            tempArray(0, i) = "Min Temperature"
            tempArray(1, i) = "for Transpiration"
            i += 1
            tempArray(0, i) = "Threshold Temperature"
            tempArray(1, i) = "for Transpiration"
            i += 1
            tempArray(0, i) = "Min Temperature"
            tempArray(1, i) = "for Cold Damage"
            i += 1
            tempArray(0, i) = "Threshold Temperature"
            tempArray(1, i) = "for Cold Damage"
            i += 1
            tempArray(0, i) = "Base Temperature"
            tempArray(1, i) = "for Development"
            i += 1
            tempArray(0, i) = "Optimum Temperature"
            tempArray(1, i) = "for Development"
            i += 1
            tempArray(0, i) = "Max Temperature"
            tempArray(1, i) = "for Development"
            i += 1
            tempArray(0, i) = "Initial Partitioning"
            tempArray(1, i) = "to Shoot"
            i += 1
            tempArray(0, i) = "Final Partitioning"
            tempArray(1, i) = "to Shoot"
            i += 1
            tempArray(0, i) = "Radiation"
            tempArray(1, i) = "Use Efficiency"
            i += 1
            tempArray(0, i) = "Transpiration"
            tempArray(1, i) = "Use Efficiency"
            i += 1
            tempArray(0, i) = "Maximum"
            tempArray(1, i) = "Harvest Index"
            i += 1
            tempArray(0, i) = "Minimum"
            tempArray(1, i) = "Harvest Index"
            i += 1
            tempArray(0, i) = ""
            tempArray(1, i) = "Harvest Index"
            i += 1
            tempArray(0, i) = "Thermal Time"
            tempArray(1, i) = "to Emergence"
            i += 1
            tempArray(0, i) = "N Max"
            tempArray(1, i) = "Concentration"
            i += 1
            tempArray(0, i) = "N Dilution"
            tempArray(1, i) = "Slope"
            i += 1
            tempArray(0, i) = ""
            tempArray(1, i) = "Kc"
            i += 1
            tempArray(0, i) = "Annual or"
            tempArray(1, i) = "Perennial"
            i += 1
            tempArray(0, i) = ""
            tempArray(1, i) = "Legume"
            i += 1
            tempArray(0, i) = ""
            tempArray(1, i) = "C3 or C4"

            xlsRange.Value = tempArray
        End Sub

        Public Sub PlantingOrder(ByVal myWorkbook As Excel.Workbook, ByVal opList(,) As Object)
            Dim curSheet As String = "Planting Order"
            Dim Sheet As Excel.Worksheet

            If Me.WriteFieldOps(myWorkbook, curSheet, opList, True) Then
                Sheet = myWorkbook.Worksheets.Item(curSheet)
                Call Me.HeadersPlantingOrder(Sheet, curSheet)
            End If
        End Sub
        Private Sub HeadersPlantingOrder(ByRef Sheet As Excel.Worksheet, ByVal curSheet As String)
            Dim xlsRange As Excel.Range = Nothing
            Dim tempArray(,) As String
            Dim i As Integer = -1

            xlsRange = Sheet.Range("A1").Resize(1, 3)
            Call SideSubs.TitleSettings(xlsRange)
            Sheet.Range("A1").Value = curSheet

            ReDim tempArray(1, plantingOrderParameters - 1)
            xlsRange = Sheet.Range("A4").Resize(2, plantingOrderParameters)
            Call SideSubs.HeaderSettings(xlsRange, "center")
            i += 1
            tempArray(0, i) = "Rotation"
            tempArray(1, i) = "Year"
            i += 1
            tempArray(0, i) = "Calendar"
            tempArray(1, i) = "Day"
            i += 1
            tempArray(0, i) = "Crop"
            tempArray(1, i) = "Name"
            i += 1
            tempArray(0, i) = "Automatic"
            tempArray(1, i) = "Irrigation"
            i += 1
            tempArray(0, i) = "Automatic"
            tempArray(1, i) = "Fertilization"

            xlsRange.Value = tempArray
        End Sub

        Public Sub Tillage(ByRef myWorkbook As Excel.Workbook, ByVal opList(,) As Object, ByVal usingOps As Boolean)
            Dim curSheet As String = "Tillage"
            Dim Sheet As Excel.Worksheet

            If Me.WriteFieldOps(myWorkbook, curSheet, opList, usingOps) Then
                Sheet = myWorkbook.Worksheets.Item(curSheet)
                Call Me.HeadersTillage(Sheet, curSheet)
            End If
        End Sub
        Private Sub HeadersTillage(ByRef Sheet As Excel.Worksheet, ByVal curSheet As String)
            Dim xlsRange As Excel.Range = Nothing
            Dim tempArray(,) As String
            Dim i As Integer = -1

            Sheet.Range("A1").Value = curSheet
            xlsRange = Sheet.Range("A1").Resize(1, 3)
            Call SideSubs.TitleSettings(xlsRange)

            Sheet.Range("B3").Value = "Use Operations:"

            ReDim tempArray(1, tillParameters - 1)
            xlsRange = Sheet.Range("A4").Resize(2, tillParameters)
            Call SideSubs.HeaderSettings(xlsRange, "center")
            i += 1
            tempArray(0, i) = "Rotation"
            tempArray(1, i) = "Year"
            i += 1
            tempArray(0, i) = "Calendar"
            tempArray(1, i) = "Day"
            i += 1
            tempArray(0, i) = "Tool"
            tempArray(1, i) = "Name"
            i += 1
            tempArray(0, i) = "Depth"
            tempArray(1, i) = "m"
            i += 1
            tempArray(0, i) = "SDR"
            tempArray(1, i) = ""
            i += 1
            tempArray(0, i) = "Mixing"
            tempArray(1, i) = "Efficiency"

            xlsRange.Value = tempArray
        End Sub

        Public Sub FixedIrrigation(ByRef myWorkbook As Excel.Workbook, ByVal opList(,) As Object, ByVal usingOps As Boolean)
            Dim curSheet As String = "Fixed Irrigation"
            Dim Sheet As Excel.Worksheet

            If Me.WriteFieldOps(myWorkbook, curSheet, opList, usingOps) Then
                Sheet = myWorkbook.Worksheets.Item(curSheet)
                Call Me.HeadersFixedIrrigation(Sheet, curSheet)
            End If
        End Sub
        Private Sub HeadersFixedIrrigation(ByRef Sheet As Excel.Worksheet, ByVal curSheet As String)
            Dim xlsRange As Excel.Range = Nothing
            Dim tempArray(,) As String
            Dim i As Integer = -1

            Sheet.Range("A1").Value = curSheet
            xlsRange = Sheet.Range("A1").Resize(1, 3)
            Call SideSubs.TitleSettings(xlsRange)

            Sheet.Range("B3").Value = "Use Operations:"

            ReDim tempArray(1, fixedIrrParameters - 1)
            xlsRange = Sheet.Range("A4").Resize(2, fixedIrrParameters)
            Call SideSubs.HeaderSettings(xlsRange, "center")
            i += 1
            tempArray(0, i) = "Rotation"
            tempArray(1, i) = "Year"
            i += 1
            tempArray(0, i) = "Calendar"
            tempArray(1, i) = "Day"
            i += 1
            tempArray(0, i) = "Volume"
            tempArray(1, i) = "mm"

            xlsRange.Value = tempArray
        End Sub

        Public Sub AutoIrrigation(ByRef myWorkbook As Excel.Workbook, ByVal opList(,) As Object, ByVal usingOps As Boolean)
            Dim curSheet As String = "Automatic Irrigation"
            Dim Sheet As Excel.Worksheet

            If Me.WriteFieldOps(myWorkbook, curSheet, opList, usingOps) Then
                Sheet = myWorkbook.Worksheets.Item(curSheet)
                Call Me.HeadersAutoIrrigation(Sheet, curSheet)
            End If
        End Sub
        Private Sub HeadersAutoIrrigation(ByRef Sheet As Excel.Worksheet, ByVal curSheet As String)
            Dim xlsRange As Excel.Range = Nothing
            Dim tempArray(,) As String
            Dim i As Integer = -1

            Sheet.Range("A1").Value = curSheet
            xlsRange = Sheet.Range("A1").Resize(1, 3)
            Call SideSubs.TitleSettings(xlsRange)

            Sheet.Range("B3").Value = "Use Operations:"

            ReDim tempArray(1, autoIrrParameters - 1)
            xlsRange = Sheet.Range("A4").Resize(2, autoIrrParameters)
            Call SideSubs.HeaderSettings(xlsRange, "center")
            i += 1
            tempArray(0, i) = "Crop"
            tempArray(1, i) = "Name"
            i += 1
            tempArray(0, i) = "Start"
            tempArray(1, i) = "Day"
            i += 1
            tempArray(0, i) = "Stop"
            tempArray(1, i) = "Day"
            i += 1
            tempArray(0, i) = "Allowable Plant"
            tempArray(1, i) = "Water Depletion"
            i += 1
            tempArray(0, i) = "Last Soil Layer"
            tempArray(1, i) = "to Monitor"

            xlsRange.Value = tempArray
        End Sub

        Public Sub FixedFertilization(ByRef myWorkbook As Excel.Workbook, ByVal opList(,) As Object, ByVal usingOps As Boolean)
            Dim curSheet As String = "Fixed Fertilization"
            Dim Sheet As Excel.Worksheet

            If Me.WriteFieldOps(myWorkbook, curSheet, opList, usingOps) Then
                Sheet = myWorkbook.Worksheets.Item(curSheet)
                Call Me.HeadersFixedFertilization(Sheet, curSheet)
            End If
        End Sub
        Private Sub HeadersFixedFertilization(ByRef Sheet As Excel.Worksheet, ByVal curSheet As String)
            Dim xlsRange As Excel.Range = Nothing
            Dim tempArray(,) As String
            Dim i As Integer = -1

            Sheet.Range("A1").Value = curSheet
            xlsRange = Sheet.Range("A1").Resize(1, 3)
            Call SideSubs.TitleSettings(xlsRange)

            Sheet.Range("B3").Value = "Use Operations:"

            ReDim tempArray(1, fixedFertParameters - 1)
            xlsRange = Sheet.Range("A4").Resize(2, fixedFertParameters)
            Call SideSubs.HeaderSettings(xlsRange, "center")
            i += 1
            tempArray(0, i) = "Rotation"
            tempArray(1, i) = "Year"
            i += 1
            tempArray(0, i) = "Calendar"
            tempArray(1, i) = "Day"
            i += 1
            tempArray(0, i) = ""
            tempArray(1, i) = "Source"
            i += 1
            tempArray(0, i) = "Mass"
            tempArray(1, i) = "kg/ha"
            i += 1
            tempArray(0, i) = ""
            tempArray(1, i) = "Form"
            i += 1
            tempArray(0, i) = ""
            tempArray(1, i) = "Method"
            i += 1
            tempArray(0, i) = ""
            tempArray(1, i) = "Depth"
            i += 1
            tempArray(0, i) = ""
            tempArray(1, i) = "C Organic"
            i += 1
            tempArray(0, i) = ""
            tempArray(1, i) = "C Charcoal"
            i += 1
            tempArray(0, i) = ""
            tempArray(1, i) = "N Organic"
            i += 1
            tempArray(0, i) = ""
            tempArray(1, i) = "N Charcoal"
            i += 1
            tempArray(0, i) = ""
            tempArray(1, i) = "N NH4"
            i += 1
            tempArray(0, i) = ""
            tempArray(1, i) = "N NO3"
            i += 1
            tempArray(0, i) = ""
            tempArray(1, i) = "P Organic"
            i += 1
            tempArray(0, i) = ""
            tempArray(1, i) = "P Charcoal"
            i += 1
            tempArray(0, i) = ""
            tempArray(1, i) = "P Inorganic"
            i += 1
            tempArray(0, i) = ""
            tempArray(1, i) = "K"
            i += 1
            tempArray(0, i) = ""
            tempArray(1, i) = "S"

            xlsRange.Value = tempArray
        End Sub

        Public Sub AutoFertilization(ByRef myWorkbook As Excel.Workbook, ByVal opList(,) As Object, ByVal usingOps As Boolean)
            Dim curSheet As String = "Automatic Fertilization"
            Dim Sheet As Excel.Worksheet

            If Me.WriteFieldOps(myWorkbook, curSheet, opList, usingOps) Then
                Sheet = myWorkbook.Worksheets.Item(curSheet)
                Call Me.HeadersAutoFertilization(Sheet, curSheet)
            End If
        End Sub
        Private Sub HeadersAutoFertilization(ByRef Sheet As Excel.Worksheet, ByVal curSheet As String)
            Dim xlsRange As Excel.Range = Nothing
            Dim tempArray(,) As String
            Dim i As Integer = -1

            Sheet.Range("A1").Value = curSheet
            xlsRange = Sheet.Range("A1").Resize(1, 3)
            Call SideSubs.TitleSettings(xlsRange)

            Sheet.Range("B3").Value = "Use Operations:"

            ReDim tempArray(1, autoFertParameters - 1)
            xlsRange = Sheet.Range("A4").Resize(2, autoFertParameters)
            Call SideSubs.HeaderSettings(xlsRange, "center")
            i += 1
            tempArray(0, i) = "Crop"
            tempArray(1, i) = "Name"
            i += 1
            tempArray(0, i) = "Start"
            tempArray(1, i) = "Day"
            i += 1
            tempArray(0, i) = "Stop"
            tempArray(1, i) = "Day"
            i += 1
            tempArray(0, i) = "Mass"
            tempArray(1, i) = "kg/ha"
            i += 1
            tempArray(0, i) = ""
            tempArray(1, i) = "Source"
            i += 1
            tempArray(0, i) = ""
            tempArray(1, i) = "Form"
            i += 1
            tempArray(0, i) = ""
            tempArray(1, i) = "Method"

            xlsRange.Value = tempArray
        End Sub

        Public Sub SoilDescription(ByRef myWorkbook As Excel.Workbook, ByVal manualBD As Boolean, ByVal manualFC As Boolean, _
                                   ByVal manualPWP As Boolean, ByVal LT() As Double, ByVal clay() As Double, ByVal sand() As Double, _
                                   ByVal IOM() As Double, ByVal NO3() As Double, ByVal NH4() As Double, ByVal BD() As Double, _
                                   ByVal FC() As Double, ByVal PWP() As Double, ByRef totalLayers As Integer, _
                                   ByVal selectedLayer As Integer, ByVal slope As Double, ByVal curve As Double)

            Dim curSheet As String = "Soil"
            Dim Sheet As Excel.Worksheet = myWorkbook.Worksheets.Item(curSheet)
            Dim sum As Double = 0
            Dim tempArray(,) As Object
            Dim xlsRange As Excel.Range

            Call HeadersSoil(Sheet, curSheet)

            ReDim tempArray(0, 2)
            xlsRange = Sheet.Range("G6").Resize(1, 3)
            tempArray(0, 0) = manualBD
            tempArray(0, 1) = manualFC
            tempArray(0, 2) = manualPWP
            xlsRange.Value = tempArray

            ReDim tempArray(totalLayers - 1, 10)
            For i As Integer = 0 To (totalLayers - 1)
                sum += LT(i)

                tempArray(i, 0) = i + 1
                tempArray(i, 1) = SideSubs.Formatting(LT(i))
                tempArray(i, 2) = SideSubs.Formatting(sum)
                tempArray(i, 3) = SideSubs.Formatting(clay(i))
                tempArray(i, 4) = SideSubs.Formatting(sand(i))
                tempArray(i, 5) = SideSubs.Formatting(IOM(i))
                tempArray(i, 6) = SideSubs.Formatting(BD(i))
                tempArray(i, 7) = SideSubs.Formatting(FC(i))
                tempArray(i, 8) = SideSubs.Formatting(PWP(i))
                tempArray(i, 9) = SideSubs.Formatting(NO3(i))
                tempArray(i, 10) = SideSubs.Formatting(NH4(i))
            Next

            xlsRange = Sheet.Range("A10").Resize(totalLayers, 11)
            xlsRange.Value = tempArray

            ReDim tempArray(2, 1)
            xlsRange = Sheet.Range("C3").Resize(3, 2)
            tempArray(0, 0) = curve
            tempArray(1, 0) = slope * 100
            tempArray(2, 1) = totalLayers
            tempArray(2, 0) = selectedLayer
            xlsRange.Value = tempArray
        End Sub
        Private Sub HeadersSoil(ByRef Sheet As Excel.Worksheet, ByVal curSheet As String)
            Dim xlsRange As Excel.Range = Nothing
            Dim tempArray(,) As String
            Dim i As Integer = -1

            Sheet.Range("A1").Value = curSheet
            xlsRange = Sheet.Range("A1").Resize(1, 3)
            Call SideSubs.TitleSettings(xlsRange)

            Sheet.Cells(4, 1).value = "Manual Data"

            ReDim tempArray(2, 10)
            xlsRange = Sheet.Range("A7").Resize(3, 11)
            Call SideSubs.HeaderSettings(xlsRange, "center")

            i += 1
            tempArray(0, i) = ""
            tempArray(1, i) = "Layer #"
            tempArray(2, i) = ""
            i += 1
            tempArray(0, i) = "Layer"
            tempArray(1, i) = "Thickness"
            tempArray(2, i) = "m"
            i += 1
            tempArray(0, i) = "Cumulative"
            tempArray(1, i) = "Depth"
            tempArray(2, i) = "m"
            i += 1
            tempArray(0, i) = ""
            tempArray(1, i) = "Clay"
            tempArray(2, i) = "%"
            i += 1
            tempArray(0, i) = ""
            tempArray(1, i) = "Sand"
            tempArray(2, i) = "%"
            i += 1
            tempArray(0, i) = "Organic"
            tempArray(1, i) = "Matter"
            tempArray(2, i) = "%"
            i += 1
            tempArray(0, i) = "Bulk"
            tempArray(1, i) = "Density"
            tempArray(2, i) = "Mg/m3"
            i += 1
            tempArray(0, i) = "Field"
            tempArray(1, i) = "Capacity"
            tempArray(2, i) = "m3/m3"
            i += 1
            tempArray(0, i) = "Permanent"
            tempArray(1, i) = "Wilting Point"
            tempArray(2, i) = "m3/m3"
            i += 1
            tempArray(0, i) = "Initial"
            tempArray(1, i) = "Nitrate"
            tempArray(2, i) = "kg/ha"
            i += 1
            tempArray(0, i) = "Initial"
            tempArray(1, i) = "Ammonium"
            tempArray(2, i) = "kg/ha"

            xlsRange.Value = tempArray

            ReDim tempArray(2, 1)
            xlsRange = Sheet.Range("A3").Resize(3, 2)
            Call SideSubs.HeaderSettings(xlsRange, "right")
            tempArray(0, 1) = "Curve Number"
            tempArray(1, 1) = "Slope"
            tempArray(2, 1) = "Selected/Total Layers"
            xlsRange.Value = tempArray
        End Sub

        Private Function WriteFieldOps(ByVal myWorkbook As Excel.Workbook, ByVal curSheet As String, ByRef oplist(,) As Object, ByVal usingOps As Boolean) As Boolean
            Dim Sheet As Excel.Worksheet

            If FileOps.WorksheetExists(curSheet, myWorkbook) Then
                Sheet = myWorkbook.Worksheets.Item(curSheet)

                Sheet.Range("C3").Value = usingOps

                If oplist(oplist.GetLowerBound(0), oplist.GetLowerBound(1)) <> Nothing Then
                    Sheet.Range("A6").Resize(UBound(oplist, Rank:=1) + 1, UBound(oplist, Rank:=2) + 1).Value = oplist
                End If

                Return True
            Else
                Return False
            End If
        End Function

    End Class

End Module