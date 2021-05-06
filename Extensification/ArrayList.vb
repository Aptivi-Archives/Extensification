
'    Extensification  Copyright (C) 2020-2021  EoflaOE
'
'    This file is part of Extensification
'
'    Extensification is free software: you can redistribute it and/or modify
'    it under the terms of the GNU General Public License as published by
'    the Free Software Foundation, either version 3 of the License, or
'    (at your option) any later version.
'
'    Extensification is distributed in the hope that it will be useful,
'    but WITHOUT ANY WARRANTY; without even the implied warranty of
'    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
'    GNU General Public License for more details.
'
'    You should have received a copy of the GNU General Public License
'    along with this program.  If not, see <https://www.gnu.org/licenses/>.

Imports System.Runtime.CompilerServices
Imports Extensification.ArrayExts

Namespace ArrayListExts
    Public Module Extensions

        ''' <summary>
        ''' Converts an array list to list of <see cref="Object"/>.
        ''' </summary>
        ''' <param name="TargetArray">Target array list</param>
        ''' <returns>A list from array list</returns>
        <Extension>
        Public Function ToList(ByVal TargetArray As ArrayList) As List(Of Object)
            If TargetArray Is Nothing Then Throw New ArgumentNullException(NameOf(TargetArray))
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
            If TargetArray Is Nothing Then Throw New ArgumentNullException(NameOf(TargetArray))
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

        ''' <summary>
        ''' Gets indexes of non-empty items
        ''' </summary>
        ''' <param name="TargetArray">Target array</param>
        ''' <returns>Indexes of non-empty items</returns>
        <Extension>
        Public Function GetIndexesOfFullEntries(TargetArray As ArrayList) As Integer()
            Dim FullIndexes As New List(Of Integer)
            For i As Long = 0 To TargetArray.Count - 1
                If TargetArray(i) IsNot Nothing Then
                    If TypeOf TargetArray(i) Is String Then
                        If Not TargetArray(i).Equals("") Then
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
        ''' <param name="TargetArray">Target array</param>
        ''' <returns>Indexes of empty items</returns>
        <Extension>
        Public Function GetIndexesOfEmptyEntries(TargetArray As ArrayList) As Integer()
            Dim EmptyIndexes As New List(Of Integer)
            For i As Long = 0 To TargetArray.Count - 1
                If TargetArray(i) Is Nothing Then
                    EmptyIndexes.Add(i)
                ElseIf TypeOf TargetArray(i) Is String And TargetArray(i).Equals("") Then
                    EmptyIndexes.Add(i)
                End If
            Next
            Return EmptyIndexes.ToArray
        End Function

        ''' <summary>
        ''' Tries to remove an entry from the array list
        ''' </summary>
        ''' <param name="TargetArray">Target array list</param>
        ''' <param name="Entry">An entry to be removed</param>
        ''' <returns>True if successful; False if unsuccessful</returns>
        <Extension>
        Public Function TryRemove(TargetArray As ArrayList, Entry As Object) As Boolean
            If Entry Is Nothing Then Throw New ArgumentNullException(NameOf(Entry))
            If Not TargetArray.Contains(Entry) Then Return False
            Try
                TargetArray.Remove(Entry)
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        ''' <summary>
        ''' Checks to see if the array contains any of the targets.
        ''' </summary>
        ''' <param name="TargetArray">Source array</param>
        ''' <param name="Targets">Target array</param>
        ''' <returns>True if all of them are found; else, false.</returns>
        <Extension>
        Public Function ContainsAnyOf(TargetArray As ArrayList, Targets As ArrayList) As Boolean
            If TargetArray Is Nothing Then Throw New ArgumentNullException(NameOf(TargetArray))
            For Each Target In Targets
                If TargetArray.Contains(Target) Then Return True
            Next
            Return False
        End Function

        ''' <summary>
        ''' Checks to see if the array contains all of the targets.
        ''' </summary>
        ''' <param name="TargetArray">Source array</param>
        ''' <param name="Targets">Target array</param>
        ''' <returns>True if all of them are found; else, false.</returns>
        <Extension>
        Public Function ContainsAllOf(TargetArray As ArrayList, Targets As ArrayList) As Boolean
            If TargetArray Is Nothing Then Throw New ArgumentNullException(NameOf(TargetArray))
#If NET45 Then
            Dim Done() As Object = {}
#Else
            Dim Done() As Object = Array.Empty(Of Object)
#End If
            For Each Target In Targets
                If TargetArray.Contains(Target) Then Done.Add(Target)
            Next
            Return Done.SequenceEqual(Targets.ToArray)
        End Function

    End Module
End Namespace
