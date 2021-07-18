
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
    ''' Provides the character extensions related to manipulation
    ''' </summary>
    Public Module Manipulation

        ''' <summary>
        ''' Increments the character
        ''' </summary>
        ''' <param name="Character">Character</param>
        ''' <param name="IncrementThreshold">How many times to increment</param>
        ''' <returns>Incremented character</returns>
        <Extension>
        Public Function Increment(ByVal Character As Char, ByVal IncrementThreshold As Integer) As Char
            If IncrementThreshold < 0 Then Throw New InvalidOperationException("Threshold is negative. Use Decrement().")
            Return ChrW(AscW(Character) + IncrementThreshold)
        End Function

        ''' <summary>
        ''' Decrements the character
        ''' </summary>
        ''' <param name="Character">Character</param>
        ''' <param name="DecrementThreshold">How many times to decrement</param>
        ''' <returns>Decremented character</returns>
        <Extension>
        Public Function Decrement(ByVal Character As Char, ByVal DecrementThreshold As Integer) As Char
            If DecrementThreshold < 0 Then Throw New InvalidOperationException("Threshold is negative. Use Increment().")
            Return ChrW(AscW(Character) - DecrementThreshold)
        End Function

    End Module
End Namespace