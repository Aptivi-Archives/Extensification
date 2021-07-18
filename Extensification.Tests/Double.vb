
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
Imports Extensification.DoubleExts

<TestClass>
Public Class DoubleTests

#Region "Manipulation"
    ''' <summary>
    ''' Tests double-precision number incrementation
    ''' </summary>
    <TestMethod>
    Public Sub TestIncrement()
        Dim ExpectedDouble As Double = 5
        Dim TargetDouble As Double = 3
        TargetDouble = TargetDouble.Increment(2)
        Assert.AreEqual(ExpectedDouble, TargetDouble)
    End Sub

    ''' <summary>
    ''' Tests double-precision number decrementation
    ''' </summary>
    <TestMethod>
    Public Sub TestDecrement()
        Dim ExpectedDouble As Double = 3
        Dim TargetDouble As Double = 5
        TargetDouble = TargetDouble.Decrement(2)
        Assert.AreEqual(ExpectedDouble, TargetDouble)
    End Sub
#End Region

#Region "Querying"
    ''' <summary>
    ''' Tests double digit listing (before the decimal point)
    ''' </summary>
    <TestMethod>
    Public Sub TestListDigitsBeforeDecimal()
        Dim ExpectedDigits() As Double = {3, 2}
        Dim TargetNumber As Double = 32.9
        Assert.IsTrue(ExpectedDigits.SequenceEqual(TargetNumber.ListDigitsBeforeDecimal))
    End Sub

    ''' <summary>
    ''' Tests double digit listing (after the decimal point)
    ''' </summary>
    <TestMethod>
    Public Sub TestListDigitsAfterDecimal()
        Dim ExpectedDigits() As Double = {9}
        Dim TargetNumber As Double = 32.9
        Assert.IsTrue(ExpectedDigits.SequenceEqual(TargetNumber.ListDigitsAfterDecimal))
    End Sub

    ''' <summary>
    ''' Tests double Armstrong number detection
    ''' </summary>
    <TestMethod>
    Public Sub TestIsArmstrong()
        Dim TargetNumber As Double = 153.4
        Assert.IsTrue(TargetNumber.IsArmstrong)
    End Sub
#End Region

End Class
