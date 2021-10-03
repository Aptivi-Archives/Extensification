
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

Namespace SingleExts
    ''' <summary>
    ''' Provides the single-precision number extensions related to manipulation
    ''' </summary>
    Public Module Manipulation

        ''' <summary>
        ''' Increments the number
        ''' </summary>
        ''' <param name="Number">Number</param>
        ''' <param name="IncrementThreshold">How many times to increment</param>
        ''' <returns>Incremented number</returns>
        <Extension>
        Public Function Increment(Number As Single, IncrementThreshold As Single) As Single
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
        Public Function Decrement(Number As Single, DecrementThreshold As Single) As Single
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
        Public Sub Swap(ByRef SourceNumber As Single, ByRef TargetNumber As Single)
            Dim Source As Single = SourceNumber
            Dim Target As Single = TargetNumber
            SourceNumber = Target
            TargetNumber = Source
        End Sub

        ''' <summary>
        ''' Swaps the two numbers if the source is larger than the target
        ''' </summary>
        ''' <param name="SourceNumber">Number</param>
        ''' <param name="TargetNumber">Number</param>
        <Extension>
        Public Sub SwapIfSourceLarger(ByRef SourceNumber As Single, ByRef TargetNumber As Single)
            Dim Source As Single = SourceNumber
            Dim Target As Single = TargetNumber
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
        Public Sub SwapIfTargetLarger(ByRef SourceNumber As Single, ByRef TargetNumber As Single)
            Dim Source As Single = SourceNumber
            Dim Target As Single = TargetNumber
            If SourceNumber < TargetNumber Then
                SourceNumber = Target
                TargetNumber = Source
            End If
        End Sub

    End Module
End Namespace