
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
Imports Extensification.CharExts

<TestClass>
Public Class CharTests

    ''' <summary>
    ''' Tests character incrementation
    ''' </summary>
    <TestMethod>
    Public Sub TestIncrement()
        Dim Target As Char = "A"
        Target = Target.Increment(4)
        Assert.AreEqual("E"c, Target)
    End Sub

    ''' <summary>
    ''' Tests character decrementation
    ''' </summary>
    <TestMethod>
    Public Sub TestDecrement()
        Dim Target As Char = "E"
        Target = Target.Decrement(4)
        Assert.AreEqual("A"c, Target)
    End Sub

    ''' <summary>
    ''' Tests character ASCII code fetching
    ''' </summary>
    <TestMethod>
    Public Sub TestGetAsciiCode()
        Dim Target As Char = "E"
        Assert.AreEqual(69, Target.GetAsciiCode)
    End Sub

End Class
