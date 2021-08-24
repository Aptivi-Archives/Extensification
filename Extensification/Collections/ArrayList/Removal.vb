﻿
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

Namespace ArrayListExts
    ''' <summary>
    ''' Provides the array list extensions related to removal
    ''' </summary>
    Public Module Removal

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

    End Module
End Namespace