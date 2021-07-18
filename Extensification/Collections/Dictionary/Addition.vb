
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
    ''' Provides the dictionary extensions related to addition
    ''' </summary>
    Public Module Addition

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
        ''' Adds or renames an entry to dictionary to identify the copy number
        ''' </summary>
        ''' <typeparam name="TValue">Value</typeparam>
        ''' <param name="Dict">Target dictionary</param>
        ''' <param name="EntryKey">A key entry to be added</param>
        ''' <param name="EntryValue">A value of entry</param>
        <Extension>
        Public Sub AddOrRename(Of TValue)(Dict As Dictionary(Of String, TValue), EntryKey As String, EntryValue As TValue)
            If EntryKey Is Nothing Then Throw New ArgumentNullException(NameOf(EntryKey))
            If Not Dict.ContainsKey(EntryKey) Then
                Dict.Add(EntryKey, EntryValue)
            Else
                Dict.Add(EntryKey & " [" & (Dict.Count + 1) & "]", EntryValue)
            End If
        End Sub

        ''' <summary>
        ''' Adds an entry or increments a value of an already-existing entry to dictionary
        ''' </summary>
        ''' <typeparam name="TKey">Key</typeparam>
        ''' <param name="Dict">Target dictionary</param>
        ''' <param name="EntryKey">A key entry to be added</param>
        ''' <param name="EntryValue">A value of entry, or a value to add to an already-existing entry</param>
        <Extension>
        Public Sub AddOrIncrement(Of TKey)(Dict As Dictionary(Of TKey, Integer), EntryKey As TKey, EntryValue As Integer)
            If EntryKey Is Nothing Then Throw New ArgumentNullException(NameOf(EntryKey))
            If Not Dict.ContainsKey(EntryKey) Then
                Dict.Add(EntryKey, EntryValue)
            Else
                Dict(EntryKey) += EntryValue
            End If
        End Sub

        ''' <summary>
        ''' Adds an entry or increments a value of an already-existing entry to dictionary
        ''' </summary>
        ''' <typeparam name="TKey">Key</typeparam>
        ''' <param name="Dict">Target dictionary</param>
        ''' <param name="EntryKey">A key entry to be added</param>
        ''' <param name="EntryValue">A value of entry, or a value to add to an already-existing entry</param>
        <Extension>
        Public Sub AddOrIncrement(Of TKey)(Dict As Dictionary(Of TKey, UInteger), EntryKey As TKey, EntryValue As UInteger)
            If EntryKey Is Nothing Then Throw New ArgumentNullException(NameOf(EntryKey))
            If Not Dict.ContainsKey(EntryKey) Then
                Dict.Add(EntryKey, EntryValue)
            Else
                Dict(EntryKey) += EntryValue
            End If
        End Sub

        ''' <summary>
        ''' Adds an entry or increments a value of an already-existing entry to dictionary
        ''' </summary>
        ''' <typeparam name="TKey">Key</typeparam>
        ''' <param name="Dict">Target dictionary</param>
        ''' <param name="EntryKey">A key entry to be added</param>
        ''' <param name="EntryValue">A value of entry, or a value to add to an already-existing entry</param>
        <Extension>
        Public Sub AddOrIncrement(Of TKey)(Dict As Dictionary(Of TKey, Byte), EntryKey As TKey, EntryValue As Byte)
            If EntryKey Is Nothing Then Throw New ArgumentNullException(NameOf(EntryKey))
            If Not Dict.ContainsKey(EntryKey) Then
                Dict.Add(EntryKey, EntryValue)
            Else
                Dict(EntryKey) += EntryValue
            End If
        End Sub

        ''' <summary>
        ''' Adds an entry or increments a value of an already-existing entry to dictionary
        ''' </summary>
        ''' <typeparam name="TKey">Key</typeparam>
        ''' <param name="Dict">Target dictionary</param>
        ''' <param name="EntryKey">A key entry to be added</param>
        ''' <param name="EntryValue">A value of entry, or a value to add to an already-existing entry</param>
        <Extension>
        Public Sub AddOrIncrement(Of TKey)(Dict As Dictionary(Of TKey, SByte), EntryKey As TKey, EntryValue As SByte)
            If EntryKey Is Nothing Then Throw New ArgumentNullException(NameOf(EntryKey))
            If Not Dict.ContainsKey(EntryKey) Then
                Dict.Add(EntryKey, EntryValue)
            Else
                Dict(EntryKey) += EntryValue
            End If
        End Sub

        ''' <summary>
        ''' Adds an entry or increments a value of an already-existing entry to dictionary
        ''' </summary>
        ''' <typeparam name="TKey">Key</typeparam>
        ''' <param name="Dict">Target dictionary</param>
        ''' <param name="EntryKey">A key entry to be added</param>
        ''' <param name="EntryValue">A value of entry, or a value to add to an already-existing entry</param>
        <Extension>
        Public Sub AddOrIncrement(Of TKey)(Dict As Dictionary(Of TKey, Double), EntryKey As TKey, EntryValue As Double)
            If EntryKey Is Nothing Then Throw New ArgumentNullException(NameOf(EntryKey))
            If Not Dict.ContainsKey(EntryKey) Then
                Dict.Add(EntryKey, EntryValue)
            Else
                Dict(EntryKey) += EntryValue
            End If
        End Sub

        ''' <summary>
        ''' Adds an entry or increments a value of an already-existing entry to dictionary
        ''' </summary>
        ''' <typeparam name="TKey">Key</typeparam>
        ''' <param name="Dict">Target dictionary</param>
        ''' <param name="EntryKey">A key entry to be added</param>
        ''' <param name="EntryValue">A value of entry, or a value to add to an already-existing entry</param>
        <Extension>
        Public Sub AddOrIncrement(Of TKey)(Dict As Dictionary(Of TKey, Long), EntryKey As TKey, EntryValue As Long)
            If EntryKey Is Nothing Then Throw New ArgumentNullException(NameOf(EntryKey))
            If Not Dict.ContainsKey(EntryKey) Then
                Dict.Add(EntryKey, EntryValue)
            Else
                Dict(EntryKey) += EntryValue
            End If
        End Sub

        ''' <summary>
        ''' Adds an entry or increments a value of an already-existing entry to dictionary
        ''' </summary>
        ''' <typeparam name="TKey">Key</typeparam>
        ''' <param name="Dict">Target dictionary</param>
        ''' <param name="EntryKey">A key entry to be added</param>
        ''' <param name="EntryValue">A value of entry, or a value to add to an already-existing entry</param>
        <Extension>
        Public Sub AddOrIncrement(Of TKey)(Dict As Dictionary(Of TKey, ULong), EntryKey As TKey, EntryValue As ULong)
            If EntryKey Is Nothing Then Throw New ArgumentNullException(NameOf(EntryKey))
            If Not Dict.ContainsKey(EntryKey) Then
                Dict.Add(EntryKey, EntryValue)
            Else
                Dict(EntryKey) += EntryValue
            End If
        End Sub

        ''' <summary>
        ''' Adds an entry or increments a value of an already-existing entry to dictionary
        ''' </summary>
        ''' <typeparam name="TKey">Key</typeparam>
        ''' <param name="Dict">Target dictionary</param>
        ''' <param name="EntryKey">A key entry to be added</param>
        ''' <param name="EntryValue">A value of entry, or a value to add to an already-existing entry</param>
        <Extension>
        Public Sub AddOrIncrement(Of TKey)(Dict As Dictionary(Of TKey, Short), EntryKey As TKey, EntryValue As Short)
            If EntryKey Is Nothing Then Throw New ArgumentNullException(NameOf(EntryKey))
            If Not Dict.ContainsKey(EntryKey) Then
                Dict.Add(EntryKey, EntryValue)
            Else
                Dict(EntryKey) += EntryValue
            End If
        End Sub

        ''' <summary>
        ''' Adds an entry or increments a value of an already-existing entry to dictionary
        ''' </summary>
        ''' <typeparam name="TKey">Key</typeparam>
        ''' <param name="Dict">Target dictionary</param>
        ''' <param name="EntryKey">A key entry to be added</param>
        ''' <param name="EntryValue">A value of entry, or a value to add to an already-existing entry</param>
        <Extension>
        Public Sub AddOrIncrement(Of TKey)(Dict As Dictionary(Of TKey, UShort), EntryKey As TKey, EntryValue As UShort)
            If EntryKey Is Nothing Then Throw New ArgumentNullException(NameOf(EntryKey))
            If Not Dict.ContainsKey(EntryKey) Then
                Dict.Add(EntryKey, EntryValue)
            Else
                Dict(EntryKey) += EntryValue
            End If
        End Sub

        ''' <summary>
        ''' Adds an entry or increments a value of an already-existing entry to dictionary
        ''' </summary>
        ''' <typeparam name="TKey">Key</typeparam>
        ''' <param name="Dict">Target dictionary</param>
        ''' <param name="EntryKey">A key entry to be added</param>
        ''' <param name="EntryValue">A value of entry, or a value to add to an already-existing entry</param>
        <Extension>
        Public Sub AddOrIncrement(Of TKey)(Dict As Dictionary(Of TKey, Single), EntryKey As TKey, EntryValue As Single)
            If EntryKey Is Nothing Then Throw New ArgumentNullException(NameOf(EntryKey))
            If Not Dict.ContainsKey(EntryKey) Then
                Dict.Add(EntryKey, EntryValue)
            Else
                Dict(EntryKey) += EntryValue
            End If
        End Sub

        ''' <summary>
        ''' Adds an entry or decrements a value of an already-existing entry to dictionary
        ''' </summary>
        ''' <typeparam name="TKey">Key</typeparam>
        ''' <param name="Dict">Target dictionary</param>
        ''' <param name="EntryKey">A key entry to be added</param>
        ''' <param name="EntryValue">A value of entry, or a value to subtract from an already-existing entry</param>
        <Extension>
        Public Sub AddOrDecrement(Of TKey)(Dict As Dictionary(Of TKey, Integer), EntryKey As TKey, EntryValue As Integer)
            If EntryKey Is Nothing Then Throw New ArgumentNullException(NameOf(EntryKey))
            If Not Dict.ContainsKey(EntryKey) Then
                Dict.Add(EntryKey, EntryValue)
            Else
                Dict(EntryKey) -= EntryValue
            End If
        End Sub

        ''' <summary>
        ''' Adds an entry or decrements a value of an already-existing entry to dictionary
        ''' </summary>
        ''' <typeparam name="TKey">Key</typeparam>
        ''' <param name="Dict">Target dictionary</param>
        ''' <param name="EntryKey">A key entry to be added</param>
        ''' <param name="EntryValue">A value of entry, or a value to subtract from an already-existing entry</param>
        <Extension>
        Public Sub AddOrDecrement(Of TKey)(Dict As Dictionary(Of TKey, UInteger), EntryKey As TKey, EntryValue As UInteger)
            If EntryKey Is Nothing Then Throw New ArgumentNullException(NameOf(EntryKey))
            If Not Dict.ContainsKey(EntryKey) Then
                Dict.Add(EntryKey, EntryValue)
            Else
                Dict(EntryKey) -= EntryValue
            End If
        End Sub

        ''' <summary>
        ''' Adds an entry or decrements a value of an already-existing entry to dictionary
        ''' </summary>
        ''' <typeparam name="TKey">Key</typeparam>
        ''' <param name="Dict">Target dictionary</param>
        ''' <param name="EntryKey">A key entry to be added</param>
        ''' <param name="EntryValue">A value of entry, or a value to subtract from an already-existing entry</param>
        <Extension>
        Public Sub AddOrDecrement(Of TKey)(Dict As Dictionary(Of TKey, Byte), EntryKey As TKey, EntryValue As Byte)
            If EntryKey Is Nothing Then Throw New ArgumentNullException(NameOf(EntryKey))
            If Not Dict.ContainsKey(EntryKey) Then
                Dict.Add(EntryKey, EntryValue)
            Else
                Dict(EntryKey) -= EntryValue
            End If
        End Sub

        ''' <summary>
        ''' Adds an entry or decrements a value of an already-existing entry to dictionary
        ''' </summary>
        ''' <typeparam name="TKey">Key</typeparam>
        ''' <param name="Dict">Target dictionary</param>
        ''' <param name="EntryKey">A key entry to be added</param>
        ''' <param name="EntryValue">A value of entry, or a value to subtract from an already-existing entry</param>
        <Extension>
        Public Sub AddOrDecrement(Of TKey)(Dict As Dictionary(Of TKey, SByte), EntryKey As TKey, EntryValue As SByte)
            If EntryKey Is Nothing Then Throw New ArgumentNullException(NameOf(EntryKey))
            If Not Dict.ContainsKey(EntryKey) Then
                Dict.Add(EntryKey, EntryValue)
            Else
                Dict(EntryKey) -= EntryValue
            End If
        End Sub

        ''' <summary>
        ''' Adds an entry or decrements a value of an already-existing entry to dictionary
        ''' </summary>
        ''' <typeparam name="TKey">Key</typeparam>
        ''' <param name="Dict">Target dictionary</param>
        ''' <param name="EntryKey">A key entry to be added</param>
        ''' <param name="EntryValue">A value of entry, or a value to subtract from an already-existing entry</param>
        <Extension>
        Public Sub AddOrDecrement(Of TKey)(Dict As Dictionary(Of TKey, Double), EntryKey As TKey, EntryValue As Double)
            If EntryKey Is Nothing Then Throw New ArgumentNullException(NameOf(EntryKey))
            If Not Dict.ContainsKey(EntryKey) Then
                Dict.Add(EntryKey, EntryValue)
            Else
                Dict(EntryKey) -= EntryValue
            End If
        End Sub

        ''' <summary>
        ''' Adds an entry or decrements a value of an already-existing entry to dictionary
        ''' </summary>
        ''' <typeparam name="TKey">Key</typeparam>
        ''' <param name="Dict">Target dictionary</param>
        ''' <param name="EntryKey">A key entry to be added</param>
        ''' <param name="EntryValue">A value of entry, or a value to subtract from an already-existing entry</param>
        <Extension>
        Public Sub AddOrDecrement(Of TKey)(Dict As Dictionary(Of TKey, Long), EntryKey As TKey, EntryValue As Long)
            If EntryKey Is Nothing Then Throw New ArgumentNullException(NameOf(EntryKey))
            If Not Dict.ContainsKey(EntryKey) Then
                Dict.Add(EntryKey, EntryValue)
            Else
                Dict(EntryKey) -= EntryValue
            End If
        End Sub

        ''' <summary>
        ''' Adds an entry or decrements a value of an already-existing entry to dictionary
        ''' </summary>
        ''' <typeparam name="TKey">Key</typeparam>
        ''' <param name="Dict">Target dictionary</param>
        ''' <param name="EntryKey">A key entry to be added</param>
        ''' <param name="EntryValue">A value of entry, or a value to subtract from an already-existing entry</param>
        <Extension>
        Public Sub AddOrDecrement(Of TKey)(Dict As Dictionary(Of TKey, ULong), EntryKey As TKey, EntryValue As ULong)
            If EntryKey Is Nothing Then Throw New ArgumentNullException(NameOf(EntryKey))
            If Not Dict.ContainsKey(EntryKey) Then
                Dict.Add(EntryKey, EntryValue)
            Else
                Dict(EntryKey) -= EntryValue
            End If
        End Sub

        ''' <summary>
        ''' Adds an entry or decrements a value of an already-existing entry to dictionary
        ''' </summary>
        ''' <typeparam name="TKey">Key</typeparam>
        ''' <param name="Dict">Target dictionary</param>
        ''' <param name="EntryKey">A key entry to be added</param>
        ''' <param name="EntryValue">A value of entry, or a value to subtract from an already-existing entry</param>
        <Extension>
        Public Sub AddOrDecrement(Of TKey)(Dict As Dictionary(Of TKey, Short), EntryKey As TKey, EntryValue As Short)
            If EntryKey Is Nothing Then Throw New ArgumentNullException(NameOf(EntryKey))
            If Not Dict.ContainsKey(EntryKey) Then
                Dict.Add(EntryKey, EntryValue)
            Else
                Dict(EntryKey) -= EntryValue
            End If
        End Sub

        ''' <summary>
        ''' Adds an entry or decrements a value of an already-existing entry to dictionary
        ''' </summary>
        ''' <typeparam name="TKey">Key</typeparam>
        ''' <param name="Dict">Target dictionary</param>
        ''' <param name="EntryKey">A key entry to be added</param>
        ''' <param name="EntryValue">A value of entry, or a value to subtract from an already-existing entry</param>
        <Extension>
        Public Sub AddOrDecrement(Of TKey)(Dict As Dictionary(Of TKey, UShort), EntryKey As TKey, EntryValue As UShort)
            If EntryKey Is Nothing Then Throw New ArgumentNullException(NameOf(EntryKey))
            If Not Dict.ContainsKey(EntryKey) Then
                Dict.Add(EntryKey, EntryValue)
            Else
                Dict(EntryKey) -= EntryValue
            End If
        End Sub

        ''' <summary>
        ''' Adds an entry or decrements a value of an already-existing entry to dictionary
        ''' </summary>
        ''' <typeparam name="TKey">Key</typeparam>
        ''' <param name="Dict">Target dictionary</param>
        ''' <param name="EntryKey">A key entry to be added</param>
        ''' <param name="EntryValue">A value of entry, or a value to subtract from an already-existing entry</param>
        <Extension>
        Public Sub AddOrDecrement(Of TKey)(Dict As Dictionary(Of TKey, Single), EntryKey As TKey, EntryValue As Single)
            If EntryKey Is Nothing Then Throw New ArgumentNullException(NameOf(EntryKey))
            If Not Dict.ContainsKey(EntryKey) Then
                Dict.Add(EntryKey, EntryValue)
            Else
                Dict(EntryKey) -= EntryValue
            End If
        End Sub

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
