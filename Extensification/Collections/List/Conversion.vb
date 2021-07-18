
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

Namespace ListExts
    ''' <summary>
    ''' Provides the list extensions related to conversion
    ''' </summary>
    Public Module Conversion

        ''' <summary>
        ''' Converts list to array list
        ''' </summary>
        ''' <typeparam name="T">Type</typeparam>
        ''' <param name="TargetList">Target list</param>
        <Extension>
        Public Function ToArrayList(Of T)(ByVal TargetList As List(Of T)) As ArrayList
            Dim ResultList As New ArrayList
            ResultList.AddRange(TargetList)
            Return ResultList
        End Function

    End Module
End Namespace