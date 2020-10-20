Imports System.Runtime.CompilerServices

Namespace ListExts
    Public Module Extensions

        <Extension>
        Public Function ToArrayList(Of T)(ByVal TargetList As List(Of T)) As ArrayList
            Dim ResultList As New ArrayList
            ResultList.AddRange(TargetList)
            Return ResultList
        End Function

        <Extension>
        Public Function GetIndexFromEntry(Of T)(ByVal TargetList As List(Of T), ByVal Entry As String) As List(Of Integer)
            Dim Indexes As New List(Of Integer)
            For Index As Integer = 0 To TargetList.Count - 1
                If TargetList(Index).Equals(Entry) Then
                    Indexes.Add(Index)
                End If
            Next
            Return Indexes
        End Function

    End Module
End Namespace
