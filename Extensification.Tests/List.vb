
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
Imports Extensification.ListExts

<TestClass>
Public Class ListTests

    ''' <summary>
    ''' Tests converting list to array list
    ''' </summary>
    <TestMethod>
    Public Sub TestToArrayList()
        Dim TargetList As New List(Of String) From {"Test converting", "target list", "to array list."}
        Dim TargetArrayList As ArrayList = TargetList.ToArrayList
        Assert.IsNotNull(TargetArrayList)
        Assert.IsTrue(TargetArrayList.Count > 0)
    End Sub

    ''' <summary>
    ''' Tests getting index from entry
    ''' </summary>
    <TestMethod>
    Public Sub TestGetIndexFromEntry()
        Dim TargetList As New List(Of String) From {"Test getting", "index from", "array list entry."}
        Dim ExpectedIndex As Integer = 1
        Assert.AreEqual(ExpectedIndex, TargetList.GetIndexFromEntry("index from")(0))
    End Sub

    ''' <summary>
    ''' Tests counting full entries
    ''' </summary>
    <TestMethod>
    Public Sub TestCountFullEntries()
        Dim TargetList As New List(Of String) From {"Full", "", "", "entry", "", "5"}
        Dim TargetListObjects As New List(Of Object) From {12, Nothing, 32, 48}
        Assert.AreEqual(3, TargetList.CountFullEntries)
        Assert.AreEqual(3, TargetListObjects.CountFullEntries)
    End Sub

    ''' <summary>
    ''' Tests counting empty entries
    ''' </summary>
    <TestMethod>
    Public Sub TestCountEmptyEntries()
        Dim TargetList As New List(Of String) From {"Full", "", "", "entry", "", "", "6"}
        Dim TargetListObjects As New List(Of Object) From {12, Nothing, 32, 48}
        Assert.AreEqual(4, TargetList.CountEmptyEntries)
        Assert.AreEqual(1, TargetListObjects.CountEmptyEntries)
    End Sub

    ''' <summary>
    ''' Tests getting indexes of full entries
    ''' </summary>
    <TestMethod>
    Public Sub TestGetIndexesOfFullEntries()
        Dim TargetList As New List(Of String) From {"", "Full", "", "Entry", ""}
        Dim TargetListObjects As New List(Of Object) From {4, Nothing, Nothing}
        Dim ExpectedIndexes() As Integer = {1, 3}
        Dim ExpectedIndexesObjects() As Integer = {0}
        Assert.IsNotNull(TargetList.GetIndexesOfFullEntries)
        Assert.IsNotNull(TargetListObjects.GetIndexesOfFullEntries)
        Assert.IsTrue(TargetList.GetIndexesOfFullEntries.SequenceEqual(ExpectedIndexes))
        Assert.IsTrue(TargetListObjects.GetIndexesOfFullEntries.SequenceEqual(ExpectedIndexesObjects))
    End Sub

    ''' <summary>
    ''' Tests getting indexes of empty entries
    ''' </summary>
    <TestMethod>
    Public Sub TestGetIndexesOfEmptyEntries()
        Dim TargetList As New List(Of String) From {"", "Full", "", "Entry", ""}
        Dim TargetListObjects As New List(Of Object) From {4, Nothing, Nothing}
        Dim ExpectedIndexes() As Integer = {0, 2, 4}
        Dim ExpectedIndexesObjects() As Integer = {1, 2}
        Assert.IsNotNull(TargetList.GetIndexesOfEmptyEntries)
        Assert.IsNotNull(TargetListObjects.GetIndexesOfEmptyEntries)
        Assert.IsTrue(TargetList.GetIndexesOfEmptyEntries.SequenceEqual(ExpectedIndexes))
        Assert.IsTrue(TargetListObjects.GetIndexesOfEmptyEntries.SequenceEqual(ExpectedIndexesObjects))
    End Sub

    ''' <summary>
    ''' Tests adding an entry to list if not found
    ''' </summary>
    <TestMethod>
    Public Sub TestAddIfNotFound()
        Dim TargetList As New List(Of String)
        TargetList.AddIfNotFound("String 1")
        TargetList.AddIfNotFound("String 1")
        Assert.IsTrue(TargetList.Count = 1)
    End Sub

    ''' <summary>
    ''' Tests trying to remove an entry from list
    ''' </summary>
    <TestMethod>
    Public Sub TestTryRemove()
        Dim TargetList As New List(Of String) From {"Test"}
        Assert.IsTrue(TargetList.TryRemove("Test"))
        Assert.IsFalse(TargetList.TryRemove("Test2"))
    End Sub

End Class
