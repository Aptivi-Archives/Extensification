
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

Namespace EnumerableExts
    ''' <summary>
    ''' Provides the enumerable extensions related to addition
    ''' </summary>
    Public Module Addition

#If Not NETCOREAPP Then
        ''' <summary>
        ''' Appends a value to the end of the sequence
        ''' </summary>
        ''' <typeparam name="Source">Source type</typeparam>
        ''' <param name="TargetEnumerable">Source</param>
        ''' <param name="Value">Value</param>
        <Extension>
        Public Function Append(Of Source)(TargetEnumerable As IEnumerable(Of Source), Value As Source) As IEnumerable(Of Source)
            Return TargetEnumerable.Concat({Value})
        End Function
#End If

    End Module
End Namespace