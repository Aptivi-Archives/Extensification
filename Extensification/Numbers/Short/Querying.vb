﻿
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

Namespace ShortExts
    ''' <summary>
    ''' Provides the 16-bit integer extensions related to querying
    ''' </summary>
    Public Module Querying

        ''' <summary>
        ''' Makes a list of digits
        ''' </summary>
        ''' <param name="Number">Number</param>
        ''' <returns>Array of digits</returns>
        <Extension>
        Public Function ListDigits(Number As Short) As Short()
            Dim StrNum As String = Number.ToString
            Dim NumList As Short() = Array.ConvertAll(StrNum.ToCharArray, Function(x) Convert.ToInt16(x.ToString))
            Return NumList
        End Function

        ''' <summary>
        ''' Makes a list of digits
        ''' </summary>
        ''' <param name="Number">Number</param>
        ''' <returns>Array of digits</returns>
        <Extension>
        Public Function ListDigits(Number As UShort) As UShort()
            Dim StrNum As String = Number.ToString
            Dim NumList As UShort() = Array.ConvertAll(StrNum.ToCharArray, Function(x) Convert.ToUInt16(x.ToString))
            Return NumList
        End Function

        ''' <summary>
        ''' Checks to see if the number is an Armstrong number (sum of cube of each digit of number equals the number itself)
        ''' </summary>
        ''' <param name="Number">Number</param>
        ''' <returns>True if the number is an Armstrong number; False if not.</returns>
        <Extension>
        Public Function IsArmstrong(Number As Short) As Boolean
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
        Public Function IsArmstrong(Number As UShort) As Boolean
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