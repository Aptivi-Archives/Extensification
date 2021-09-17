
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

Namespace ByteExts
    ''' <summary>
    ''' Provides the byte extensions related to querying
    ''' </summary>
    Public Module Querying

        ''' <summary>
        ''' Makes a list of digits
        ''' </summary>
        ''' <param name="Number">Number</param>
        ''' <returns>Array of digits</returns>
        <Extension>
        Public Function ListDigits(Number As Byte) As Byte()
            Dim StrNum As String = Number.ToString
            Dim NumList As Byte() = Array.ConvertAll(StrNum.ToCharArray, Function(x) Convert.ToByte(x.ToString))
            Return NumList
        End Function

        ''' <summary>
        ''' Makes a list of digits
        ''' </summary>
        ''' <param name="Number">Number</param>
        ''' <returns>Array of digits</returns>
        <Extension>
        Public Function ListDigits(Number As SByte) As SByte()
            Dim StrNum As String = Number.ToString
            Dim NumList As SByte() = Array.ConvertAll(StrNum.ToCharArray, Function(x) Convert.ToSByte(x.ToString))
            Return NumList
        End Function

        ''' <summary>
        ''' Checks to see if the number is an Armstrong number (sum of cube of each digit of number equals the number itself)
        ''' </summary>
        ''' <param name="Number">Number</param>
        ''' <returns>True if the number is an Armstrong number; False if not.</returns>
        <Extension>
        Public Function IsArmstrong(Number As Byte) As Boolean
            Dim IntNum As Byte = Number
            Dim NumberDigits() As Byte = IntNum.ListDigits
            Dim SumOfCubesOfDigits As Byte
            For i As Byte = 0 To NumberDigits.Length - 1
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
        Public Function IsArmstrong(Number As SByte) As Boolean
            Dim IntNum As SByte = Number
            Dim NumberDigits() As SByte = IntNum.ListDigits
            Dim SumOfCubesOfDigits As SByte
            For i As SByte = 0 To NumberDigits.Length - 1
                SumOfCubesOfDigits += Math.Pow(NumberDigits(i), 3)
            Next
            Return IntNum = SumOfCubesOfDigits
        End Function

    End Module
End Namespace