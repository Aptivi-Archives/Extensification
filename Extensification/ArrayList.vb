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
            ArrayValues.AddRange(TargetArray.ToArray)
            Return ArrayValues
        End Function

        ''' <summary>
        ''' Gets index of an entry from the list
        ''' </summary>
        ''' <param name="TargetArray">Target array list</param>
        ''' <param name="Entry">An entry found in the list</param>
        ''' <returns>List of indexes. If none is found, returns an empty array list</returns>
        <Extension>
        Public Function GetIndexOfEntry(ByVal TargetArray As ArrayList, ByVal Entry As Object) As ArrayList
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

        ''' <summary>
        ''' Gets how many non-empty items are there
        ''' </summary>
        ''' <typeparam name="T">Type</typeparam>
        ''' <param name="TargetArray">Target array</param>
        ''' <returns>Count of non-empty items</returns>
        <Extension>
        Public Function CountFullEntries(TargetArray As ArrayList) As Long
            Dim FullEntries As Long
            For i As Long = 0 To TargetArray.Count - 1
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
        Public Function CountEmptyEntries(TargetArray As ArrayList) As Long
            Dim EmptyEntries As Long
            For i As Long = 0 To TargetArray.Count - 1
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
