Partial Friend Class MainForm

    Private Sub AddValidationHandling()
        'Precondition:  all fields are either text boxes or combo boxes (ie: no masked textboxes)
        'Postcondition: Validation handling added to all user input fields that exist upon form creation

        '====================================== Simulation Controls ====================================
        AddHandler Me.duration_StartYear.Validating, AddressOf Me.ValidatingComboBoxValue
        AddHandler Me.duration_StopYear.Validating, AddressOf Me.ValidatingComboBoxValue
        AddHandler Me.duration_RotationSize.Validating, AddressOf Me.ValidatingComboBoxValue

        AddHandler Me.duration_StartYear.Validated, AddressOf Me.PassedValidation
        AddHandler Me.duration_StopYear.Validated, AddressOf Me.PassedValidation
        AddHandler Me.duration_RotationSize.Validated, AddressOf Me.PassedValidation

        '====================================== Soil Description =======================================
        AddHandler Me.soil_curve.Validating, AddressOf Me.Validating0to100
        AddHandler Me.soil_slope.Validating, AddressOf Me.ValidatingSoilSlope
        AddHandler Me.soil_maxLayer.Validating, AddressOf Me.ValidatingComboBoxValue

        AddHandler Me.soil_curve.Validated, AddressOf Me.PassedValidation
        AddHandler Me.soil_slope.Validated, AddressOf Me.PassedValidation
        AddHandler Me.soil_maxLayer.Validated, AddressOf Me.PassedValidation

        '====================================== Crop Descriptions ======================================
        AddHandler Me.CropDescrip2.Validating, AddressOf Me.Validating1to366
        AddHandler Me.CropDescrip3.Validating, AddressOf Me.Validating1to366
        AddHandler Me.CropDescrip4.Validating, AddressOf Me.Validating1to366
        AddHandler Me.CropDescrip5.Validating, AddressOf Me.Validating0to100
        AddHandler Me.CropDescrip6.Validating, AddressOf Me.ValidatingPositiveDoubleInput
        AddHandler Me.CropDescrip7.Validating, AddressOf Me.ValidatingPositiveDoubleInput
        AddHandler Me.CropDescrip8.Validating, AddressOf Me.ValidatingPositiveDoubleInput
        AddHandler Me.CropDescrip9.Validating, AddressOf Me.ValidatingPositiveDoubleInput
        AddHandler Me.CropDescrip10.Validating, AddressOf Me.Validating0to100
        AddHandler Me.CropDescrip11.Validating, AddressOf Me.Validating0to100
        AddHandler Me.CropDescrip12.Validating, AddressOf Me.Validating0to100
        AddHandler Me.CropDescrip13.Validating, AddressOf Me.Validating0to100
        AddHandler Me.CropDescrip14.Validating, AddressOf Me.ValidatingNeg50to50
        AddHandler Me.CropDescrip15.Validating, AddressOf Me.ValidatingNeg50to50
        AddHandler Me.CropDescrip16.Validating, AddressOf Me.ValidatingNeg50to50
        AddHandler Me.CropDescrip17.Validating, AddressOf Me.ValidatingNeg50to50
        AddHandler Me.CropDescrip18.Validating, AddressOf Me.ValidatingNeg50to50
        AddHandler Me.CropDescrip19.Validating, AddressOf Me.ValidatingNeg50to50
        AddHandler Me.CropDescrip20.Validating, AddressOf Me.ValidatingNeg50to50
        AddHandler Me.CropDescrip21.Validating, AddressOf Me.Validating0to1
        AddHandler Me.CropDescrip22.Validating, AddressOf Me.Validating0to1
        AddHandler Me.CropDescrip23.Validating, AddressOf Me.Validating0to15
        AddHandler Me.CropDescrip24.Validating, AddressOf Me.Validating0to15
        AddHandler Me.CropDescrip25.Validating, AddressOf Me.Validating0to1
        AddHandler Me.CropDescrip26.Validating, AddressOf Me.Validating0to1
        AddHandler Me.CropDescrip27.Validating, AddressOf Me.Validating0to5
        AddHandler Me.CropDescrip28.Validating, AddressOf Me.Validating0to500
        AddHandler Me.CropDescrip29.Validating, AddressOf Me.Validating0toPoint08
        AddHandler Me.CropDescrip30.Validating, AddressOf Me.Validating0to1
        AddHandler Me.CropDescrip31.Validating, AddressOf Me.Validating0to2
        AddHandler Me.CropDescrip32.Validating, AddressOf Me.ValidatingComboBoxValue
        AddHandler Me.CropDescrip33.Validating, AddressOf Me.ValidatingComboBoxValue
        AddHandler Me.CropDescrip34.Validating, AddressOf Me.ValidatingComboBoxValue

        AddHandler Me.CropDescrip2.Validated, AddressOf Me.PassedValidation
        AddHandler Me.CropDescrip3.Validated, AddressOf Me.PassedValidation
        AddHandler Me.CropDescrip4.Validated, AddressOf Me.PassedValidation
        AddHandler Me.CropDescrip5.Validated, AddressOf Me.PassedValidation
        AddHandler Me.CropDescrip6.Validated, AddressOf Me.PassedValidation
        AddHandler Me.CropDescrip7.Validated, AddressOf Me.PassedValidation
        AddHandler Me.CropDescrip8.Validated, AddressOf Me.PassedValidation
        AddHandler Me.CropDescrip9.Validated, AddressOf Me.PassedValidation
        AddHandler Me.CropDescrip10.Validated, AddressOf Me.PassedValidation
        AddHandler Me.CropDescrip11.Validated, AddressOf Me.PassedValidation
        AddHandler Me.CropDescrip12.Validated, AddressOf Me.PassedValidation
        AddHandler Me.CropDescrip13.Validated, AddressOf Me.PassedValidation
        AddHandler Me.CropDescrip14.Validated, AddressOf Me.PassedValidation
        AddHandler Me.CropDescrip15.Validated, AddressOf Me.PassedValidation
        AddHandler Me.CropDescrip16.Validated, AddressOf Me.PassedValidation
        AddHandler Me.CropDescrip17.Validated, AddressOf Me.PassedValidation
        AddHandler Me.CropDescrip18.Validated, AddressOf Me.PassedValidation
        AddHandler Me.CropDescrip19.Validated, AddressOf Me.PassedValidation
        AddHandler Me.CropDescrip20.Validated, AddressOf Me.PassedValidation
        AddHandler Me.CropDescrip21.Validated, AddressOf Me.PassedValidation
        AddHandler Me.CropDescrip22.Validated, AddressOf Me.PassedValidation
        AddHandler Me.CropDescrip23.Validated, AddressOf Me.PassedValidation
        AddHandler Me.CropDescrip24.Validated, AddressOf Me.PassedValidation
        AddHandler Me.CropDescrip25.Validated, AddressOf Me.PassedValidation
        AddHandler Me.CropDescrip26.Validated, AddressOf Me.PassedValidation
        AddHandler Me.CropDescrip27.Validated, AddressOf Me.PassedValidation
        AddHandler Me.CropDescrip28.Validated, AddressOf Me.PassedValidation
        AddHandler Me.CropDescrip29.Validated, AddressOf Me.PassedValidation
        AddHandler Me.CropDescrip30.Validated, AddressOf Me.PassedValidation
        AddHandler Me.CropDescrip31.Validated, AddressOf Me.PassedValidation
        AddHandler Me.CropDescrip32.Validated, AddressOf Me.PassedValidation
        AddHandler Me.CropDescrip33.Validated, AddressOf Me.PassedValidation
        AddHandler Me.CropDescrip34.Validated, AddressOf Me.PassedValidation

        '====================================== Planting Order =========================================
        AddHandler Me.plantingSetup_cropName.Validating, AddressOf Me.ValidatingComboBoxValue
        AddHandler Me.plantingSetup_Year.Validating, AddressOf Me.ValidatingComboBoxValue
        AddHandler Me.plantingSetup_Day.Validating, AddressOf Me.Validating1to366

        AddHandler Me.plantingSetup_cropName.Validated, AddressOf Me.PassedValidation
        AddHandler Me.plantingSetup_Year.Validated, AddressOf Me.PassedValidation
        AddHandler Me.plantingSetup_Day.Validated, AddressOf Me.PassedValidation

        '====================================== Tillage ================================================
        AddHandler Me.tillSetup_Year.Validating, AddressOf Me.ValidatingComboBoxValue
        AddHandler Me.tillSetup_Day.Validating, AddressOf Me.Validating1to366
        AddHandler Me.tillSetup_Depth.Validating, AddressOf Me.ValidatingPositiveDoubleInput
        AddHandler Me.tillSetup_SDR.Validating, AddressOf Me.ValidatingPositiveIntegerInput
        AddHandler Me.tillSetup_ME.Validating, AddressOf Me.ValidatingPositiveDoubleInput

        AddHandler Me.tillSetup_Year.Validated, AddressOf Me.PassedValidation
        AddHandler Me.tillSetup_Day.Validated, AddressOf Me.PassedValidation
        AddHandler Me.tillSetup_Depth.Validated, AddressOf Me.PassedValidation
        AddHandler Me.tillSetup_SDR.Validated, AddressOf Me.PassedValidation
        AddHandler Me.tillSetup_ME.Validated, AddressOf Me.PassedValidation

        '====================================== Fixed Irrigation =======================================
        AddHandler Me.fixedIrrSetup_Year.Validating, AddressOf Me.ValidatingComboBoxValue
        AddHandler Me.fixedIrrSetup_Day.Validating, AddressOf Me.Validating1to366
        AddHandler Me.fixedIrrSetup_Volume.Validating, AddressOf Me.ValidatingPositiveDoubleInput

        AddHandler Me.fixedIrrSetup_Year.Validated, AddressOf Me.PassedValidation
        AddHandler Me.fixedIrrSetup_Day.Validated, AddressOf Me.PassedValidation
        AddHandler Me.fixedIrrSetup_Volume.Validated, AddressOf Me.PassedValidation

        '====================================== Automatic Irrigation ===================================
        AddHandler Me.autoIrrSetup_Name.Validating, AddressOf Me.ValidatingComboBoxValue
        AddHandler Me.autoIrrSetup_StartDay.Validating, AddressOf Me.Validating1to366
        AddHandler Me.autoIrrSetup_StopDay.Validating, AddressOf Me.Validating1to366
        AddHandler Me.autoIrrSetup_WaterDepletion.Validating, AddressOf Me.Validating0to1
        AddHandler Me.autoIrrSetup_LastSoilLayer.Validating, AddressOf Me.ValidatingComboBoxValue

        AddHandler Me.autoIrrSetup_Name.Validated, AddressOf Me.PassedValidation
        AddHandler Me.autoIrrSetup_StartDay.Validated, AddressOf Me.PassedValidation
        AddHandler Me.autoIrrSetup_StopDay.Validated, AddressOf Me.PassedValidation
        AddHandler Me.autoIrrSetup_WaterDepletion.Validated, AddressOf Me.PassedValidation
        AddHandler Me.autoIrrSetup_LastSoilLayer.Validated, AddressOf Me.PassedValidation

        '====================================== Fixed Fertilization ====================================
        AddHandler Me.fixedFertSetup_Year.Validating, AddressOf Me.ValidatingComboBoxValue
        AddHandler Me.fixedFertSetup_Day.Validating, AddressOf Me.Validating1to366
        AddHandler Me.fixedFertSetup_Form.Validating, AddressOf Me.ValidatingComboBoxValue
        AddHandler Me.fixedFertSetup_Layer.Validating, AddressOf Me.ValidatingComboBoxValue
        AddHandler Me.fixedFertSetup_Mass.Validating, AddressOf Me.ValidatingPositiveDoubleInput
        AddHandler Me.fixedFertSetup_C_Organic.Validating, AddressOf Me.ValidatingPositiveDoubleInput
        AddHandler Me.fixedFertSetup_C_Charcoal.Validating, AddressOf Me.ValidatingPositiveDoubleInput
        AddHandler Me.fixedFertSetup_N_Organic.Validating, AddressOf Me.ValidatingPositiveDoubleInput
        AddHandler Me.fixedFertSetup_N_Charcoal.Validating, AddressOf Me.ValidatingPositiveDoubleInput
        AddHandler Me.fixedFertSetup_N_NH4.Validating, AddressOf Me.ValidatingPositiveDoubleInput
        AddHandler Me.fixedFertSetup_N_NO3.Validating, AddressOf Me.ValidatingPositiveDoubleInput
        AddHandler Me.fixedFertSetup_P_Organic.Validating, AddressOf Me.ValidatingPositiveDoubleInput
        AddHandler Me.fixedFertSetup_P_Charcoal.Validating, AddressOf Me.ValidatingPositiveDoubleInput
        AddHandler Me.fixedFertSetup_P_Inorganic.Validating, AddressOf Me.ValidatingPositiveDoubleInput
        AddHandler Me.fixedFertSetup_K.Validating, AddressOf Me.ValidatingPositiveDoubleInput
        AddHandler Me.fixedFertSetup_S.Validating, AddressOf Me.ValidatingPositiveDoubleInput

        AddHandler Me.fixedFertSetup_Year.Validated, AddressOf Me.PassedValidation
        AddHandler Me.fixedFertSetup_Day.Validated, AddressOf Me.PassedValidation
        AddHandler Me.fixedFertSetup_Form.Validated, AddressOf Me.PassedValidation
        AddHandler Me.fixedFertSetup_Layer.Validated, AddressOf Me.PassedValidation
        AddHandler Me.fixedFertSetup_Mass.Validated, AddressOf Me.PassedValidation
        AddHandler Me.fixedFertSetup_C_Organic.Validated, AddressOf Me.PassedValidation
        AddHandler Me.fixedFertSetup_C_Charcoal.Validated, AddressOf Me.PassedValidation
        AddHandler Me.fixedFertSetup_N_Organic.Validated, AddressOf Me.PassedValidation
        AddHandler Me.fixedFertSetup_N_Charcoal.Validated, AddressOf Me.PassedValidation
        AddHandler Me.fixedFertSetup_N_NH4.Validated, AddressOf Me.PassedValidation
        AddHandler Me.fixedFertSetup_N_NO3.Validated, AddressOf Me.PassedValidation
        AddHandler Me.fixedFertSetup_P_Organic.Validated, AddressOf Me.PassedValidation
        AddHandler Me.fixedFertSetup_P_Charcoal.Validated, AddressOf Me.PassedValidation
        AddHandler Me.fixedFertSetup_P_Inorganic.Validated, AddressOf Me.PassedValidation
        AddHandler Me.fixedFertSetup_K.Validated, AddressOf Me.PassedValidation
        AddHandler Me.fixedFertSetup_S.Validated, AddressOf Me.PassedValidation

        '====================================== Auto Fertilization =====================================
        AddHandler Me.autoFertSetup_Name.Validating, AddressOf Me.ValidatingComboBoxValue
        AddHandler Me.autoFertSetup_StartDay.Validating, AddressOf Me.Validating1to366
        AddHandler Me.autoFertSetup_EndDay.Validating, AddressOf Me.Validating1to366
        AddHandler Me.autoFertSetup_Source.Validating, AddressOf Me.ValidatingComboBoxValue
        AddHandler Me.autoFertSetup_Form.Validating, AddressOf Me.ValidatingComboBoxValue
        AddHandler Me.autoFertSetup_Method.Validating, AddressOf Me.ValidatingComboBoxValue
        AddHandler Me.autoFertSetup_Mass.Validating, AddressOf Me.ValidatingPositiveDoubleInput

        AddHandler Me.autoFertSetup_Name.Validated, AddressOf Me.PassedValidation
        AddHandler Me.autoFertSetup_StartDay.Validated, AddressOf Me.PassedValidation
        AddHandler Me.autoFertSetup_EndDay.Validated, AddressOf Me.PassedValidation
        AddHandler Me.autoFertSetup_Source.Validated, AddressOf Me.PassedValidation
        AddHandler Me.autoFertSetup_Form.Validated, AddressOf Me.PassedValidation
        AddHandler Me.autoFertSetup_Method.Validated, AddressOf Me.PassedValidation
        AddHandler Me.autoFertSetup_Mass.Validated, AddressOf Me.PassedValidation

    End Sub

    Private Sub ValidatingComboBoxValue(ByVal sender As System.Windows.Forms.ComboBox, ByVal e As System.ComponentModel.CancelEventArgs)
        Dim errorText As String = "Selected value not listed:  " & sender.Text
        Dim found As Boolean = False

        If sender.Text.Trim <> Nothing Then
            For Each listVal As String In sender.Items
                If listVal = sender.Text Then
                    found = True
                    Exit For
                End If
            Next

            If Not found Then
                FailedValidation(sender, e, errorText)
            End If
        End If
    End Sub

    Private Sub ValidatingPositiveIntegerInput(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        Dim errorText As String = "Positive integer value required:  " & sender.Text

        If sender.Text.Trim <> Nothing Then
            Try
                Dim temp As Integer = Integer.Parse(sender.Text)
            Catch
                FailedValidation(sender, e, errorText)
            End Try

            If sender.Text < 0 Then
                FailedValidation(sender, e, errorText)
            End If
        End If
    End Sub

    Private Sub ValidatingPositiveDoubleInput(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        Dim errorText As String = "Positive numerical value required:  " & sender.Text

        If sender.Text.Trim <> Nothing Then
            If Not IsNumeric(sender.Text) Then
                FailedValidation(sender, e, errorText)

            ElseIf sender.Text < 0 Then
                FailedValidation(sender, e, errorText)
            End If
        End If
    End Sub

    Private Sub Validating0toPoint08(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        Dim errorText As String = "Positive value between 0 and 0.08 required:  " & sender.Text

        If sender.Text.Trim <> Nothing Then
            If Not IsNumeric(sender.Text) Then
                FailedValidation(sender, e, errorText)

            ElseIf sender.Text > 0.08 Or sender.Text < 0 Then
                FailedValidation(sender, e, errorText)

            End If
        End If
    End Sub

    Private Sub Validating0to1(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        Dim errorText As String = "Positive value between 0 and 1 required:  " & sender.Text

        If sender.Text.Trim <> Nothing Then
            If Not IsNumeric(sender.Text) Then
                FailedValidation(sender, e, errorText)

            ElseIf sender.Text > 1 Or sender.Text < 0 Then
                FailedValidation(sender, e, errorText)

            End If
        End If
    End Sub

    Private Sub Validating0to2(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        Dim errorText As String = "Positive value between 0 and 2 required:  " & sender.Text

        If sender.Text.Trim <> Nothing Then
            If Not IsNumeric(sender.Text) Then
                FailedValidation(sender, e, errorText)

            ElseIf sender.Text > 2 Or sender.Text < 0 Then
                FailedValidation(sender, e, errorText)

            End If
        End If
    End Sub

    Private Sub Validating0to5(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        Dim errorText As String = "Positive value between 0 and 5 required:  " & sender.Text

        If sender.Text.Trim <> Nothing Then
            If Not IsNumeric(sender.Text) Then
                FailedValidation(sender, e, errorText)

            ElseIf sender.Text > 5 Or sender.Text < 0 Then
                FailedValidation(sender, e, errorText)

            End If
        End If
    End Sub

    Private Sub Validating0to15(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        Dim errorText As String = "Positive value between 0 and 15 required:  " & sender.Text

        If sender.Text.Trim <> Nothing Then
            If Not IsNumeric(sender.Text) Then
                FailedValidation(sender, e, errorText)

            ElseIf sender.Text > 15 Or sender.Text < 0 Then
                FailedValidation(sender, e, errorText)

            End If
        End If
    End Sub

    Private Sub ValidatingNeg50to50(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        Dim errorText As String = "Numerical value between -50 and 50 required:  " & sender.Text

        If sender.Text.Trim <> Nothing Then
            If Not IsNumeric(sender.Text) Then
                FailedValidation(sender, e, errorText)

            ElseIf Math.Abs(CDbl(sender.Text)) > 50 Then
                FailedValidation(sender, e, errorText)

            End If
        End If
    End Sub

    Private Sub Validating0to100(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        Dim errorText As String = "Positive value between 0 and 100 required:  " & sender.Text

        If sender.Text.Trim <> Nothing Then
            If Not IsNumeric(sender.Text) Then
                FailedValidation(sender, e, errorText)

            ElseIf sender.Text > 100 Or sender.Text < 0 Then
                FailedValidation(sender, e, errorText)
            End If
        End If
    End Sub

    Private Sub Validating1to366(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        Dim errorText As String = "Positive value between 1 and 366 required:  " & sender.Text

        If sender.Text.Trim <> Nothing Then
            Try
                Dim temp As Integer = Integer.Parse(sender.Text)
            Catch
                FailedValidation(sender, e, errorText)
            End Try

            If sender.Text > 366 Or sender.Text < 1 Then
                FailedValidation(sender, e, errorText)
            End If
        End If
    End Sub

    'Private Sub ValidatingMonthDay(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
    '    Dim errorText As String = "Date value expected (ex: May 31):  " & sender.Text

    '    If sender.Text.Trim <> Nothing Then
    '        Try
    '            Dim temp As Date = sender.Text
    '        Catch
    '            FailedValidation(sender, e, errorText)
    '        End Try
    '    End If
    'End Sub

    Private Sub Validating0to500(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        Dim errorText As String = "Positive value between 0 and 500 required:  " & sender.Text

        If sender.Text.Trim <> Nothing Then
            If Not IsNumeric(sender.Text) Then
                FailedValidation(sender, e, errorText)

            ElseIf sender.Text > 500 Or sender.Text < 0 Then
                FailedValidation(sender, e, errorText)

            End If
        End If
    End Sub

    Private Sub ValidatingSoilSlope(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        Dim errorText As String = "Positive value between 0.0 and 0.9 required:  " & sender.Text

        If sender.Text.Trim <> Nothing Then
            If Not IsNumeric(sender.Text) Then
                FailedValidation(sender, e, errorText)

            ElseIf sender.Text > 0.9 Or sender.Text <= 0 Then
                FailedValidation(sender, e, errorText)
            End If
        End If
    End Sub

    Private Sub PassedValidation(ByVal sender As Object, ByVal e As System.EventArgs)
        sender.BackColor = Color.White
        inputErrorProvider.SetError(sender, "")
    End Sub

    Private Sub FailedValidation(ByRef sender As Object, ByRef e As System.ComponentModel.CancelEventArgs, ByVal errorText As String)
        e.Cancel = True
        sender.BackColor = Color.Red
        sender.Select(0, sender.Text.Length)
        inputErrorProvider.SetError(sender, errorText)
    End Sub

End Class
