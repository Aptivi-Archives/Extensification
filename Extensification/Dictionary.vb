
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

Namespace DictionaryExts
    Public Module Extensions

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
                If ListEntry = Key Then
                    DetectedIndex = Index
                End If
            Next
            Return DetectedIndex
        End Function

        ''' <summary>
        ''' Gets how many non-empty values are there (Empty keys are not counted)
        ''' </summary>
        ''' <typeparam name="TKey">Key</typeparam>
        ''' <typeparam name="TValue">Value</typeparam>
        ''' <param name="Dict">Target dictionary</param>
        ''' <returns>Count of non-empty values</returns>
        <Extension>
        Public Function CountFullEntries(Of TKey, TValue)(Dict As Dictionary(Of TKey, TValue)) As Integer
            Dim FullEntries As Integer
            For i As Long = 0 To Dict.Count - 1
                If Dict.Values(i) IsNot Nothing Then
                    If TypeOf Dict.Values(i) Is String Then
                        If Not Dict.Values(i).Equals("") Then
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
        ''' Gets how many empty values are there (Empty keys are not counted)
        ''' </summary>
        ''' <typeparam name="TKey">Key</typeparam>
        ''' <typeparam name="TValue">Value</typeparam>
        ''' <param name="Dict">Target dictionary</param>
        ''' <returns>Count of empty values</returns>
        <Extension>
        Public Function CountEmptyEntries(Of TKey, TValue)(Dict As Dictionary(Of TKey, TValue)) As Integer
            Dim EmptyEntries As Integer
            For i As Long = 0 To Dict.Count - 1
                If Dict.Values(i) Is Nothing Then
                    EmptyEntries += 1
                ElseIf TypeOf Dict.Values(i) Is String And Dict.Values(i).Equals("") Then
                    EmptyEntries += 1
                End If
            Next
            Return EmptyEntries
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

        ''' <summary>
        ''' Adds an entry to dictionary if not found
        ''' </summary>
        ''' <typeparam name="TKey">Key</typeparam>
        ''' <typeparam name="TValue">Value</typeparam>
        ''' <param name="Dict">Target dictionary</param>
        ''' <param name="EntryKey">A key entry to be added</param>
        ''' <param name="EntryValue">A value of entry</param>
        <Extension>
        Public Sub AddIfNotFound(Of TKey, TValue)(Dict As Dictionary(Of TKey, TValue), EntryKey As TKey, EntryValue As TValue)
            If EntryKey Is Nothing Then Throw New ArgumentNullException(NameOf(EntryKey))
            If Not Dict.ContainsKey(EntryKey) Then
                Dict.Add(EntryKey, EntryValue)
            End If
        End Sub

        ''' <summary>
        ''' Adds or modifies an entry to dictionary
        ''' </summary>
        ''' <typeparam name="TKey">Key</typeparam>
        ''' <typeparam name="TValue">Value</typeparam>
        ''' <param name="Dict">Target dictionary</param>
        ''' <param name="EntryKey">A key entry to be added</param>
        ''' <param name="EntryValue">A value of entry</param>
        <Extension>
        Public Sub AddOrModify(Of TKey, TValue)(Dict As Dictionary(Of TKey, TValue), EntryKey As TKey, EntryValue As TValue)
            If EntryKey Is Nothing Then Throw New ArgumentNullException(NameOf(EntryKey))
            If Not Dict.ContainsKey(EntryKey) Then
                Dict.Add(EntryKey, EntryValue)
            Else
                Dict(EntryKey) = EntryValue
            End If
        End Sub

        ''' <summary>
        ''' Increments number value in key. The key will be created if not found.
        ''' </summary>
        ''' <typeparam name="TKey">Key</typeparam>
        ''' <param name="Dict">Target dictionary</param>
        ''' <param name="EntryKey">A key entry to be incremented</param>
        <Extension>
        Public Sub IncrementNumber(Of TKey)(Dict As Dictionary(Of TKey, Integer), EntryKey As TKey)
            If EntryKey Is Nothing Then Throw New ArgumentNullException(NameOf(EntryKey))
            If Not Dict.ContainsKey(EntryKey) Then Dict.Add(EntryKey, 0)
            Dict(EntryKey) += 1
        End Sub

        ''' <summary>
        ''' Increments number value in key. The key will be created if not found.
        ''' </summary>
        ''' <typeparam name="TKey">Key</typeparam>
        ''' <param name="Dict">Target dictionary</param>
        ''' <param name="EntryKey">A key entry to be incremented</param>
        <Extension>
        Public Sub IncrementNumber(Of TKey)(Dict As Dictionary(Of TKey, UInteger), EntryKey As TKey)
            If EntryKey Is Nothing Then Throw New ArgumentNullException(NameOf(EntryKey))
            If Not Dict.ContainsKey(EntryKey) Then Dict.Add(EntryKey, 0)
            Dict(EntryKey) += 1
        End Sub

        ''' <summary>
        ''' Increments number value in key. The key will be created if not found.
        ''' </summary>
        ''' <typeparam name="TKey">Key</typeparam>
        ''' <param name="Dict">Target dictionary</param>
        ''' <param name="EntryKey">A key entry to be incremented</param>
        <Extension>
        Public Sub IncrementNumber(Of TKey)(Dict As Dictionary(Of TKey, Long), EntryKey As TKey)
            If EntryKey Is Nothing Then Throw New ArgumentNullException(NameOf(EntryKey))
            If Not Dict.ContainsKey(EntryKey) Then Dict.Add(EntryKey, 0)
            Dict(EntryKey) += 1
        End Sub

        ''' <summary>
        ''' Increments number value in key. The key will be created if not found.
        ''' </summary>
        ''' <typeparam name="TKey">Key</typeparam>
        ''' <param name="Dict">Target dictionary</param>
        ''' <param name="EntryKey">A key entry to be incremented</param>
        <Extension>
        Public Sub IncrementNumber(Of TKey)(Dict As Dictionary(Of TKey, ULong), EntryKey As TKey)
            If EntryKey Is Nothing Then Throw New ArgumentNullException(NameOf(EntryKey))
            If Not Dict.ContainsKey(EntryKey) Then Dict.Add(EntryKey, 0)
            Dict(EntryKey) += 1
        End Sub

        ''' <summary>
        ''' Increments number value in key. The key will be created if not found.
        ''' </summary>
        ''' <typeparam name="TKey">Key</typeparam>
        ''' <param name="Dict">Target dictionary</param>
        ''' <param name="EntryKey">A key entry to be incremented</param>
        <Extension>
        Public Sub IncrementNumber(Of TKey)(Dict As Dictionary(Of TKey, Short), EntryKey As TKey)
            If EntryKey Is Nothing Then Throw New ArgumentNullException(NameOf(EntryKey))
            If Not Dict.ContainsKey(EntryKey) Then Dict.Add(EntryKey, 0)
            Dict(EntryKey) += 1
        End Sub

        ''' <summary>
        ''' Increments number value in key. The key will be created if not found.
        ''' </summary>
        ''' <typeparam name="TKey">Key</typeparam>
        ''' <param name="Dict">Target dictionary</param>
        ''' <param name="EntryKey">A key entry to be incremented</param>
        <Extension>
        Public Sub IncrementNumber(Of TKey)(Dict As Dictionary(Of TKey, UShort), EntryKey As TKey)
            If EntryKey Is Nothing Then Throw New ArgumentNullException(NameOf(EntryKey))
            If Not Dict.ContainsKey(EntryKey) Then Dict.Add(EntryKey, 0)
            Dict(EntryKey) += 1
        End Sub

        ''' <summary>
        ''' Increments number value in key. The key will be created if not found.
        ''' </summary>
        ''' <typeparam name="TKey">Key</typeparam>
        ''' <param name="Dict">Target dictionary</param>
        ''' <param name="EntryKey">A key entry to be incremented</param>
        <Extension>
        Public Sub IncrementNumber(Of TKey)(Dict As Dictionary(Of TKey, Single), EntryKey As TKey)
            If EntryKey Is Nothing Then Throw New ArgumentNullException(NameOf(EntryKey))
            If Not Dict.ContainsKey(EntryKey) Then Dict.Add(EntryKey, 0)
            Dict(EntryKey) += 1
        End Sub

        ''' <summary>
        ''' Increments number value in key. The key will be created if not found.
        ''' </summary>
        ''' <typeparam name="TKey">Key</typeparam>
        ''' <param name="Dict">Target dictionary</param>
        ''' <param name="EntryKey">A key entry to be incremented</param>
        <Extension>
        Public Sub IncrementNumber(Of TKey)(Dict As Dictionary(Of TKey, Double), EntryKey As TKey)
            If EntryKey Is Nothing Then Throw New ArgumentNullException(NameOf(EntryKey))
            If Not Dict.ContainsKey(EntryKey) Then Dict.Add(EntryKey, 0)
            Dict(EntryKey) += 1
        End Sub

        ''' <summary>
        ''' Decrements number value in key. The key will be created if not found.
        ''' </summary>
        ''' <typeparam name="TKey">Key</typeparam>
        ''' <param name="Dict">Target dictionary</param>
        ''' <param name="EntryKey">A key entry to be decremented</param>
        <Extension>
        Public Sub DecrementNumber(Of TKey)(Dict As Dictionary(Of TKey, Integer), EntryKey As TKey)
            If EntryKey Is Nothing Then Throw New ArgumentNullException(NameOf(EntryKey))
            If Not Dict.ContainsKey(EntryKey) Then Dict.Add(EntryKey, 0)
            Dict(EntryKey) -= 1
        End Sub

        ''' <summary>
        ''' Decrements number value in key. The key will be created if not found.
        ''' </summary>
        ''' <typeparam name="TKey">Key</typeparam>
        ''' <param name="Dict">Target dictionary</param>
        ''' <param name="EntryKey">A key entry to be decremented</param>
        <Extension>
        Public Sub DecrementNumber(Of TKey)(Dict As Dictionary(Of TKey, UInteger), EntryKey As TKey)
            If EntryKey Is Nothing Then Throw New ArgumentNullException(NameOf(EntryKey))
            If Not Dict.ContainsKey(EntryKey) Then Dict.Add(EntryKey, 0)
            Dict(EntryKey) -= 1
        End Sub

        ''' <summary>
        ''' Decrements number value in key. The key will be created if not found.
        ''' </summary>
        ''' <typeparam name="TKey">Key</typeparam>
        ''' <param name="Dict">Target dictionary</param>
        ''' <param name="EntryKey">A key entry to be decremented</param>
        <Extension>
        Public Sub DecrementNumber(Of TKey)(Dict As Dictionary(Of TKey, Long), EntryKey As TKey)
            If EntryKey Is Nothing Then Throw New ArgumentNullException(NameOf(EntryKey))
            If Not Dict.ContainsKey(EntryKey) Then Dict.Add(EntryKey, 0)
            Dict(EntryKey) -= 1
        End Sub

        ''' <summary>
        ''' Decrements number value in key. The key will be created if not found.
        ''' </summary>
        ''' <typeparam name="TKey">Key</typeparam>
        ''' <param name="Dict">Target dictionary</param>
        ''' <param name="EntryKey">A key entry to be decremented</param>
        <Extension>
        Public Sub DecrementNumber(Of TKey)(Dict As Dictionary(Of TKey, ULong), EntryKey As TKey)
            If EntryKey Is Nothing Then Throw New ArgumentNullException(NameOf(EntryKey))
            If Not Dict.ContainsKey(EntryKey) Then Dict.Add(EntryKey, 0)
            Dict(EntryKey) -= 1
        End Sub

        ''' <summary>
        ''' Decrements number value in key. The key will be created if not found.
        ''' </summary>
        ''' <typeparam name="TKey">Key</typeparam>
        ''' <param name="Dict">Target dictionary</param>
        ''' <param name="EntryKey">A key entry to be decremented</param>
        <Extension>
        Public Sub DecrementNumber(Of TKey)(Dict As Dictionary(Of TKey, Short), EntryKey As TKey)
            If EntryKey Is Nothing Then Throw New ArgumentNullException(NameOf(EntryKey))
            If Not Dict.ContainsKey(EntryKey) Then Dict.Add(EntryKey, 0)
            Dict(EntryKey) -= 1
        End Sub

        ''' <summary>
        ''' Decrements number value in key. The key will be created if not found.
        ''' </summary>
        ''' <typeparam name="TKey">Key</typeparam>
        ''' <param name="Dict">Target dictionary</param>
        ''' <param name="EntryKey">A key entry to be decremented</param>
        <Extension>
        Public Sub DecrementNumber(Of TKey)(Dict As Dictionary(Of TKey, UShort), EntryKey As TKey)
            If EntryKey Is Nothing Then Throw New ArgumentNullException(NameOf(EntryKey))
            If Not Dict.ContainsKey(EntryKey) Then Dict.Add(EntryKey, 0)
            Dict(EntryKey) -= 1
        End Sub

        ''' <summary>
        ''' Decrements number value in key. The key will be created if not found.
        ''' </summary>
        ''' <typeparam name="TKey">Key</typeparam>
        ''' <param name="Dict">Target dictionary</param>
        ''' <param name="EntryKey">A key entry to be decremented</param>
        <Extension>
        Public Sub DecrementNumber(Of TKey)(Dict As Dictionary(Of TKey, Single), EntryKey As TKey)
            If EntryKey Is Nothing Then Throw New ArgumentNullException(NameOf(EntryKey))
            If Not Dict.ContainsKey(EntryKey) Then Dict.Add(EntryKey, 0)
            Dict(EntryKey) -= 1
        End Sub

        ''' <summary>
        ''' Decrements number value in key. The key will be created if not found.
        ''' </summary>
        ''' <typeparam name="TKey">Key</typeparam>
        ''' <param name="Dict">Target dictionary</param>
        ''' <param name="EntryKey">A key entry to be decremented</param>
        <Extension>
        Public Sub DecrementNumber(Of TKey)(Dict As Dictionary(Of TKey, Double), EntryKey As TKey)
            If EntryKey Is Nothing Then Throw New ArgumentNullException(NameOf(EntryKey))
            If Not Dict.ContainsKey(EntryKey) Then Dict.Add(EntryKey, 0)
            Dict(EntryKey) -= 1
        End Sub

        ''' <summary>
        ''' Checks to see if the keys in dictionary contains any of the targets.
        ''' </summary>
        ''' <param name="Dict">Source dictionary</param>
        ''' <param name="Targets">Target dictionary</param>
        ''' <returns>True if all of them are found; else, false.</returns>
        <Extension>
        Public Function ContainsAnyOfInKeys(Of TKey, TValue)(Dict As Dictionary(Of TKey, TValue), Targets As TKey()) As Boolean
            If Dict Is Nothing Then Throw New ArgumentNullException(NameOf(Dict))
            For Each Target In Targets
                If Dict.ContainsKey(Target) Then Return True
            Next
            Return False
        End Function

        ''' <summary>
        ''' Checks to see if the values in dictionary contains any of the targets.
        ''' </summary>
        ''' <param name="Dict">Source dictionary</param>
        ''' <param name="Targets">Target dictionary</param>
        ''' <returns>True if all of them are found; else, false.</returns>
        <Extension>
        Public Function ContainsAnyOfInValues(Of TKey, TValue)(Dict As Dictionary(Of TKey, TValue), Targets As TValue()) As Boolean
            If Dict Is Nothing Then Throw New ArgumentNullException(NameOf(Dict))
            For Each Target In Targets
                If Dict.ContainsValue(Target) Then Return True
            Next
            Return False
        End Function

        ''' <summary>
        ''' Checks to see if the keys in dictionary contains all of the targets.
        ''' </summary>
        ''' <param name="Dict">Source dictionary</param>
        ''' <param name="Targets">Target dictionary</param>
        ''' <returns>True if all of them are found; else, false.</returns>
        <Extension>
        Public Function ContainsAllOfInKeys(Of TKey, TValue)(Dict As Dictionary(Of TKey, TValue), Targets As TKey()) As Boolean
            If Dict Is Nothing Then Throw New ArgumentNullException(NameOf(Dict))
#If NET45 Then
            Dim Done() As TKey = {}
#Else
            Dim Done() As TKey = Array.Empty(Of TKey)
#End If
            For Each Target In Targets
                If Dict.ContainsKey(Target) Then Done.Add(Target)
            Next
            Return Done.SequenceEqual(Targets)
        End Function

        ''' <summary>
        ''' Checks to see if the values in dictionary contains all of the targets.
        ''' </summary>
        ''' <param name="Dict">Source dictionary</param>
        ''' <param name="Targets">Target dictionary</param>
        ''' <returns>True if all of them are found; else, false.</returns>
        <Extension>
        Public Function ContainsAllOfInValues(Of TKey, TValue)(Dict As Dictionary(Of TKey, TValue), Targets As TValue()) As Boolean
            If Dict Is Nothing Then Throw New ArgumentNullException(NameOf(Dict))
#If NET45 Then
            Dim Done() As TValue = {}
#Else
            Dim Done() As TValue = Array.Empty(Of TValue)
#End If
            For Each Target In Targets
                If Dict.ContainsValue(Target) Then Done.Add(Target)
            Next
            Return Done.SequenceEqual(Targets)
        End Function

#If NET45 Then
        ''' <summary>
        ''' Attempts to add the specified key and value to the dictionary
        ''' </summary>
        ''' <typeparam name="TKey">Key</typeparam>
        ''' <typeparam name="TValue">Value</typeparam>
        ''' <param name="Dict">Target dictionary</param>
        ''' <param name="EntryKey">A key entry to be added</param>
        ''' <param name="EntryValue">A value of entry</param>
        ''' <returns>True if successful; False if unsuccessful</returns>
        <Extension>
        Public Function TryAdd(Of TKey, TValue)(Dict As Dictionary(Of TKey, TValue), EntryKey As TKey, EntryValue As TValue) As Boolean
            If EntryKey Is Nothing Then Throw New ArgumentNullException(NameOf(EntryKey))
            Try
                Dict.Add(EntryKey, EntryValue)
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function
#End If

    End Module
End Namespace

