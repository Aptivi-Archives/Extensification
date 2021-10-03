
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
    ''' <summary>
    ''' Provides the integer extensions related to manipulation
    ''' </summary>
    Public Module Manipulation

        ''' <summary>
        ''' Increments the number
        ''' </summary>
        ''' <param name="Number">Number</param>
        ''' <param name="IncrementThreshold">How many times to increment</param>
        ''' <returns>Incremented number</returns>
        <Extension>
        Public Function Increment(Number As Integer, IncrementThreshold As Integer) As Integer
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
        Public Function Increment(Number As UInteger, IncrementThreshold As UInteger) As UInteger
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
        Public Function Decrement(Number As Integer, DecrementThreshold As Integer) As Integer
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
        Public Function Decrement(Number As UInteger, DecrementThreshold As UInteger) As UInteger
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
        Public Sub Swap(ByRef SourceNumber As Integer, ByRef TargetNumber As Integer)
            Dim Source As Integer = SourceNumber
            Dim Target As Integer = TargetNumber
            SourceNumber = Target
            TargetNumber = Source
        End Sub

        ''' <summary>
        ''' Swaps the two numbers if the source is larger than the target
        ''' </summary>
        ''' <param name="SourceNumber">Number</param>
        ''' <param name="TargetNumber">Number</param>
        <Extension>
        Public Sub SwapIfSourceLarger(ByRef SourceNumber As Integer, ByRef TargetNumber As Integer)
            Dim Source As Integer = SourceNumber
            Dim Target As Integer = TargetNumber
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
        Public Sub SwapIfTargetLarger(ByRef SourceNumber As Integer, ByRef TargetNumber As Integer)
            Dim Source As Integer = SourceNumber
            Dim Target As Integer = TargetNumber
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
        Public Sub Swap(ByRef SourceNumber As UInteger, ByRef TargetNumber As UInteger)
            Dim Source As UInteger = SourceNumber
            Dim Target As UInteger = TargetNumber
            SourceNumber = Target
            TargetNumber = Source
        End Sub

        ''' <summary>
        ''' Swaps the two numbers if the source is larger than the target
        ''' </summary>
        ''' <param name="SourceNumber">Number</param>
        ''' <param name="TargetNumber">Number</param>
        <Extension>
        Public Sub SwapIfSourceLarger(ByRef SourceNumber As UInteger, ByRef TargetNumber As UInteger)
            Dim Source As UInteger = SourceNumber
            Dim Target As UInteger = TargetNumber
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
        Public Sub SwapIfTargetLarger(ByRef SourceNumber As UInteger, ByRef TargetNumber As UInteger)
            Dim Source As UInteger = SourceNumber
            Dim Target As UInteger = TargetNumber
            If SourceNumber < TargetNumber Then
                SourceNumber = Target
                TargetNumber = Source
            End If
        End Sub

    End Module
End Namespace