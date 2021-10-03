
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
    ''' Provides the byte extensions related to manipulation
    ''' </summary>
    Public Module Manipulation

        ''' <summary>
        ''' Increments the number
        ''' </summary>
        ''' <param name="Number">Number</param>
        ''' <param name="IncrementThreshold">How many times to increment</param>
        ''' <returns>Incremented number</returns>
        <Extension>
        Public Function Increment(Number As Byte, IncrementThreshold As Byte) As Byte
            If IncrementThreshold < 0 Then Throw New InvalidOperationException("Threshold is negative. Use Decrement().")
            Number += IncrementThreshold
            Return Number
        End Function

        ''' <summary>
        ''' Increments the number
        ''' </summary>
        ''' <param name="Number">Number</param>
        ''' <param name="IncrementThreshold">How many times to increment</param>
        ''' <returns>Incremented number</returns>
        <Extension>
        Public Function Increment(Number As SByte, IncrementThreshold As SByte) As SByte
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
        Public Function Decrement(Number As Byte, DecrementThreshold As Byte) As Byte
            If DecrementThreshold < 0 Then Throw New InvalidOperationException("Threshold is negative. Use Increment().")
            Number -= DecrementThreshold
            Return Number
        End Function

        ''' <summary>
        ''' Decrements the number
        ''' </summary>
        ''' <param name="Number">Number</param>
        ''' <param name="DecrementThreshold">How many times to decrement</param>
        ''' <returns>Decremented number</returns>
        <Extension>
        Public Function Decrement(Number As SByte, DecrementThreshold As SByte) As SByte
            If DecrementThreshold < 0 Then Throw New InvalidOperationException("Threshold is negative. Use Increment().")
            Number -= DecrementThreshold
            Return Number
        End Function

        ''' <summary>
        ''' Swaps the two numbers
        ''' </summary>
        ''' <param name="SourceNumber">Number</param>
        ''' <param name="TargetNumber">Number</param>
        <Extension>
        Public Sub Swap(ByRef SourceNumber As Byte, ByRef TargetNumber As Byte)
            Dim Source As Byte = SourceNumber
            Dim Target As Byte = TargetNumber
            SourceNumber = Target
            TargetNumber = Source
        End Sub

        ''' <summary>
        ''' Swaps the two numbers if the source is larger than the target
        ''' </summary>
        ''' <param name="SourceNumber">Number</param>
        ''' <param name="TargetNumber">Number</param>
        <Extension>
        Public Sub SwapIfSourceLarger(ByRef SourceNumber As Byte, ByRef TargetNumber As Byte)
            Dim Source As Byte = SourceNumber
            Dim Target As Byte = TargetNumber
            If SourceNumber > TargetNumber Then
                SourceNumber = Target
                TargetNumber = Source
            End If
        End Sub

        ''' <summary>
        ''' Swaps the two numbers if the target is larger than the target
        ''' </summary>
        ''' <param name="SourceNumber">Number</param>
        ''' <param name="TargetNumber">Number</param>
        <Extension>
        Public Sub SwapIfTargetLarger(ByRef SourceNumber As Byte, ByRef TargetNumber As Byte)
            Dim Source As Byte = SourceNumber
            Dim Target As Byte = TargetNumber
            If SourceNumber < TargetNumber Then
                SourceNumber = Target
                TargetNumber = Source
            End If
        End Sub

        ''' <summary>
        ''' Swaps the two numbers
        ''' </summary>
        ''' <param name="SourceNumber">Number</param>
        ''' <param name="TargetNumber">Number</param>
        <Extension>
        Public Sub Swap(ByRef SourceNumber As SByte, ByRef TargetNumber As SByte)
            Dim Source As SByte = SourceNumber
            Dim Target As SByte = TargetNumber
            SourceNumber = Target
            TargetNumber = Source
        End Sub

        ''' <summary>
        ''' Swaps the two numbers if the source is larger than the target
        ''' </summary>
        ''' <param name="SourceNumber">Number</param>
        ''' <param name="TargetNumber">Number</param>
        <Extension>
        Public Sub SwapIfSourceLarger(ByRef SourceNumber As SByte, ByRef TargetNumber As SByte)
            Dim Source As SByte = SourceNumber
            Dim Target As SByte = TargetNumber
            If SourceNumber > TargetNumber Then
                SourceNumber = Target
                TargetNumber = Source
            End If
        End Sub

        ''' <summary>
        ''' Swaps the two numbers if the target is larger than the target
        ''' </summary>
        ''' <param name="SourceNumber">Number</param>
        ''' <param name="TargetNumber">Number</param>
        <Extension>
        Public Sub SwapIfTargetLarger(ByRef SourceNumber As SByte, ByRef TargetNumber As SByte)
            Dim Source As SByte = SourceNumber
            Dim Target As SByte = TargetNumber
            If SourceNumber < TargetNumber Then
                SourceNumber = Target
                TargetNumber = Source
            End If
        End Sub

    End Module
End Namespace