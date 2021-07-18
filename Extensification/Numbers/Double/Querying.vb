
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
Imports Extensification.IntegerExts

Namespace DoubleExts
    ''' <summary>
    ''' Provides the double-precision number extensions related to querying
    ''' </summary>
    Public Module Querying

        ''' <summary>
        ''' Makes a list of digits before the decimal point
        ''' </summary>
        ''' <param name="Number">Number</param>
        ''' <returns>Array of digits</returns>
        <Extension>
        Public Function ListDigitsBeforeDecimal(ByVal Number As Double) As Double()
            Dim StrNum As String = Number.ToString.Substring(0, Number.ToString.IndexOf("."))
            Dim NumList As Double() = Array.ConvertAll(StrNum.ToCharArray, Function(x) Convert.ToDouble(x.ToString))
            Return NumList
        End Function

        ''' <summary>
        ''' Makes a list of digits after the decimal point
        ''' </summary>
        ''' <param name="Number">Number</param>
        ''' <returns>Array of digits</returns>
        <Extension>
        Public Function ListDigitsAfterDecimal(ByVal Number As Double) As Double()
            Dim StrNum As String = Number.ToString.Substring(Number.ToString.IndexOf(".") + 1)
            Dim NumList As Double() = Array.ConvertAll(StrNum.ToCharArray, Function(x) Convert.ToDouble(x.ToString))
            Return NumList
        End Function

        ''' <summary>
        ''' Checks to see if the number is an Armstrong number (sum of cube of each digit of number equals the number itself)
        ''' </summary>
        ''' <param name="Number">Number</param>
        ''' <returns>True if the number is an Armstrong number; False if not.</returns>
        <Extension>
        Public Function IsArmstrong(ByVal Number As Double) As Boolean
            Dim IntNum As Integer = Number
            Dim NumberDigits() As Integer = IntNum.ListDigits
            Dim SumOfCubesOfDigits As Integer
            For i As Integer = 0 To NumberDigits.Length - 1
                SumOfCubesOfDigits += Math.Pow(NumberDigits(i), 3)
            Next
            Return IntNum = SumOfCubesOfDigits
        End Function

    End Module
End Namespace