'DO NOT IMPORT FROM VBA
Option Explicit On

Friend Module SideSubs

    Public Sub CopyrightInfo()
        MsgBox("        Contact Information:" & vbCr & _
               vbCr & _
               "Authored by:" & vbCr & _
               "        Armen R. Kemanian" & vbCr & _
               "        akemanian@psu.edu" & vbCr & _
               "        814 863 9852" & vbCr & _
               vbCr & _
               "        Claudio O. Stockle" & vbCr & _
               "        stockle@wsu.edu" & vbCr & _
               "        509 335 1578" & vbCr & _
               vbCr & _
               "Programmer:" & vbCr & _
               "        Shawn A. Quisenberry" & vbCr & _
               "        squisenberry@brc.tamus.edu" & vbCr & _
               "        254 774 6120" & vbCr & _
               vbCr & _
               "       Copyright © 2010-2015" & vbCr & _
               "                PSU / WSU" & vbCr & _
               "            All rights reserved", vbOKOnly, MainForm.ProductName)
    End Sub

    Public Sub WeatherFileDates(ByRef startDate As Object, ByRef endDate As Object, ByRef myWorkBook As Excel.Workbook)
        'Precondition:  Workbook has been assigned a valid value
        '               Weather file is in the correct format
        'Postcondition: Returns start and stop dates of the weather file

        Dim i, skip As Integer
        Dim sheet As String = "Weather"
        Dim myWorkSheet As Excel.Worksheet

        If WorksheetExists(sheet, myWorkBook) Then
            myWorkSheet = myWorkBook.Sheets.Item(sheet)

            i = 7
            skip = 350

            startDate = myWorkSheet.Range("$A$" & i).Text                        'stores start date of weather file

            Do
                i += skip                                            'Will check year up to twice per year, skip allows for a substantial speed boost
                endDate = myWorkSheet.Range("$A$" & i).Text
            Loop Until endDate.Trim = Nothing

            endDate = myWorkSheet.Range("$A$" & i - skip).Text
        End If
    End Sub

    Public Sub HeaderSettings(ByRef xlsRange As Range, ByVal adjustment As String)
        'Precondition:  xlsRange is not nothing
        'Postcondition: xlsRange settings set

        With xlsRange
            Select Case adjustment.ToLower
                Case "center"
                    .HorizontalAlignment = XlHAlign.xlHAlignCenter
                Case "right"
                    .HorizontalAlignment = XlHAlign.xlHAlignRight
                Case "left"
                    .HorizontalAlignment = XlHAlign.xlHAlignLeft
            End Select

            .Font.Size = 9
            .Interior.Color = RGB(153, 51, 102)
            .Font.Color = RGB(255, 255, 255)
            .Font.Name = "Arial"
        End With
    End Sub

    Public Sub TitleSettings(ByRef xlsRange As Range)
        'Precondition:  xlsRange is not nothing
        'Postcondition: xlsRange settings set

        With xlsRange
            .HorizontalAlignment = XlHAlign.xlHAlignLeft
            .Font.Bold = True
            .Font.Size = 12
            .Interior.Color = RGB(153, 51, 102)
            .Font.Color = RGB(255, 255, 255)
            .Font.Name = "Arial"
        End With
    End Sub

    Public Function ConvertToDate(ByVal doy As Integer, Optional ByVal LastDOY As Integer = 365) As String
        If LastDOY = 365 Then
            Select Case doy
                Case 1 To 31
                    Return "Jan " & doy - 0
                Case 32 To 59
                    Return "Feb " & doy - 31
                Case 60 To 90
                    Return "Mar " & doy - 59
                Case 91 To 120
                    Return "Apr " & doy - 90
                Case 121 To 151
                    Return "May " & doy - 120
                Case 152 To 181
                    Return "Jun " & doy - 151
                Case 182 To 212
                    Return "Jul " & doy - 181
                Case 213 To 243
                    Return "Aug " & doy - 212
                Case 244 To 273
                    Return "Sep " & doy - 243
                Case 274 To 304
                    Return "Oct " & doy - 273
                Case 305 To 334
                    Return "Nov " & doy - 304
                Case 335 To 365
                    Return "Dec " & doy - 334
            End Select

        Else
            Select Case doy
                Case 1 To 31
                    Return "Jan " & doy - 0
                Case 32 To 60
                    Return "Feb " & doy - 31
                Case 61 To 91
                    Return "Mar " & doy - 60
                Case 92 To 121
                    Return "Apr " & doy - 91
                Case 122 To 152
                    Return "May " & doy - 121
                Case 153 To 182
                    Return "Jun " & doy - 152
                Case 183 To 213
                    Return "Jul " & doy - 182
                Case 214 To 244
                    Return "Aug " & doy - 213
                Case 245 To 274
                    Return "Sep " & doy - 244
                Case 275 To 305
                    Return "Oct " & doy - 274
                Case 306 To 335
                    Return "Nov " & doy - 305
                Case 336 To 366
                    Return "Dec " & doy - 335
            End Select
        End If

        Return "ERROR"
    End Function
    Public Function ConvertToDOY(ByRef d As String) As Integer
        Dim mon As String = Left(d, 3)
        Dim doy As Integer

        For i As Integer = 1 To d.Length
            If Mid(d, i, 1) = " " Then
                doy = Right(d, d.Length - i)
                Exit For
            End If
        Next

        'If lastDOY = 365 Then
        Select Case mon
            Case "Jan"
                Return doy + 0 '1 To 31
            Case "Feb"
                Return doy + 31 '32 To 59
            Case "Mar"
                Return doy + 59 '60 To 90
            Case "Apr"
                Return doy + 90 '91 To 120
            Case "May"
                Return doy + 120 '121 To 151
            Case "Jun"
                Return doy + 151 '152 To 181
            Case "Jul"
                Return doy + 181 '182 To 212
            Case "Aug"
                Return doy + 212 '213 To 243
            Case "Sep"
                Return doy + 243 '244 To 273
            Case "Oct"
                Return doy + 273 '274 To 304
            Case "Nov"
                Return doy + 304 '305 To 334
            Case "Dec"
                Return doy + 334 '335 To 365
        End Select

        'Else
        'Select Case mon
        '    Case "Jan"
        '        Return doy + 0 '1 To 31
        '    Case "Feb"
        '        Return doy + 31 '32 To 60
        '    Case "Mar"
        '        Return doy + 60 '61 To 91
        '    Case "Apr"
        '        Return doy + 91 '92 To 121
        '    Case "May"
        '        Return doy + 121 '122 To 152
        '    Case "Jun"
        '        Return doy + 152 '153 To 182
        '    Case "Jul"
        '        Return doy + 182 '183 To 213
        '    Case "Aug"
        '        Return doy + 213 '214 To 244
        '    Case "Sep"
        '        Return doy + 244 '245 To 274
        '    Case "Oct"
        '        Return doy + 274 '275 To 305
        '    Case "Nov"
        '        Return doy + 305 '306 To 335
        '    Case "Dec"
        '        Return doy + 335 '336 To 366
        'End Select
        'End If

        Return "ERROR"
    End Function

    Public Function Maximum(ByVal ParamArray list() As Integer) As Integer
        Dim num As Integer

        If list.Length > 0 Then
            num = list(0)

            If list.Length > 1 Then
                For i As Integer = 1 To UBound(list)
                    If list(i) > num Then num = list(i)
                Next
            End If

            Return num
        Else
            Return Nothing
        End If
    End Function
    Public Function Maximum(ByVal ParamArray list() As Double) As Double
        Dim num As Integer

        If list.Length > 0 Then
            num = list(0)

            If list.Length > 1 Then
                For i As Integer = 1 To UBound(list)
                    If list(i) > num Then num = list(i)
                Next
            End If

            Return num
        Else
            Return Nothing
        End If
    End Function

    Public Function Minimum(ByVal ParamArray list() As Integer) As Integer
        Dim num As Integer

        If list.Length > 0 Then
            num = list(0)

            If list.Length > 1 Then
                For i As Integer = 1 To UBound(list)
                    If list(i) < num Then num = list(i)
                Next
            End If

            Return num
        Else
            Return Nothing
        End If
    End Function
    Public Function Minimum(ByVal ParamArray list() As Double) As Double
        Dim num As Double

        If list.Length > 0 Then
            num = list(0)

            If list.Length > 1 Then
                For i As Integer = 1 To UBound(list)
                    If list(i) < num Then num = list(i)
                Next
            End If

            Return num
        Else
            Return Nothing
        End If
    End Function

    Public Function Formatting(ByVal val As Double) As Double
        Return Format(val, "0.000000")
    End Function

End Module
