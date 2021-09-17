
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
    ''' Provides the array list extensions related to conversion
    ''' </summary>
    Public Module Conversion

        ''' <summary>
        ''' Converts an array list to list of <see cref="Object"/>.
        ''' </summary>
        ''' <param name="TargetArray">Target array list</param>
        ''' <returns>A list from array list</returns>
        <Extension>
        Public Function ToList(TargetArray As ArrayList) As List(Of Object)
            If TargetArray Is Nothing Then Throw New ArgumentNullException(NameOf(TargetArray))
            Dim ArrayValues As New List(Of Object)
            ArrayValues.AddRange(TargetArray.ToArray)
            Return ArrayValues
        End Function

    End Module
End Namespace