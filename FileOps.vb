'DO NOT IMPORT FROM VBA
Option Explicit On

Friend Module FileOps
    Private Const dialogFilter As String = "Excel 97-2003 Workbook(*.xls)|*.xls|" & _
                                           "Excel Workbook(*.xlsx)|*.xlsx|" & _
                                           "Excel Macro Enabled Workbook(*.xlsm)|*.xlsm|" & _
                                           "Excel Binary Workbook(*.xlsb)|*.xlsb|" & _
                                           "All files|*.*"

    Public Function SelectFile(ByVal Title_Bar As String, ByRef fileName As String) As Boolean
        'Precondition:  none
        'Postcondition: True returned: File selected for read/write, filename updated
        '               False returned: Error encountered

        Dim xcFileDialog As New OpenFileDialog()

        xcFileDialog.AddExtension = True
        xcFileDialog.Title = Title_Bar
        xcFileDialog.Filter = dialogFilter

        If xcFileDialog.ShowDialog = DialogResult.OK Then
            System.Windows.Forms.Application.DoEvents() 'clears out popups from display cache

            If xcFileDialog.CheckFileExists Then
                If IsFileOpen(xcFileDialog.FileName) Then
                    Return False
                Else
                    fileName = xcFileDialog.FileName
                    Return True
                End If
            Else
                MsgBox("File Not Found", MsgBoxStyle.Exclamation, Title_Bar)
                Return False
            End If
        End If
    End Function

    Public Function CreateFile_FilenamePassed(ByVal fileName As String, ByRef fileReplaced As Boolean, ByVal overwrite As Boolean, _
                                              ByVal myExcel As Excel.Application, ByRef myWorkbook As Excel.Workbook) As Boolean
        'Precondition:  Excel has been started
        'Postcondition: True returned: Output workbook file has been created
        '               False returned: Outfile not created due to error

        Dim xcFileInfo As New IO.FileInfo(fileName)

        If xcFileInfo.Exists And Not overwrite Then
            Return False

        ElseIf xcFileInfo.Exists And overwrite Then
            Try
                xcFileInfo.Delete()
            Catch ex As Exception
                MsgBox(Err.Description, MsgBoxStyle.Critical, MainForm.ProductName)
                Return False
            End Try

            fileReplaced = True
        End If

        System.Windows.Forms.Application.DoEvents() 'clears out popups from display cache

        Try
            myWorkbook = myExcel.Workbooks.Add
        Catch ex As Exception
            MsgBox(Err.Description, MsgBoxStyle.Critical, MainForm.ProductName)
            Return False
        End Try

        Call CreateMandatorySheets(myWorkbook)

        myWorkbook.SaveAs(xcFileInfo.FullName)
        Return True
    End Function

    Public Function CreateFile_GUI(ByVal title As String, ByRef fileName As String, ByRef fileReplaced As Boolean, _
                               ByVal myExcel As Excel.Application, ByRef myWorkbook As Excel.Workbook) As Boolean
        'Precondition:  Excel has been started
        'Postcondition: True returned: Output workbook file has been created
        '               False returned: Outfile not created due to error

        Dim xcFileDialog As New SaveFileDialog
        Dim xcFileInfo As IO.FileInfo

        xcFileDialog.FileName = fileName
        xcFileDialog.Title = title
        xcFileDialog.AddExtension = True
        xcFileDialog.Filter = dialogFilter

        If xcFileDialog.ShowDialog = DialogResult.OK Then
            xcFileInfo = New IO.FileInfo(xcFileDialog.FileName)
            fileName = xcFileDialog.FileName

            If xcFileInfo.Exists Then
                Try
                    xcFileInfo.Delete()
                Catch ex As Exception
                    MsgBox(Err.Description, MsgBoxStyle.Critical, MainForm.ProductName)
                    Return False
                End Try

                fileReplaced = True
            End If

            System.Windows.Forms.Application.DoEvents() 'clears out popups from display cache

            Try
                myWorkbook = myExcel.Workbooks.Add
            Catch ex As Exception
                MsgBox(Err.Description, MsgBoxStyle.Critical, MainForm.ProductName)
                Return False
            End Try

            Call CreateMandatorySheets(myWorkbook)

            myWorkbook.SaveAs(xcFileInfo.FullName)
            Return True
        Else
            Return False
        End If
    End Function

    Public Function FileExists(ByRef FileFullPath As String) As Boolean
        'Precondition:  none
        'Postcondition: True returned: file found
        '               False returned: file not found

        If Trim(FileFullPath) <> Nothing Then
            Dim f As New System.IO.FileInfo(FileFullPath)
            Return f.Exists
        Else
            Return False
        End If

    End Function

    Public Function IsFileOpen(ByVal fileName As String) As Boolean
        'Precondition:  File does exists
        'Postcondition: True returned: No error
        '               False returned: Displays error message

        Dim sr As IO.Stream

        ' Attempt to open the file and lock it.
        On Error Resume Next                    ' No Error checking

        sr = IO.File.Open(fileName, IO.FileMode.Open)
        sr.Close()

        On Error GoTo 0                         ' Turn error checking back on.

        Select Case Err.Number
            Case 0
                IsFileOpen = False
            Case Else
                IsFileOpen = True
                MsgBox(Err.Description, vbExclamation, MainForm.ProductName)
        End Select
    End Function

    Public Function WorksheetExists(ByRef name As String, ByRef wb As Excel.Workbook) As Boolean
        'Precondition:  Workbook has been assigned 
        'Postcondition: True returned: Sheet found
        '               False returned: Sheet missing, displays error message

        Dim ws As Excel.Worksheet

        For Each ws In wb.Worksheets
            If UCase(ws.Name) = UCase(name) Then Return True
        Next

        MsgBox("Worksheet not found: " & name, MsgBoxStyle.Information, MainForm.ProductName)
        Return False
    End Function

    Public Sub CreateMandatorySheets(ByRef myWorkbook As Excel.Workbook)
        'Precondition:  Empty Workbook has been assigned 
        'Postcondition: Mandatory sheets create and named

        For i As Integer = (myWorkbook.Worksheets.Count + 1) To 9
            myWorkbook.Worksheets.Add(After:=myWorkbook.Worksheets.Item(i - 1))
        Next

        With myWorkbook
            .Sheets(1).name = "Simulation Controls"
            .Sheets(2).name = "Soil"
            .Sheets(3).name = "Crop Descriptions"
            .Sheets(4).name = "Planting Order"
            .Sheets(5).name = "Tillage"
            .Sheets(6).name = "Fixed Irrigation"
            .Sheets(7).name = "Fixed Fertilization"
            .Sheets(8).name = "Automatic Irrigation"
            .Sheets(9).name = "Automatic Fertilization"
        End With
    End Sub

    Public Sub CreateResultSheets(ByVal myWorkbook As Excel.Workbook, ByVal dailyCrop As Boolean, ByVal dailySoil As Boolean, _
                                  ByVal dailyNitrogen As Boolean, ByVal dailyWater As Boolean, ByVal dailyWeather As Boolean, _
                                  ByVal dailyResidue As Boolean, ByVal dailySoilCarbon As Boolean, ByVal annualSoil As Boolean, _
                                  ByVal annualProfile As Boolean, ByVal seasonOuts As Boolean)

        'default mandatory outputs
        myWorkbook.Worksheets.Add(After:=myWorkbook.Worksheets.Item(myWorkbook.Worksheets.Count))
        myWorkbook.Sheets(myWorkbook.Worksheets.Count).name = "Soil Carbon Totals"

        myWorkbook.Worksheets.Add(After:=myWorkbook.Worksheets.Item(myWorkbook.Worksheets.Count))
        myWorkbook.Sheets(myWorkbook.Worksheets.Count).name = "Soil Carbon Evolution"

        'optional outputs
        If dailyCrop Or dailySoil Or dailyNitrogen Or dailyWater Or dailyWeather Or dailyResidue Or dailySoilCarbon Then
            myWorkbook.Worksheets.Add(After:=myWorkbook.Worksheets.Item(myWorkbook.Worksheets.Count))
            myWorkbook.Sheets(myWorkbook.Worksheets.Count).name = "Daily Outputs"
        End If

        If annualSoil Then
            myWorkbook.Worksheets.Add(After:=myWorkbook.Worksheets.Item(myWorkbook.Worksheets.Count))
            myWorkbook.Sheets(myWorkbook.Worksheets.Count).name = "Annual Soil Outputs"
        End If

        If annualProfile Then
            myWorkbook.Worksheets.Add(After:=myWorkbook.Worksheets.Item(myWorkbook.Worksheets.Count))
            myWorkbook.Sheets(myWorkbook.Worksheets.Count).name = "Annual Soil Profile"
        End If

        If seasonOuts Then
            myWorkbook.Worksheets.Add(After:=myWorkbook.Worksheets.Item(myWorkbook.Worksheets.Count))
            myWorkbook.Sheets(myWorkbook.Worksheets.Count).name = "Season Output"
        End If
    End Sub

End Module
