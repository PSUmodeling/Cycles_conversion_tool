Partial Friend Class MainForm

    '====================================== Soil Description =======================================
    Private Sub Layer_btn_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) 'handler is auto generated
        'Precondition:  control arrays previously populated
        'Postcondition: sets enabled state as necessary for all fields based on layer selected

        Dim max As Integer = CInt(sender.text)

        If sender.Checked Then
            For layer As Integer = 1 To max
                'enable usable fields 
                ctlLayerThickness(layer).Enabled = True
                ctlCumDepth(layer).Enabled = True
                ctlClay(layer).Enabled = True
                ctlSand(layer).Enabled = True
                ctlIOM(layer).Enabled = True
                ctlNO3(layer).Enabled = True
                ctlNH4(layer).Enabled = True

                ctlBD(layer).Enabled = Me.Manual_BD_ckbx.Checked
                ctlFC(layer).Enabled = Me.Manual_FC_ckbx.Checked
                ctlPWP(layer).Enabled = Me.Manual_PWP_ckbx.Checked
            Next

            For layer As Integer = (max + 1) To Me.ctlLayerBtn.GetUpperBound(0)
                'disable un-usable fields
                ctlLayerThickness(layer).Enabled = False
                ctlCumDepth(layer).Enabled = False
                ctlClay(layer).Enabled = False
                ctlSand(layer).Enabled = False
                ctlIOM(layer).Enabled = False
                ctlNO3(layer).Enabled = False
                ctlNH4(layer).Enabled = False

                ctlBD(layer).Enabled = False
                ctlFC(layer).Enabled = False
                ctlPWP(layer).Enabled = False
            Next

            Call ChangeLayersAvailable(max) 'changes layer list on dependent combo boxes
        End If
    End Sub

    Private Sub thicknessLayer_Textchanged() 'handler is auto generated
        'Precondition:  control arrays previously populated
        'Postcondition: cumulative depth fields updated

        Dim total As Double = 0

        For i As Integer = 1 To Me.soil_maxLayer.Text
            If IsNumeric(ctlLayerThickness(i).Text) Then
                total += ctlLayerThickness(i).Text
            End If

            ctlCumDepth(i).Text = SideSubs.Formatting(total)
        Next
    End Sub

    Private Sub Manual_BD_ckbx_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Manual_BD_ckbx.CheckedChanged
        'Precondition:  control list previously populated
        'Postcondition: control list enabled state set to sender's value

        Call ManualChecked(sender.Checked, ctlBD)
    End Sub
    Private Sub Manual_FC_ckbx_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Manual_FC_ckbx.CheckedChanged
        'Precondition:  control list previously populated
        'Postcondition: control list enabled state set to sender's value

        Call ManualChecked(sender.Checked, ctlFC)
    End Sub
    Private Sub Manual_PWP_ckbx_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Manual_PWP_ckbx.CheckedChanged
        'Precondition:  control list previously populated
        'Postcondition: control list enabled state set to sender's value

        Call ManualChecked(sender.Checked, ctlPWP)
    End Sub

    Private Sub ChangeLayersAvailable(ByVal layer As Integer)
        'Precondition:  none
        'Postcondition: Dependent lists changed to match soil description

        Dim irrNum As Integer = 0
        Dim fertNum As Integer = 0

        If IsNumeric(Me.autoIrrSetup_LastSoilLayer.Text) Then irrNum = Me.autoIrrSetup_LastSoilLayer.Text
        If IsNumeric(Me.fixedFertSetup_Layer.Text) Then fertNum = Me.fixedFertSetup_Layer.Text

        Me.autoIrrSetup_LastSoilLayer.Items.Clear()
        Me.fixedFertSetup_Layer.Items.Clear()

        Me.autoIrrSetup_LastSoilLayer.Items.Add("")
        Me.fixedFertSetup_Layer.Items.Add("")
        Me.fixedFertSetup_Layer.Items.Add(0)

        For i As Integer = 1 To layer
            Me.autoIrrSetup_LastSoilLayer.Items.Add(i)
            Me.fixedFertSetup_Layer.Items.Add(i)
        Next

        Me.autoIrrSetup_LastSoilLayer.Text = irrNum
        Me.fixedFertSetup_Layer.Text = fertNum
    End Sub

    Private Sub ManualChecked(ByVal state As Boolean, ByVal manual_field() As System.Windows.Forms.TextBox)
        'Precondition:  each control in the array exists
        'Postcondition: all controls' enabled state set to passed value

        Dim selectedLayer As Integer = 0


        For i As Integer = 1 To Me.ctlLayerBtn.GetUpperBound(0)
            If Me.ctlLayerBtn(i).Checked Then
                selectedLayer = i
                Exit For
            End If
        Next

        For layer As Integer = 1 To selectedLayer
            If layer <= manual_field.GetUpperBound(0) Then
                manual_field(layer).Enabled = state
            End If
        Next
    End Sub

    Private Sub MaxLayerSelectedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles soil_maxLayer.TextChanged, soil_maxLayer.SelectedIndexChanged
        'Precondition:  none
        'Postcondition: number of layers able to be described = currently selected max soil layer field
        '               auto irrigation soil layers available matches soil description soil layers available

        Static curMax As Integer = 0
        Dim selectedLayer As Integer

        If soil_maxLayer.Text.Trim <> Nothing Then
            selectedLayer = soil_maxLayer.Text
        Else
            selectedLayer = 0
        End If

        If curMax < selectedLayer Then                  'create new soil description fields
            For i As Integer = curMax + 1 To selectedLayer
                Me.NewSoilLayer()
            Next
        ElseIf curMax > selectedLayer Then              'destroy existing soil description fields
            For i As Integer = curMax To selectedLayer + 1 Step -1
                If Me.ctlLayerBtn(i).Checked And selectedLayer > 0 Then Me.ctlLayerBtn(selectedLayer).Checked = True
                Me.RemoveSoilLayer()
            Next
        End If

        curMax = selectedLayer

        Me.autoIrrSetup_LastSoilLayer.Items.Clear()
        Me.fixedFertSetup_Layer.Items.Clear()

        Me.autoIrrSetup_LastSoilLayer.Items.Add("")
        Me.fixedFertSetup_Layer.Items.Add("")

        For i As Integer = 1 To curMax
            Me.autoIrrSetup_LastSoilLayer.Items.Add(i)
            Me.fixedFertSetup_Layer.Items.Add(i)
        Next
    End Sub

    Private Sub NewSoilLayer()
        'Precondition:  none
        'Postcondition: adds a new layer to the soil descriptions tab

        Dim maxLayer As Integer = ctlLayerBtn.GetUpperBound(0) + 1
        Dim rowPos As Integer = 20
        Dim boxHeight As Integer = 20
        Dim boxwidth As Integer = 55
        Dim spacer As Integer = 6

        ReDim Preserve ctlLayerBtn(maxLayer)
        ReDim Preserve ctlCumDepth(maxLayer)
        ReDim Preserve ctlLayerThickness(maxLayer)
        ReDim Preserve ctlClay(maxLayer)
        ReDim Preserve ctlSand(maxLayer)
        ReDim Preserve ctlIOM(maxLayer)
        ReDim Preserve ctlNO3(maxLayer)
        ReDim Preserve ctlNH4(maxLayer)
        ReDim Preserve ctlBD(maxLayer)
        ReDim Preserve ctlFC(maxLayer)
        ReDim Preserve ctlPWP(maxLayer)

        Me.grp_LayerButtons.Height = maxLayer * boxHeight

        ctlLayerBtn(maxLayer) = New System.Windows.Forms.RadioButton
        ctlCumDepth(maxLayer) = New System.Windows.Forms.TextBox
        ctlLayerThickness(maxLayer) = New System.Windows.Forms.TextBox
        ctlClay(maxLayer) = New System.Windows.Forms.TextBox
        ctlSand(maxLayer) = New System.Windows.Forms.TextBox
        ctlIOM(maxLayer) = New System.Windows.Forms.TextBox
        ctlNO3(maxLayer) = New System.Windows.Forms.TextBox
        ctlNH4(maxLayer) = New System.Windows.Forms.TextBox
        ctlBD(maxLayer) = New System.Windows.Forms.TextBox
        ctlFC(maxLayer) = New System.Windows.Forms.TextBox
        ctlPWP(maxLayer) = New System.Windows.Forms.TextBox

        With ctlLayerBtn(maxLayer)
            .Text = maxLayer
            .TextAlign = ContentAlignment.MiddleCenter
            .Size = New System.Drawing.Point(37, boxHeight)
            .Location = New System.Drawing.Point(5, (maxLayer - 1) * .Height)
            AddHandler .CheckedChanged, AddressOf Me.Layer_btn_CheckedChanged
            rowPos += .Width
        End With

        With ctlCumDepth(maxLayer)
            If maxLayer >= 2 Then .Text = ctlCumDepth(maxLayer - 1).Text
            .ReadOnly = True
            .Enabled = False
            .TextAlign = HorizontalAlignment.Center
            .TabStop = False
            .Size = New System.Drawing.Point(boxwidth, boxHeight)
            .Location = New System.Drawing.Point(rowPos, (maxLayer - 1) * .Height)
            rowPos += .Width + spacer
        End With

        With ctlLayerThickness(maxLayer)
            .TextAlign = HorizontalAlignment.Center
            .Enabled = False
            .Size = New System.Drawing.Point(boxwidth, boxHeight)
            .Location = New System.Drawing.Point(rowPos, (maxLayer - 1) * .Height)
            AddHandler .TextChanged, AddressOf Me.thicknessLayer_Textchanged
            AddHandler .Validating, AddressOf Me.Validating0to2
            AddHandler .Validated, AddressOf Me.PassedValidation
            rowPos += .Width - 1
        End With

        With ctlClay(maxLayer)
            .TextAlign = HorizontalAlignment.Center
            .Enabled = False
            .Size = New System.Drawing.Point(boxwidth, boxHeight)
            .Location = New System.Drawing.Point(rowPos, (maxLayer - 1) * .Height)
            AddHandler .Validating, AddressOf Me.Validating0to100
            AddHandler .Validated, AddressOf Me.PassedValidation
            rowPos += .Width - 1
        End With

        With ctlSand(maxLayer)
            .TextAlign = HorizontalAlignment.Center
            .Enabled = False
            .Size = New System.Drawing.Point(boxwidth, boxHeight)
            .Location = New System.Drawing.Point(rowPos, (maxLayer - 1) * .Height)
            AddHandler .Validating, AddressOf Me.Validating0to100
            AddHandler .Validated, AddressOf Me.PassedValidation
            rowPos += .Width - 1
        End With

        With ctlIOM(maxLayer)
            .TextAlign = HorizontalAlignment.Center
            .Enabled = False
            .Size = New System.Drawing.Point(boxwidth, boxHeight)
            .Location = New System.Drawing.Point(rowPos, (maxLayer - 1) * .Height)
            AddHandler .Validating, AddressOf Me.Validating0to100
            AddHandler .Validated, AddressOf Me.PassedValidation
            rowPos += .Width + spacer
        End With

        With ctlNO3(maxLayer)
            .TextAlign = HorizontalAlignment.Center
            .Enabled = False
            .Size = New System.Drawing.Point(boxwidth, boxHeight)
            .Location = New System.Drawing.Point(rowPos, (maxLayer - 1) * .Height)
            AddHandler .Validating, AddressOf Me.Validating0to500
            AddHandler .Validated, AddressOf Me.PassedValidation
            rowPos += .Width - 1
        End With

        With ctlNH4(maxLayer)
            .TextAlign = HorizontalAlignment.Center
            .Enabled = False
            .Size = New System.Drawing.Point(boxwidth, boxHeight)
            .Location = New System.Drawing.Point(rowPos, (maxLayer - 1) * .Height)
            AddHandler .Validating, AddressOf Me.Validating0to500
            AddHandler .Validated, AddressOf Me.PassedValidation
            rowPos += .Width + spacer
        End With

        With ctlBD(maxLayer)
            .TextAlign = HorizontalAlignment.Center
            .Enabled = False
            .Size = New System.Drawing.Point(boxwidth, boxHeight)
            .Location = New System.Drawing.Point(rowPos, (maxLayer - 1) * .Height)
            AddHandler .Validating, AddressOf Me.ValidatingPositiveDoubleInput
            AddHandler .Validated, AddressOf Me.PassedValidation
            rowPos += .Width - 1
        End With

        With ctlFC(maxLayer)
            .TextAlign = HorizontalAlignment.Center
            .Enabled = False
            .Size = New System.Drawing.Point(boxwidth, boxHeight)
            .Location = New System.Drawing.Point(rowPos, (maxLayer - 1) * .Height)
            AddHandler .Validating, AddressOf Me.ValidatingPositiveDoubleInput
            AddHandler .Validated, AddressOf Me.PassedValidation
            rowPos += .Width - 1
        End With

        With ctlPWP(maxLayer)
            .TextAlign = HorizontalAlignment.Center
            .Enabled = False
            .Size = New System.Drawing.Point(boxwidth, boxHeight)
            .Location = New System.Drawing.Point(rowPos, (maxLayer - 1) * .Height)
            AddHandler .Validating, AddressOf Me.ValidatingPositiveDoubleInput
            AddHandler .Validated, AddressOf Me.PassedValidation
            rowPos += .Width - 1
        End With

        Me.grp_LayerButtons.Controls.Add(ctlLayerBtn(maxLayer))
        Me.grp_SoilProfile.Controls.AddRange(New System.Windows.Forms.Control() _
                                      {ctlCumDepth(maxLayer), ctlLayerThickness(maxLayer), ctlClay(maxLayer), ctlSand(maxLayer), _
                                       ctlIOM(maxLayer), ctlNO3(maxLayer), ctlNH4(maxLayer), ctlBD(maxLayer), ctlFC(maxLayer), ctlPWP(maxLayer)})

    End Sub

    Private Sub RemoveSoilLayer()
        'Precondition:  at least one soil layer fields set has been created
        'Postcondition: all soil description fields for the last soil layer are destroyed

        Dim maxLayer As Integer = ctlLayerBtn.GetUpperBound(0)

        Me.grp_LayerButtons.Controls.Remove(ctlLayerBtn(maxLayer))
        Me.grp_SoilProfile.Controls.Remove(ctlCumDepth(maxLayer))
        Me.grp_SoilProfile.Controls.Remove(ctlLayerThickness(maxLayer))
        Me.grp_SoilProfile.Controls.Remove(ctlClay(maxLayer))
        Me.grp_SoilProfile.Controls.Remove(ctlSand(maxLayer))
        Me.grp_SoilProfile.Controls.Remove(ctlIOM(maxLayer))
        Me.grp_SoilProfile.Controls.Remove(ctlNO3(maxLayer))
        Me.grp_SoilProfile.Controls.Remove(ctlNH4(maxLayer))
        Me.grp_SoilProfile.Controls.Remove(ctlBD(maxLayer))
        Me.grp_SoilProfile.Controls.Remove(ctlFC(maxLayer))
        Me.grp_SoilProfile.Controls.Remove(ctlPWP(maxLayer))

        Me.grp_LayerButtons.Height = (maxLayer - 1) * ctlCumDepth(maxLayer).Height

        ctlLayerBtn(maxLayer) = Nothing
        ctlCumDepth(maxLayer) = Nothing
        ctlLayerThickness(maxLayer) = Nothing
        ctlClay(maxLayer) = Nothing
        ctlSand(maxLayer) = Nothing
        ctlIOM(maxLayer) = Nothing
        ctlNO3(maxLayer) = Nothing
        ctlNH4(maxLayer) = Nothing
        ctlBD(maxLayer) = Nothing
        ctlFC(maxLayer) = Nothing
        ctlPWP(maxLayer) = Nothing

        ReDim Preserve ctlLayerBtn(maxLayer - 1)
        ReDim Preserve ctlCumDepth(maxLayer - 1)
        ReDim Preserve ctlLayerThickness(maxLayer - 1)
        ReDim Preserve ctlClay(maxLayer - 1)
        ReDim Preserve ctlSand(maxLayer - 1)
        ReDim Preserve ctlIOM(maxLayer - 1)
        ReDim Preserve ctlNO3(maxLayer - 1)
        ReDim Preserve ctlNH4(maxLayer - 1)
        ReDim Preserve ctlBD(maxLayer - 1)
        ReDim Preserve ctlFC(maxLayer - 1)
        ReDim Preserve ctlPWP(maxLayer - 1)

    End Sub

End Class
