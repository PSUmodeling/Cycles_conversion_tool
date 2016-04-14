Partial Friend Class MainForm
    Private Const irrType As String = "Fixed Irrigation"
    Private Const tillType As String = "Tillage"
    Private Const fertType As String = "Fertilization"
    Private Const cropType As String = "Planting"

    '====================================== Crop: Descriptions =====================================
    Private Sub btn_AddDescribedCrop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_AddDescribedCrop.Click
        'Precondition:  cropDescripTxtBox array has been initialized
        '               crop listview has been initialized
        'Postcondition: adds described crop to list, removes description from described area, and updates rotation boxes

        Dim ctlList(UBound(ctlCropDescrip) - 1) As Control
        Dim opList() As Object = Nothing

        'copy to zero based array
        For i As Integer = 0 To UBound(ctlList)
            ctlList(i) = ctlCropDescrip(i + 1)
        Next

        'read operation
        Call Me.ReadFormOperations(ctlList, opList)

        'check that mandatory fields contain no blanks
        For i As Integer = 0 To UBound(opList)
            If i <> 12 Then ' skip harvest timing, optional field 
                If opList(i).Trim = Nothing Then
                    Exit Sub
                End If
            End If
        Next

        If Not Me.IsCropDescribed(opList(0)) Then
            Call Me.SetupToList(sender, Me.lv_DescribedCrops, opList, ctlList)
        Else
            MsgBox("Crop already described." & vbCr & "Unable to add " & Me.CropDescrip1.Text & ".", MsgBoxStyle.Information, Me.ProductName)
        End If
    End Sub
    Private Sub btn_ChangeDescribedCrop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ChangeDescribedCrop.Click
        'Precondition:  cropDescripTxtBox is initialized
        'Postcondition: removes selected item from list, adds it to described area, and updates rotation boxes

        Dim ctlList(UBound(ctlCropDescrip) - 1) As Control

        For i As Integer = 0 To UBound(ctlList)
            ctlList(i) = ctlCropDescrip(i + 1)
        Next

        Call Me.ListToSetup(sender, Me.lv_DescribedCrops, ctlList)
    End Sub

    Private Sub CropDescrip1_SelectedIndexChanged() Handles CropDescrip1.SelectedIndexChanged, CropDescrip1.TextChanged
        'Precondition:  all cropDescription fields exist
        'Postcondition: field enabled state and default values are set

        Dim state As Boolean

        'sets enabled state for fields
        If Trim(Me.CropDescrip1.Text) <> Nothing Then
            state = True
        Else
            state = False
        End If

        For i As Integer = 2 To 13
            ctlCropDescrip(i).Enabled = state
        Next

        Me.Chkbx_UseAdvancedDescrip.Checked = False

        'fills fields with crop specific default values
        For i As Integer = 0 To UBound(cropList, Rank:=1)
            If Me.CropDescrip1.Text = cropList(i, 1) Then
                For j As Integer = 14 To UBound(ctlCropDescripLabel)
                    ctlCropDescrip(j).Text = cropList(i, j)
                Next

                Exit For
            End If
        Next
    End Sub

    Private Sub Cbox_UseAdvancedDescrip_CheckedChanged() Handles Chkbx_UseAdvancedDescrip.CheckedChanged
        'Precondition:  advanced crop fields must exist
        'Postcondition: enabled status set

        Dim state As Boolean

        If Trim(Me.CropDescrip1.Text) <> Nothing Then
            state = Me.Chkbx_UseAdvancedDescrip.Checked
        Else
            state = False
        End If

        For i As Integer = 14 To (UBound(Me.ctlCropDescrip))
            Me.ctlCropDescrip(i).Enabled = state
        Next
    End Sub

    Private Sub UpdateDescribedCropsComboBoxes()
        'Precondition:  rotationCbox has been initialized
        'Postcondition: rotation list combo boxes match table

        With Me.plantingSetup_cropName.Items
            .Clear()
            .Add("")

            For Each lvi As ListViewItem In Me.lv_DescribedCrops.Items
                .Add(lvi.Text)
            Next
        End With

        Call Me.IrrigationPlantAvailableListChanged()
        Call Me.FertilizationPlantAvailableListChanged()
    End Sub

    Private Sub AddToUndescribedCropList(ByVal cropName As String)
        'Precondition:  croplist is already populated
        'Postcondition: cropName added to available crop list in appropriate position

        Dim tempArray(Me.CropDescrip1.Items.Count) As String
        Dim c As Integer = 0
        Dim found As Boolean

        With Me.CropDescrip1.Items
            'copy available crops to temporary array
            For i As Integer = 0 To (.Count - 1)
                tempArray(i) = .Item(i)
            Next

            'copy added crop to temporary array
            tempArray(.Count) = cropName

            'copy master list to available crops list
            Call Me.PopulateUndescribedCropsList()

            'remove from available crops list all crops not in the temporary list
            Do
                found = False

                For Each item As String In tempArray
                    If .Item(c) = item Then
                        found = True
                        Exit For
                    End If
                Next

                If Not found Then
                    .Remove(.Item(c))
                Else
                    c += 1
                End If
            Loop Until c >= .Count
        End With
    End Sub
    Private Sub RemoveFromUndescribedCropList(ByVal cropName As String)
        'Precondition:  none
        'Postcondition: Removes passed crop name from list of available crops to be described

        With Me.CropDescrip1.Items
            If .Contains(cropName) Then .Remove(cropName)
        End With
    End Sub
    Private Sub PopulateUndescribedCropsList()
        'Precondition:  none
        'Postcondition: Resets crops available list to default state with all crops listed

        With Me.CropDescrip1.Items
            .Clear()
            .Add("")

            For i As Integer = 1 To (UBound(Me.cropList, Rank:=1) - 1)
                .Add(Me.cropList(i, 1))
            Next
        End With
    End Sub

    Private Function IsCropDescribed(ByVal cropName As String) As Boolean
        'Precondition:  none
        'Postcondition: returns existence of cropName in described list

        Dim lv As ListView = Me.lv_DescribedCrops
        Dim lvi As ListViewItem

        For Each lvi In lv.Items
            If lvi.Text = cropName Then Return True
        Next

        Return False
    End Function

    Private Sub CropDescrip2MonthDaySelection(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CropDescrip2.DoubleClick
        Me.CalendarPopup(sender.Text, Nothing)
    End Sub
    Private Sub CropDescrip3MonthDaySelection(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CropDescrip3.DoubleClick
        Me.CalendarPopup(sender.Text, Nothing, CropDescrip2.Text.Trim)
    End Sub
    Private Sub CropDescrip4MonthDaySelection(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CropDescrip4.DoubleClick
        Me.CalendarPopup(sender.Text, Nothing, CropDescrip3.Text.Trim)
    End Sub

    '====================================== Planting Order =========================================
    Private Sub btn_AddPlantingEvent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_AddPlantingEvent.Click
        'Precondition:  none
        'Postcondition: user fields read, initially error checked, and written to the listview

        Dim ctlList() As Control = {Me.plantingSetup_Year, Me.plantingSetup_Day, Me.plantingSetup_cropName}
        Dim opList() As Object = Nothing

        If Me.plantingSetup_Day.Text = Nothing Then Me.plantingSetup_Day.Text = Me.plantingSetup_defaultDay.Text

        If Me.plantingSetup_Day.Text.Trim = Nothing Then      'check if default value used
            Me.plantingSetup_Day.Text = Me.plantingSetup_DefaultDay.Text
        End If

        Call Me.ReadFormOperations(ctlList, opList)                 'read operation
        ReDim Preserve opList(4)

        opList(3) = Me.plantingSetup_AutoIrr.Checked
        opList(4) = Me.plantingSetup_AutoFert.Checked

        For i As Integer = 3 To 4
            If opList(i) = True Then
                opList(i) = "True"
            Else
                opList(i) = ""
            End If
        Next

        If Trim(opList(0)) <> Nothing And Trim(opList(1)) <> Nothing And Trim(opList(2)) <> Nothing Then
            If IsNumeric(opList(0)) And IsNumeric(opList(1)) Then
                Call Me.SetupToList(sender, Me.lv_PlantedCrops, opList, ctlList)
            End If
        Else
            MsgBox("Unable to add operation to list. Please verify operation is correct.", MsgBoxStyle.Information, Me.ProductName)
        End If
    End Sub
    Private Sub btn_ChangePlantingEvent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ChangePlantingEvent.Click
        'Precondition:  none
        'Postcondition: selected row is written to the setup fields and deleted from the listview

        Dim ctlList() As Control = {Me.plantingSetup_Year, Me.plantingSetup_Day, Me.plantingSetup_cropName}

        Call Me.ListToSetup(sender, Me.lv_PlantedCrops, ctlList)
    End Sub

    Private Sub plantingSetup_cropName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles plantingSetup_cropName.SelectedIndexChanged, plantingSetup_cropName.SelectedValueChanged
        'Precondition:  listed crops match exactly the described crops listview
        'Postcondition: selected crop's user described planting day copied to the setup area default day field

        If sender.text = Nothing Then
            Me.plantingSetup_DefaultDay.Text = Nothing
            Me.plantingSetup_labelDefaultDay.Visible = False
        Else
            Me.plantingSetup_labelDefaultDay.Visible = True
            For Each listItem As ListViewItem In Me.lv_DescribedCrops.Items
                If listItem.Text = sender.text Then
                    Me.plantingSetup_DefaultDay.Text = listItem.SubItems.Item(1).Text
                    Exit For
                End If
            Next
        End If
    End Sub

    Private Sub plantingSetup_Year_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles plantingSetup_Year.DoubleClick
        Dim yr As Integer

        If plantingSetup_Year.Text.Trim <> Nothing Then
            yr = plantingSetup_Year.Text
        Else
            yr = 0
        End If

        Me.CalendarPopup(plantingSetup_Day.Text, yr)

        If yr > 0 Then plantingSetup_Year.Text = yr
    End Sub
    Private Sub plantingSetup_Day_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles plantingSetup_Day.DoubleClick
        Dim yr As Integer

        If plantingSetup_Year.Text.Trim <> Nothing Then
            yr = plantingSetup_Year.Text
        Else
            yr = 0
        End If

        Me.CalendarPopup(plantingSetup_Day.Text, yr, plantingSetup_DefaultDay.Text.Trim)

        If yr > 0 Then plantingSetup_Year.Text = yr
    End Sub

    '====================================== Tillage ================================================
    Private Sub btn_AddTillageOp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_AddTillageOp.Click
        'Precondition:  none
        'Postcondition: user fields read, initially error checked, and written to the listview

        Dim ctlList() As Control = {Me.tillSetup_Year, Me.tillSetup_Day, Me.tillSetup_Tool, Me.tillSetup_Depth, Me.tillSetup_SDR, Me.tillSetup_ME}
        Dim opList() As Object = Nothing

        If Me.tillSetup_Depth.Text.Trim = Nothing Then             'check if default value used
            Me.tillSetup_Depth.Text = Format(CDbl(Me.tillSetup_defaultDepth.Text.Trim), "0.00")
        End If
        If Me.tillSetup_SDR.Text.Trim = Nothing Then                'check if default value used
            Me.tillSetup_SDR.Text = CInt(Me.tillSetup_defaultSDR.Text.Trim)
        End If
        If Me.tillSetup_ME.Text.Trim = Nothing Then                 'check if default value used
            Me.tillSetup_ME.Text = Format(CDbl(Me.tillSetup_defaultME.Text.Trim), "0.000000")
        End If

        Call Me.ReadFormOperations(ctlList, opList)                 'read operation

        If Trim(opList(0)) <> Nothing And Trim(opList(1)) <> Nothing And Trim(opList(2)) <> Nothing Then
            If IsNumeric(opList(0)) And IsNumeric(opList(1)) Then
                Call Me.SetupToList(sender, Me.lv_Tillage, opList, ctlList)
            Else
                MsgBox("Unable to add operation to list. Please verify operation is correct.", MsgBoxStyle.Information, Me.ProductName)
            End If
        End If
    End Sub
    Private Sub btn_ChangeTillOp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ChangeTillageOp.Click
        'Precondition:  none
        'Postcondition: selected row is written to the setup fields and deleted from the listview

        Dim ctlList() As Control = {Me.tillSetup_Year, Me.tillSetup_Day, Me.tillSetup_Tool, Me.tillSetup_Depth, Me.tillSetup_SDR, Me.tillSetup_ME}

        Call Me.ListToSetup(sender, Me.lv_Tillage, ctlList)
    End Sub

    Private Sub tillSetup_PerformOperations_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tillSetup_PerformOperations.CheckedChanged
        'Precondition:  none
        'Postcondition: All fields enabled status changed to senders value
        '               Listed operations on the listview added or removed as needed

        Me.grp_Tillage.Enabled = sender.Checked
        Me.grp_TillSetup.Enabled = sender.Checked
        Me.btn_AddTillageOp.Enabled = sender.Checked
        Me.btn_ChangeTillageOp.Enabled = sender.Checked

        Call Me.PerformOperationsStatusChanged(Me.lv_Tillage, tillType, sender.checked)
    End Sub

    Private Sub tillSetup_Tool_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tillSetup_Tool.SelectedIndexChanged, tillSetup_Tool.SelectedValueChanged
        'Precondition:  tillageList previously populated
        'Postcondition: default depth for that tool copied to the defaultDepth field

        If sender.text = Nothing Then
            Me.tillSetup_labelDefaultDepth.Visible = False
            Me.tillSetup_defaultDepth.Text = Nothing
            Me.tillSetup_defaultSDR.Text = Nothing
            Me.tillSetup_defaultME.Text = Nothing
        Else
            For i As Integer = 0 To TillageOps.maxTools
                If sender.Text = TillageOps.listToolName(i) Then
                    Me.tillSetup_labelDefaultDepth.Visible = True
                    Me.tillSetup_Depth.Text = Nothing
                    Me.tillSetup_defaultDepth.Text = TillageOps.listDefaultDepth(i)
                    Me.tillSetup_defaultSDR.Text = TillageOps.listSoilDisturbanceRating(i)
                    Me.tillSetup_defaultME.Text = TillageOps.listMixingEfficiency(i)
                    Exit For
                End If
            Next
        End If
    End Sub

    Private Sub tillSetup_Year_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tillSetup_Year.DoubleClick
        Dim yr As Integer

        If tillSetup_Year.Text.Trim <> Nothing Then
            yr = tillSetup_Year.Text
        Else
            yr = 0
        End If

        Me.CalendarPopup(tillSetup_Day.Text, yr)

        If yr > 0 Then tillSetup_Year.Text = yr
    End Sub
    Private Sub tillSetup_Day_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tillSetup_Day.DoubleClick
        Dim yr As Integer

        If tillSetup_Year.Text.Trim <> Nothing Then
            yr = tillSetup_Year.Text
        Else
            yr = 0
        End If

        Me.CalendarPopup(tillSetup_Day.Text, yr)

        If yr > 0 Then tillSetup_Year.Text = yr
    End Sub

    '====================================== Fixed Irrigation =======================================
    Private Sub btn_AddFixedIrrOp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_AddFixedIrrOp.Click
        'Precondition:  none
        'Postcondition: user fields read, initially error checked, and written to the listview

        Dim ctlList() As Control = {Me.fixedIrrSetup_Year, Me.fixedIrrSetup_Day, Me.fixedIrrSetup_Volume}
        Dim opList() As Object = Nothing

        Me.ReadFormOperations(ctlList, opList)             'read operation
        opList(1) = SideSubs.ConvertToDOY(opList(1))

        If Trim(opList(0)) <> Nothing And Trim(opList(1)) <> Nothing And Trim(opList(2)) <> Nothing Then
            If IsNumeric(opList(0)) And IsNumeric(opList(1)) And IsNumeric(opList(2)) Then
                Me.SetupToList(sender, Me.lv_FixedIrrigation, opList, ctlList)
            Else
                MsgBox("Unable to add operation to list. Please verify operation is correct.", MsgBoxStyle.Information, Me.ProductName)
            End If
        End If
    End Sub
    Private Sub btn_ChangeFixedIrrOp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ChangeFixedIrrOp.Click
        'Precondition:  none
        'Postcondition: selected row is written to the setup fields and deleted from the listview

        Dim ctlList() As Control = {Me.fixedIrrSetup_Year, Me.fixedIrrSetup_Day, Me.fixedIrrSetup_Volume}

        Call Me.ListToSetup(sender, Me.lv_FixedIrrigation, ctlList)

        If IsNumeric(ctlList(1).Text) Then
            ctlList(1).Text = SideSubs.ConvertToDate(ctlList(1).Text)
        End If
    End Sub

    Private Sub fixedIrrSetup_PerformOperations_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fixedIrrSetup_PerformOperations.CheckedChanged
        'Precondition:  none
        'Postcondition: All fields enabled status changed to senders value
        '               Listed operations on the listview added or removed as needed

        Me.grp_fixedIrrSetup.Enabled = sender.Checked
        Me.grp_FixedIrrigation.Enabled = sender.Checked
        Me.btn_AddFixedIrrOp.Enabled = sender.Checked
        Me.btn_ChangeFixedIrrOp.Enabled = sender.Checked

        Call Me.PerformOperationsStatusChanged(Me.lv_FixedIrrigation, irrType, sender.checked)
    End Sub

    Private Sub fixedIrrSetup_Year_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fixedIrrSetup_Year.DoubleClick
        Dim yr As Integer

        If fixedIrrSetup_Year.Text.Trim <> Nothing Then
            yr = fixedIrrSetup_Year.Text
        Else
            yr = 0
        End If

        Me.CalendarPopup(fixedIrrSetup_Day.Text, yr)

        If yr > 0 Then fixedIrrSetup_Year.Text = yr
    End Sub
    Private Sub fixedIrrSetup_Day_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fixedIrrSetup_Day.DoubleClick
        Dim yr As Integer

        If fixedIrrSetup_Year.Text.Trim <> Nothing Then
            yr = fixedIrrSetup_Year.Text
        Else
            yr = 0
        End If

        Me.CalendarPopup(fixedIrrSetup_Day.Text, yr)

        If yr > 0 Then fixedIrrSetup_Year.Text = yr
    End Sub

    '====================================== Automatic Irrigation ===================================
    Private Sub btn_AddAutoIrrOp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_AddAutoIrrOp.Click
        'Precondition:  none
        'Postcondition: user fields read, initially error checked, and written to the listview

        Dim ctlList() As Control = {Me.autoIrrSetup_Name, Me.autoIrrSetup_StartDay, Me.autoIrrSetup_StopDay, Me.autoIrrSetup_WaterDepletion, Me.autoIrrSetup_LastSoilLayer}
        Dim opList() As Object = Nothing

        If Me.autoIrrSetup_StartDay.Text.Trim = Nothing Then        'check if default value used
            Me.autoIrrSetup_StartDay.Text = Me.autoIrrSetup_DefaultStartDay.Text.Trim
        End If
        If Me.autoIrrSetup_StopDay.Text.Trim = Nothing Then         'check if default value used
            Me.autoIrrSetup_StopDay.Text = Me.autoIrrSetup_DefaultEndDay.Text.Trim
        End If

        Call Me.ReadFormOperations(ctlList, opList)                 'read operation

        If Trim(opList(0)) <> Nothing And Trim(opList(1)) <> Nothing And Trim(opList(2)) <> Nothing And Trim(opList(3)) <> Nothing And Trim(opList(4)) <> Nothing Then
            If IsNumeric(opList(1)) And IsNumeric(opList(2)) And IsNumeric(opList(3)) And IsNumeric(opList(4)) Then
                Call Me.SetupToList(sender, Me.lv_AutomaticIrrigation, opList, ctlList)
            Else
                MsgBox("Unable to add operation to list. Please verify operation is correct.", MsgBoxStyle.Information, "C-Farm")
            End If
        End If
    End Sub
    Private Sub btn_ChangeAutoIrrOp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ChangeAutoIrrOp.Click
        'Precondition:  none
        'Postcondition: selected row is written to the setup fields and deleted from the listview

        Dim ctlList() As Control = {Me.autoIrrSetup_Name, Me.autoIrrSetup_StartDay, Me.autoIrrSetup_StopDay, Me.autoIrrSetup_WaterDepletion, Me.autoIrrSetup_LastSoilLayer}

        Call Me.ListToSetup(sender, Me.lv_AutomaticIrrigation, ctlList)
    End Sub

    Private Sub autoIrrSetup_PerformOperations_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles autoIrrSetup_PerformOperations.CheckedChanged
        'Precondition:  none
        'Postcondition: All fields enabled status changed to senders value

        Me.grp_AutoIrrSetup.Enabled = sender.Checked
        Me.grp_AutomaticIrrigation.Enabled = sender.Checked
        Me.btn_AddAutoIrrOp.Enabled = sender.Checked
        Me.btn_ChangeAutoIrrOp.Enabled = sender.Checked
    End Sub

    Private Sub autoIrrSetup_Name_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles autoIrrSetup_Name.SelectedIndexChanged, autoIrrSetup_Name.SelectedValueChanged
        'Precondition:  listed crops match exactly the described crops listview
        'Postcondition: selected crop's user described planting date copied to the setup area default start day field
        '               selected crop's user described maturity date copied to the setup area default end day field

        If sender.text.trim = Nothing Then
            Me.autoIrrSetup_DefaultStartDay.Text = Nothing
            Me.autoIrrSetup_DefaultEndDay.Text = Nothing
            Me.autoIrrSetup_labelDefaultStartDay.Visible = False
            Me.autoIrrSetup_labelDefaultEndDay.Visible = False
        Else
            Me.autoIrrSetup_labelDefaultStartDay.Visible = True
            Me.autoIrrSetup_labelDefaultEndDay.Visible = True

            For Each listItem As ListViewItem In Me.lv_DescribedCrops.Items
                If listItem.Text = sender.text Then
                    Me.autoIrrSetup_DefaultStartDay.Text = listItem.SubItems.Item(1).Text
                    Me.autoIrrSetup_DefaultEndDay.Text = listItem.SubItems.Item(3).Text
                    Exit For
                End If
            Next
        End If
    End Sub

    Private Sub IrrigationPlantAvailableListChanged()
        'Precondition:  none
        'Postcondition: crops that are described and have no automatic parameters are listed

        Dim listItem As ListViewItem

        With Me.autoIrrSetup_Name.Items
            'delete available list
            .Clear()
            .Add("")

            'copy described crops list
            For Each listItem In Me.lv_DescribedCrops.Items
                .Add(listItem.Text)
            Next

            'delete used crops
            For Each listItem In Me.lv_AutomaticIrrigation.Items
                If .Contains(listItem.Text) And Not listItem.Text = "" Then
                    .Remove(listItem.Text)
                End If
            Next
        End With
    End Sub

    Private Sub autoIrrSetup_StartDay_DoubleClick() Handles autoIrrSetup_StartDay.DoubleClick
        Me.CalendarPopup(autoIrrSetup_StartDay.Text, Nothing, autoIrrSetup_DefaultStartDay.Text)
    End Sub
    Private Sub autoIrrSetup_StopDay_DoubleClick() Handles autoIrrSetup_StopDay.DoubleClick
        Me.CalendarPopup(autoIrrSetup_StopDay.Text, Nothing, autoIrrSetup_DefaultEndDay.Text)
    End Sub

    '====================================== Fixed Fertilization ====================================
    Private Sub btn_AddFixedFertOp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_AddFixedFertOp.Click
        'Precondition:  none
        'Postcondition: user fields read, initially error checked, and written to the listview

        Dim ctlList() As Control = {Me.fixedFertSetup_Year, Me.fixedFertSetup_Day, Me.fixedFertSetup_Source, Me.fixedFertSetup_Mass, _
                                    Me.fixedFertSetup_Form, Me.fixedFertSetup_Method, Me.fixedFertSetup_Layer, Me.fixedFertSetup_C_Organic, _
                                    Me.fixedFertSetup_C_Charcoal, Me.fixedFertSetup_N_Organic, Me.fixedFertSetup_N_Charcoal, _
                                    Me.fixedFertSetup_N_NH4, Me.fixedFertSetup_N_NO3, Me.fixedFertSetup_P_Organic, Me.fixedFertSetup_P_Charcoal, _
                                    Me.fixedFertSetup_P_Inorganic, Me.fixedFertSetup_K, Me.fixedFertSetup_S}
        Dim opList() As Object = Nothing

        Call Me.ReadFormOperations(ctlList, opList)                 'read operation

        If Trim(opList(0)) <> Nothing And Trim(opList(1)) <> Nothing And Trim(opList(2)) <> Nothing And _
                Trim(opList(3)) <> Nothing And Trim(opList(4)) <> Nothing And Trim(opList(5)) <> Nothing Then
            Call Me.SetupToList(sender, Me.lv_FixedFertilization, opList, ctlList)
        Else
            MsgBox("Unable to add operation to list. Please verify operation is correct.", MsgBoxStyle.Information, Me.ProductName)
        End If
    End Sub
    Private Sub btn_ChangeFixedFertOp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ChangeFixedFertOp.Click
        'Precondition:  none
        'Postcondition: selected row is written to the setup fields and deleted from the listview

        Dim ctlList() As Control = {Me.fixedFertSetup_Year, Me.fixedFertSetup_Day, Me.fixedFertSetup_Source, Me.fixedFertSetup_Mass, _
                                    Me.fixedFertSetup_Form, Me.fixedFertSetup_Method, Me.fixedFertSetup_Layer, Me.fixedFertSetup_C_Organic, _
                                    Me.fixedFertSetup_C_Charcoal, Me.fixedFertSetup_N_Organic, Me.fixedFertSetup_N_Charcoal, _
                                    Me.fixedFertSetup_N_NH4, Me.fixedFertSetup_N_NO3, Me.fixedFertSetup_P_Organic, Me.fixedFertSetup_P_Charcoal, _
                                    Me.fixedFertSetup_P_Inorganic, Me.fixedFertSetup_K, Me.fixedFertSetup_S}

        Call Me.ListToSetup(sender, Me.lv_FixedFertilization, ctlList)
    End Sub

    Private Sub fixedFertSetup_PerformOperations_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fixedFertSetup_PerformOperations.CheckedChanged
        'Precondition:  none
        'Postcondition: All fields enabled status changed to senders value
        '               Listed operations on the listview added or removed as needed

        Me.grp_FixedFertilization.Enabled = sender.Checked
        Me.grp_FixedFertSetup.Enabled = sender.Checked
        Me.btn_AddFixedFertOp.Enabled = sender.Checked
        Me.btn_ChangeFixedFertOp.Enabled = sender.Checked

        Call Me.PerformOperationsStatusChanged(Me.lv_FixedFertilization, fertType, sender.checked)
    End Sub

    Private Sub fixedFertSetup_Tool_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fixedFertSetup_Source.SelectedIndexChanged, fixedFertSetup_Source.SelectedValueChanged
        'Precondition:  fertilizationList previously populated
        'Postcondition: default values for that operation copied to fields

        If sender.text = Nothing Then
            Me.fixedFertSetup_Mass.Text = Nothing
            Me.fixedFertSetup_Form.Text = Nothing
            Me.fixedFertSetup_Method.Text = Nothing
            Me.fixedFertSetup_Layer.Text = Nothing

            Me.fixedFertSetup_C_Organic.Text = Nothing
            Me.fixedFertSetup_C_Charcoal.Text = Nothing
            Me.fixedFertSetup_N_Organic.Text = Nothing
            Me.fixedFertSetup_N_Charcoal.Text = Nothing
            Me.fixedFertSetup_N_NH4.Text = Nothing
            Me.fixedFertSetup_N_NO3.Text = Nothing
            Me.fixedFertSetup_P_Organic.Text = Nothing
            Me.fixedFertSetup_P_Charcoal.Text = Nothing
            Me.fixedFertSetup_P_Inorganic.Text = Nothing
            Me.fixedFertSetup_K.Text = Nothing
            Me.fixedFertSetup_S.Text = Nothing
        Else
            For i As Integer = 0 To Fertilization.maxFertilizers
                If sender.Text = Fertilization.Source(i) Then
                    Me.fixedFertSetup_C_Organic.Text = Fertilization.C_Organic(i)
                    Me.fixedFertSetup_C_Charcoal.Text = Fertilization.C_Charcoal(i)
                    Me.fixedFertSetup_N_Organic.Text = Fertilization.N_Organic(i)
                    Me.fixedFertSetup_N_Charcoal.Text = Fertilization.N_Charcoal(i)
                    Me.fixedFertSetup_N_NH4.Text = Fertilization.N_NH4(i)
                    Me.fixedFertSetup_N_NO3.Text = Fertilization.N_NO3(i)
                    Me.fixedFertSetup_P_Organic.Text = Fertilization.P_Organic(i)
                    Me.fixedFertSetup_P_Charcoal.Text = Fertilization.P_Charcoal(i)
                    Me.fixedFertSetup_P_Inorganic.Text = Fertilization.P(i)
                    Me.fixedFertSetup_K.Text = Fertilization.K(i)
                    Me.fixedFertSetup_S.Text = Fertilization.S(i)
                    Exit For
                End If
            Next
        End If

    End Sub

    Private Sub fixedFertSetup_Year_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fixedFertSetup_Year.DoubleClick
        Dim yr As Integer

        If fixedFertSetup_Year.Text.Trim <> Nothing Then
            yr = fixedFertSetup_Year.Text
        Else
            yr = 0
        End If

        Me.CalendarPopup(fixedFertSetup_Day.Text, yr)

        If yr > 0 Then fixedFertSetup_Year.Text = yr
    End Sub
    Private Sub fixedFertSetup_Day_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fixedFertSetup_Day.DoubleClick
        Dim yr As Integer

        If fixedFertSetup_Year.Text.Trim <> Nothing Then
            yr = fixedFertSetup_Year.Text
        Else
            yr = 0
        End If

        Me.CalendarPopup(fixedFertSetup_Day.Text, yr)

        If yr > 0 Then fixedFertSetup_Year.Text = yr
    End Sub

    '====================================== Auto Fertilization =====================================
    Private Sub btn_AddAutoFertOp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_AddAutoFertOp.Click
        'Precondition:  none
        'Postcondition: user fields read, initially error checked, and written to the listview

        Dim ctlList() As Control = {Me.autoFertSetup_Name, Me.autoFertSetup_StartDay, Me.autoFertSetup_EndDay, Me.autoFertSetup_Source, _
                                    Me.autoFertSetup_Mass, Me.autoFertSetup_Form, Me.autoFertSetup_Method, Me.autoFertSetup_C_Organic, _
                                    Me.autoFertSetup_C_Charcoal, Me.autoFertSetup_N_Organic, Me.autoFertSetup_N_Charcoal, _
                                    Me.autoFertSetup_N_NH4, Me.autoFertSetup_N_NO3, Me.autoFertSetup_P_Organic, Me.autoFertSetup_P_Charcoal, _
                                    Me.autoFertSetup_P_Inorganic, Me.autoFertSetup_K, Me.autoFertSetup_S}
        Dim opList() As Object = Nothing

        If Me.autoFertSetup_StartDay.Text.Trim = Nothing Then       'check if default value used
            Me.autoFertSetup_StartDay.Text = Me.autoFertSetup_DefaultStartDay.Text.Trim
        End If
        If Me.autoFertSetup_EndDay.Text.Trim = Nothing Then         'check if default value used
            Me.autoFertSetup_EndDay.Text = Me.autoFertSetup_DefaultEndDay.Text.Trim
        End If

        Call Me.ReadFormOperations(ctlList, opList)                 'read operation

        If Trim(opList(0)) <> Nothing And Trim(opList(1)) <> Nothing And Trim(opList(2)) <> Nothing And _
            Trim(opList(3)) <> Nothing And Trim(opList(4)) <> Nothing And Trim(opList(5)) <> Nothing Then

            If IsNumeric(opList(1)) And IsNumeric(opList(2)) And IsNumeric(opList(3)) Then
                Call Me.SetupToList(sender, Me.lv_AutoFertilization, opList, ctlList)
            End If
        Else
            MsgBox("Unable to add operation to list. Please verify operation is correct.", MsgBoxStyle.Information, Me.ProductName)
        End If
    End Sub
    Private Sub btn_ChangeAutoFertOp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ChangeAutoFertOp.Click
        'Precondition:  none
        'Postcondition: selected row is written to the setup fields and deleted from the listview

        Dim ctlList() As Control = {Me.autoFertSetup_Name, Me.autoFertSetup_StartDay, Me.autoFertSetup_EndDay, Me.autoFertSetup_Source, _
                                    Me.autoFertSetup_Mass, Me.autoFertSetup_Form, Me.autoFertSetup_Method, Me.autoFertSetup_C_Organic, _
                                    Me.autoFertSetup_C_Charcoal, Me.autoFertSetup_N_Organic, Me.autoFertSetup_N_Charcoal, _
                                    Me.autoFertSetup_N_NH4, Me.autoFertSetup_N_NO3, Me.autoFertSetup_P_Organic, Me.autoFertSetup_P_Charcoal, _
                                    Me.autoFertSetup_P_Inorganic, Me.autoFertSetup_K, Me.autoFertSetup_S}

        Call Me.ListToSetup(sender, Me.lv_AutoFertilization, ctlList)
    End Sub

    Private Sub AutoFertSetup_PerformOperations_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles autoFertSetup_PerformOperations.CheckedChanged
        'Precondition:  none
        'Postcondition: All fields enabled status changed to senders value

        Me.grp_AutoFertilization.Enabled = sender.Checked
        Me.grp_AutoFertSetup.Enabled = sender.Checked
        Me.btn_AddAutoFertOp.Enabled = sender.Checked
        Me.btn_ChangeAutoFertOp.Enabled = sender.Checked
    End Sub

    Private Sub autoFertSetup_Name_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles autoFertSetup_Name.SelectedIndexChanged, autoFertSetup_Name.SelectedValueChanged
        'Precondition:  listed crops match exactly the described crops listview
        'Postcondition: selected crop's user described planting date copied to the setup area default start day field
        '               selected crop's user described maturity date copied to the setup area default end day field

        If sender.text.trim = Nothing Then
            Me.autoFertSetup_DefaultStartDay.Text = Nothing
            Me.autoFertSetup_DefaultEndDay.Text = Nothing
            Me.autoFertSetup_labelDefaultStartDay.Visible = False
            Me.autoFertSetup_labelDefaultEndDay.Visible = False
        Else
            Me.autoFertSetup_labelDefaultStartDay.Visible = True
            Me.autoFertSetup_labelDefaultEndDay.Visible = True

            For Each listItem As ListViewItem In Me.lv_DescribedCrops.Items
                If listItem.Text = sender.text Then
                    Me.autoFertSetup_DefaultStartDay.Text = listItem.SubItems.Item(1).Text
                    Me.autoFertSetup_DefaultEndDay.Text = listItem.SubItems.Item(3).Text
                    Exit For
                End If
            Next
        End If
    End Sub

    Private Sub autoFertSetup_Tool_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles autoFertSetup_Source.SelectedIndexChanged, autoFertSetup_Source.SelectedValueChanged
        'Precondition:  fertilizationList previously populated
        'Postcondition: default values for that operation copied to fields

        If sender.text = Nothing Then
            Me.autoFertSetup_Mass.Text = Nothing
            Me.autoFertSetup_Form.Text = Nothing
            Me.autoFertSetup_Method.Text = Nothing
            Me.autoFertSetup_Depth.Text = Nothing

            Me.autoFertSetup_C_Organic.Text = Nothing
            Me.autoFertSetup_C_Charcoal.Text = Nothing
            Me.autoFertSetup_N_Organic.Text = Nothing
            Me.autoFertSetup_N_Charcoal.Text = Nothing
            Me.autoFertSetup_N_NH4.Text = Nothing
            Me.autoFertSetup_N_NO3.Text = Nothing
            Me.autoFertSetup_P_Organic.Text = Nothing
            Me.autoFertSetup_P_Charcoal.Text = Nothing
            Me.autoFertSetup_P_Inorganic.Text = Nothing
            Me.autoFertSetup_K.Text = Nothing
            Me.autoFertSetup_S.Text = Nothing
        Else
            For i As Integer = 0 To Fertilization.maxFertilizers
                If sender.Text = Fertilization.Source(i) Then
                    Me.autoFertSetup_C_Organic.Text = Fertilization.C_Organic(i)
                    Me.autoFertSetup_C_Charcoal.Text = Fertilization.C_Charcoal(i)
                    Me.autoFertSetup_N_Organic.Text = Fertilization.N_Organic(i)
                    Me.autoFertSetup_N_Charcoal.Text = Fertilization.N_Charcoal(i)
                    Me.autoFertSetup_N_NH4.Text = Fertilization.N_NH4(i)
                    Me.autoFertSetup_N_NO3.Text = Fertilization.N_NO3(i)
                    Me.autoFertSetup_P_Organic.Text = Fertilization.P_Organic(i)
                    Me.autoFertSetup_P_Charcoal.Text = Fertilization.P_Charcoal(i)
                    Me.autoFertSetup_P_Inorganic.Text = Fertilization.P(i)
                    Me.autoFertSetup_K.Text = Fertilization.K(i)
                    Me.autoFertSetup_S.Text = Fertilization.S(i)
                    Exit For
                End If
            Next
        End If

    End Sub

    Private Sub FertilizationPlantAvailableListChanged()
        'Precondition:  none
        'Postcondition: crops that are described and have no automatic parameters are listed

        Dim listItem As ListViewItem

        With Me.autoFertSetup_Name.Items
            'delete available list
            .Clear()
            .Add("")

            'copy described crops list
            For Each listItem In Me.lv_DescribedCrops.Items
                .Add(listItem.Text)
            Next

            'delete used crops
            For Each listItem In Me.lv_AutoFertilization.Items
                If .Contains(listItem.Text) Then
                    .Remove(listItem.Text)
                End If
            Next
        End With
    End Sub

    Private Sub autoFertSetup_StartDay_DoubleClick() Handles autoFertSetup_StartDay.DoubleClick
        Me.CalendarPopup(autoFertSetup_StartDay.Text, Nothing, autoFertSetup_DefaultStartDay.Text)
    End Sub
    Private Sub autoFertSetup_EndDay_DoubleClick() Handles autoFertSetup_EndDay.DoubleClick
        Me.CalendarPopup(autoFertSetup_EndDay.Text, Nothing, autoFertSetup_DefaultEndDay.Text)
    End Sub

    Private Sub DISABLE_AUTO_FERTILIZATION(ByVal sender As System.Windows.Forms.CheckBox, ByVal e As System.EventArgs) Handles autoFertSetup_PerformOperations.CheckedChanged
        If sender.Checked Then sender.CheckState = False
    End Sub

    '====================================== Common Actions =========================================
    Private Sub ListviewRowDelete(ByVal sender As ListView, ByVal e As System.Windows.Forms.KeyEventArgs) Handles _
                lv_PlantedCrops.KeyDown, lv_AutoFertilization.KeyDown, lv_FixedFertilization.KeyDown, lv_Tillage.KeyDown, _
                lv_FixedIrrigation.KeyDown, lv_AutomaticIrrigation.KeyDown, lv_DescribedCrops.KeyDown

        'Precondition:  sending listview is not empty
        'Postcondition: focused row is deleted from the sending listview
        '               focused row's parameters are removed from the aggrigate listview as needed
        '               visual cue describing the focused row's active status is changed
        '               active operations count is updated

        Dim oplist() As Object = Nothing
        Dim activeOp As Boolean = True
        Dim grpTitle As String

        If (e.KeyCode = Keys.Delete) Then

            Call Me.ReadFocusedListViewRow(sender.FocusedItem, oplist)               'read focused row's parameters
            If sender.FocusedItem.BackColor = Me.colorInactive Then activeOp = False 'only delete from aggrigate list if operation is active
            sender.Items.Remove(sender.FocusedItem)                                  'delete focused row
            grpTitle = Me.ActiveListviewOperations(sender)                           'update active operations count

            Select Case sender.Name                                                  'sender specific options
                Case "lv_DescribedCrops"
                    Me.grp_DescribedCrops.Text = grpTitle
                    Call Me.AddToUndescribedCropList(oplist(0))
                    Call Me.UpdateDescribedCropsComboBoxes()

                Case "lv_PlantedCrops"
                    Me.grp_PlantedCrops.Text = grpTitle
                    If activeOp Then Me.RemoveFromAggrigateList(oplist, cropType)

                Case "lv_Tillage"
                    Me.grp_Tillage.Text = grpTitle
                    If activeOp Then Me.RemoveFromAggrigateList(oplist, tillType)

                Case "lv_FixedIrrigation"
                    Me.grp_FixedIrrigation.Text = grpTitle
                    If activeOp Then Me.RemoveFromAggrigateList(oplist, irrType)

                Case "lv_FixedFertilization"
                    Me.grp_FixedFertilization.Text = grpTitle
                    If activeOp Then Me.RemoveFromAggrigateList(oplist, fertType)

                Case "lv_AutomaticIrrigation"
                    Me.grp_AutomaticIrrigation.Text = grpTitle
                    Call Me.IrrigationPlantAvailableListChanged()

                Case "lv_AutoFertilization"
                    Me.grp_AutoFertilization.Text = grpTitle
                    Call Me.FertilizationPlantAvailableListChanged()

            End Select
        End If
    End Sub

    Private Sub ListviewRowStatusChange(ByVal sender As ListView, ByVal e As System.EventArgs) Handles _
                lv_PlantedCrops.DoubleClick, lv_Tillage.DoubleClick, lv_FixedIrrigation.DoubleClick, lv_FixedFertilization.DoubleClick, _
                lv_AutoFertilization.DoubleClick, lv_AutomaticIrrigation.DoubleClick

        'Precondition:  sending listview is not empty
        'Postcondition: passed parameters are added/removed to/from the aggrigate listview as needed
        '               visual cue describing the focused row's active status is changed
        '               active operations count is updated

        Dim oplist() As Object = Nothing
        Dim opType As String = Nothing
        Dim grpTitle As String

        With sender.FocusedItem                                         'switch focused row's color
            If .BackColor = Me.colorActive Then
                .BackColor = Me.colorInactive
            Else
                .BackColor = Me.colorActive
            End If
        End With

        Call Me.ReadFocusedListViewRow(sender.FocusedItem, oplist)      'read focused row's parameters
        grpTitle = Me.ActiveListviewOperations(sender)                  'store active operations count

        Select Case sender.Name                                         'sender specific options
            Case "lv_PlantedCrops"
                Me.grp_PlantedCrops.Text = grpTitle
                opType = cropType

            Case "lv_Tillage"
                Me.grp_Tillage.Text = grpTitle
                opType = tillType

            Case "lv_FixedIrrigation"
                Me.grp_FixedIrrigation.Text = grpTitle
                opType = irrType

            Case "lv_FixedFertilization"
                Me.grp_FixedFertilization.Text = grpTitle
                opType = fertType

            Case "lv_AutomaticIrrigation"
                Me.grp_AutomaticIrrigation.Text = grpTitle
                opType = Nothing

            Case "lv_AutoFertilization"
                Me.grp_AutoFertilization.Text = grpTitle
                opType = Nothing

        End Select

        If Trim(opType) <> Nothing Then                                 'aggrigate list operations based on case statement
            If sender.FocusedItem.BackColor = Me.colorActive Then
                Call Me.WriteListViewRow(Me.lv_ActiveFieldOperations, oplist, opType)
            Else
                Call Me.RemoveFromAggrigateList(oplist, opType)
            End If
        End If
    End Sub

    Private Sub SetupToList(ByVal sender As System.Object, ByRef lv As ListView, ByVal opList() As Object, ByRef ctlList() As Control)
        'Precondition:  sender is a field operations add/remove button
        '               sender is named as listed
        '               listview is initialized
        '               operations list not empty
        '               control list not empty
        'Postcondition: setup parameters are cleared
        '               parameters written to the listview
        '               active operations count updated
        '               parameters added to the aggrigate list as needed

        Dim grpTitle As String = Nothing
        Dim opType As String = Nothing

        Call Me.ClearFormOperations(ctlList)                            'clear source
        Call Me.WriteListViewRow(lv, opList)                            'write operation
        grpTitle = Me.ActiveListviewOperations(lv)                      'update displayed counts

        Select Case sender.name                                         'sender specific options
            Case "btn_AddDescribedCrop"
                opType = Nothing
                Me.grp_DescribedCrops.Text = grpTitle
                Call Me.RemoveFromUndescribedCropList(opList(0))        'update crop list
                Call Me.UpdateDescribedCropsComboBoxes()                'update rotation lists

            Case "btn_AddPlantingEvent"
                opType = cropType
                Me.grp_PlantedCrops.Text = grpTitle
                Me.plantingSetup_AutoIrr.Checked = False
                Me.plantingSetup_AutoFert.Checked = False

            Case "btn_AddTillageOp"
                opType = tillType
                Me.grp_Tillage.Text = grpTitle
                Me.tillSetup_DefaultDepth.Text = Nothing

            Case "btn_AddFixedIrrOp"
                opType = irrType
                Me.grp_FixedIrrigation.Text = grpTitle

            Case "btn_AddFixedFertOp"
                opType = fertType
                Me.grp_FixedFertilization.Text = grpTitle

            Case "btn_AddAutoIrrOp"
                opType = Nothing
                Me.grp_AutomaticIrrigation.Text = grpTitle
                Me.autoIrrSetup_Name.Items.Remove(opList(0))            'remove crop from available list

            Case "btn_AddAutoFertOp"
                opType = Nothing
                Me.grp_AutoFertilization.Text = grpTitle
                Me.autoFertSetup_Name.Items.Remove(opList(0))           'remove crop from available list

        End Select

        If Trim(opType) <> Nothing Then
            Call Me.WriteListViewRow(Me.lv_ActiveFieldOperations, opList, opType) 'write operation
        End If
    End Sub

    Private Sub ListToSetup(ByVal sender As System.Object, ByRef lv As ListView, ByRef ctlList() As Control)
        'Precondition:  sender is a field operations add/remove button
        '               sender is named as listed
        '               listview is initialized
        '               control list not empty
        'Postcondition: setup parameters are written
        '               parameters removed from the listview
        '               active operations count updated
        '               parameters removed from the aggrigate list as needed

        Dim grpTitle As String = Nothing
        Dim opList() As Object = Nothing
        Dim opType As String = Nothing

        If Me.ReadFocusedListViewRow(lv.FocusedItem, opList) Then           'read operation
            Call Me.WriteFormOperations(ctlList, opList)                    'write operation
            lv.FocusedItem.Remove()                                         'clear source
            grpTitle = Me.ActiveListviewOperations(lv)                      'store active count

            Select Case sender.name                                         'sender specific options
                Case "btn_ChangeDescribedCrop"
                    opType = Nothing
                    Me.grp_DescribedCrops.Text = grpTitle
                    Call Me.AddToUndescribedCropList(opList(0))             'remove crop from available crop list
                    Call Me.UpdateDescribedCropsComboBoxes()                'update rotation lists

                Case "btn_ChangePlantingEvent"
                    opType = cropType
                    Me.grp_PlantedCrops.Text = grpTitle

                    If opList(3) = "True" Then
                        Me.plantingSetup_AutoIrr.Checked = True
                    Else
                        Me.plantingSetup_AutoIrr.Checked = False
                    End If

                    If opList(4) = "True" Then
                        Me.plantingSetup_AutoFert.Checked = True
                    Else
                        Me.plantingSetup_AutoFert.Checked = False
                    End If

                Case "btn_ChangeTillageOp"
                    opType = tillType
                    Me.grp_Tillage.Text = grpTitle

                Case "btn_ChangeFixedIrrOp"
                    opType = irrType
                    Me.grp_FixedIrrigation.Text = grpTitle

                Case "btn_ChangeFixedFertOp"
                    opType = fertType
                    Me.grp_FixedFertilization.Text = grpTitle

                Case "btn_ChangeAutoIrrOp"
                    opType = Nothing
                    Me.grp_AutomaticIrrigation.Text = grpTitle
                    Call Me.IrrigationPlantAvailableListChanged()           'update available list
                    Me.autoIrrSetup_Name.Text = opList(0)

                Case "btn_ChangeAutoFertOp"
                    opType = Nothing
                    Me.grp_AutoFertilization.Text = grpTitle
                    Call Me.FertilizationPlantAvailableListChanged()        'update available list
                    Me.autoFertSetup_Name.Text = opList(0)

            End Select

            If Trim(opType) <> Nothing Then
                Me.RemoveFromAggrigateList(opList, opType)
            End If
        End If
    End Sub

    Private Sub RemoveFromAggrigateList(ByVal oplist() As Object, ByVal opType As String)
        'Precondition:  oplist has been dimentioned >= 3
        'Postcondition: row that matches passed parameters is removed from the listview, if any

        Dim lv As ListView = Me.lv_ActiveFieldOperations
        Dim yr, dy, src As String

        ReDim Preserve oplist(lv.Columns.Count - 1)

        For Each listItem As ListViewItem In lv.Items
            yr = listItem.SubItems.Item(0).Text
            dy = listItem.SubItems.Item(1).Text
            src = listItem.SubItems.Item(2).Text

            If src = opType And yr = oplist(0) And dy = oplist(1) Then

                For i As Integer = 3 To UBound(oplist)
                    If listItem.SubItems.Item(i).Text <> CStr(oplist(i - 1)) Then
                        Exit For
                    ElseIf i = UBound(oplist) Then
                        listItem.Remove()
                        Exit Sub
                    End If
                Next
            End If
        Next
    End Sub

    Private Sub PerformOperationsStatusChanged(ByVal lv As ListView, ByVal opType As String, ByVal usingOps As Boolean)
        'Precondition:  passed listview is initialized
        '               opType is not nothing
        'Postcondition: active operations in the passed listview added/removed to/from the aggrigate as needed

        Dim oplist(lv.Columns.Count - 1) As Object

        For Each listitem As ListViewItem In lv.Items
            If listitem.BackColor = Me.colorActive Then
                For i As Integer = 0 To UBound(oplist)
                    oplist(i) = listitem.SubItems(i).Text
                Next

                If usingOps Then
                    Call WriteListViewRow(Me.lv_ActiveFieldOperations, oplist, opType)
                Else
                    Call Me.RemoveFromAggrigateList(oplist, opType)
                End If
            End If
        Next
    End Sub

End Class
