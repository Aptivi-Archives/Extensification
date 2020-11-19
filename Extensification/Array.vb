Imports System.Runtime.CompilerServices

Namespace ArrayExts
    Public Module Extensions

        ''' <summary>
        ''' Adds an entry to array
        ''' </summary>
        ''' <typeparam name="T">Type</typeparam>
        ''' <param name="TargetArray">Target array</param>
        ''' <param name="Item">Any item</param>
        ''' <returns>An array with added item</returns>
        <Extension>
        Public Function Add(Of T)(ByVal TargetArray() As T, ByVal Item As Object) As T()
            If TargetArray Is Nothing Then Throw New ArgumentNullException("TargetArray")
            ReDim Preserve TargetArray(TargetArray.Length)
            TargetArray(TargetArray.Length - 1) = Item
            Return TargetArray
        End Function

        ''' <summary>
        ''' Removes an entry from array
        ''' </summary>
        ''' <typeparam name="T">Type</typeparam>
        ''' <param name="TargetArray">Target array</param>
        ''' <param name="Item">Any item</param>
        ''' <returns>An array without targeted item</returns>
        <Extension>
        Public Function Remove(Of T)(ByVal TargetArray() As T, ByVal Item As Object) As T()
            If TargetArray Is Nothing Then Throw New ArgumentNullException("TargetArray")
            Dim TargetArrayList As List(Of T) = TargetArray.ToList
            TargetArrayList.Remove(Item)
            Return TargetArrayList.ToArray()
        End Function

        ''' <summary>
        ''' COnverts array to array list
        ''' </summary>
        ''' <typeparam name="T">Type</typeparam>
        ''' <param name="TargetArray">Target array</param>
        ''' <returns>An array list of an array</returns>
        <Extension>
        Public Function ToArrayList(Of T)(ByVal TargetArray() As T) As ArrayList
            If TargetArray Is Nothing Then Throw New ArgumentNullException("TargetArray")
            Dim ArrayValues As New ArrayList
            ArrayValues.AddRange(TargetArray)
            Return ArrayValues
        End Function

        ''' <summary>
        ''' Gets index from entry
        ''' </summary>
        ''' <typeparam name="T">Type</typeparam>
        ''' <param name="TargetArray">Target array</param>
        ''' <param name="Entry">An entry from array</param>
        ''' <returns>List of indexes. If none is found, returns an empty array list</returns>
        <Extension>
        Public Function GetIndexFromEntry(Of T)(ByVal TargetArray() As T, ByVal Entry As String) As T()
            If TargetArray Is Nothing Then Throw New ArgumentNullException("TargetArray")
            Dim Indexes As New ArrayList
            For Index As Integer = 0 To TargetArray.Length - 1
                Dim ArrayEntry As Object = TargetArray(Index)
                If ArrayEntry = Entry Then
                    Indexes.Add(Index)
                End If
            Next
            Return Indexes.ToArray(GetType(T))
        End Function

        ''' <summary>
        ''' Gets how many non-empty items are there
        ''' </summary>
        ''' <typeparam name="T">Type</typeparam>
        ''' <param name="TargetArray">Target array</param>
        ''' <returns>Count of non-empty items</returns>
        <Extension>
        Public Function CountFullEntries(Of T)(TargetArray() As T) As Long
            Dim FullEntries As Long
            For i As Long = 0 To TargetArray.LongCount - 1
                If TargetArray(i) IsNot Nothing Then
                    If TypeOf TargetArray(i) Is String Then
                        If Not TargetArray(i).Equals("") Then
                            FullEntries += 1
                        End If
                    Else
                        FullEntries += 1
                    End If
                End If
            Next
            Return FullEntries
        End Function

        ''' <summary>
        ''' Gets how many empty items are there
        ''' </summary>
        ''' <typeparam name="T">Type</typeparam>
        ''' <param name="TargetArray">Target array</param>
        ''' <returns>Count of empty items</returns>
        <Extension>
        Public Function CountEmptyEntries(Of T)(TargetArray() As T) As Long
            Dim EmptyEntries As Long
            For i As Long = 0 To TargetArray.LongCount - 1
                If TargetArray(i) Is Nothing Then
                    EmptyEntries += 1
                ElseIf TypeOf TargetArray(i) Is String And TargetArray(i).Equals("") Then
                    EmptyEntries += 1
                End If
            Next
            Return EmptyEntries
        End Function

    End Module
End Namespace
