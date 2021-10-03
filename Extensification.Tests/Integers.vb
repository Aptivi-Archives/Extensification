
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

Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Extensification.IntegerExts

<TestClass>
Public Class IntegerTests

#Region "Manipulation"
    ''' <summary>
    ''' Tests integer incrementation
    ''' </summary>
    <TestMethod>
    Public Sub TestIncrement()
        Dim ExpectedInteger As Integer = 5
        Dim TargetInteger As Integer = 3
        TargetInteger = TargetInteger.Increment(2)
        Assert.AreEqual(ExpectedInteger, TargetInteger)
    End Sub

    ''' <summary>
    ''' Tests unsigned integer incrementation
    ''' </summary>
    <TestMethod>
    Public Sub TestIncrementUnsigned()
        Dim ExpectedUInteger As UInteger = 5
        Dim TargetUInteger As UInteger = 3
        TargetUInteger = TargetUInteger.Increment(2)
        Assert.AreEqual(ExpectedUInteger, TargetUInteger)
    End Sub

    ''' <summary>
    ''' Tests integer decrementation
    ''' </summary>
    <TestMethod>
    Public Sub TestDecrement()
        Dim ExpectedInteger As Integer = 3
        Dim TargetInteger As Integer = 5
        TargetInteger = TargetInteger.Decrement(2)
        Assert.AreEqual(ExpectedInteger, TargetInteger)
    End Sub

    ''' <summary>
    ''' Tests unsigned integer decrementation
    ''' </summary>
    <TestMethod>
    Public Sub TestDecrementUnsigned()
        Dim ExpectedUInteger As UInteger = 3
        Dim TargetUInteger As UInteger = 5
        TargetUInteger = TargetUInteger.Decrement(2)
        Assert.AreEqual(ExpectedUInteger, TargetUInteger)
    End Sub

    ''' <summary>
    ''' Tests byte swap
    ''' </summary>
    <TestMethod>
    Public Sub TestSwap()
        Dim ExpectedFirstByte As Integer = 9
        Dim ExpectedSecondByte As Integer = 8
        Dim TargetFirstByte As Integer = 8
        Dim TargetSecondByte As Integer = 9
        TargetFirstByte.Swap(TargetSecondByte)
        Assert.AreEqual(ExpectedFirstByte, TargetFirstByte)
        Assert.AreEqual(ExpectedSecondByte, TargetSecondByte)
    End Sub

    ''' <summary>
    ''' Tests signed byte swap
    ''' </summary>
    <TestMethod>
    Public Sub TestSwapSigned()
        Dim ExpectedFirstByte As UInteger = 9
        Dim ExpectedSecondByte As UInteger = 8
        Dim TargetFirstByte As UInteger = 8
        Dim TargetSecondByte As UInteger = 9
        TargetFirstByte.Swap(TargetSecondByte)
        Assert.AreEqual(ExpectedFirstByte, TargetFirstByte)
        Assert.AreEqual(ExpectedSecondByte, TargetSecondByte)
    End Sub

    ''' <summary>
    ''' Tests byte swap if source is larger
    ''' </summary>
    <TestMethod>
    Public Sub TestSwapIfSourceLarger()
        Dim ExpectedFirstByte As Integer = 8
        Dim ExpectedSecondByte As Integer = 10
        Dim TargetFirstByte As Integer = 10
        Dim TargetSecondByte As Integer = 8
        TargetFirstByte.SwapIfSourceLarger(TargetSecondByte)
        Assert.AreEqual(ExpectedFirstByte, TargetFirstByte)
        Assert.AreEqual(ExpectedSecondByte, TargetSecondByte)
    End Sub

    ''' <summary>
    ''' Tests signed byte swap if source is larger
    ''' </summary>
    <TestMethod>
    Public Sub TestSwapIfSourceLargerSigned()
        Dim ExpectedFirstByte As UInteger = 8
        Dim ExpectedSecondByte As UInteger = 10
        Dim TargetFirstByte As UInteger = 10
        Dim TargetSecondByte As UInteger = 8
        TargetFirstByte.SwapIfSourceLarger(TargetSecondByte)
        Assert.AreEqual(ExpectedFirstByte, TargetFirstByte)
        Assert.AreEqual(ExpectedSecondByte, TargetSecondByte)
    End Sub

    ''' <summary>
    ''' Tests byte swap if target is larger
    ''' </summary>
    <TestMethod>
    Public Sub TestSwapIfTargetLarger()
        Dim ExpectedFirstByte As Integer = 10
        Dim ExpectedSecondByte As Integer = 8
        Dim TargetFirstByte As Integer = 8
        Dim TargetSecondByte As Integer = 10
        TargetFirstByte.SwapIfTargetLarger(TargetSecondByte)
        Assert.AreEqual(ExpectedFirstByte, TargetFirstByte)
        Assert.AreEqual(ExpectedSecondByte, TargetSecondByte)
    End Sub

    ''' <summary>
    ''' Tests signed byte swap if target is larger
    ''' </summary>
    <TestMethod>
    Public Sub TestSwapIfTargetLargerSigned()
        Dim ExpectedFirstByte As UInteger = 10
        Dim ExpectedSecondByte As UInteger = 8
        Dim TargetFirstByte As UInteger = 8
        Dim TargetSecondByte As UInteger = 10
        TargetFirstByte.SwapIfTargetLarger(TargetSecondByte)
        Assert.AreEqual(ExpectedFirstByte, TargetFirstByte)
        Assert.AreEqual(ExpectedSecondByte, TargetSecondByte)
    End Sub
#End Region

#Region "Querying"
    ''' <summary>
    ''' Tests integer digit listing
    ''' </summary>
    <TestMethod>
    Public Sub TestListDigits()
        Dim ExpectedDigits() As Integer = {7, 5}
        Dim TargetNumber As Integer = 75
        Assert.IsTrue(ExpectedDigits.SequenceEqual(TargetNumber.ListDigits))
    End Sub

    ''' <summary>
    ''' Tests unsigned integer digit listing
    ''' </summary>
    <TestMethod>
    Public Sub TestListDigitsUnsigned()
        Dim ExpectedDigits() As UInteger = {7, 5}
        Dim TargetNumber As UInteger = 75
        Assert.IsTrue(ExpectedDigits.SequenceEqual(TargetNumber.ListDigits))
    End Sub

    ''' <summary>
    ''' Tests integer Armstrong number detection
    ''' </summary>
    <TestMethod>
    Public Sub TestIsArmstrong()
        Dim TargetNumber As Integer = 153
        Assert.IsTrue(TargetNumber.IsArmstrong)
    End Sub

    ''' <summary>
    ''' Tests unsigned integer Armstrong number detection
    ''' </summary>
    <TestMethod>
    Public Sub TestIsArmstrongUnsigned()
        Dim TargetNumber As UInteger = 153
        Assert.IsTrue(TargetNumber.IsArmstrong)
    End Sub
#End Region

End Class
