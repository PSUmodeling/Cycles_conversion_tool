Partial Friend Class MainForm
    Private Const ext As String = "Excel 97-2003 Workbook(*.xls)|*.xls|" & _
                                  "Excel Workbook(*.xlsx)|*.xlsx|" & _
                                  "Excel Macro Enabled Workbook(*.xlsm)|*.xlsm|" & _
                                  "Excel Binary Workbook(*.xlsb)|*.xlsb|" & _
                                  "All files|*.*"

    Private Sub duration_StartYear_Changed() Handles duration_StartYear.TextChanged, duration_StartYear.SelectedIndexChanged
        Call Me.CalculateTotalYears()
    End Sub
    Private Sub duration_StopYear_Changed() Handles duration_StopYear.TextChanged, duration_StopYear.SelectedIndexChanged
        Call Me.CalculateTotalYears()
    End Sub
    Private Function CalculateTotalYears() As Integer
        Const MAX_YEARS As Integer = 175          'max years using daily output. Excel limitation (365x175=63875, limit=65536)
        Dim startYear As String = duration_StartYear.Text
        Dim stopYear As String = duration_StopYear.Text
        Dim totYrs As Integer
        Dim rotSize As Integer

        If Me.duration_RotationSize.Text.Trim <> Nothing Then rotSize = Me.duration_RotationSize.Text

        ' calculate years in the simulation
        Me.duration_TotalYears.Text = Nothing
        Me.duration_RotationSize.Items.Clear()
        Me.duration_RotationSize.Items.Add("")

        If startYear.Trim <> Nothing And stopYear.Trim <> Nothing Then
            If startYear <= stopYear Then
                totYrs = CInt(stopYear) - CInt(startYear) + 1
                Me.duration_TotalYears.Text = totYrs

                If totYrs <= MAX_YEARS Then 'populate rotationSize combobox
                    Me.duration_labelTotalYearsError.Text = Nothing

                    With Me.duration_RotationSize
                        For i As Integer = 1 To totYrs
                            .Items.Add(i)
                        Next

                        If rotSize <= totYrs And rotSize > 0 Then
                            .Text = rotSize
                        Else
                            .Text = Nothing
                        End If
                    End With
                Else
                    Me.duration_labelTotalYearsError.Text = "Exceeded"
                End If
            End If
        End If
    End Function

    Private Sub duration_totalYears_Changed() Handles duration_TotalYears.TextChanged
        Call Me.CalculateTotalRotations()
    End Sub
    Private Sub duration_rotationSize_Changed() Handles duration_RotationSize.TextChanged, duration_RotationSize.SelectedIndexChanged
        Call Me.CalculateTotalRotations()
    End Sub
    Private Sub CalculateTotalRotations()
        Dim rot, tot As Integer

        If Me.duration_RotationSize.Text.Trim <> Nothing Then
            rot = Me.duration_RotationSize.Text.Trim
        Else
            rot = 0
        End If

        If Me.duration_TotalYears.Text.Trim <> Nothing Then
            tot = Me.duration_TotalYears.Text.Trim
        Else
            tot = 0
        End If

        If tot = 0 Then
            Me.duration_TotalRotations.Text = Nothing
            UpdateRotationYearsAvailable(0)

        ElseIf rot = 0 Then
            Me.duration_TotalRotations.Text = Nothing
            UpdateRotationYearsAvailable(0)

        Else
            Me.duration_TotalRotations.Text = Format(tot / rot, "0.00")
            UpdateRotationYearsAvailable(rot)
        End If

    End Sub

    Private Sub UpdateRotationYearsAvailable(ByVal rotationSize As Integer)
        'Precondition:  none
        'Postcondition: Available rotation years updated to match Simulation Controls information

        Me.plantingSetup_Year.Items.Clear()
        Me.tillSetup_Year.Items.Clear()
        Me.fixedIrrSetup_Year.Items.Clear()
        Me.fixedFertSetup_Year.Items.Clear()

        Me.plantingSetup_Year.Items.Add("")
        Me.tillSetup_Year.Items.Add("")
        Me.fixedIrrSetup_Year.Items.Add("")
        Me.fixedFertSetup_Year.Items.Add("")

        For i As Integer = 1 To rotationSize
            Me.plantingSetup_Year.Items.Add(i)
            Me.tillSetup_Year.Items.Add(i)
            Me.fixedIrrSetup_Year.Items.Add(i)
            Me.fixedFertSetup_Year.Items.Add(i)
        Next
    End Sub

    Private Sub SelectWeatherFile() Handles weatherFile_selectFileBtn.Click, weatherFile_Path.MouseDoubleClick
        'Precondition:  Excel started
        '               Weather file is in the correct format
        'Postcondition: Weatherfile path copied to interface
        '               Weatherfile dates copied to date comboboxes

        Dim fileName As String = Nothing
        Dim xcFileDialog As New OpenFileDialog()

        If SelectFile(Me.ProductName & ": Select Weather File", fileName) Then
            Me.weatherFile_Path.Text = fileName
            Call EditLog("Weather file selected", False)
        End If

    End Sub

    Private Sub SetResultsFilePath() Handles resultsFile_selectFileBtn.Click, resultsFile_Path.MouseDoubleClick
        'Precondition:  none
        'Postcondition: resultsFile field populated with a properly formatted filename and path

        Dim xcFileDialog As New SaveFileDialog

        xcFileDialog.Title = "Select Results File"
        xcFileDialog.AddExtension = True
        xcFileDialog.Filter = ext
        resultsFile_Overwrite.Checked = False

        If xcFileDialog.ShowDialog = DialogResult.OK Then
            resultsFile_Path.Text = xcFileDialog.FileName
            If FileExists(resultsFile_Path.Text) Then resultsFile_Overwrite.Checked = True
        End If
    End Sub

    Private Function CreateOutFile(ByVal myExcel As Excel.Application, ByRef myWorkBook As Excel.Workbook) As Boolean
        'Precondition:  Data verification completed
        '               Excel has been started
        'Postcondition: All output sheets to be used have been created in the workbook

        Dim fileReplaced As Boolean = False
        Dim fileCreated As Boolean

        If Me.resultsFile_Path.Text.Trim = Nothing Then
            Call Me.SetResultsFilePath()
        End If

        fileCreated = FileOps.CreateFile_FilenamePassed(Me.resultsFile_Path.Text, fileReplaced, Me.resultsFile_Overwrite.Checked, myExcel, myWorkBook)

        If fileCreated Then
            If fileReplaced Then
                Call Me.EditLog("Results file overwritten: " & Me.resultsFile_Path.Text, False)
            Else
                Call Me.EditLog("Results file created: " & Me.resultsFile_Path.Text, False)
            End If

            myWorkBook.Save()
            Return True
        Else
            Return False
        End If
    End Function

End Class
