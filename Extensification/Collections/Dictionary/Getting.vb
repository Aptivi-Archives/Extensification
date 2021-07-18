
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

Namespace DictionaryExts
    ''' <summary>
    ''' Provides the dictionary extensions related to getting
    ''' </summary>
    Public Module Getting

        ''' <summary>
        ''' Gets a key from a value in the dictionary
        ''' </summary>
        ''' <typeparam name="TKey">Key</typeparam>
        ''' <typeparam name="TValue">Value</typeparam>
        ''' <param name="Dict">Source dictionary</param>
        ''' <param name="Value">Value</param>
        ''' <returns>Key from value</returns>
        <Extension>
        Public Function GetKeyFromValue(Of TKey, TValue)(ByVal Dict As Dictionary(Of TKey, TValue), ByVal Value As TValue) As TKey
            If Dict Is Nothing Then Throw New ArgumentNullException(NameOf(Dict))
            For Each DictKey As TKey In Dict.Keys
                If Dict(DictKey).Equals(Value) Then
                    Return DictKey
                End If
            Next
            Return Nothing
        End Function

        ''' <summary>
        ''' Gets an index from a key in the dictionary
        ''' </summary>
        ''' <typeparam name="TKey">Key</typeparam>
        ''' <typeparam name="TValue">Value</typeparam>
        ''' <param name="Dict">Source dictionary</param>
        ''' <param name="Key">Key</param>
        ''' <returns>Index of key</returns>
        <Extension>
        Public Function GetIndexOfKey(Of TKey, TValue)(ByVal Dict As Dictionary(Of TKey, TValue), ByVal Key As TKey) As Integer
            If Dict Is Nothing Then Throw New ArgumentNullException(NameOf(Dict))
            Dim DetectedIndex As Integer = 0
            For Index As Integer = 0 To Dict.Count - 1
                Dim ListEntry As Object = Dict.Keys(Index)
                If ListEntry.Equals(Key) Then
                    DetectedIndex = Index
                End If
            Next
            Return DetectedIndex
        End Function

        ''' <summary>
        ''' Gets an index from a value in the dictionary
        ''' </summary>
        ''' <typeparam name="TKey">Key</typeparam>
        ''' <typeparam name="TValue">Value</typeparam>
        ''' <param name="Dict">Source dictionary</param>
        ''' <param name="Value">Value</param>
        ''' <returns>Index of value</returns>
        <Extension>
        Public Function GetIndexOfValue(Of TKey, TValue)(ByVal Dict As Dictionary(Of TKey, TValue), ByVal Value As TValue) As Integer
            If Dict Is Nothing Then Throw New ArgumentNullException(NameOf(Dict))
            Dim DetectedIndex As Integer = 0
            For Index As Integer = 0 To Dict.Count - 1
                Dim ListEntry As Object = Dict.Values(Index)
                If ListEntry.Equals(Value) Then
                    DetectedIndex = Index
                End If
            Next
            Return DetectedIndex
        End Function

        ''' <summary>
        ''' Gets indexes of non-empty items
        ''' </summary>
        ''' <typeparam name="TKey">Key</typeparam>
        ''' <typeparam name="TValue">Value</typeparam>
        ''' <param name="Dict">Target dictionary</param>
        ''' <returns>Indexes of non-empty items</returns>
        <Extension>
        Public Function GetIndexesOfFullEntries(Of TKey, TValue)(Dict As Dictionary(Of TKey, TValue)) As Integer()
            Dim FullIndexes As New List(Of Integer)
            For i As Long = 0 To Dict.Count - 1
                If Dict.Values(i) IsNot Nothing Then
                    If TypeOf Dict.Values(i) Is String Then
                        If Not Dict.Values(i).Equals("") Then
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
        ''' <typeparam name="TKey">Key</typeparam>
        ''' <typeparam name="TValue">Value</typeparam>
        ''' <param name="Dict">Target dictionary</param>
        ''' <returns>Indexes of empty items</returns>
        <Extension>
        Public Function GetIndexesOfEmptyEntries(Of TKey, TValue)(Dict As Dictionary(Of TKey, TValue)) As Integer()
            Dim EmptyIndexes As New List(Of Integer)
            For i As Long = 0 To Dict.Count - 1
                If Dict.Values(i) Is Nothing Then
                    EmptyIndexes.Add(i)
                ElseIf TypeOf Dict.Values(i) Is String And Dict.Values(i).Equals("") Then
                    EmptyIndexes.Add(i)
                End If
            Next
            Return EmptyIndexes.ToArray
        End Function

    End Module
End Namespace