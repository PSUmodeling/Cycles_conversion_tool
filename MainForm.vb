Option Explicit On
Imports System.Threading

Friend Class MainForm
    Private Const WM_QUIT As Integer = &H12                         'Used to kill Excel
    Private ReadOnly totalCropFields As Integer = 34                'total number of user changable crop fields on the interface

    Private myExcel As Excel.Application
    Private cropList(,) As Object

    Private colorActive As Color = Color.White
    Private colorInactive As Color = Color.Crimson

    'control arrays
    Private ctlLayerBtn(0) As RadioButton
    Private ctlCumDepth(0) As System.Windows.Forms.TextBox
    Private ctlLayerThickness(0) As System.Windows.Forms.TextBox
    Private ctlClay(0) As System.Windows.Forms.TextBox
    Private ctlSand(0) As System.Windows.Forms.TextBox
    Private ctlIOM(0) As System.Windows.Forms.TextBox
    Private ctlNO3(0) As System.Windows.Forms.TextBox
    Private ctlNH4(0) As System.Windows.Forms.TextBox
    Private ctlBD(0) As System.Windows.Forms.TextBox
    Private ctlFC(0) As System.Windows.Forms.TextBox
    Private ctlPWP(0) As System.Windows.Forms.TextBox
    Private ctlCropDescrip(totalCropFields) As Control
    Private ctlCropDescripLabel(totalCropFields) As System.Windows.Forms.Label

    Private lclDir As String = System.Windows.Forms.Application.StartupPath & "\"

    '====================================== Used to kill stubborn Excel COM instances ==============
    Private Declare Function PostMessage Lib "user32" Alias "PostMessageA" (ByRef hwnd As Int32, ByRef wMsg As Int32, ByRef wParam As Int32, ByRef lParam As Int32) As Int32

    '====================================== Publicly Available Functions ===========================
    Private Sub SimulationYearUpdate(ByVal File_Start As Integer, ByVal File_End As Integer)
        'Precondition:  start and stop dates are numeric or blank
        'Postcondition: Start & End Year comboboxes have been filled with current weatherfile dates

        'Clear and replace existing Weather File Dates
        Me.duration_StartYear.Items.Clear()
        Me.duration_StopYear.Items.Clear()

        Me.duration_StartYear.Items.Add("")
        Me.duration_StopYear.Items.Add("")

        'fill with weatherfile dates
        For year As Integer = File_Start To File_End
            Me.duration_StartYear.Items.Add(year)
            Me.duration_StopYear.Items.Add(year)
        Next
    End Sub
    Public WriteOnly Property RotationYears() As Integer
        Set(ByVal value As Integer)
            Me.duration_RotationSize.Text = value
        End Set
    End Property

    Public Class formRead

        Public Sub SimulationControls(ByRef weatherFile As String, ByRef startYear As Integer, ByRef endYear As Integer, _
                                      ByRef rotationSize As Integer, ByRef adjustedYields As Boolean, ByRef hourlyInfiltration As Boolean, _
                                      ByRef autoNitrogen As Boolean, ByRef autoPhosphorus As Boolean, ByRef autoSulfur As Boolean, _
                                      ByRef dailyCropOut As Boolean, ByRef dailySoilOut As Boolean, ByRef dailyNitrogenOut As Boolean, _
                                      ByRef dailyWaterOut As Boolean, ByRef dailyWeatherOut As Boolean, ByRef dailyResidueOut As Boolean, _
                                      ByRef dailySoilCarbonOut As Boolean, ByRef annualSoilOut As Boolean, ByRef soilProfileOut As Boolean, _
                                      ByRef seasonOut As Boolean)

            weatherFile = MainForm.weatherFile_Path.Text

            If MainForm.duration_StartYear.Text <> Nothing Then startYear = MainForm.duration_StartYear.Text
            If MainForm.duration_StopYear.Text <> Nothing Then endYear = MainForm.duration_StopYear.Text
            If MainForm.duration_RotationSize.Text <> Nothing Then rotationSize = MainForm.duration_RotationSize.Text

            adjustedYields = MainForm.calcOptions_adjustedYields.Checked
            hourlyInfiltration = MainForm.calcOptions_waterInfiltration.Checked
            autoNitrogen = MainForm.calcOptions_autoNitrogen.Checked
            autoPhosphorus = MainForm.calcOptions_autoPhosphorus.Checked
            autoSulfur = MainForm.calcOptions_autoSulfur.Checked

            dailyWeatherOut = MainForm.DailyWeatherReporting.Checked
            dailyCropOut = MainForm.DailyCropReporting.Checked
            dailyResidueOut = MainForm.DailyResidueReporting.Checked
            dailyWaterOut = MainForm.DailyWaterReporting.Checked
            dailyNitrogenOut = MainForm.DailyNitrogenReporting.Checked
            dailySoilCarbonOut = MainForm.DailySoilCarbonReporting.Checked
            dailySoilOut = MainForm.DailySoilReporting.Checked
            annualSoilOut = MainForm.AnnualSoilReporting.Checked
            soilProfileOut = MainForm.AnnualSoilProfileReporting.Checked
            seasonOut = MainForm.SeasonReporting.Checked
        End Sub
        Public Sub SoilDescription(ByRef manualBD As Boolean, ByRef manualFC As Boolean, ByRef manualPWP As Boolean, _
                                   ByRef LT() As Double, ByRef clay() As Double, ByRef sand() As Double, ByRef IOM() As Double, _
                                   ByRef NO3() As Double, ByRef NH4() As Double, ByRef BD() As Double, ByRef FC() As Double, _
                                   ByRef PWP() As Double, ByRef totalLayers As Integer, ByRef selectedLayer As Integer, _
                                   ByRef slope As Double, ByRef curve As Double)

            If IsNumeric(MainForm.soil_curve.Text) Then curve = CDbl(MainForm.soil_curve.Text)
            If IsNumeric(MainForm.soil_slope.Text) Then slope = CDbl(MainForm.soil_slope.Text) / 100

            If MainForm.soil_maxLayer.Text.Trim <> Nothing Then
                totalLayers = MainForm.soil_maxLayer.Text

                ReDim LT(totalLayers - 1)
                ReDim clay(totalLayers - 1)
                ReDim sand(totalLayers - 1)
                ReDim IOM(totalLayers - 1)
                ReDim NO3(totalLayers - 1)
                ReDim NH4(totalLayers - 1)
                ReDim BD(totalLayers - 1)
                ReDim FC(totalLayers - 1)
                ReDim PWP(totalLayers - 1)

                manualBD = MainForm.Manual_BD_ckbx.Checked
                manualFC = MainForm.Manual_FC_ckbx.Checked
                manualPWP = MainForm.Manual_PWP_ckbx.Checked

                For i As Integer = 1 To totalLayers
                    If MainForm.ctlLayerBtn(i).Checked Then selectedLayer = i
                    If IsNumeric(MainForm.ctlLayerThickness(i).Text) Then LT(i - 1) = CDbl(MainForm.ctlLayerThickness(i).Text)
                    If IsNumeric(MainForm.ctlClay(i).Text) Then clay(i - 1) = CDbl(MainForm.ctlClay(i).Text)
                    If IsNumeric(MainForm.ctlSand(i).Text) Then sand(i - 1) = CDbl(MainForm.ctlSand(i).Text)
                    If IsNumeric(MainForm.ctlIOM(i).Text) Then IOM(i - 1) = CDbl(MainForm.ctlIOM(i).Text)
                    If IsNumeric(MainForm.ctlNO3(i).Text) Then NO3(i - 1) = CDbl(MainForm.ctlNO3(i).Text)
                    If IsNumeric(MainForm.ctlNH4(i).Text) Then NH4(i - 1) = CDbl(MainForm.ctlNH4(i).Text)
                    If IsNumeric(MainForm.ctlBD(i).Text) Then BD(i - 1) = CDbl(MainForm.ctlBD(i).Text)
                    If IsNumeric(MainForm.ctlFC(i).Text) Then FC(i - 1) = CDbl(MainForm.ctlFC(i).Text)
                    If IsNumeric(MainForm.ctlPWP(i).Text) Then PWP(i - 1) = CDbl(MainForm.ctlPWP(i).Text)
                Next
            End If
        End Sub
        Public Sub PlantingOrder(ByRef opList(,) As Object)
            'Precondition:  none
            'Postcondition: returns planted crop list

            Dim lv As ListView = MainForm.lv_PlantedCrops

            Call Me.readList(lv, opList)
        End Sub
        Public Sub CropDescriptions(ByRef opList(,) As Object)
            'Precondition:  all described crops are complete
            'Postcondition: returns list of all crops

            Dim lv As ListView = MainForm.lv_DescribedCrops

            Call Me.readList(lv, opList)
        End Sub
        Public Sub Tillage(ByRef opList(,) As Object, ByRef usingOps As Boolean)
            'Precondition:  any recorded operations are complete (year, day, etc) 
            'Postcondition: returns list of all operations

            Dim lv As ListView = MainForm.lv_Tillage

            If lv.Items.Count <= 0 Then
                MainForm.tillSetup_PerformOperations.Checked = False
            End If

            usingOps = MainForm.tillSetup_PerformOperations.Checked
            Call Me.readList(lv, opList)
        End Sub
        Public Sub FixedIrrigation(ByRef opList(,) As Object, ByRef usingOps As Boolean)
            'Precondition:  any recorded operations are complete (year, day, etc) 
            'Postcondition: returns list of all operations

            Dim lv As ListView = MainForm.lv_FixedIrrigation

            If lv.Items.Count <= 0 Then
                MainForm.fixedIrrSetup_PerformOperations.Checked = False
            End If

            usingOps = MainForm.fixedIrrSetup_PerformOperations.Checked
            Call Me.readList(lv, opList)
        End Sub
        Public Sub AutoIrrigation(ByRef opList(,) As Object, ByRef usingOps As Boolean)
            'Precondition:  any recorded operations are complete (year, day, etc) 
            'Postcondition: returns list of all operations

            Dim lv As ListView = MainForm.lv_AutomaticIrrigation

            If lv.Items.Count <= 0 Then
                MainForm.autoIrrSetup_PerformOperations.Checked = False
            End If

            usingOps = MainForm.autoIrrSetup_PerformOperations.Checked
            Call Me.readList(lv, opList)
        End Sub
        Public Sub FixedFertilization(ByRef opList(,) As Object, ByRef usingOps As Boolean)
            'Precondition:  any recorded operations are complete (year, day, etc) 
            'Postcondition: returns list of all operations

            Dim lv As ListView = MainForm.lv_FixedFertilization

            If lv.Items.Count <= 0 Then
                MainForm.fixedFertSetup_PerformOperations.Checked = False
            End If

            usingOps = MainForm.fixedFertSetup_PerformOperations.Checked
            Call Me.readList(lv, opList)
        End Sub
        Public Sub AutoFertilization(ByRef opList(,) As Object, ByRef usingOps As Boolean)
            'Precondition:  any recorded operations are complete (year, day, etc) 
            'Postcondition: returns list of all operations

            Dim lv As ListView = MainForm.lv_AutoFertilization

            If lv.Items.Count <= 0 Then
                MainForm.autoFertSetup_PerformOperations.Checked = False
            End If

            usingOps = MainForm.autoFertSetup_PerformOperations.Checked
            Call Me.readList(lv, opList)
        End Sub

        Private Sub readList(ByVal lv As ListView, ByRef opList(,) As Object)
            'Precondition:  The listview passed exists
            'Postcondition: resizes the passed array to 0 x colCount or rowCount x colCount
            '               array populated with active data from the listview
            '               returned array is zero based

            Dim i As Integer = 0
            Dim cnt As Integer = 0

            For Each listItem In lv.Items
                If listItem.BackColor = MainForm.colorActive Then i += 1
            Next

            If i > 0 Then
                ReDim opList(i - 1, lv.Columns.Count - 1)
            Else
                ReDim opList(0, lv.Columns.Count - 1)
            End If

            cnt = 0

            For Each listItem In lv.Items
                If listItem.BackColor = MainForm.colorActive Then
                    For i = 0 To UBound(opList, Rank:=2)
                        opList(cnt, i) = listItem.SubItems.Item(i).Text
                    Next

                    cnt += 1
                End If
            Next
        End Sub

    End Class

    Public Class formWrite

        Public Sub SimulationControls(ByVal weatherFile As String, ByVal startYear As Integer, ByVal endYear As Integer, _
                                      ByVal rotationSize As Integer, ByVal adjustedYields As Boolean, ByVal hourlyInfiltration As Boolean, _
                                      ByVal autoNitrogen As Boolean, ByVal autoPhosphorus As Boolean, ByVal autoSulfur As Boolean, _
                                      ByVal dailyCropOut As Boolean, ByVal dailySoilOut As Boolean, ByVal dailyNitrogenOut As Boolean, _
                                      ByVal dailyWaterOut As Boolean, ByVal dailyWeatherOut As Boolean, ByVal dailyResidueOut As Boolean, _
                                      ByVal dailySoilCarbonOut As Boolean, ByVal annualSoilOut As Boolean, ByVal soilProfileOut As Boolean, _
                                      ByVal seasonOut As Boolean)

            If FileOps.FileExists(weatherFile) Then
                MainForm.weatherFile_Path.Text = weatherFile
                MainForm.duration_StartYear.Text = startYear
                MainForm.duration_StopYear.Text = endYear
                MainForm.duration_RotationSize.Text = rotationSize
            Else
                Call MainForm.SelectWeatherFile()
                MainForm.duration_StartYear.Text = startYear
                MainForm.duration_StopYear.Text = endYear
                MainForm.duration_RotationSize.Text = rotationSize
            End If

            MainForm.calcOptions_adjustedYields.Checked = adjustedYields
            MainForm.calcOptions_waterInfiltration.Checked = hourlyInfiltration
            MainForm.calcOptions_autoNitrogen.Checked = autoNitrogen
            MainForm.calcOptions_autoPhosphorus.Checked = autoPhosphorus
            MainForm.calcOptions_autoSulfur.Checked = autoSulfur

            MainForm.DailyWeatherReporting.Checked = dailyWeatherOut
            MainForm.DailyCropReporting.Checked = dailyCropOut
            MainForm.DailyResidueReporting.Checked = dailyResidueOut
            MainForm.DailyWaterReporting.Checked = dailyWaterOut
            MainForm.DailyNitrogenReporting.Checked = dailyNitrogenOut
            MainForm.DailySoilCarbonReporting.Checked = dailySoilCarbonOut
            MainForm.DailySoilReporting.Checked = dailySoilOut
            MainForm.AnnualSoilReporting.Checked = annualSoilOut
            MainForm.AnnualSoilProfileReporting.Checked = soilProfileOut
            MainForm.SeasonReporting.Checked = seasonOut
        End Sub
        Public Sub SoilDescription(ByVal manualBD As Boolean, ByVal manualFC As Boolean, ByVal manualPWP As Boolean, _
                                   ByVal LT() As Double, ByVal Clay() As Double, ByVal Sand() As Double, ByVal IOM() As Double, _
                                   ByVal NO3() As Double, ByVal NH4() As Double, ByVal BD() As Double, ByVal FC() As Double, _
                                   ByVal PWP() As Double, ByVal totalLayers As Integer, ByVal selectedLayer As Integer, _
                                   ByVal Curve As Double, ByVal Slope As Double)

            If totalLayers >= 1 Then
                MainForm.soil_maxLayer.Text = totalLayers

                For i As Integer = 1 To totalLayers
                    If LT(i) <> Nothing Then MainForm.ctlLayerThickness(i).Text = SideSubs.Formatting(LT(i))
                    If Clay(i) <> Nothing Then MainForm.ctlClay(i).Text = SideSubs.Formatting(Clay(i))
                    If Sand(i) <> Nothing Then MainForm.ctlSand(i).Text = SideSubs.Formatting(Sand(i))
                    If IOM(i) <> Nothing Then MainForm.ctlIOM(i).Text = SideSubs.Formatting(IOM(i))
                    If NO3(i) <> Nothing Then MainForm.ctlNO3(i).Text = SideSubs.Formatting(NO3(i))
                    If NH4(i) <> Nothing Then MainForm.ctlNH4(i).Text = SideSubs.Formatting(NH4(i))
                    If BD(i) <> Nothing Then MainForm.ctlBD(i).Text = SideSubs.Formatting(BD(i))
                    If FC(i) <> Nothing Then MainForm.ctlFC(i).Text = SideSubs.Formatting(FC(i))
                    If PWP(i) <> Nothing Then MainForm.ctlPWP(i).Text = SideSubs.Formatting(PWP(i))
                Next

                MainForm.ctlLayerBtn(selectedLayer).Checked = True

                MainForm.Manual_BD_ckbx.Checked = manualBD
                MainForm.Manual_FC_ckbx.Checked = manualFC
                MainForm.Manual_PWP_ckbx.Checked = manualPWP
            End If

            MainForm.soil_curve.Text = Curve
            MainForm.soil_slope.Text = Slope
        End Sub
        Public Sub CropDescriptions(ByVal Described(,) As Object)
            Dim activeLv As ListView = MainForm.lv_DescribedCrops
            Dim oplist(UBound(MainForm.ctlCropDescrip) - 1) As Object
            Dim cropVal As Object

            'Restore default state
            Call MainForm.PopulateUndescribedCropsList()
            activeLv.Items.Clear()

            'Copy crop descriptions to listview
            For i As Integer = LBound(Described, Rank:=1) To UBound(Described, Rank:=1)

                If Trim(Described(i, 1)) <> Nothing Then                                'crop is not blank

                    If Not MainForm.IsCropDescribed(Described(i, 1)) Then               'crop not already described

                        Call MainForm.RemoveFromUndescribedCropList(Described(i, 1))    'remove from available to be described crop list

                        'read operation
                        For j As Integer = 1 To UBound(Described, Rank:=2)
                            cropVal = Trim(Described(i, j))

                            If Trim(cropVal) <> Nothing Then
                                oplist(j - 1) = cropVal                                 'passed values
                            Else
                                oplist(j - 1) = ""                                      'optional values
                            End If
                        Next

                        'write operation
                        Call MainForm.WriteListViewRow(activeLv, oplist)
                    Else
                        MsgBox("Crop already described." & vbCr & "Unable to add " & MainForm.CropDescrip1.Text & ".", MsgBoxStyle.Information, MainForm.ProductName)
                    End If
                End If
            Next

            'update displayed counts
            MainForm.grp_DescribedCrops.Text = MainForm.ActiveListviewOperations(activeLv)

            'update rotation lists
            Call MainForm.UpdateDescribedCropsComboBoxes()
        End Sub
        Public Sub PlantingOrder(ByVal rotation(,) As Object)
            'Precondition:  Rotation is a Years x 3 properly filled array
            'Postcondition: populates planted crop list

            Dim lv As ListView = MainForm.lv_PlantedCrops
            Dim oplist(UBound(rotation, Rank:=2) - 1) As Object

            For Each op As Object In rotation
                If TypeOf op Is Boolean Then
                    If op = True Then
                        op = "True"
                    Else
                        op = ""
                    End If
                End If
            Next

            For i As Integer = LBound(rotation, Rank:=1) To UBound(rotation, Rank:=1)
                If IsNumeric(rotation(i, 1)) And IsNumeric(rotation(i, 2)) And Trim(rotation(i, 3)) <> Nothing Then
                    'read operation
                    For j As Integer = 1 To UBound(rotation, Rank:=2)
                        oplist(j - 1) = rotation(i, j)
                    Next

                    'write operation
                    Call MainForm.WriteListViewRow(lv, oplist)
                    Call MainForm.WriteListViewRow(MainForm.lv_ActiveFieldOperations, oplist, cropType)
                End If
            Next

            'update displayed counts
            MainForm.grp_PlantedCrops.Text = MainForm.ActiveListviewOperations(lv)
        End Sub
        Public Sub Tillage(ByVal mstrList(,) As Object, ByVal usingOps As Boolean)
            'Precondition:  Tillage has been initialized
            '               tillageOps is formatted correctly
            'Postcondition: Tillage listviews have been cleared and filled with operations from file

            Dim lv As ListView = MainForm.lv_Tillage
            Dim opList(mstrList.GetUpperBound(1) - 1) As Object
            Dim used As Boolean

            MainForm.tillSetup_PerformOperations.Checked = usingOps

            lv.Items.Clear()

            For i As Integer = mstrList.GetLowerBound(0) To mstrList.GetUpperBound(0)
                If IsNumeric(mstrList(i, 1)) And IsNumeric(mstrList(i, 2)) And IsNumeric(mstrList(i, 4)) And IsNumeric(mstrList(i, 5)) And IsNumeric(mstrList(i, 6)) Then
                    For j As Integer = 1 To mstrList.GetUpperBound(1)
                        opList(j - 1) = mstrList(i, j)
                    Next

                    If opList(0) <= 0 Then
                        used = False

                    ElseIf opList(1) <= 0 Or opList(1) > 366 Then
                        used = False

                    ElseIf Trim(opList(2)) = Nothing Then
                        used = False

                    ElseIf opList(3) < 0 Then
                        used = False

                    Else
                        used = True
                    End If

                    If used Then
                        opList(0) = CInt(opList(0)) 'Year
                        opList(1) = CInt(opList(1)) 'Day 
                        opList(2) = CStr(opList(2)) 'Tool Name
                        opList(3) = CDbl(opList(3)) 'Assigned Depth
                        opList(4) = CDbl(opList(4)) 'Soil Disturbance Ratio
                        opList(5) = CDbl(opList(5)) 'Mixing Efficiency

                        For j As Integer = 0 To maxTools
                            If opList(2) = TillageOps.listToolName(j) Then
                                Call MainForm.WriteListViewRow(lv, opList)

                                If usingOps Then
                                    Call MainForm.WriteListViewRow(MainForm.lv_ActiveFieldOperations, opList, tillType)
                                End If
                            End If
                        Next

                    End If
                End If
            Next

            'update displayed counts
            MainForm.grp_Tillage.Text = MainForm.ActiveListviewOperations(lv)
        End Sub
        Public Sub FixedIrrigation(ByVal mstrList(,) As Object, ByVal usingOps As Boolean)
            'Precondition:  Fixed_Irr_Ops is formatted correctly
            'Postcondition: Fixed_Irr_Ops listviews have been cleared and filled with operations from file

            Dim lv As ListView = MainForm.lv_FixedIrrigation
            Dim opList(mstrList.GetUpperBound(1) - 1) As Object
            Dim used As Boolean

            MainForm.fixedIrrSetup_PerformOperations.Checked = usingOps

            lv.Items.Clear()

            For i As Integer = mstrList.GetLowerBound(0) To mstrList.GetUpperBound(0)
                If IsNumeric(mstrList(i, 1)) And IsNumeric(mstrList(i, 2)) And IsNumeric(mstrList(i, 3)) Then
                    For j As Integer = mstrList.GetLowerBound(0) To mstrList.GetUpperBound(1)
                        opList(j - 1) = mstrList(i, j)
                    Next

                    If opList(0) <= 0 Then
                        used = False

                    ElseIf opList(1) <= 0 Or opList(1) > 366 Then
                        used = False

                    ElseIf opList(2) <= 0 Then
                        used = False

                    Else
                        used = True
                    End If

                    If used Then
                        opList(0) = CInt(opList(0))
                        opList(1) = CInt(opList(1))
                        opList(2) = Format(opList(2), "0.0")

                        Call MainForm.WriteListViewRow(lv, opList)
                        If usingOps Then
                            Call MainForm.WriteListViewRow(MainForm.lv_ActiveFieldOperations, opList, irrType)
                        End If
                    End If
                End If
            Next

            'update displayed count
            MainForm.grp_FixedIrrigation.Text = MainForm.ActiveListviewOperations(lv)
        End Sub
        Public Sub AutoIrrigation(ByVal mstrList(,) As Object, ByVal usingOps As Boolean)
            'Precondition:  Auto_Irr_Ops is formatted correctly
            'Postcondition: Auto_Irr_Ops listviews have been cleared and filled with operations from file

            Dim lv As ListView = MainForm.lv_AutomaticIrrigation
            Dim oplist(mstrList.GetUpperBound(1) - 1) As Object
            Dim used As Boolean

            MainForm.autoIrrSetup_PerformOperations.Checked = usingOps

            lv.Items.Clear()

            For i As Integer = mstrList.GetLowerBound(0) To mstrList.GetUpperBound(0)
                If IsNumeric(mstrList(i, 2)) And IsNumeric(mstrList(i, 3)) And IsNumeric(mstrList(i, 4)) And IsNumeric(mstrList(i, 5)) Then
                    For j As Integer = mstrList.GetLowerBound(0) To mstrList.GetUpperBound(1)
                        oplist(j - 1) = mstrList(i, j)
                    Next

                    If Trim(oplist(0)) = Nothing Then
                        used = False

                    ElseIf oplist(1) <= 0 Or oplist(1) > 366 Then
                        used = False

                    ElseIf oplist(2) <= 0 Or oplist(2) > 366 Then
                        used = False

                    ElseIf oplist(3) <= 0 Then
                        used = False

                    ElseIf oplist(4) <= 0 Then
                        used = False

                    Else
                        used = True
                    End If

                    If used Then
                        oplist(0) = Trim(oplist(0))
                        oplist(1) = CInt(oplist(1))
                        oplist(2) = CInt(oplist(2))
                        oplist(3) = Format(CDbl(oplist(3)), "0.0")
                        oplist(4) = CInt(oplist(4))

                        Call MainForm.WriteListViewRow(lv, oplist)
                    End If
                End If
            Next

            'update available list
            MainForm.IrrigationPlantAvailableListChanged()

            'update displayed count
            MainForm.grp_AutomaticIrrigation.Text = MainForm.ActiveListviewOperations(lv)
        End Sub
        Public Sub FixedFertilization(ByVal mstrList(,) As Object, ByVal usingOps As Boolean)
            'Precondition:  fertOps is formatted correctly
            'Postcondition: fertOps listviews have been cleard and filled with operations from file

            Dim lv As ListView = MainForm.lv_FixedFertilization
            Dim oplist(mstrList.GetUpperBound(1) - 1) As Object
            Dim used As Boolean

            MainForm.fixedFertSetup_PerformOperations.Checked = usingOps

            lv.Items.Clear()

            For i As Integer = 1 To mstrList.GetUpperBound(0)
                If IsNumeric(mstrList(i, 1)) And IsNumeric(mstrList(i, 2)) Then
                    For j As Integer = mstrList.GetLowerBound(0) To mstrList.GetUpperBound(1)
                        oplist(j - 1) = mstrList(i, j)
                    Next

                    If oplist(0) <= 0 Then
                        used = False

                    ElseIf oplist(1) <= 0 Or oplist(1) > 366 Then
                        used = False

                    ElseIf Trim(oplist(3)) = Nothing Or Trim(oplist(5)) = Nothing Or Trim(oplist(6)) = Nothing Then
                        used = False

                    Else
                        used = True
                    End If

                    If used Then
                        Call MainForm.WriteListViewRow(lv, oplist)

                        If usingOps Then
                            Call MainForm.WriteListViewRow(MainForm.lv_ActiveFieldOperations, oplist, fertType)
                        End If
                    End If
                End If
            Next

            'update displayed count
            MainForm.grp_FixedFertilization.Text = MainForm.ActiveListviewOperations(lv)
        End Sub
        Public Sub AutoFertilization(ByVal mstrList(,) As Object, ByVal usingOps As Boolean)
            'Precondition:  fertOps is formatted correctly
            'Postcondition: fertOps listviews have been cleard and filled with operations from file

            Dim lv As ListView = MainForm.lv_AutoFertilization
            Dim oplist(mstrList.GetUpperBound(1) - 1) As Object
            Dim used As Boolean

            MainForm.autoFertSetup_PerformOperations.Checked = usingOps

            lv.Items.Clear()

            For i As Integer = mstrList.GetLowerBound(0) To mstrList.GetUpperBound(0)
                If IsNumeric(mstrList(i, 2)) And IsNumeric(mstrList(i, 3)) And IsNumeric(mstrList(i, 4)) Then
                    For j As Integer = mstrList.GetLowerBound(0) To mstrList.GetUpperBound(1)
                        oplist(j - 1) = mstrList(i, j)
                    Next

                    If Trim(oplist(0)) = Nothing Then
                        used = False

                    ElseIf oplist(1) <= 0 Then
                        used = False

                    ElseIf oplist(2) <= 0 Or oplist(2) > 366 Then
                        used = False

                    ElseIf oplist(3) <= 0 Or oplist(3) > 366 Then
                        used = False

                    ElseIf Trim(oplist(4)) = Nothing Or Trim(oplist(5)) = Nothing Or Trim(oplist(6)) = Nothing Then
                        used = False

                    Else
                        used = True
                    End If

                    If used Then
                        'format array to remove null values
                        oplist(0) = Trim(oplist(0)) 'crop
                        oplist(1) = CInt(oplist(1)) 'start day
                        oplist(2) = CInt(oplist(2)) 'stopday
                        oplist(3) = Format(CDbl(oplist(3)), "0.0") 'mass
                        oplist(4) = Trim(oplist(4)) 'source
                        oplist(5) = Trim(oplist(5)) 'form
                        oplist(6) = Trim(oplist(6)) 'method

                        Call MainForm.WriteListViewRow(lv, oplist)
                    End If
                End If
            Next

            'update available list
            MainForm.FertilizationPlantAvailableListChanged()

            'update displayed count
            MainForm.grp_AutoFertilization.Text = MainForm.ActiveListviewOperations(lv)
        End Sub

    End Class

    Public Sub startProgressBar(ByVal totalYears As Integer)
        'Precondition:  1 <= totalYears
        '               totalUpdateCalls = actual number of calls in main
        'Postcondition: Progress Bar set to initial state and made visible

        With Me.ProgressBar
            .Style = ProgressBarStyle.Continuous
            .Visible = True
            .Value = 0
            .Minimum = 0
            .Maximum = totalYears
        End With

        System.Windows.Forms.Application.DoEvents()
    End Sub
    Public Sub updateProgressBar()
        'Precondition:  ProgressBar's value < maximum value
        'Postcondition: Progress Bar visual status changed

        With Me.ProgressBar
            .Value += 1
        End With

        System.Windows.Forms.Application.DoEvents()
    End Sub
    Public Sub stopProgressBar()
        'Precondition:  none
        'Postcondition: ProgressBar set to initial state and made invisible

        With Me.ProgressBar
            .Visible = False
            .Value = 0
        End With

        System.Windows.Forms.Application.DoEvents()
    End Sub

    Public Sub EditLog(ByVal line As String, ByVal updateStatusBar As Boolean)
        'Precondition:  none
        'Postcondition: passed string copied to log and time/date stamped
        '               passed string copied to statusLabel as requested

        Dim lv As ListViewItem

        lv = Me.lv_logViewer.Items.Add(System.DateTime.Now)
        lv.SubItems.Add(line)

        If updateStatusBar Then Me.StatusLabel.Text = line
    End Sub

    Public Sub RuntimeStatus(ByVal section As String)
        'Precondition:  none
        'Postcondition: passed string copied to statusLabel 

        Me.StatusLabel.Text = section
        System.Windows.Forms.Application.DoEvents()
    End Sub

    Public Sub NeuterInterface()
        'Precondition:  control arrays previously populated
        'Postcondition: Interface options limited for trial style usage

        Dim Neutered As Boolean = False
        Dim found As Boolean
        Dim tempVal As Object = Nothing
        Dim formObjects() As Object = {Me.tillSetup_PerformOperations, Me.fixedIrrSetup_PerformOperations, Me.autoIrrSetup_PerformOperations, Me.fixedFertSetup_PerformOperations, _
                                       Me.Manual_BD_ckbx, Me.Manual_FC_ckbx, Me.Manual_PWP_ckbx, Chkbx_UseAdvancedDescrip}

        If Neutered Then
            Me.Text = "Project X - Trial Version"

            For Each fo As Object In formObjects
                With fo
                    .Checked = False
                    .Enabled = False
                End With
            Next

            With Me.duration_RotationSize
                If .Text <> Nothing Then
                    If IsNumeric(.Text) Then
                        If .Text > 5 Then
                            tempVal = 5
                        Else
                            tempVal = CInt(.Text)
                        End If
                    End If
                End If
                .Items.Clear()

                For i As Integer = 1 To 5
                    .Items.Add(i)
                Next

                .Text = tempVal
            End With

            found = False
            MsgBox("Neuter the soil descriptions tab", MsgBoxStyle.Exclamation, Me.ProductName)
            'For i As Integer = 1 To MAX_LAYERS
            '    If ctlLayerBtn(i).Checked = True Then
            '        If i <= 5 Then
            '            found = True
            '            Exit For
            '        ElseIf i > 5 Then
            '            ctlLayerBtn(5).Checked = True
            '            found = True
            '            Exit For
            '        End If
            '    End If
            'Next
            'If Not found Then ctlLayerBtn(5).Checked = True

            'For i As Integer = 6 To MAX_LAYERS
            '    ctlLayerBtn(i).Enabled = False
            'Next
        End If
    End Sub

    '====================================== Private Only Functions =================================
    Private Sub SetControlsToArrays()
        'Precondition:  strings used by "Find" are actual field names
        'Postcondition: controls that are commonly needed to be searched for by name are stored in control arrays

        'For i As Integer = 1 To MAX_LAYERS
        '    ctlLayerBtn(i) = Me.Controls.Find("Layer_btn_" & i, True)(0)
        '    ctlCumDepth(i) = Me.Controls.Find("cumDepthLayer" & i, True)(0)
        '    ctlLayerThickness(i) = Me.Controls.Find("thicknessLayer" & i, True)(0)
        '    ctlClay(i) = Me.Controls.Find("ClayLayer" & i, True)(0)
        '    ctlSand(i) = Me.Controls.Find("SandLayer" & i, True)(0)
        '    ctlIOM(i) = Me.Controls.Find("iomLayer" & i, True)(0)
        '    ctlNO3(i) = Me.Controls.Find("nitrateLayer" & i, True)(0)
        '    ctlNH4(i) = Me.Controls.Find("ammoniumLayer" & i, True)(0)
        '    ctlBD(i) = Me.Controls.Find("bdLayer" & i, True)(0)
        '    ctlFC(i) = Me.Controls.Find("fcLayer" & i, True)(0)
        '    ctlPWP(i) = Me.Controls.Find("pwpLayer" & i, True)(0)
        'Next

        For i As Integer = 1 To totalCropFields
            ctlCropDescrip(i) = Me.Controls.Find("CropDescrip" & i, True)(0)
            ctlCropDescripLabel(i) = Me.Controls.Find("CropLabel" & i, True)(0)
        Next
    End Sub

    Private Sub MainForm_Load() Handles MyBase.Load
        'Precondition:  Excel is installed on the computer
        'Postcondition: Excel started
        '               controls arrays are populated
        '               combo boxes are populated
        '               listviews are initialized
        '               settings restored if available

        Try
            myExcel = New Excel.Application
        Catch ex As Exception
            MsgBox(Err.Description, MsgBoxStyle.Critical, Me.ProductName)
            Me.Close()
        End Try

        TillageOps.PopulateOperationsTable()
        Fertilization.PopulateOperationsTable()

        Me.SetControlsToArrays()
        Me.FillComboBoxes()
        Me.InitializeCropDescription()
        Me.InitializeListViews()
        Me.AddValidationHandling()
        Me.InitializeProgressBar()
        Me.EditLog(Me.ProductName & " started", True)
        Me.RestoreSettings()

        'Call NeuterInterface()
        Me.autoFertSetup_PerformOperations.CheckState = False
    End Sub

    Private Sub FillComboBoxes()
        'Precondition:  none
        'Postcondition: combo boxes populated

        Me.autoIrrSetup_WaterDepletion.Items.Clear()
        Me.autoIrrSetup_LastSoilLayer.Items.Clear()
        Me.soil_maxLayer.Items.Clear()
        Me.CropDescrip32.Items.Clear()
        Me.CropDescrip33.Items.Clear()
        Me.CropDescrip34.Items.Clear()
        Me.tillSetup_Tool.Items.Clear()
        Me.fixedFertSetup_Source.Items.Clear()
        Me.fixedFertSetup_Form.Items.Clear()
        Me.fixedFertSetup_Method.Items.Clear()
        Me.autoFertSetup_Source.Items.Clear()
        Me.autoFertSetup_Form.Items.Clear()
        Me.autoFertSetup_Method.Items.Clear()

        Me.autoIrrSetup_WaterDepletion.Items.Add("")
        Me.soil_maxLayer.Items.Add("")
        Me.CropDescrip32.Items.Add("")
        Me.CropDescrip33.Items.Add("")
        Me.CropDescrip34.Items.Add("")
        Me.tillSetup_Tool.Items.Add("")
        Me.fixedFertSetup_Source.Items.Add("")
        Me.fixedFertSetup_Form.Items.Add("")
        Me.fixedFertSetup_Method.Items.Add("")
        Me.autoFertSetup_Source.Items.Add("")
        Me.autoFertSetup_Form.Items.Add("")
        Me.autoFertSetup_Method.Items.Add("")

        For i As Integer = 0 To 20
            Me.autoIrrSetup_WaterDepletion.Items.Add(Format(i / 20, "0.00"))
        Next

        For i As Integer = 1 To 99
            Me.soil_maxLayer.Items.Add(i)
        Next
        Me.soil_maxLayer.Text = 1
        Me.ctlLayerBtn(1).Checked = True

        For i As Integer = 0 To TillageOps.maxTools
            Me.tillSetup_Tool.Items.Add(TillageOps.listToolName(i))
        Next

        With Me.CropDescrip32
            .Items.Add("Annual")
            .Items.Add("Perennial")
        End With

        With Me.CropDescrip33
            .Items.Add(True)
            .Items.Add(False)
        End With

        With Me.CropDescrip34
            .Items.Add("C3")
            .Items.Add("C4")
        End With

        For i As Integer = 0 To Fertilization.maxFertilizers
            Me.fixedFertSetup_Source.Items.Add(Fertilization.Source(i))
        Next

        With Me.fixedFertSetup_Form
            .Items.Add("Solid")
            .Items.Add("Liquid")
        End With

        With Me.fixedFertSetup_Method
            .Items.Add("Broadcast")
            .Items.Add("Incorporated")
        End With

        With Me.autoFertSetup_Source
            .Items.Add("Nitrate")
            .Items.Add("Ammonium")
            .Items.Add("Urea")
            .Items.Add("UAN")
        End With

        With Me.autoFertSetup_Form
            .Items.Add("Solid")
            .Items.Add("Liquid")
        End With

        With Me.autoFertSetup_Method
            .Items.Add("Broadcast")
            .Items.Add("Incorporated")
        End With

    End Sub

    Private Sub InitializeListViews()
        'Precondition:  none
        'Postcondition: listviews column count increased to the number of parameters in the setup associated with each listview
        '               listview column headers names match setup names

        Dim ctl As Control
        Dim intWidth As Integer

        With Me.lv_DescribedCrops
            intWidth = 10
            .View = View.Details
            .GridLines = True
            .CheckBoxes = False

            For i As Integer = 1 To UBound(ctlCropDescripLabel)
                ctl = ctlCropDescripLabel(i)

                If ctl.Width > 100 Then
                    .Columns.Add(ctl.Text, 100 + intWidth)
                ElseIf ctl.Width < 70 Then
                    .Columns.Add(ctl.Text, 70 + intWidth)
                Else
                    .Columns.Add(ctl.Text, ctl.Width + intWidth)
                End If
            Next
        End With

        With Me.lv_PlantedCrops
            intWidth = .Width - 5
            .View = View.Details
            .GridLines = True
            .CheckBoxes = False
            .Columns.Add("Year", CInt(intWidth * (1 / 6)))
            .Columns.Add("Day", CInt(intWidth * (1 / 6)))
            .Columns.Add("Crop", CInt(intWidth * (2 / 6)))
            .Columns.Add("Irrigation", CInt(intWidth * (1 / 6)))
            .Columns.Add("Fertilization", CInt(intWidth * (1 / 6)))
        End With

        With Me.lv_Tillage
            intWidth = .Width - 5
            .View = View.Details
            .GridLines = True
            .CheckBoxes = False
            .Columns.Add("Year", CInt(intWidth * (1 / 6)))
            .Columns.Add("Day", CInt(intWidth * (1 / 6)))
            .Columns.Add("Tool", CInt(intWidth * (3 / 6)))
            .Columns.Add("Depth", CInt(intWidth * (1 / 6)))
            .Columns.Add("Soil Disturbance Ratio", CInt(intWidth * (1 / 6)))
            .Columns.Add("Mixing Efficiency", CInt(intWidth * (1 / 6)))
        End With

        With Me.lv_FixedIrrigation
            intWidth = .Width - 5
            .View = View.Details
            .GridLines = True
            .CheckBoxes = False
            .Columns.Add("Year", CInt(intWidth * (1 / 3)))
            .Columns.Add("Day", CInt(intWidth * (1 / 3)))
            .Columns.Add("Volume", CInt(intWidth * (1 / 3)))
        End With

        With Me.lv_AutomaticIrrigation
            intWidth = .Width - 5
            .View = View.Details
            .GridLines = True
            .CheckBoxes = False
            .Columns.Add("Crop", CInt(intWidth * (2 / 6)))
            .Columns.Add("Start", CInt(intWidth * (1 / 6)))
            .Columns.Add("Stop", CInt(intWidth * (1 / 6)))
            .Columns.Add("Depletion", CInt(intWidth * (1 / 6)))
            .Columns.Add("Layer", CInt(intWidth * (1 / 6)))
        End With

        With Me.lv_FixedFertilization
            intWidth = .Width - 5
            .View = View.Details
            .GridLines = True
            .CheckBoxes = False
            .Columns.Add("Year", CInt(intWidth * (3 / 20)))
            .Columns.Add("Day", CInt(intWidth * (3 / 20)))
            .Columns.Add("Source", CInt(intWidth * (4 / 20)))
            .Columns.Add("Mass", CInt(intWidth * (3 / 20)))
            .Columns.Add("Form", CInt(intWidth * (4 / 20)))
            .Columns.Add("Method", CInt(intWidth * (4 / 20)))
            .Columns.Add("Depth", CInt(intWidth * (3 / 20)))
            .Columns.Add("C Organic", CInt(intWidth * (3 / 20)))
            .Columns.Add("C Charcoal", CInt(intWidth * (3 / 20)))
            .Columns.Add("N Organic", CInt(intWidth * (3 / 20)))
            .Columns.Add("N Charcoal", CInt(intWidth * (3 / 20)))
            .Columns.Add("N NH4", CInt(intWidth * (3 / 20)))
            .Columns.Add("N NO3", CInt(intWidth * (3 / 20)))
            .Columns.Add("P Organic", CInt(intWidth * (3 / 20)))
            .Columns.Add("P Charcoal", CInt(intWidth * (3 / 20)))
            .Columns.Add("P Inorganic", CInt(intWidth * (3 / 20)))
            .Columns.Add("K", CInt(intWidth * (3 / 20)))
            .Columns.Add("S", CInt(intWidth * (3 / 20)))
        End With

        With Me.lv_AutoFertilization
            intWidth = .Width - 5
            .View = View.Details
            .GridLines = True
            .CheckBoxes = False
            .Columns.Add("Crop", CInt(intWidth * (3 / 20)))
            .Columns.Add("Start", CInt(intWidth * (3 / 20)))
            .Columns.Add("Stop", CInt(intWidth * (3 / 20)))
            .Columns.Add("Mass", CInt(intWidth * (3 / 20)))
            .Columns.Add("Source", CInt(intWidth * (4 / 20)))
            .Columns.Add("Form", CInt(intWidth * (4 / 20)))
            .Columns.Add("Method", CInt(intWidth * (4 / 20)))
            .Columns.Add("C Organic", CInt(intWidth * (3 / 20)))
            .Columns.Add("C Charcoal", CInt(intWidth * (3 / 20)))
            .Columns.Add("N Organic", CInt(intWidth * (3 / 20)))
            .Columns.Add("N Charcoal", CInt(intWidth * (3 / 20)))
            .Columns.Add("N NH4", CInt(intWidth * (3 / 20)))
            .Columns.Add("N NO3", CInt(intWidth * (3 / 20)))
            .Columns.Add("P Organic", CInt(intWidth * (3 / 20)))
            .Columns.Add("P Charcoal", CInt(intWidth * (3 / 20)))
            .Columns.Add("P Inorganic", CInt(intWidth * (3 / 20)))
            .Columns.Add("K", CInt(intWidth * (3 / 20)))
            .Columns.Add("S", CInt(intWidth * (3 / 20)))
        End With

        With lv_ActiveFieldOperations
            intWidth = .Width - 5
            .View = View.Details
            .GridLines = True
            .CheckBoxes = False
            .Columns.Add("Year", CInt(intWidth * (2 / 30)))
            .Columns.Add("Day", CInt(intWidth * (2 / 30)))
            .Columns.Add("Type", CInt(intWidth * (4 / 30)))
            .Columns.Add(Nothing, CInt(intWidth * (4 / 30)))
            .Columns.Add(Nothing, CInt(intWidth * (3 / 30)))
            .Columns.Add(Nothing, CInt(intWidth * (3 / 30)))
            .Columns.Add(Nothing, CInt(intWidth * (3 / 30)))
            .Columns.Add(Nothing, CInt(intWidth * (3 / 30)))
            .Columns.Add(Nothing, CInt(intWidth * (3 / 30)))
            .Columns.Add(Nothing, CInt(intWidth * (3 / 30)))
        End With

        With Me.lv_logViewer
            intWidth = .Width - 5
            .View = View.Details
            .GridLines = False
            .CheckBoxes = False
            .Columns.Add("Date", CInt(intWidth * (1 / 5)))
            .Columns.Add("Activity", CInt(intWidth * (4 / 5)))
        End With
    End Sub

    Private Sub RestoreSettings()
        Dim curSettings As String = lclDir & Me.ProductName & "Working Setup.xls"

        If FileOps.FileExists(curSettings) Then
            'Call Me.ImportSettings(curSettings)
            'EditLog("Settings restored: " & curSettings, True)
        End If
    End Sub

    Private Sub InitializeProgressBar()
        With ProgressBar
            .Value = 0
            .Visible = False
        End With
    End Sub

    Private Sub FillYearsAvailable(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles weatherFile_Path.TextChanged
        Dim myWorkBook As Excel.Workbook
        Dim startDate, endDate As Integer

        If FileOps.FileExists(weatherFile_Path.Text) Then
            Try
                myWorkBook = myExcel.Workbooks.Open(sender.Text)

                Call SideSubs.WeatherFileDates(startDate, endDate, myWorkBook)
                Call Me.SimulationYearUpdate(startDate, endDate)

                myWorkBook.Close(SaveChanges:=False)
            Catch ex As Exception
                MsgBox(Err.Description, MsgBoxStyle.Critical, Me.ProductName)
                Exit Sub
            End Try
        End If
    End Sub
    Private Sub SortListView(ByRef activeLv As ListView)
        'Precondition:  Passed listview is initialized
        '               Items to be sorted are of same type per column
        'Postcondition: Listview sorted by 1st column then 2nd column

        Dim itemA, itemB As ListViewItem
        Dim tempItem As ListViewItem.ListViewSubItem
        Dim found As Boolean

        With activeLv.Items
            If .Count > 1 Then
                Do
                    found = False

                    For i As Integer = 1 To (.Count - 1)
                        itemA = .Item(i - 1)
                        itemB = .Item(i)

                        If (IsNumeric(itemA.SubItems.Item(0).Text) And IsNumeric(itemB.SubItems.Item(0).Text)) Then
                            Dim col1A, col1B, col2A, col2B As Double

                            col1A = itemA.SubItems.Item(0).Text
                            col1B = itemB.SubItems.Item(0).Text
                            col2A = itemA.SubItems.Item(1).Text
                            col2B = itemB.SubItems.Item(1).Text

                            If (col1A > col1B) Or (col1A = col1B And col2A > col2B) Then
                                found = True

                                For j As Integer = 0 To activeLv.Columns.Count - 1
                                    tempItem = itemA.SubItems.Item(j)
                                    itemA.SubItems.Item(j) = itemB.SubItems.Item(j)
                                    itemB.SubItems.Item(j) = tempItem
                                Next
                            End If

                        Else
                            Dim col1A, col1B, col2A, col2B As Object

                            col1A = itemA.SubItems.Item(0).Text
                            col1B = itemB.SubItems.Item(0).Text
                            col2A = itemA.SubItems.Item(1).Text
                            col2B = itemB.SubItems.Item(1).Text

                            If (col1A > col1B) Or (col1A = col1B And col2A > col2B) Then
                                found = True

                                For j As Integer = 0 To activeLv.Columns.Count - 1
                                    tempItem = itemA.SubItems.Item(j)
                                    itemA.SubItems.Item(j) = itemB.SubItems.Item(j)
                                    itemB.SubItems.Item(j) = tempItem
                                Next
                            End If
                        End If
                    Next
                Loop While found
            End If
        End With
    End Sub

    'Private Sub SortListView(ByRef activeLv As ListView)
    '    'Precondition:  Passed listview is initialized
    '    '               Items to be sorted are of same type per column
    '    'Postcondition: Listview sorted by 1st column then 2nd column

    '    Dim itemA, itemB As ListViewItem
    '    Dim tempItem As ListViewItem.ListViewSubItem
    '    Dim col1A, col1B, col2A, col2B As Object
    '    Dim found As Boolean

    '    With activeLv.Items
    '        If .Count > 1 Then
    '            Do
    '                found = False

    '                For i As Integer = 1 To (.Count - 1)
    '                    itemA = .Item(i - 1)
    '                    itemB = .Item(i)

    '                    col1A = itemA.SubItems.Item(0).Text
    '                    col1B = itemB.SubItems.Item(0).Text
    '                    col2A = itemA.SubItems.Item(1).Text
    '                    col2B = itemB.SubItems.Item(1).Text

    '                    If (IsNumeric(itemA.SubItems.Item(0).Text) And IsNumeric(itemB.SubItems.Item(0).Text)) Then
    '                        Convert.ToDouble(col1A)
    '                        Convert.ToDouble(col1B)
    '                        Convert.ToDouble(col2A)
    '                        Convert.ToDouble(col2B)
    '                    End If

    '                    If (col1A > col1B) Or (col1A = col1B And col2A > col2B) Then
    '                        found = True

    '                        For j As Integer = 0 To activeLv.Columns.Count - 1
    '                            tempItem = itemA.SubItems.Item(j)
    '                            itemA.SubItems.Item(j) = itemB.SubItems.Item(j)
    '                            itemB.SubItems.Item(j) = tempItem
    '                        Next
    '                    End If
    '                Next
    '            Loop While found
    '        End If
    '    End With
    'End Sub

    Private Sub WriteListViewRow(ByRef lv As ListView, ByVal opList() As Object, Optional ByVal opType As String = Nothing)
        'Precondition:  Passed listview is initialized
        '               Passed array is zero based
        'Postcondition: row added to listview and filled with values from the operation array
        '               Listview sorted

        Dim listItem As ListViewItem
        ReDim Preserve opList(lv.Columns.Count - 1)

        listItem = lv.Items.Add(opList(0))

        With listItem
            .SubItems.Add(opList(1))

            If Trim(opType) <> Nothing Then .SubItems.Add(opType)

            For i As Integer = 2 To UBound(opList)
                If IsNumeric(opList(i)) Then
                    .SubItems.Add(opList(i))
                ElseIf opList(i) <> Nothing Then
                    .SubItems.Add(CStr(opList(i)))
                Else
                    .SubItems.Add("")
                End If
            Next

            .ImageIndex = 0
            .BackColor = Me.colorActive
        End With

        'sort
        Call Me.SortListView(lv)
    End Sub

    Private Sub ReadFormOperations(ByVal ctlList() As Control, ByRef opList() As Object)
        'Precondition:  Passed control array contains at least on control
        'Postcondition: Operations array is assigned the text values from the passed controls

        Dim i As Integer = 0
        ReDim opList(UBound(ctlList))

        For Each ctl As Control In ctlList
            If ctl.Text <> Nothing Then
                opList(i) = ctl.Text
            Else
                opList(i) = ""
            End If

            i += 1
        Next
    End Sub

    Private Sub WriteFormOperations(ByRef ctlList() As Control, ByVal opList() As Object)
        'Precondition:  Passed control array contains at least on control
        '               Control and operations arrays are the same size
        'Postcondition: Control's text is assigned values from the operation array

        Dim i As Integer = 0
        'ReDim Preserve opList(UBound(ctlList, Rank:=1)) 'resize list

        For Each ctl As Control In ctlList
            If opList(i) <> Nothing Then
                ctl.Text = opList(i)
            Else
                ctl.Text = Nothing
            End If

            If i < UBound(opList) Then
                i += 1
            Else
                Exit For
            End If
        Next
    End Sub

    Private Sub ClearFormOperations(ByRef ctlList() As Control)
        'Precondition:  Passed control array contains at least on control
        'Postcondition: Control text fields are cleared

        For Each ctl As Control In ctlList
            ctl.Text = Nothing
        Next
    End Sub

    Private Sub InitializeCropDescription()
        'Precondition:  none
        'Postcondition: crop data stored
        '               croplist field lists available crops

        Dim Crop As New DefaultCrops

        ReDim Me.cropList(Crop.MAX_CROPS, totalCropFields)

        For cropNum As Integer = 2 To UBound(Me.cropList, Rank:=1)
            Me.cropList(cropNum - 1, 1) = Crop.srcCropName(cropNum)
            Me.cropList(cropNum - 1, 2) = Nothing
            Me.cropList(cropNum - 1, 3) = Nothing
            Me.cropList(cropNum - 1, 4) = Nothing
            Me.cropList(cropNum - 1, 5) = Nothing
            Me.cropList(cropNum - 1, 6) = Nothing
            Me.cropList(cropNum - 1, 7) = Nothing
            Me.cropList(cropNum - 1, 8) = Nothing
            Me.cropList(cropNum - 1, 9) = Nothing
            Me.cropList(cropNum - 1, 10) = Nothing
            Me.cropList(cropNum - 1, 11) = Nothing
            Me.cropList(cropNum - 1, 12) = Nothing
            Me.cropList(cropNum - 1, 13) = Nothing
            Me.cropList(cropNum - 1, 14) = Crop.srcTranspirationMinTemperature(cropNum)
            Me.cropList(cropNum - 1, 15) = Crop.srcTranspirationThresholdTemperature(cropNum)
            Me.cropList(cropNum - 1, 16) = Crop.srcColdDamageMinTemperature(cropNum)
            Me.cropList(cropNum - 1, 17) = Crop.srcColdDamageThresholdTemperature(cropNum)
            Me.cropList(cropNum - 1, 18) = Crop.srcTemperatureBase(cropNum)
            Me.cropList(cropNum - 1, 19) = Crop.srcTemperatureOptimum(cropNum)
            Me.cropList(cropNum - 1, 20) = Crop.srcTemperatureMaximum(cropNum)
            Me.cropList(cropNum - 1, 21) = Crop.srcShootPartitionInitial(cropNum)
            Me.cropList(cropNum - 1, 22) = Crop.srcShootPartitionFinal(cropNum)
            Me.cropList(cropNum - 1, 23) = Crop.srcRadiationUseEfficiency(cropNum)
            Me.cropList(cropNum - 1, 24) = Crop.srcTranspirationUseEfficiency(cropNum)
            Me.cropList(cropNum - 1, 25) = Crop.srcHIx(cropNum)
            Me.cropList(cropNum - 1, 26) = Crop.srcHIo(cropNum)
            Me.cropList(cropNum - 1, 27) = Crop.srcHIk(cropNum)
            Me.cropList(cropNum - 1, 28) = Crop.srcEmergenceTT(cropNum)
            Me.cropList(cropNum - 1, 29) = Crop.srcNMaxConcentration(cropNum)
            Me.cropList(cropNum - 1, 30) = Crop.srcNDilutionSlope(cropNum)
            Me.cropList(cropNum - 1, 31) = Crop.srcKc(cropNum)
            Me.cropList(cropNum - 1, 32) = Crop.srcAnnualOrPerennial(cropNum)
            Me.cropList(cropNum - 1, 33) = Crop.srcLegume(cropNum)
            Me.cropList(cropNum - 1, 34) = Crop.srcC3orC4(cropNum)
        Next

        Call Me.PopulateUndescribedCropsList()
        Crop = Nothing
    End Sub

    Private Sub CalendarPopup(ByRef monthDay As Object, ByRef rotYear As Integer, Optional ByVal defaultDay As Object = 1)
        'Precondition:  startYear, stopYear, and roationSize must have been assigned
        'Postcondition: Returns date selected by the user

        If Me.duration_RotationSize.Text.Trim <> Nothing Then
            Dim calForm As New Form
            Dim cal As New MonthCalendar

            If defaultDay <> Nothing Then
                defaultDay = SideSubs.ConvertToDate(defaultDay)
            Else
                defaultDay = "Jan 1"
            End If

            If rotYear > 0 Then rotYear -= 1

            With cal
                .MaxSelectionCount = 1
                .MinDate = "1/1/" & Me.duration_StartYear.Text
                .MaxDate = "12/31/" & (CInt(Me.duration_StartYear.Text) + CInt(Me.duration_RotationSize.Text) - 1)
                If monthDay <> Nothing Then
                    .SelectionStart = SideSubs.ConvertToDate(monthDay) & " " & CInt(Me.duration_StartYear.Text) + rotYear
                Else
                    .SelectionStart = defaultDay & " " & CInt(Me.duration_StartYear.Text) + rotYear
                End If
                .ShowToday = False
                .ScrollChange = 1
            End With

            With calForm
                .Text = "Date Selection"
                .Controls.Add(cal)
                .ClientSize = cal.Size
                '.Height += 24
                .MinimizeBox = False
                .MaximizeBox = False
                .MinimumSize = calForm.Size
                .MaximumSize = calForm.Size
                .ShowDialog()
            End With

            monthDay = SideSubs.ConvertToDOY(cal.SelectionStart.ToString("M"))
            rotYear = Strings.Right(cal.SelectionStart.ToString("Y"), 4) - CInt(Me.duration_StartYear.Text) + 1

            calForm.Close()
            calForm.Dispose()
            calForm = Nothing
            cal.Dispose()
            cal = Nothing
        End If
    End Sub

    Private Function RequiredEntriesFilled(ByRef field As String) As Boolean
        Dim found As Boolean = False

        If Me.weatherFile_Path.Text.Trim = Nothing Then
            field = "Weather File"
            Return False

        ElseIf Me.duration_StartYear.Text.Trim = Nothing Then
            field = "Simulation Start Year"
            Return False

        ElseIf Me.duration_StopYear.Text.Trim = Nothing Then
            field = "Simulation End Year"
            Return False

        ElseIf Me.duration_RotationSize.Text.Trim = Nothing Then
            field = "Rotation Size"
            Return False

        ElseIf Me.soil_maxLayer.Text.Trim = Nothing Then
            field = "Maximum Layer"
            Return False

        ElseIf Me.soil_curve.Text.Trim = Nothing Then
            field = "Soil: Curve"
            Return False

        ElseIf Me.soil_slope.Text.Trim = Nothing Then
            field = "Soil: Slope"
            Return False
        End If

        If Me.soil_maxLayer.Text >= 1 Then
            For i As Integer = 1 To Me.soil_maxLayer.Text
                If Me.ctlLayerThickness(i).Text.Trim = Nothing Then
                    field = "Soil: Layer Thickness - Layer " & i
                    Return False

                ElseIf Me.ctlClay(i).Text.Trim = Nothing Then
                    field = "Soil: Clay - Layer " & i
                    Return False

                ElseIf Me.ctlSand(i).Text.Trim = Nothing Then
                    field = "Soil: Sand - Layer " & i
                    Return False

                ElseIf Me.ctlIOM(i).Text.Trim = Nothing Then
                    field = "Soil: Organic Matter - Layer " & i
                    Return False

                ElseIf Me.ctlNO3(i).Text.Trim = Nothing Then
                    field = "Soil: Nitrogen - Layer " & i
                    Return False

                ElseIf Me.ctlNH4(i).Text.Trim = Nothing Then
                    field = "Soil: Ammonium - Layer " & i
                    Return False

                ElseIf Me.Manual_BD_ckbx.Checked And Me.ctlBD(i).Text.Trim = Nothing Then
                    field = "Soil: Bulk Density - Layer " & i
                    Return False

                ElseIf Me.Manual_FC_ckbx.Checked And Me.ctlFC(i).Text.Trim = Nothing Then
                    field = "Soil: Field Capacity - Layer " & i
                    Return False

                ElseIf Me.Manual_PWP_ckbx.Checked And Me.ctlPWP(i).Text.Trim = Nothing Then
                    field = "Soil: Permanent Wilting Point - Layer " & i
                    Return False

                End If

                If Me.ctlLayerBtn(i).Checked Then
                    found = True
                    Exit For
                End If
            Next

            If Not found Then
                field = "Soil: Layer Selection"
                Return False
            End If
        End If

        'For Each plantedCrop As ListViewItem In Me.lv_PlantedCrops.Items
        '    found = False

        '    For Each describedCrop As ListViewItem In Me.lv_DescribedCrops.Items
        '        If plantedCrop.Text = describedCrop.Text Then
        '            found = True
        '            Exit For
        '        End If
        '    Next

        '    If Not found Then
        '        field = "Planting Order: " & plantedCrop.Text
        '        Return False
        '    End If
        'Next

        Return True
    End Function

    Private Function ActiveListviewOperations(ByVal lv As ListView) As String
        Dim cnt As Integer = 0

        For Each listItem As ListViewItem In lv.Items
            If listItem.BackColor = Me.colorActive Then cnt += 1
        Next

        Return "Active Operations: " & cnt
    End Function

    Private Function ReadFocusedListViewRow(ByRef listItem As ListViewItem, ByRef opList() As Object) As Boolean
        'Precondition:  Passed listview is initialized
        '               Passed array is zero based
        'Postcondition: Operation array set to number of columns in the listview
        '               Operation array assigned values from the selected row in the listview

        Dim i As Integer = 0

        If listItem IsNot Nothing Then
            ReDim opList(listItem.SubItems.Count - 1)

            'copy operation
            For Each subItem As ListViewItem.ListViewSubItem In listItem.SubItems
                If subItem.Text <> Nothing Then
                    opList(i) = subItem.Text
                Else
                    opList(i) = ""
                End If

                i += 1
            Next

            Return True
        Else
            Return False
        End If
    End Function

    Private Function YearlyTotalOperations(ByVal lv As ListView, ByVal year As Integer) As Integer
        'Precondition:  Passed listview is initialized
        'Postcondition: Returns number of times year was found in the listview

        Dim total As Integer = 0 - 1
        Dim lvi As ListViewItem

        For Each lvi In lv.Items
            If lvi.Text = year Then total += 1
        Next

        Return total
    End Function

End Class