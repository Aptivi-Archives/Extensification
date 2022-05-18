
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

Imports NUnit.Framework
Imports Extensification.DoubleExts

<TestFixture>
Public Class DoubleTests

#Region "Manipulation"
    ''' <summary>
    ''' Tests double-precision number incrementation
    ''' </summary>
    <Test>
    Public Sub TestIncrement()
        Dim ExpectedDouble As Double = 5
        Dim TargetDouble As Double = 3
        TargetDouble = TargetDouble.Increment(2)
        Assert.AreEqual(ExpectedDouble, TargetDouble)
    End Sub

    ''' <summary>
    ''' Tests double-precision number decrementation
    ''' </summary>
    <Test>
    Public Sub TestDecrement()
        Dim ExpectedDouble As Double = 3
        Dim TargetDouble As Double = 5
        TargetDouble = TargetDouble.Decrement(2)
        Assert.AreEqual(ExpectedDouble, TargetDouble)
    End Sub

    ''' <summary>
    ''' Tests byte swap
    ''' </summary>
    <Test>
    Public Sub TestSwap()
        Dim ExpectedFirstByte As Double = 9
        Dim ExpectedSecondByte As Double = 8
        Dim TargetFirstByte As Double = 8
        Dim TargetSecondByte As Double = 9
        TargetFirstByte.Swap(TargetSecondByte)
        Assert.AreEqual(ExpectedFirstByte, TargetFirstByte)
        Assert.AreEqual(ExpectedSecondByte, TargetSecondByte)
    End Sub

    ''' <summary>
    ''' Tests byte swap if source is larger
    ''' </summary>
    <Test>
    Public Sub TestSwapIfSourceLarger()
        Dim ExpectedFirstByte As Double = 8
        Dim ExpectedSecondByte As Double = 10
        Dim TargetFirstByte As Double = 10
        Dim TargetSecondByte As Double = 8
        TargetFirstByte.SwapIfSourceLarger(TargetSecondByte)
        Assert.AreEqual(ExpectedFirstByte, TargetFirstByte)
        Assert.AreEqual(ExpectedSecondByte, TargetSecondByte)
    End Sub

    ''' <summary>
    ''' Tests byte swap if target is larger
    ''' </summary>
    <Test>
    Public Sub TestSwapIfTargetLarger()
        Dim ExpectedFirstByte As Double = 10
        Dim ExpectedSecondByte As Double = 8
        Dim TargetFirstByte As Double = 8
        Dim TargetSecondByte As Double = 10
        TargetFirstByte.SwapIfTargetLarger(TargetSecondByte)
        Assert.AreEqual(ExpectedFirstByte, TargetFirstByte)
        Assert.AreEqual(ExpectedSecondByte, TargetSecondByte)
    End Sub
#End Region

#Region "Querying"
    ''' <summary>
    ''' Tests double digit listing (before the decimal point)
    ''' </summary>
    <Test>
    Public Sub TestListDigitsBeforeDecimal()
        Dim ExpectedDigits() As Double = {3, 2}
        Dim TargetNumber As Double = 32.9
        Assert.IsTrue(ExpectedDigits.SequenceEqual(TargetNumber.ListDigitsBeforeDecimal))
    End Sub

    ''' <summary>
    ''' Tests double digit listing (after the decimal point)
    ''' </summary>
    <Test>
    Public Sub TestListDigitsAfterDecimal()
        Dim ExpectedDigits() As Double = {9}
        Dim TargetNumber As Double = 32.9
        Assert.IsTrue(ExpectedDigits.SequenceEqual(TargetNumber.ListDigitsAfterDecimal))
    End Sub

    ''' <summary>
    ''' Tests double Armstrong number detection
    ''' </summary>
    <Test>
    Public Sub TestIsArmstrong()
        Dim TargetNumber As Double = 153.4
        Assert.IsTrue(TargetNumber.IsArmstrong)
    End Sub
#End Region

End Class
