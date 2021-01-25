
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
Imports Extensification.ArrayListExts

<TestClass>
Public Class ArrayListTests

    ''' <summary>
    ''' Tests converting array list to list
    ''' </summary>
    <TestMethod>
    Public Sub TestToArrayList()
        Dim TargetArrayList As New ArrayList From {"Test converting", "target array list", "to list."}
        Dim TargetList As List(Of Object) = TargetArrayList.ToList
        Assert.IsNotNull(TargetList)
        Assert.IsTrue(TargetList.Count > 0)
    End Sub

    ''' <summary>
    ''' Tests getting index from entry
    ''' </summary>
    <TestMethod>
    Public Sub TestGetIndexOfEntry()
        Dim TargetList As New ArrayList From {"Test getting", "index from", "array list entry."}
        Dim ExpectedIndex As Integer = 1
        Assert.AreEqual(ExpectedIndex, TargetList.GetIndexOfEntry("index from")(0))
    End Sub

    ''' <summary>
    ''' Tests counting full entries
    ''' </summary>
    <TestMethod>
    Public Sub TestCountFullEntries()
        Dim TargetArray As New ArrayList From {"", "Full", "", "Entry", ""}
        Dim TargetArrayObjects As New ArrayList From {4, Nothing, Nothing}
        Assert.AreEqual(CLng(2), TargetArray.CountFullEntries)
        Assert.AreEqual(CLng(1), TargetArrayObjects.CountFullEntries)
    End Sub

    ''' <summary>
    ''' Tests counting empty entries
    ''' </summary>
    <TestMethod>
    Public Sub TestCountEmptyEntries()
        Dim TargetArray As New ArrayList From {"", "Full", "", "Entry", ""}
        Dim TargetArrayObjects As New ArrayList From {4, Nothing, Nothing}
        Assert.AreEqual(CLng(3), TargetArray.CountEmptyEntries)
        Assert.AreEqual(CLng(2), TargetArrayObjects.CountEmptyEntries)
    End Sub

    ''' <summary>
    ''' Tests getting indexes of full entries
    ''' </summary>
    <TestMethod>
    Public Sub TestGetIndexesOfFullEntries()
        Dim TargetArray As New ArrayList From {"", "Full", "", "Entry", ""}
        Dim TargetArrayObjects As New ArrayList From {4, Nothing, Nothing}
        Dim ExpectedIndexes() As Integer = {1, 3}
        Dim ExpectedIndexesObjects() As Integer = {0}
        Assert.IsNotNull(TargetArray.GetIndexesOfFullEntries)
        Assert.IsNotNull(TargetArrayObjects.GetIndexesOfFullEntries)
        Assert.IsTrue(TargetArray.GetIndexesOfFullEntries.SequenceEqual(ExpectedIndexes))
        Assert.IsTrue(TargetArrayObjects.GetIndexesOfFullEntries.SequenceEqual(ExpectedIndexesObjects))
    End Sub

    ''' <summary>
    ''' Tests getting indexes of empty entries
    ''' </summary>
    <TestMethod>
    Public Sub TestGetIndexesOfEmptyEntries()
        Dim TargetArray As New ArrayList From {"", "Full", "", "Entry", ""}
        Dim TargetArrayObjects As New ArrayList From {4, Nothing, Nothing}
        Dim ExpectedIndexes() As Integer = {0, 2, 4}
        Dim ExpectedIndexesObjects() As Integer = {1, 2}
        Assert.IsNotNull(TargetArray.GetIndexesOfEmptyEntries)
        Assert.IsNotNull(TargetArrayObjects.GetIndexesOfEmptyEntries)
        Assert.IsTrue(TargetArray.GetIndexesOfEmptyEntries.SequenceEqual(ExpectedIndexes))
        Assert.IsTrue(TargetArrayObjects.GetIndexesOfEmptyEntries.SequenceEqual(ExpectedIndexesObjects))
    End Sub

    ''' <summary>
    ''' Tests trying to remove an entry from array list
    ''' </summary>
    <TestMethod>
    Public Sub TestTryRemove()
        Dim TargetArray As New ArrayList From {"Test"}
        Assert.IsTrue(TargetArray.TryRemove("Test"))
        Assert.IsFalse(TargetArray.TryRemove("Test2"))
    End Sub

    ''' <summary>
    ''' Tests seeing if the array list contains any of the specified clauses
    ''' </summary>
    <TestMethod>
    Public Sub TestContainsAnyOf()
        Dim TargetArray As New ArrayList From {"Test", "Hello and Test", "Tester! Hello!"}
        Assert.IsTrue(TargetArray.ContainsAnyOf(New ArrayList From {"Hello and Test", "Test"}))
        Assert.IsFalse(TargetArray.ContainsAnyOf(New ArrayList From {"Goodbye", "Works"}))
    End Sub

    ''' <summary>
    ''' Tests seeing if the array list contains all of the specified clauses
    ''' </summary>
    <TestMethod>
    Public Sub TestContainsAllOf()
        Dim TargetArray As New ArrayList From {"Test", "Hello and Test", "Tester! Hello!"}
        Assert.IsTrue(TargetArray.ContainsAllOf(New ArrayList From {"Hello and Test", "Test"}))
        Assert.IsFalse(TargetArray.ContainsAllOf(New ArrayList From {"Goodbye", "Works"}))
    End Sub

End Class
