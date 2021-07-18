
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
    ''' <summary>
    ''' Provides the dictionary extensions related to querying
    ''' </summary>
    Public Module Querying

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

    End Module
End Namespace