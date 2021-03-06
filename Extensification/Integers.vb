
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

        ''' <summary>
        ''' Makes a list of digits
        ''' </summary>
        ''' <param name="Number">Number</param>
        ''' <returns>Array of digits</returns>
        <Extension>
        Public Function ListDigits(ByVal Number As Integer) As Integer()
            Dim StrNum As String = Number.ToString
            Dim NumList As Integer() = Array.ConvertAll(StrNum.ToCharArray, Function(x) Convert.ToInt32(x.ToString))
            Return NumList
        End Function

        ''' <summary>
        ''' Makes a list of digits
        ''' </summary>
        ''' <param name="Number">Number</param>
        ''' <returns>Array of digits</returns>
        <Extension>
        Public Function ListDigits(ByVal Number As UInteger) As UInteger()
            Dim StrNum As String = Number.ToString
            Dim NumList As UInteger() = Array.ConvertAll(StrNum.ToCharArray, Function(x) Convert.ToUInt32(x.ToString))
            Return NumList
        End Function

        ''' <summary>
        ''' Checks to see if the number is an Armstrong number (sum of cube of each digit of number equals the number itself)
        ''' </summary>
        ''' <param name="Number">Number</param>
        ''' <returns>True if the number is an Armstrong number; False if not.</returns>
        <Extension>
        Public Function IsArmstrong(ByVal Number As Integer) As Boolean
            Dim IntNum As Integer = Number
            Dim NumberDigits() As Integer = IntNum.ListDigits
            Dim SumOfCubesOfDigits As Integer
            For i As Integer = 0 To NumberDigits.Length - 1
                SumOfCubesOfDigits += Math.Pow(NumberDigits(i), 3)
            Next
            Return IntNum = SumOfCubesOfDigits
        End Function

        ''' <summary>
        ''' Checks to see if the number is an Armstrong number (sum of cube of each digit of number equals the number itself)
        ''' </summary>
        ''' <param name="Number">Number</param>
        ''' <returns>True if the number is an Armstrong number; False if not.</returns>
        <Extension>
        Public Function IsArmstrong(ByVal Number As UInteger) As Boolean
            Dim IntNum As UInteger = Number
            Dim NumberDigits() As UInteger = IntNum.ListDigits
            Dim SumOfCubesOfDigits As UInteger
            For i As UInteger = 0 To NumberDigits.Length - 1
                SumOfCubesOfDigits += Math.Pow(NumberDigits(i), 3)
            Next
            Return IntNum = SumOfCubesOfDigits
        End Function

    End Module
End Namespace
