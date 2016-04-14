Option Explicit On

Friend Module LinkedLists

    Public Class LinkedList
        Private firstNode As Node
        Private lastNode As Node
        Private currentNode As Node

        Public Sub New()
            firstNode = Nothing
            lastNode = Nothing
            currentNode = Nothing
        End Sub

        Public Sub RemoveFromFront()
            If Not IsEmpty() Then
                If firstNode Is lastNode Then
                    firstNode = Nothing
                    lastNode = Nothing
                Else
                    firstNode = firstNode.Link
                End If
            End If
        End Sub

        Public Sub RemoveFromBack()
            Dim current As Node = firstNode

            If Not IsEmpty() Then
                If firstNode Is lastNode Then
                    lastNode = Nothing
                    firstNode = Nothing
                Else
                    current = firstNode

                    While Not (current.Link Is lastNode)
                        current = current.Link
                    End While

                    lastNode = current
                    lastNode.Link = Nothing
                End If
            End If
        End Sub

        Public Sub InsertHead(ByVal ParamArray data() As Object)
            If IsEmpty() Then
                lastNode = New Node(data)
                firstNode = lastNode
            Else
                Dim newNode As Node = New Node(data)
                newNode.Link = firstNode
                firstNode = newNode
            End If
        End Sub

        Public Sub InsertTail(ByVal ParamArray data() As Object)
            If IsEmpty() Then
                Me.lastNode = New Node(data)
                Me.firstNode = Me.lastNode
            Else
                Me.lastNode.Link = New Node(data)
                Me.lastNode = Me.lastNode.Link
            End If
        End Sub

        Public Sub Insert(ByVal ParamArray newData() As Object)
            Dim newNode As Node

            newNode = New Node(newData)
            newNode.Link = currentNode.Link
            currentNode.Link = newNode
        End Sub

        Public Sub DeleteNode(ByVal data As Object)
            Dim current As Node = firstNode
            Dim deletedNode As Node

            If Not IsEmpty() Then
                If CStr(data) = CStr(firstNode.NodeData(0)) Then
                    deletedNode = firstNode
                    firstNode = firstNode.Link
                    deletedNode = Nothing
                Else
                    While Not (current.Link Is lastNode)
                        If data = current.Link.NodeData(0) Then
                            deletedNode = current.Link.Link
                            current.Link = current.Link.Link
                            deletedNode = Nothing
                            Exit While
                        End If

                        current = current.Link
                    End While
                End If

                If IsEmpty() Then currentNode = Nothing
            End If
        End Sub

        Public Sub SelectFirstNode()
            currentNode = Me.firstNode
        End Sub

        Public Sub SelectNextNode()
            If currentNode IsNot Nothing Then
                If currentNode.Link IsNot Nothing Then
                    currentNode = currentNode.Link
                Else
                    currentNode = Nothing
                End If
            End If
        End Sub

        Public Sub SelectLastNode()
            currentNode = lastNode
        End Sub

        Public Function IsEmpty() As Boolean
            If firstNode Is Nothing Then
                Return True
            Else
                Return False
            End If
        End Function

        Public Property Data(ByVal pos As Integer) As Object
            Get
                If currentNode IsNot Nothing Then
                    Return currentNode.NodeData(pos)
                Else
                    Return Nothing
                End If
            End Get
            Set(ByVal value As Object)
                If currentNode IsNot Nothing Then
                    currentNode.NodeData(pos) = value
                End If
            End Set
        End Property

        Public ReadOnly Property LinkData(ByVal pos As Integer) As Object
            Get
                If currentNode.Link IsNot Nothing Then
                    Return currentNode.Link.NodeData(pos)
                Else
                    Return Nothing
                End If
            End Get
        End Property

    End Class

    Private Class Node
        Private mData(0) As Object
        Private mNextNode As Node

        Public Sub New(ByVal ParamArray data() As Object)
            If UBound(data) > 0 Then
                ReDim mData(UBound(data))
            End If

            For i As Integer = 0 To UBound(data)
                mData(i) = data(i)
            Next

            mNextNode = Nothing
        End Sub

        Public Property NodeData(ByVal index As Integer) As Object
            Get
                Return mData(index)
            End Get
            Set(ByVal value As Object)
                Me.mData(index) = value
            End Set
        End Property
        Public Property Link() As Node
            Get
                Return mNextNode
            End Get
            Set(ByVal value As Node)
                mNextNode = value
            End Set
        End Property

    End Class

End Module
