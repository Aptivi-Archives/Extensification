
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
Imports Extensification.StringExts

Namespace DictionaryExts
    ''' <summary>
    ''' Provides the dictionary extensions related to manipulation
    ''' </summary>
    Public Module Manipulation

        ''' <summary>
        ''' Renames a key in a dictionary that has the key type of string
        ''' </summary>
        ''' <typeparam name="TValue">Value</typeparam>
        ''' <param name="Dict">Target dictionary</param>
        ''' <param name="OldName">Original key name</param>
        ''' <param name="NewName">New key name</param>
        ''' <exception cref="KeyNotFoundException"></exception>
        <Extension>
        Public Sub RenameKey(Of TValue)(Dict As Dictionary(Of String, TValue), OldName As String, NewName As String)
            If Dict.ContainsKey(OldName) Then
                Dim KeyValue As TValue = Dict(OldName)
                Dict.Remove(OldName)
                Dict.Add(NewName, KeyValue)
            Else
                Throw New KeyNotFoundException("Key {0} not found".FormatString(OldName))
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
        Public Sub IncrementNumber(Of TKey)(Dict As Dictionary(Of TKey, Byte), EntryKey As TKey)
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
        Public Sub IncrementNumber(Of TKey)(Dict As Dictionary(Of TKey, SByte), EntryKey As TKey)
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
        Public Sub DecrementNumber(Of TKey)(Dict As Dictionary(Of TKey, Byte), EntryKey As TKey)
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
        Public Sub DecrementNumber(Of TKey)(Dict As Dictionary(Of TKey, SByte), EntryKey As TKey)
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

    End Module
End Namespace