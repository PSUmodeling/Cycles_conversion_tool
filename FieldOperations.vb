Option Explicit On

Friend MustInherit Class FieldOperationsBaseClass
    'Private to this class and any classes that inherit this class
    Protected opList As LinkedList
    Protected opYear As Integer
    Protected opDay As Integer

    Public Sub New()
        Me.opList = New LinkedList

        Me.opYear = -1
        Me.opDay = -1
    End Sub

    Public Sub SelectNextOperation()
        'Precondition:  none
        'Postcondition: next operation in the list selected, if any

        Call Me.opList.SelectNextNode()

        If Me.opList.Data(0) IsNot Nothing Then
            Me.opYear = Me.opList.Data(0)
            Me.opDay = Me.opList.Data(1)
        Else
            Me.opYear = -1
            Me.opDay = -1
        End If
    End Sub

    Public Sub SelectFirstOperation()
        'Precondition:  none
        'Postcondition: first operation in the list selected, if any

        Call Me.opList.SelectFirstNode()

        If Me.opList.Data(0) IsNot Nothing Then
            Me.opYear = Me.opList.Data(0)
            Me.opDay = Me.opList.Data(1)
        Else
            Me.opYear = -1
            Me.opDay = -1
        End If
    End Sub

    Public Sub SelectOperationYear(ByVal rotationYear As Integer)
        'Precondition:  1 <= rotationYear <= MAX_ROTATION_YEARS 
        'Postcondition: active operation assigned to passed year
        '               active operation reset to 0

        If rotationYear > 0 Then
            Call SelectFirstOperation()

            Do Until CInt(Me.opList.Data(0)) >= rotationYear Or CInt(Me.opList.Data(0)) = Nothing
                Call Me.SelectNextOperation()
            Loop
        Else
            MsgBox("Field operations attempting to be passed an invalid year: " & rotationYear, MsgBoxStyle.Critical, MainForm.ProductName & ": SetActiveOperationYear")
        End If
    End Sub

    Protected Sub AddOperation(ByVal ParamArray parameterList() As Object)
        'Precondition:  passed values are valid and not empty
        'Postcondition: operation added to list sorted in ascending order by year and day

        'data(0) = year
        'data(1) = day
        'data(2 - ???) = operation specific data

        Call Me.SelectFirstOperation()

        If Me.opList.IsEmpty Then                                   'check for empty list
            Call Me.opList.InsertHead(parameterList)

        ElseIf parameterList(0) < Me.opList.Data(0) And parameterList(1) < Me.opList.Data(1) Then 'check head
            Call Me.opList.InsertHead(parameterList)

        Else                                                        'check body
            Do Until Me.opList.LinkData(0) Is Nothing               'find insert position
                If parameterList(0) < Me.opList.LinkData(0) And parameterList(1) < Me.opList.LinkData(1) Then
                    Call Me.opList.Insert(parameterList)
                    Exit Sub
                End If

                Call Me.SelectNextOperation()
            Loop

            Call Me.opList.InsertTail(parameterList)                'add new tail node if unable to insert in body
        End If

    End Sub

    Public Function IsOperationToday(ByVal rotationYear As Integer, ByVal doy As Integer) As Boolean
        'Precondition:  nextOpDay is reset at the beginning of each year to a non-calender day
        '               1 <= doy <= 366
        'Postcondition: returns a true or false indicating if an operation happens on that day

        If rotationYear = Me.opYear And doy = Me.opDay Then
            Return True
        Else
            Return False
        End If
    End Function

    Public ReadOnly Property opOperationYear() As Integer
        Get
            Return Me.opYear
        End Get
    End Property
    Public ReadOnly Property opOperationDay() As Integer
        Get
            Return Me.opDay
        End Get
    End Property

End Class
