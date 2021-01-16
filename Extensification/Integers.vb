
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

Namespace IntegerExts
    Public Module Extensions

        ''' <summary>
        ''' Increments the number
        ''' </summary>
        ''' <param name="Number">Number</param>
        ''' <param name="IncrementThreshold">How many times to increment</param>
        ''' <returns>Incremented number</returns>
        <Extension>
        Public Function Increment(ByVal Number As Integer, ByVal IncrementThreshold As Integer) As Integer
            If IncrementThreshold < 0 Then Throw New InvalidOperationException("Threshold is negative. Use Decrement().")
            Number += IncrementThreshold
            Return Number
        End Function

        ''' <summary>
        ''' Decrements the number
        ''' </summary>
        ''' <param name="Number">Number</param>
        ''' <param name="DecrementThreshold">How many times to decrement</param>
        ''' <returns>Decremented number</returns>
        <Extension>
        Public Function Decrement(ByVal Number As Integer, ByVal DecrementThreshold As Integer) As Integer
            If DecrementThreshold < 0 Then Throw New InvalidOperationException("Threshold is negative. Use Increment().")
            Number -= DecrementThreshold
            Return Number
        End Function

        ''' <summary>
        ''' Increments the number
        ''' </summary>
        ''' <param name="Number">Number</param>
        ''' <param name="IncrementThreshold">How many times to increment</param>
        ''' <returns>Incremented number</returns>
        <Extension>
        Public Function Increment(ByVal Number As UInteger, ByVal IncrementThreshold As Integer) As Integer
            If IncrementThreshold < 0 Then Throw New InvalidOperationException("Threshold is negative. Use Decrement().")
            Number += IncrementThreshold
            Return Number
        End Function

        ''' <summary>
        ''' Decrements the number
        ''' </summary>
        ''' <param name="Number">Number</param>
        ''' <param name="DecrementThreshold">How many times to decrement</param>
        ''' <returns>Decremented number</returns>
        <Extension>
        Public Function Decrement(ByVal Number As UInteger, ByVal DecrementThreshold As Integer) As Integer
            If DecrementThreshold < 0 Then Throw New InvalidOperationException("Threshold is negative. Use Increment().")
            Number -= DecrementThreshold
            Return Number
        End Function

    End Module
End Namespace
