
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

Namespace CharExts
    ''' <summary>
    ''' Provides the character extensions related to querying
    ''' </summary>
    Public Module Querying

        ''' <summary>
        ''' Gets an ASCII code of a character
        ''' </summary>
        ''' <param name="Character">Character</param>
        ''' <returns>ASCII code of a character</returns>
        <Extension>
        Public Function GetAsciiCode(Character As Char) As Integer
            Return Convert.ToInt32(Character)
        End Function

    End Module
End Namespace