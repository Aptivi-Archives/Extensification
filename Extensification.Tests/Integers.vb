
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
    ''' Tests unsigned integer decrementation
    ''' </summary>
    <TestMethod>
    Public Sub TestDecrementUnsigned()
        Dim ExpectedUInteger As UInteger = 3
        Dim TargetUInteger As UInteger = 5
        TargetUInteger = TargetUInteger.Decrement(2)
        Assert.AreEqual(ExpectedUInteger, TargetUInteger)
    End Sub

End Class
