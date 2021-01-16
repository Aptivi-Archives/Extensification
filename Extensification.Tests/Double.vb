
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

End Class
