
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
Imports Extensification.ShortExts

<TestClass>
Public Class ShortTests

    ''' <summary>
    ''' Tests short integer incrementation
    ''' </summary>
    <TestMethod>
    Public Sub TestIncrement()
        Dim ExpectedShort As Short = 5
        Dim TargetShort As Short = 3
        TargetShort = TargetShort.Increment(2)
        Assert.AreEqual(ExpectedShort, TargetShort)
    End Sub

    ''' <summary>
    ''' Tests short integer decrementation
    ''' </summary>
    <TestMethod>
    Public Sub TestDecrement()
        Dim ExpectedShort As Short = 3
        Dim TargetShort As Short = 5
        TargetShort = TargetShort.Decrement(2)
        Assert.AreEqual(ExpectedShort, TargetShort)
    End Sub

    ''' <summary>
    ''' Tests unsigned short integer incrementation
    ''' </summary>
    <TestMethod>
    Public Sub TestIncrementUnsigned()
        Dim ExpectedUShort As UShort = 5
        Dim TargetUShort As UShort = 3
        TargetUShort = TargetUShort.Increment(2)
        Assert.AreEqual(ExpectedUShort, TargetUShort)
    End Sub

    ''' <summary>
    ''' Tests unsigned short integer decrementation
    ''' </summary>
    <TestMethod>
    Public Sub TestDecrementUnsigned()
        Dim ExpectedUShort As UShort = 3
        Dim TargetUShort As UShort = 5
        TargetUShort = TargetUShort.Decrement(2)
        Assert.AreEqual(ExpectedUShort, TargetUShort)
    End Sub

End Class
