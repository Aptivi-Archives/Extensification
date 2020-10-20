Imports System.Runtime.CompilerServices

Namespace ArrayExts
    Public Module Extensions

        <Extension>
        Public Function Add(ByVal TargetArray As Array, ByVal Item As Object) As Array
            Dim TargetArrayList As ArrayList = TargetArray.ToArrayList
            TargetArrayList.Add(Item)
            Return TargetArrayList.ToArray
        End Function

        <Extension>
        Public Function Remove(ByVal TargetArray As Array, ByVal Item As Object) As Array
            Dim TargetArrayList As ArrayList = TargetArray.ToArrayList
            TargetArrayList.Remove(Item)
            Return TargetArrayList.ToArray
        End Function

        <Extension>
        Public Function ToArrayList(ByVal TargetArray As Array) As ArrayList
            Dim ArrayValues As New ArrayList
            ArrayValues.AddRange(TargetArray)
            Return ArrayValues
        End Function

        <Extension>
        Public Function ToList(ByVal TargetArray As Array) As List(Of Object)
            Dim ArrayValues As New List(Of Object)
            ArrayValues.AddRange(TargetArray)
            Return ArrayValues
        End Function

        <Extension>
        Public Function GetIndexFromEntry(ByVal TargetArray As Array, ByVal Entry As String) As Array
            Dim Indexes As New ArrayList
            For Index As Integer = 0 To TargetArray.Length - 1
                If TargetArray(Index) = Entry Then
                    Indexes.Add(Index)
                End If
            Next
            Return Indexes.ToArray
        End Function

    End Module
End Namespace
