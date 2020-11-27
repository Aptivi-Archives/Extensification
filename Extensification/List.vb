Imports System.Runtime.CompilerServices

Namespace ListExts
    Public Module Extensions

        ''' <summary>
        ''' Converts list to array list
        ''' </summary>
        ''' <typeparam name="T">Type</typeparam>
        ''' <param name="TargetList">Target list</param>
        <Extension>
        Public Function ToArrayList(Of T)(ByVal TargetList As List(Of T)) As ArrayList
            Dim ResultList As New ArrayList
            ResultList.AddRange(TargetList)
            Return ResultList
        End Function

        ''' <summary>
        ''' Gets indexes from entry
        ''' </summary>
        ''' <typeparam name="T">Type</typeparam>
        ''' <param name="TargetList">Target list</param>
        ''' <param name="Entry">An entry</param>
        ''' <returns>List of indexes from entry</returns>
        <Extension>
        Public Function GetIndexFromEntry(Of T)(ByVal TargetList As List(Of T), ByVal Entry As T) As List(Of Integer)
            Dim Indexes As New List(Of Integer)
            For Index As Integer = 0 To TargetList.Count - 1
                If TargetList(Index).Equals(Entry) Then
                    Indexes.Add(Index)
                End If
            Next
            Return Indexes
        End Function

        ''' <summary>
        ''' Gets how many non-empty items are there
        ''' </summary>
        ''' <typeparam name="T">Type</typeparam>
        ''' <param name="TargetList">Target list</param>
        ''' <returns>Count of non-empty items</returns>
        <Extension>
        Public Function CountFullEntries(Of T)(TargetList As List(Of T)) As Integer
            Dim FullEntries As Integer
            For i As Long = 0 To TargetList.Count - 1
                If TargetList(i) IsNot Nothing Then
                    If TypeOf TargetList(i) Is String Then
                        If Not TargetList(i).Equals("") Then
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
        ''' <param name="TargetList">Target list</param>
        ''' <returns>Count of empty items</returns>
        <Extension>
        Public Function CountEmptyEntries(Of T)(TargetList As List(Of T)) As Integer
            Dim EmptyEntries As Integer
            For i As Long = 0 To TargetList.Count - 1
                If TargetList(i) Is Nothing Then
                    EmptyEntries += 1
                ElseIf TypeOf TargetList(i) Is String And TargetList(i).Equals("") Then
                    EmptyEntries += 1
                End If
            Next
            Return EmptyEntries
        End Function

        ''' <summary>
        ''' Gets indexes of non-empty items
        ''' </summary>
        ''' <typeparam name="T">Type</typeparam>
        ''' <param name="TargetList">Target list</param>
        ''' <returns>Indexes of non-empty items</returns>
        <Extension>
        Public Function GetIndexesOfFullEntries(Of T)(TargetList As List(Of T)) As Integer()
            Dim FullIndexes As New List(Of Integer)
            For i As Long = 0 To TargetList.Count - 1
                If TargetList(i) IsNot Nothing Then
                    If TypeOf TargetList(i) Is String Then
                        If Not TargetList(i).Equals("") Then
                            FullIndexes.Add(i)
                        End If
                    Else
                        FullIndexes.Add(i)
                    End If
                End If
            Next
            Return FullIndexes.ToArray
        End Function

        ''' <summary>
        ''' Gets indexes of empty items
        ''' </summary>
        ''' <typeparam name="T">Type</typeparam>
        ''' <param name="TargetList">Target list</param>
        ''' <returns>Indexes of empty items</returns>
        <Extension>
        Public Function GetIndexesOfEmptyEntries(Of T)(TargetList As List(Of T)) As Integer()
            Dim EmptyIndexes As New List(Of Integer)
            For i As Long = 0 To TargetList.Count - 1
                If TargetList(i) Is Nothing Then
                    EmptyIndexes.Add(i)
                ElseIf TypeOf TargetList(i) Is String And TargetList(i).Equals("") Then
                    EmptyIndexes.Add(i)
                End If
            Next
            Return EmptyIndexes.ToArray
        End Function

        ''' <summary>
        ''' Adds an entry to list if not found
        ''' </summary>
        ''' <typeparam name="T">Type</typeparam>
        ''' <param name="TargetList">Target list</param>
        ''' <param name="Entry">An entry to be added</param>
        <Extension>
        Public Sub AddIfNotFound(Of T)(TargetList As List(Of T), Entry As T)
            If Not TargetList.Contains(Entry) Then
                TargetList.Add(Entry)
            End If
        End Sub

        ''' <summary>
        ''' Tries to remove an entry from the list
        ''' </summary>
        ''' <typeparam name="T">Type</typeparam>
        ''' <param name="TargetList">Target list</param>
        ''' <param name="Entry">An entry to be removed</param>
        ''' <returns>True if successful; False if unsuccessful</returns>
        <Extension>
        Public Function TryRemove(Of T)(TargetList As List(Of T), Entry As T) As Boolean
            If Entry Is Nothing Then Throw New ArgumentNullException(NameOf(Entry))
            Try
                Return TargetList.Remove(Entry)
            Catch ex As Exception
                Return False
            End Try
        End Function

    End Module
End Namespace
