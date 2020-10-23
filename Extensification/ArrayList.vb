Imports System.Runtime.CompilerServices

Namespace ArrayListExts
    Public Module Extensions

        ''' <summary>
        ''' Converts an array list to list of <see cref="Object"/>.
        ''' </summary>
        ''' <param name="TargetArray">Target array list</param>
        ''' <returns>A list from array list</returns>
        <Extension>
        Public Function ToList(ByVal TargetArray As ArrayList) As List(Of Object)
            If TargetArray Is Nothing Then Throw New ArgumentNullException("TargetArray")
            Dim ArrayValues As New List(Of Object)
            ArrayValues.AddRange(TargetArray)
            Return ArrayValues
        End Function

        ''' <summary>
        ''' Gets index of an entry from the list
        ''' </summary>
        ''' <param name="TargetArray">Target array list</param>
        ''' <param name="Entry">An entry found in the list</param>
        ''' <returns>List of indexes. If none is found, returns an empty array list</returns>
        <Extension>
        Public Function GetIndexOfEntry(ByVal TargetArray As ArrayList, ByVal Entry As String) As ArrayList
            If TargetArray Is Nothing Then Throw New ArgumentNullException("TargetArray")
            Dim Indexes As New ArrayList
            For Index As Integer = 0 To TargetArray.Count - 1
                Dim ArrayEntry As Object = TargetArray(Index)
                If ArrayEntry = Entry Then
                    Indexes.Add(Index)
                End If
            Next
            Return Indexes
        End Function

    End Module
End Namespace
