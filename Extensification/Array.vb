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

    End Module
End Namespace
