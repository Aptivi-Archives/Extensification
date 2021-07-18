
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

Namespace ListExts
    ''' <summary>
    ''' Provides the list extensions related to querying
    ''' </summary>
    Public Module Querying

        ''' <summary>
        ''' Checks to see if the array contains any of the targets.
        ''' </summary>
        ''' <param name="TargetArray">Source array</param>
        ''' <param name="Targets">Target array</param>
        ''' <returns>True if all of them are found; else, false.</returns>
        <Extension>
        Public Function ContainsAnyOf(Of T)(TargetArray As List(Of T), Targets() As T) As Boolean
            If TargetArray Is Nothing Then Throw New ArgumentNullException(NameOf(TargetArray))
            For Each Target As T In Targets
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
        Public Function ContainsAllOf(Of T)(TargetArray As List(Of T), Targets() As T) As Boolean
            If TargetArray Is Nothing Then Throw New ArgumentNullException(NameOf(TargetArray))
#If NET45 Then
            Dim Done() As T = {}
#Else
            Dim Done() As T = Array.Empty(Of T)
#End If
            For Each Target As T In Targets
                If TargetArray.Contains(Target) Then Done.Add(Target)
            Next
            Return Done.SequenceEqual(Targets)
        End Function

    End Module
End Namespace