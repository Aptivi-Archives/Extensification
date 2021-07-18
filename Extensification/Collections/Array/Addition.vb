
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

Namespace ArrayExts
    ''' <summary>
    ''' Provides the array extensions related to addition
    ''' </summary>
    Public Module Addition

        ''' <summary>
        ''' Adds an entry to array
        ''' </summary>
        ''' <typeparam name="T">Type</typeparam>
        ''' <param name="TargetArray">Target array</param>
        ''' <param name="Item">Any item</param>
        <Extension>
        Public Sub Add(Of T)(ByRef TargetArray() As T, ByVal Item As T)
            If TargetArray Is Nothing Then Throw New ArgumentNullException(NameOf(TargetArray))
            Array.Resize(TargetArray, TargetArray.Length + 1)
            TargetArray(TargetArray.Length - 1) = Item
        End Sub

        ''' <summary>
        ''' Adds a range of entries to array
        ''' </summary>
        ''' <typeparam name="T">Type</typeparam>
        ''' <param name="TargetArray">Target array</param>
        ''' <param name="ToBeAdded">Range of entries in an array</param>
        <Extension>
        Public Sub AddRange(Of T)(ByRef TargetArray() As T, ByVal ToBeAdded() As T)
            If TargetArray Is Nothing Then Throw New ArgumentNullException(NameOf(TargetArray))
            Dim OldIndex As Integer = TargetArray.Length - 1
            Array.Resize(TargetArray, TargetArray.Length + ToBeAdded.Length)
            Dim NewIndex As Integer = TargetArray.Length - 1
            Dim AddedIndex As Integer = 0
            For CurrIndex As Integer = OldIndex + 1 To NewIndex
                TargetArray(CurrIndex) = ToBeAdded(AddedIndex)
                AddedIndex += 1
            Next
        End Sub

    End Module
End Namespace
