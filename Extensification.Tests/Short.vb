
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
Imports Extensification.ShortExts

<TestFixture>
Public Class ShortTests

#Region "Manipulation"
    ''' <summary>
    ''' Tests short integer incrementation
    ''' </summary>
    <Test>
    Public Sub TestIncrement()
        Dim ExpectedShort As Short = 5
        Dim TargetShort As Short = 3
        TargetShort = TargetShort.Increment(2)
        Assert.AreEqual(ExpectedShort, TargetShort)
    End Sub

    ''' <summary>
    ''' Tests unsigned short integer incrementation
    ''' </summary>
    <Test>
    Public Sub TestIncrementUnsigned()
        Dim ExpectedUShort As UShort = 5
        Dim TargetUShort As UShort = 3
        TargetUShort = TargetUShort.Increment(2)
        Assert.AreEqual(ExpectedUShort, TargetUShort)
    End Sub

    ''' <summary>
    ''' Tests short integer decrementation
    ''' </summary>
    <Test>
    Public Sub TestDecrement()
        Dim ExpectedShort As Short = 3
        Dim TargetShort As Short = 5
        TargetShort = TargetShort.Decrement(2)
        Assert.AreEqual(ExpectedShort, TargetShort)
    End Sub

    ''' <summary>
    ''' Tests unsigned short integer decrementation
    ''' </summary>
    <Test>
    Public Sub TestDecrementUnsigned()
        Dim ExpectedUShort As UShort = 3
        Dim TargetUShort As UShort = 5
        TargetUShort = TargetUShort.Decrement(2)
        Assert.AreEqual(ExpectedUShort, TargetUShort)
    End Sub

    ''' <summary>
    ''' Tests byte swap
    ''' </summary>
    <Test>
    Public Sub TestSwap()
        Dim ExpectedFirstByte As Short = 9
        Dim ExpectedSecondByte As Short = 8
        Dim TargetFirstByte As Short = 8
        Dim TargetSecondByte As Short = 9
        TargetFirstByte.Swap(TargetSecondByte)
        Assert.AreEqual(ExpectedFirstByte, TargetFirstByte)
        Assert.AreEqual(ExpectedSecondByte, TargetSecondByte)
    End Sub

    ''' <summary>
    ''' Tests signed byte swap
    ''' </summary>
    <Test>
    Public Sub TestSwapSigned()
        Dim ExpectedFirstByte As UShort = 9
        Dim ExpectedSecondByte As UShort = 8
        Dim TargetFirstByte As UShort = 8
        Dim TargetSecondByte As UShort = 9
        TargetFirstByte.Swap(TargetSecondByte)
        Assert.AreEqual(ExpectedFirstByte, TargetFirstByte)
        Assert.AreEqual(ExpectedSecondByte, TargetSecondByte)
    End Sub

    ''' <summary>
    ''' Tests byte swap if source is larger
    ''' </summary>
    <Test>
    Public Sub TestSwapIfSourceLarger()
        Dim ExpectedFirstByte As Short = 8
        Dim ExpectedSecondByte As Short = 10
        Dim TargetFirstByte As Short = 10
        Dim TargetSecondByte As Short = 8
        TargetFirstByte.SwapIfSourceLarger(TargetSecondByte)
        Assert.AreEqual(ExpectedFirstByte, TargetFirstByte)
        Assert.AreEqual(ExpectedSecondByte, TargetSecondByte)
    End Sub

    ''' <summary>
    ''' Tests signed byte swap if source is larger
    ''' </summary>
    <Test>
    Public Sub TestSwapIfSourceLargerSigned()
        Dim ExpectedFirstByte As UShort = 8
        Dim ExpectedSecondByte As UShort = 10
        Dim TargetFirstByte As UShort = 10
        Dim TargetSecondByte As UShort = 8
        TargetFirstByte.SwapIfSourceLarger(TargetSecondByte)
        Assert.AreEqual(ExpectedFirstByte, TargetFirstByte)
        Assert.AreEqual(ExpectedSecondByte, TargetSecondByte)
    End Sub

    ''' <summary>
    ''' Tests byte swap if target is larger
    ''' </summary>
    <Test>
    Public Sub TestSwapIfTargetLarger()
        Dim ExpectedFirstByte As Short = 10
        Dim ExpectedSecondByte As Short = 8
        Dim TargetFirstByte As Short = 8
        Dim TargetSecondByte As Short = 10
        TargetFirstByte.SwapIfTargetLarger(TargetSecondByte)
        Assert.AreEqual(ExpectedFirstByte, TargetFirstByte)
        Assert.AreEqual(ExpectedSecondByte, TargetSecondByte)
    End Sub

    ''' <summary>
    ''' Tests signed byte swap if target is larger
    ''' </summary>
    <Test>
    Public Sub TestSwapIfTargetLargerSigned()
        Dim ExpectedFirstByte As UShort = 10
        Dim ExpectedSecondByte As UShort = 8
        Dim TargetFirstByte As UShort = 8
        Dim TargetSecondByte As UShort = 10
        TargetFirstByte.SwapIfTargetLarger(TargetSecondByte)
        Assert.AreEqual(ExpectedFirstByte, TargetFirstByte)
        Assert.AreEqual(ExpectedSecondByte, TargetSecondByte)
    End Sub
#End Region

#Region "Querying"
    ''' <summary>
    ''' Tests short integer digit listing
    ''' </summary>
    <Test>
    Public Sub TestListDigits()
        Dim ExpectedDigits() As Short = {7, 5}
        Dim TargetNumber As Short = 75
        Assert.IsTrue(ExpectedDigits.SequenceEqual(TargetNumber.ListDigits))
    End Sub

    ''' <summary>
    ''' Tests unsigned short integer digit listing
    ''' </summary>
    <Test>
    Public Sub TestListDigitsUnsigned()
        Dim ExpectedDigits() As UShort = {7, 5}
        Dim TargetNumber As UShort = 75
        Assert.IsTrue(ExpectedDigits.SequenceEqual(TargetNumber.ListDigits))
    End Sub

    ''' <summary>
    ''' Tests short integer Armstrong number detection
    ''' </summary>
    <Test>
    Public Sub TestIsArmstrong()
        Dim TargetNumber As Short = 153
        Assert.IsTrue(TargetNumber.IsArmstrong)
    End Sub

    ''' <summary>
    ''' Tests unsigned short integer Armstrong number detection
    ''' </summary>
    <Test>
    Public Sub TestIsArmstrongUnsigned()
        Dim TargetNumber As UShort = 153
        Assert.IsTrue(TargetNumber.IsArmstrong)
    End Sub
#End Region

End Class
