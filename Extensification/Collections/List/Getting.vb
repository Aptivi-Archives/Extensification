
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

Namespace ListExts
    ''' <summary>
    ''' Provides the list extensions related to getting
    ''' </summary>
    Public Module Getting

        ''' <summary>
        ''' Gets indexes from entry
        ''' </summary>
        ''' <typeparam name="T">Type</typeparam>
        ''' <param name="TargetList">Target list</param>
        ''' <param name="Entry">An entry</param>
        ''' <returns>List of indexes from entry</returns>
        <Extension>
        Public Function GetIndexFromEntry(Of T)(TargetList As List(Of T), Entry As T) As List(Of Integer)
            Dim Indexes As New List(Of Integer)
            For Index As Integer = 0 To TargetList.Count - 1
                If TargetList(Index).Equals(Entry) Then
                    Indexes.Add(Index)
                End If
            Next
            Return Indexes
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

    End Module
End Namespace