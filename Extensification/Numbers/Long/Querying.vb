
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

Namespace LongExts
    ''' <summary>
    ''' Provides the 64-bit integer extensions related to querying
    ''' </summary>
    Public Module Querying

        ''' <summary>
        ''' Makes a list of digits
        ''' </summary>
        ''' <param name="Number">Number</param>
        ''' <returns>Array of digits</returns>
        <Extension>
        Public Function ListDigits(ByVal Number As Long) As Long()
            Dim StrNum As String = Number.ToString
            Dim NumList As Long() = Array.ConvertAll(StrNum.ToCharArray, Function(x) Convert.ToInt64(x.ToString))
            Return NumList
        End Function

        ''' <summary>
        ''' Makes a list of digits
        ''' </summary>
        ''' <param name="Number">Number</param>
        ''' <returns>Array of digits</returns>
        <Extension>
        Public Function ListDigits(ByVal Number As ULong) As ULong()
            Dim StrNum As String = Number.ToString
            Dim NumList As ULong() = Array.ConvertAll(StrNum.ToCharArray, Function(x) Convert.ToUInt64(x.ToString))
            Return NumList
        End Function

        ''' <summary>
        ''' Checks to see if the number is an Armstrong number (sum of cube of each digit of number equals the number itself)
        ''' </summary>
        ''' <param name="Number">Number</param>
        ''' <returns>True if the number is an Armstrong number; False if not.</returns>
        <Extension>
        Public Function IsArmstrong(ByVal Number As Long) As Boolean
            Dim Num As Long = Number
            Dim NumberDigits() As Long = Num.ListDigits
            Dim SumOfCubesOfDigits As Long
            For i As Integer = 0 To NumberDigits.Length - 1
                SumOfCubesOfDigits += Math.Pow(NumberDigits(i), 3)
            Next
            Return Num = SumOfCubesOfDigits
        End Function

        ''' <summary>
        ''' Checks to see if the number is an Armstrong number (sum of cube of each digit of number equals the number itself)
        ''' </summary>
        ''' <param name="Number">Number</param>
        ''' <returns>True if the number is an Armstrong number; False if not.</returns>
        <Extension>
        Public Function IsArmstrong(ByVal Number As ULong) As Boolean
            Dim Num As ULong = Number
            Dim NumberDigits() As ULong = Num.ListDigits
            Dim SumOfCubesOfDigits As ULong
            For i As Integer = 0 To NumberDigits.Length - 1
                SumOfCubesOfDigits += Math.Pow(NumberDigits(i), 3)
            Next
            Return Num = SumOfCubesOfDigits
        End Function

    End Module
End Namespace