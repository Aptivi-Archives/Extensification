
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
    ''' Provides the array extensions related to conversion
    ''' </summary>
    Public Module Conversion

        ''' <summary>
        ''' Converts array to array list
        ''' </summary>
        ''' <typeparam name="T">Type</typeparam>
        ''' <param name="TargetArray">Target array</param>
        ''' <returns>An array list of an array</returns>
        <Extension>
        Public Function ToArrayList(Of T)(TargetArray() As T) As ArrayList
            If TargetArray Is Nothing Then Throw New ArgumentNullException(NameOf(TargetArray))
            Dim ArrayValues As New ArrayList
            ArrayValues.AddRange(TargetArray)
            Return ArrayValues
        End Function

    End Module
End Namespace