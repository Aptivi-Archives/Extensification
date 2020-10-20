Imports System.Runtime.CompilerServices

Namespace ArrayListExts
    Public Module Extensions

        <Extension>
        Public Function ToList(ByVal TargetArray As ArrayList) As List(Of Object)
            Dim ArrayValues As New List(Of Object)
            ArrayValues.AddRange(TargetArray)
            Return ArrayValues
        End Function

        <Extension>
        Public Function GetIndexFromEntry(ByVal TargetArray As ArrayList, ByVal Entry As String) As ArrayList
            Dim Indexes As New ArrayList
            For Index As Integer = 0 To TargetArray.Count - 1
                If TargetArray(Index) = Entry Then
                    Indexes.Add(Index)
                End If
            Next
            Return Indexes
        End Function

    End Module
End Namespace
