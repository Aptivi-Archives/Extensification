
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
Imports Extensification.ArrayExts

<TestClass>
Public Class ArrayTests

    ''' <summary>
    ''' Tests adding an entry to array
    ''' </summary>
    <TestMethod>
    Public Sub TestAdd()
        Dim TargetArray() As Integer = {2, 3}
        TargetArray.Add(4)
        Assert.IsTrue(TargetArray.Length = 3)
    End Sub

    ''' <summary>
    ''' Tests removing an entry to array
    ''' </summary>
    <TestMethod>
    Public Sub TestRemove()
        Dim TargetArray() As Integer = {2, 3, 4}
        TargetArray.Remove(4)
        Assert.IsTrue(TargetArray.Length = 2)
    End Sub

    ''' <summary>
    ''' Tests converting array to array list
    ''' </summary>
    <TestMethod>
    Public Sub TestToArrayList()
        Dim TargetArray As String() = {"Test converting", "target array", "to array list."}
        Dim TargetList As ArrayList = TargetArray.ToArrayList
        Assert.IsNotNull(TargetList)
        Assert.IsTrue(TargetList.Count > 0)
    End Sub

    ''' <summary>
    ''' Tests getting index from entry
    ''' </summary>
    <TestMethod>
    Public Sub TestGetIndexFromEntry()
        Dim TargetArray As String() = {"Test getting", "index from", "array entry."}
        Dim ExpectedIndex As Integer = 1
        Dim ActualIndex As Integer() = TargetArray.GetIndexFromEntry("index from")
        Assert.AreEqual(ExpectedIndex, ActualIndex(0))
    End Sub

    ''' <summary>
    ''' Tests counting full entries
    ''' </summary>
    <TestMethod>
    Public Sub TestCountFullEntries()
        Dim TargetArray() As String = {"", "Full", "", "Entry", ""}
        Dim TargetArrayObjects As Object() = {4, Nothing, Nothing}
        Assert.AreEqual(CLng(2), TargetArray.CountFullEntries)
        Assert.AreEqual(CLng(1), TargetArrayObjects.CountFullEntries)
    End Sub

    ''' <summary>
    ''' Tests counting empty entries
    ''' </summary>
    <TestMethod>
    Public Sub TestCountEmptyEntries()
        Dim TargetArray() As String = {"", "Full", "", "Entry", ""}
        Dim TargetArrayObjects As Object() = {4, Nothing, Nothing}
        Assert.AreEqual(CLng(3), TargetArray.CountEmptyEntries)
        Assert.AreEqual(CLng(2), TargetArrayObjects.CountEmptyEntries)
    End Sub

    ''' <summary>
    ''' Tests getting indexes of full entries
    ''' </summary>
    <TestMethod>
    Public Sub TestGetIndexesOfFullEntries()
        Dim TargetArray() As String = {"", "Full", "", "Entry", ""}
        Dim TargetArrayObjects As Object() = {4, Nothing, Nothing}
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
        Dim TargetArray() As String = {"", "Full", "", "Entry", ""}
        Dim TargetArrayObjects As Object() = {4, Nothing, Nothing}
        Dim ExpectedIndexes() As Integer = {0, 2, 4}
        Dim ExpectedIndexesObjects() As Integer = {1, 2}
        Assert.IsNotNull(TargetArray.GetIndexesOfEmptyEntries)
        Assert.IsNotNull(TargetArrayObjects.GetIndexesOfEmptyEntries)
        Assert.IsTrue(TargetArray.GetIndexesOfEmptyEntries.SequenceEqual(ExpectedIndexes))
        Assert.IsTrue(TargetArrayObjects.GetIndexesOfEmptyEntries.SequenceEqual(ExpectedIndexesObjects))
    End Sub

End Class
