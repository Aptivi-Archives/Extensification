
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
Imports Extensification.ListExts

<TestFixture>
Public Class ListTests

#Region "Addition"
    ''' <summary>
    ''' Tests adding an entry to list if not found
    ''' </summary>
    <Test>
    Public Sub TestAddIfNotFound()
        Dim TargetList As New List(Of String)
        TargetList.AddIfNotFound("String 1")
        TargetList.AddIfNotFound("String 1")
        Assert.IsTrue(TargetList.Count = 1)
    End Sub
#End Region

#Region "Conversion"
    ''' <summary>
    ''' Tests converting list to array list
    ''' </summary>
    <Test>
    Public Sub TestToArrayList()
        Dim TargetList As New List(Of String) From {"Test converting", "target list", "to array list."}
        Dim TargetArrayList As ArrayList = TargetList.ToArrayList
        Assert.IsNotNull(TargetArrayList)
        Assert.IsTrue(TargetArrayList.Count > 0)
    End Sub
#End Region

#Region "Counts"
    ''' <summary>
    ''' Tests counting full entries
    ''' </summary>
    <Test>
    Public Sub TestCountFullEntries()
        Dim TargetList As New List(Of String) From {"Full", "", "", "entry", "", "5"}
        Dim TargetListObjects As New List(Of Object) From {12, Nothing, 32, 48}
        Assert.AreEqual(3, TargetList.CountFullEntries)
        Assert.AreEqual(3, TargetListObjects.CountFullEntries)
    End Sub

    ''' <summary>
    ''' Tests counting empty entries
    ''' </summary>
    <Test>
    Public Sub TestCountEmptyEntries()
        Dim TargetList As New List(Of String) From {"Full", "", "", "entry", "", "", "6"}
        Dim TargetListObjects As New List(Of Object) From {12, Nothing, 32, 48}
        Assert.AreEqual(4, TargetList.CountEmptyEntries)
        Assert.AreEqual(1, TargetListObjects.CountEmptyEntries)
    End Sub
#End Region

#Region "Getting"
    ''' <summary>
    ''' Tests getting index from entry
    ''' </summary>
    <Test>
    Public Sub TestGetIndexFromEntry()
        Dim TargetList As New List(Of String) From {"Test getting", "index from", "array list entry."}
        Dim ExpectedIndex As Integer = 1
        Assert.AreEqual(ExpectedIndex, TargetList.GetIndexFromEntry("index from")(0))
    End Sub

    ''' <summary>
    ''' Tests getting indexes of full entries
    ''' </summary>
    <Test>
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
    <Test>
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
#End Region

#Region "Manipulation"
    ''' <summary>
    ''' Tests stringifying a char array
    ''' </summary>
    <Test>
    Public Sub TestStringify()
        Dim TargetArray As New List(Of Char) From {"H", "e", "l", "l", "o"}
        Assert.AreEqual("Hello", TargetArray.Stringify)
    End Sub
#End Region

#Region "Querying"
    ''' <summary>
    ''' Tests seeing if the list contains any of the specified clauses
    ''' </summary>
    <Test>
    Public Sub TestContainsAnyOf()
        Dim TargetList As New List(Of String) From {"Test", "Hello and Test", "Tester! Hello!"}
        Assert.IsTrue(TargetList.ContainsAnyOf({"Hello and Test", "Test"}))
        Assert.IsFalse(TargetList.ContainsAnyOf({"Goodbye", "Works"}))
    End Sub

    ''' <summary>
    ''' Tests seeing if the list contains all of the specified clauses
    ''' </summary>
    <Test>
    Public Sub TestContainsAllOf()
        Dim TargetList As New List(Of String) From {"Test", "Hello and Test", "Tester! Hello!"}
        Assert.IsTrue(TargetList.ContainsAllOf({"Hello and Test", "Test"}))
        Assert.IsFalse(TargetList.ContainsAllOf({"Goodbye", "Works"}))
    End Sub
#End Region

#Region "Removal"
    ''' <summary>
    ''' Tests trying to remove an entry from list
    ''' </summary>
    <Test>
    Public Sub TestTryRemove()
        Dim TargetList As New List(Of String) From {"Test"}
        Assert.IsTrue(TargetList.TryRemove("Test"))
        Assert.IsFalse(TargetList.TryRemove("Test2"))
    End Sub
#End Region

End Class
