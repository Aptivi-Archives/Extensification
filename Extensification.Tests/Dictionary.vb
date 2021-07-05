
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
Imports Extensification.DictionaryExts
Imports System.IO

<TestClass>
Public Class DictionaryTests

    ''' <summary>
    ''' Tests getting key from value
    ''' </summary>
    <TestMethod>
    Sub TestGetKeyFromValue()
        Dim TargetDictionary As New Dictionary(Of String, Integer) From {{"Extensification", 0}, {"is", 1}, {"awesome!", 2}}
        Dim NeededNumber As Integer = 2
        Dim Returned As String = TargetDictionary.GetKeyFromValue(NeededNumber)
        Assert.AreEqual("awesome!", Returned, "Failed to get key from value. Got {0}", Returned)
    End Sub

    ''' <summary>
    ''' Tests getting index of a key in dictionary that has keys of type <see cref="String"/>
    ''' </summary>
    <TestMethod>
    Sub TestGetIndexOfKey()
        Dim TargetDictionary As New Dictionary(Of String, Integer) From {{"Extensification", 0}, {"is", 1}, {"awesome!", 2}}
        Dim NeededKey As String = "awesome!"
        Dim Returned As Integer = TargetDictionary.GetIndexOfKey(NeededKey)
        Assert.AreEqual(2, Returned, "Failed to get index of key. Got {0}", Returned)
    End Sub

    ''' <summary>
    ''' Tests getting index of a value in dictionary that has keys of type <see cref="String"/>
    ''' </summary>
    <TestMethod>
    Sub TestGetIndexOfValue()
        Dim TargetDictionary As New Dictionary(Of String, Integer) From {{"Extensification", 0}, {"is", 1}, {"awesome!", 2}}
        Dim NeededValue As Integer = 1
        Dim Returned As Integer = TargetDictionary.GetIndexOfValue(NeededValue)
        Assert.AreEqual(1, Returned, "Failed to get index of key. Got {0}", Returned)
    End Sub

    ''' <summary>
    ''' Tests getting index of a key in dictionary that has keys of a type that can't be compared using the "=" operator.
    ''' </summary>
    <TestMethod>
    Sub TestGetIndexOfKeyNonString()
        Dim NeededKey As New MemoryStream(16)
        Dim TargetDictionary As New Dictionary(Of Stream, Integer) From {{New MemoryStream(8), 0}, {NeededKey, 1}, {New MemoryStream(32), 2}}
        Dim Returned As Integer = TargetDictionary.GetIndexOfKey(NeededKey)
        Assert.AreEqual(1, Returned, "Failed to get index of key. Got {0}", Returned)
    End Sub

    ''' <summary>
    ''' Tests counting full entries
    ''' </summary>
    <TestMethod>
    Public Sub TestCountFullEntries()
        Dim TargetDict As New Dictionary(Of String, String) From {{"Full", ""}, {"", "entry"}, {"Index", "5"}}
        Dim TargetDictObjects As New Dictionary(Of String, String) From {{"Object 1", 68}, {"Object 2", Nothing}}
        Assert.AreEqual(2, TargetDict.CountFullEntries)
        Assert.AreEqual(1, TargetDictObjects.CountFullEntries)
    End Sub

    ''' <summary>
    ''' Tests counting empty entries
    ''' </summary>
    <TestMethod>
    Public Sub TestCountEmptyEntries()
        Dim TargetDict As New Dictionary(Of String, String) From {{"Full", ""}, {"", "entry"}, {"Index", "5"}}
        Dim TargetDictObjects As New Dictionary(Of String, Object) From {{"Object 1", 68}, {"Object 2", Nothing}}
        Assert.AreEqual(1, TargetDict.CountEmptyEntries)
        Assert.AreEqual(1, TargetDictObjects.CountEmptyEntries)
    End Sub

    ''' <summary>
    ''' Tests getting indexes of full entries
    ''' </summary>
    <TestMethod>
    Public Sub TestGetIndexesOfFullEntries()
        Dim TargetDict As New Dictionary(Of String, String) From {{"Full", ""}, {"", "entry"}, {"Index", "5"}}
        Dim TargetDictObjects As New Dictionary(Of String, Object) From {{"Object 1", 68}, {"Object 2", Nothing}}
        Dim ExpectedIndexes() As Integer = {1, 2}
        Dim ExpectedIndexesObjects() As Integer = {0}
        Assert.IsNotNull(TargetDict.GetIndexesOfFullEntries)
        Assert.IsNotNull(TargetDictObjects.GetIndexesOfFullEntries)
        Assert.IsTrue(TargetDict.GetIndexesOfFullEntries.SequenceEqual(ExpectedIndexes))
        Assert.IsTrue(TargetDictObjects.GetIndexesOfFullEntries.SequenceEqual(ExpectedIndexesObjects))
    End Sub

    ''' <summary>
    ''' Tests getting indexes of empty entries
    ''' </summary>
    <TestMethod>
    Public Sub TestGetIndexesOfEmptyEntries()
        Dim TargetDict As New Dictionary(Of String, String) From {{"Full", ""}, {"", "entry"}, {"Index", "5"}}
        Dim TargetDictObjects As New Dictionary(Of String, Object) From {{"Object 1", 68}, {"Object 2", Nothing}}
        Dim ExpectedIndexes() As Integer = {0}
        Dim ExpectedIndexesObjects() As Integer = {1}
        Assert.IsNotNull(TargetDict.GetIndexesOfEmptyEntries)
        Assert.IsNotNull(TargetDictObjects.GetIndexesOfEmptyEntries)
        Assert.IsTrue(TargetDict.GetIndexesOfEmptyEntries.SequenceEqual(ExpectedIndexes))
        Assert.IsTrue(TargetDictObjects.GetIndexesOfEmptyEntries.SequenceEqual(ExpectedIndexesObjects))
    End Sub

    ''' <summary>
    ''' Tests adding an entry to dictionary if not found
    ''' </summary>
    <TestMethod>
    Public Sub TestAddIfNotFound()
        Dim TargetDict As New Dictionary(Of String, Integer)
        TargetDict.AddIfNotFound("String 1", 64)
        TargetDict.AddIfNotFound("String 1", 128)
        Assert.IsTrue(TargetDict.Count = 1)
    End Sub

    ''' <summary>
    ''' Tests adding or modifying an entry to dictionary
    ''' </summary>
    <TestMethod>
    Public Sub TestAddOrModify()
        Dim TargetDict As New Dictionary(Of String, Integer)
        TargetDict.AddOrModify("String 1", 64)
        TargetDict.AddOrModify("String 1", 128)
        Assert.IsTrue(TargetDict("String 1") = 128)
    End Sub

    ''' <summary>
    ''' Tests adding or renaming an entry to dictionary
    ''' </summary>
    <TestMethod>
    Public Sub TestAddOrRename()
        Dim TargetDict As New Dictionary(Of String, Integer)
        TargetDict.AddOrRename("String 1", 64)
        TargetDict.AddOrRename("String 1", 128)
        Assert.IsTrue(TargetDict.ContainsKey("String 1 [2]"))
    End Sub

    ''' <summary>
    ''' Tests adding an entry or incrementing a value of an already-existing entry to dictionary
    ''' </summary>
    <TestMethod>
    Public Sub TestAddOrIncrement()
        Dim TargetDict As New Dictionary(Of String, Integer)
        TargetDict.AddOrIncrement("String 1", 64)
        TargetDict.AddOrIncrement("String 1", 128)
        Assert.IsTrue(TargetDict("String 1") = 192)
    End Sub

    ''' <summary>
    ''' Tests adding an entry or incrementing a value of an already-existing entry to dictionary
    ''' </summary>
    <TestMethod>
    Public Sub TestAddOrIncrementUInteger()
        Dim TargetDict As New Dictionary(Of String, UInteger)
        TargetDict.AddOrIncrement("String 1", 64)
        TargetDict.AddOrIncrement("String 1", 128)
        Assert.IsTrue(TargetDict("String 1") = 192)
    End Sub

    ''' <summary>
    ''' Tests adding an entry or incrementing a value of an already-existing entry to dictionary
    ''' </summary>
    <TestMethod>
    Public Sub TestAddOrIncrementByte()
        Dim TargetDict As New Dictionary(Of String, Byte)
        TargetDict.AddOrIncrement("String 1", 64)
        TargetDict.AddOrIncrement("String 1", 128)
        Assert.IsTrue(TargetDict("String 1") = 192)
    End Sub

    ''' <summary>
    ''' Tests adding an entry or incrementing a value of an already-existing entry to dictionary
    ''' </summary>
    <TestMethod>
    Public Sub TestAddOrIncrementSByte()
        Dim TargetDict As New Dictionary(Of String, SByte)
        TargetDict.AddOrIncrement("String 1", 16)
        TargetDict.AddOrIncrement("String 1", 16)
        Assert.IsTrue(TargetDict("String 1") = 32)
    End Sub

    ''' <summary>
    ''' Tests adding an entry or incrementing a value of an already-existing entry to dictionary
    ''' </summary>
    <TestMethod>
    Public Sub TestAddOrIncrementDouble()
        Dim TargetDict As New Dictionary(Of String, Double)
        TargetDict.AddOrIncrement("String 1", 64)
        TargetDict.AddOrIncrement("String 1", 128)
        Assert.IsTrue(TargetDict("String 1") = 192)
    End Sub

    ''' <summary>
    ''' Tests adding an entry or incrementing a value of an already-existing entry to dictionary
    ''' </summary>
    <TestMethod>
    Public Sub TestAddOrIncrementLong()
        Dim TargetDict As New Dictionary(Of String, Long)
        TargetDict.AddOrIncrement("String 1", 64)
        TargetDict.AddOrIncrement("String 1", 128)
        Assert.IsTrue(TargetDict("String 1") = 192)
    End Sub

    ''' <summary>
    ''' Tests adding an entry or incrementing a value of an already-existing entry to dictionary
    ''' </summary>
    <TestMethod>
    Public Sub TestAddOrIncrementULong()
        Dim TargetDict As New Dictionary(Of String, ULong)
        TargetDict.AddOrIncrement("String 1", 64)
        TargetDict.AddOrIncrement("String 1", 128)
        Assert.IsTrue(TargetDict("String 1") = 192)
    End Sub

    ''' <summary>
    ''' Tests adding an entry or incrementing a value of an already-existing entry to dictionary
    ''' </summary>
    <TestMethod>
    Public Sub TestAddOrIncrementShort()
        Dim TargetDict As New Dictionary(Of String, Short)
        TargetDict.AddOrIncrement("String 1", 64)
        TargetDict.AddOrIncrement("String 1", 128)
        Assert.IsTrue(TargetDict("String 1") = 192)
    End Sub

    ''' <summary>
    ''' Tests adding an entry or incrementing a value of an already-existing entry to dictionary
    ''' </summary>
    <TestMethod>
    Public Sub TestAddOrIncrementUShort()
        Dim TargetDict As New Dictionary(Of String, UShort)
        TargetDict.AddOrIncrement("String 1", 64)
        TargetDict.AddOrIncrement("String 1", 128)
        Assert.IsTrue(TargetDict("String 1") = 192)
    End Sub

    ''' <summary>
    ''' Tests adding an entry or incrementing a value of an already-existing entry to dictionary
    ''' </summary>
    <TestMethod>
    Public Sub TestAddOrIncrementSingle()
        Dim TargetDict As New Dictionary(Of String, Single)
        TargetDict.AddOrIncrement("String 1", 64)
        TargetDict.AddOrIncrement("String 1", 128)
        Assert.IsTrue(TargetDict("String 1") = 192)
    End Sub

    ''' <summary>
    ''' Tests adding an entry or decrementing a value of an already-existing entry to dictionary
    ''' </summary>
    <TestMethod>
    Public Sub TestAddOrDecrement()
        Dim TargetDict As New Dictionary(Of String, Integer)
        TargetDict.AddOrDecrement("String 1", 64)
        TargetDict.AddOrDecrement("String 1", 32)
        Assert.IsTrue(TargetDict("String 1") = 32)
    End Sub

    ''' <summary>
    ''' Tests adding an entry or decrementing a value of an already-existing entry to dictionary
    ''' </summary>
    <TestMethod>
    Public Sub TestAddOrDecrementUInteger()
        Dim TargetDict As New Dictionary(Of String, UInteger)
        TargetDict.AddOrDecrement("String 1", 64)
        TargetDict.AddOrDecrement("String 1", 32)
        Assert.IsTrue(TargetDict("String 1") = 32)
    End Sub

    ''' <summary>
    ''' Tests adding an entry or decrementing a value of an already-existing entry to dictionary
    ''' </summary>
    <TestMethod>
    Public Sub TestAddOrDecrementByte()
        Dim TargetDict As New Dictionary(Of String, Byte)
        TargetDict.AddOrDecrement("String 1", 64)
        TargetDict.AddOrDecrement("String 1", 32)
        Assert.IsTrue(TargetDict("String 1") = 32)
    End Sub

    ''' <summary>
    ''' Tests adding an entry or decrementing a value of an already-existing entry to dictionary
    ''' </summary>
    <TestMethod>
    Public Sub TestAddOrDecrementSByte()
        Dim TargetDict As New Dictionary(Of String, SByte)
        TargetDict.AddOrDecrement("String 1", 16)
        TargetDict.AddOrDecrement("String 1", 8)
        Assert.IsTrue(TargetDict("String 1") = 8)
    End Sub

    ''' <summary>
    ''' Tests adding an entry or decrementing a value of an already-existing entry to dictionary
    ''' </summary>
    <TestMethod>
    Public Sub TestAddOrDecrementDouble()
        Dim TargetDict As New Dictionary(Of String, Double)
        TargetDict.AddOrDecrement("String 1", 64)
        TargetDict.AddOrDecrement("String 1", 32)
        Assert.IsTrue(TargetDict("String 1") = 32)
    End Sub

    ''' <summary>
    ''' Tests adding an entry or decrementing a value of an already-existing entry to dictionary
    ''' </summary>
    <TestMethod>
    Public Sub TestAddOrDecrementLong()
        Dim TargetDict As New Dictionary(Of String, Long)
        TargetDict.AddOrDecrement("String 1", 64)
        TargetDict.AddOrDecrement("String 1", 32)
        Assert.IsTrue(TargetDict("String 1") = 32)
    End Sub

    ''' <summary>
    ''' Tests adding an entry or decrementing a value of an already-existing entry to dictionary
    ''' </summary>
    <TestMethod>
    Public Sub TestAddOrDecrementULong()
        Dim TargetDict As New Dictionary(Of String, ULong)
        TargetDict.AddOrDecrement("String 1", 64)
        TargetDict.AddOrDecrement("String 1", 32)
        Assert.IsTrue(TargetDict("String 1") = 32)
    End Sub

    ''' <summary>
    ''' Tests adding an entry or decrementing a value of an already-existing entry to dictionary
    ''' </summary>
    <TestMethod>
    Public Sub TestAddOrDecrementShort()
        Dim TargetDict As New Dictionary(Of String, Short)
        TargetDict.AddOrDecrement("String 1", 64)
        TargetDict.AddOrDecrement("String 1", 32)
        Assert.IsTrue(TargetDict("String 1") = 32)
    End Sub

    ''' <summary>
    ''' Tests adding an entry or decrementing a value of an already-existing entry to dictionary
    ''' </summary>
    <TestMethod>
    Public Sub TestAddOrDecrementUShort()
        Dim TargetDict As New Dictionary(Of String, UShort)
        TargetDict.AddOrDecrement("String 1", 64)
        TargetDict.AddOrDecrement("String 1", 32)
        Assert.IsTrue(TargetDict("String 1") = 32)
    End Sub

    ''' <summary>
    ''' Tests adding an entry or decrementing a value of an already-existing entry to dictionary
    ''' </summary>
    <TestMethod>
    Public Sub TestAddOrDecrementSingle()
        Dim TargetDict As New Dictionary(Of String, Single)
        TargetDict.AddOrDecrement("String 1", 64)
        TargetDict.AddOrDecrement("String 1", 32)
        Assert.IsTrue(TargetDict("String 1") = 32)
    End Sub

    ''' <summary>
    ''' Tests incrementing a number
    ''' </summary>
    <TestMethod>
    Public Sub TestIncrementNumber()
        Dim TargetDict As New Dictionary(Of String, Integer)
        For t As Integer = 1 To 10
            TargetDict.IncrementNumber("Counter")
        Next
        Assert.IsTrue(TargetDict("Counter") = 10)
    End Sub

    ''' <summary>
    ''' Tests decrementing a number
    ''' </summary>
    <TestMethod>
    Public Sub TestDecrementNumber()
        Dim TargetDict As New Dictionary(Of String, Integer)
        For t As Integer = 1 To 10
            TargetDict.DecrementNumber("Counter")
        Next
        Assert.IsTrue(TargetDict("Counter") = -10)
    End Sub

    ''' <summary>
    ''' Tests incrementing a number
    ''' </summary>
    <TestMethod>
    Public Sub TestIncrementNumberUInteger()
        Dim TargetDict As New Dictionary(Of String, UInteger)
        For t As Integer = 1 To 10
            TargetDict.IncrementNumber("Counter")
        Next
        Assert.IsTrue(TargetDict("Counter") = 10)
    End Sub

    ''' <summary>
    ''' Tests decrementing a number
    ''' </summary>
    <TestMethod>
    Public Sub TestDecrementNumberUInteger()
        Dim TargetDict As New Dictionary(Of String, UInteger) From {{"Counter", 10}}
        For t As Integer = 1 To 10
            TargetDict.DecrementNumber("Counter")
        Next
        Assert.IsTrue(TargetDict("Counter") = 0)
    End Sub

    ''' <summary>
    ''' Tests incrementing a number
    ''' </summary>
    <TestMethod>
    Public Sub TestIncrementNumberShort()
        Dim TargetDict As New Dictionary(Of String, Short)
        For t As Integer = 1 To 10
            TargetDict.IncrementNumber("Counter")
        Next
        Assert.IsTrue(TargetDict("Counter") = 10)
    End Sub

    ''' <summary>
    ''' Tests decrementing a number
    ''' </summary>
    <TestMethod>
    Public Sub TestDecrementNumberShort()
        Dim TargetDict As New Dictionary(Of String, Short)
        For t As Integer = 1 To 10
            TargetDict.DecrementNumber("Counter")
        Next
        Assert.IsTrue(TargetDict("Counter") = -10)
    End Sub

    ''' <summary>
    ''' Tests incrementing a number
    ''' </summary>
    <TestMethod>
    Public Sub TestIncrementNumberUShort()
        Dim TargetDict As New Dictionary(Of String, UShort)
        For t As Integer = 1 To 10
            TargetDict.IncrementNumber("Counter")
        Next
        Assert.IsTrue(TargetDict("Counter") = 10)
    End Sub

    ''' <summary>
    ''' Tests decrementing a number
    ''' </summary>
    <TestMethod>
    Public Sub TestDecrementNumberUShort()
        Dim TargetDict As New Dictionary(Of String, UShort) From {{"Counter", 10}}
        For t As Integer = 1 To 10
            TargetDict.DecrementNumber("Counter")
        Next
        Assert.IsTrue(TargetDict("Counter") = 0)
    End Sub

    ''' <summary>
    ''' Tests incrementing a number
    ''' </summary>
    <TestMethod>
    Public Sub TestIncrementNumberLong()
        Dim TargetDict As New Dictionary(Of String, Long)
        For t As Integer = 1 To 10
            TargetDict.IncrementNumber("Counter")
        Next
        Assert.IsTrue(TargetDict("Counter") = 10)
    End Sub

    ''' <summary>
    ''' Tests decrementing a number
    ''' </summary>
    <TestMethod>
    Public Sub TestDecrementNumberLong()
        Dim TargetDict As New Dictionary(Of String, Long)
        For t As Integer = 1 To 10
            TargetDict.DecrementNumber("Counter")
        Next
        Assert.IsTrue(TargetDict("Counter") = -10)
    End Sub

    ''' <summary>
    ''' Tests incrementing a number
    ''' </summary>
    <TestMethod>
    Public Sub TestIncrementNumberULong()
        Dim TargetDict As New Dictionary(Of String, ULong)
        For t As Integer = 1 To 10
            TargetDict.IncrementNumber("Counter")
        Next
        Assert.IsTrue(TargetDict("Counter") = 10)
    End Sub

    ''' <summary>
    ''' Tests decrementing a number
    ''' </summary>
    <TestMethod>
    Public Sub TestDecrementNumberULong()
        Dim TargetDict As New Dictionary(Of String, ULong) From {{"Counter", 10}}
        For t As Integer = 1 To 10
            TargetDict.DecrementNumber("Counter")
        Next
        Assert.IsTrue(TargetDict("Counter") = 0)
    End Sub

    ''' <summary>
    ''' Tests incrementing a number
    ''' </summary>
    <TestMethod>
    Public Sub TestIncrementNumberByte()
        Dim TargetDict As New Dictionary(Of String, Byte)
        For t As Integer = 1 To 10
            TargetDict.IncrementNumber("Counter")
        Next
        Assert.IsTrue(TargetDict("Counter") = 10)
    End Sub

    ''' <summary>
    ''' Tests decrementing a number
    ''' </summary>
    <TestMethod>
    Public Sub TestDecrementNumberByte()
        Dim TargetDict As New Dictionary(Of String, Byte) From {{"Counter", 10}}
        For t As Integer = 1 To 10
            TargetDict.DecrementNumber("Counter")
        Next
        Assert.IsTrue(TargetDict("Counter") = 0)
    End Sub

    ''' <summary>
    ''' Tests incrementing a number
    ''' </summary>
    <TestMethod>
    Public Sub TestIncrementNumberSByte()
        Dim TargetDict As New Dictionary(Of String, SByte)
        For t As Integer = 1 To 10
            TargetDict.IncrementNumber("Counter")
        Next
        Assert.IsTrue(TargetDict("Counter") = 10)
    End Sub

    ''' <summary>
    ''' Tests decrementing a number
    ''' </summary>
    <TestMethod>
    Public Sub TestDecrementNumberSByte()
        Dim TargetDict As New Dictionary(Of String, SByte) From {{"Counter", 10}}
        For t As Integer = 1 To 10
            TargetDict.DecrementNumber("Counter")
        Next
        Assert.IsTrue(TargetDict("Counter") = 0)
    End Sub

    ''' <summary>
    ''' Tests incrementing a number
    ''' </summary>
    <TestMethod>
    Public Sub TestIncrementNumberSingle()
        Dim TargetDict As New Dictionary(Of String, Single)
        For t As Integer = 1 To 10
            TargetDict.IncrementNumber("Counter")
        Next
        Assert.IsTrue(TargetDict("Counter") = 10)
    End Sub

    ''' <summary>
    ''' Tests decrementing a number
    ''' </summary>
    <TestMethod>
    Public Sub TestDecrementNumberSingle()
        Dim TargetDict As New Dictionary(Of String, Single)
        For t As Integer = 1 To 10
            TargetDict.DecrementNumber("Counter")
        Next
        Assert.IsTrue(TargetDict("Counter") = -10)
    End Sub

    ''' <summary>
    ''' Tests incrementing a number
    ''' </summary>
    <TestMethod>
    Public Sub TestIncrementNumberDouble()
        Dim TargetDict As New Dictionary(Of String, Double)
        For t As Integer = 1 To 10
            TargetDict.IncrementNumber("Counter")
        Next
        Assert.IsTrue(TargetDict("Counter") = 10)
    End Sub

    ''' <summary>
    ''' Tests decrementing a number
    ''' </summary>
    <TestMethod>
    Public Sub TestDecrementNumberDouble()
        Dim TargetDict As New Dictionary(Of String, Double)
        For t As Integer = 1 To 10
            TargetDict.DecrementNumber("Counter")
        Next
        Assert.IsTrue(TargetDict("Counter") = -10)
    End Sub

    ''' <summary>
    ''' Tests seeing if the dictionary contains any of the specified clauses
    ''' </summary>
    <TestMethod>
    Public Sub TestContainsAnyOfInKeys()
        Dim TargetDict As New Dictionary(Of String, Integer) From {{"Test", 1}, {"Hello and Test", 2}, {"Tester! Hello!", 3}}
        Assert.IsTrue(TargetDict.ContainsAnyOfInKeys({"Hello and Test", "Test"}))
        Assert.IsFalse(TargetDict.ContainsAnyOfInKeys({"Goodbye", "Works"}))
    End Sub

    ''' <summary>
    ''' Tests seeing if the dictionary contains all of the specified clauses
    ''' </summary>
    <TestMethod>
    Public Sub TestContainsAllOfInKeys()
        Dim TargetDict As New Dictionary(Of String, Integer) From {{"Test", 1}, {"Hello and Test", 2}, {"Tester! Hello!", 3}}
        Assert.IsTrue(TargetDict.ContainsAllOfInKeys({"Hello and Test", "Test"}))
        Assert.IsFalse(TargetDict.ContainsAllOfInKeys({"Goodbye", "Works"}))
    End Sub

    ''' <summary>
    ''' Tests seeing if the dictionary contains any of the specified clauses
    ''' </summary>
    <TestMethod>
    Public Sub TestContainsAnyOfInValues()
        Dim TargetDict As New Dictionary(Of String, Integer) From {{"Test", 1}, {"Hello and Test", 2}, {"Tester! Hello!", 3}}
        Assert.IsTrue(TargetDict.ContainsAnyOfInValues({1, 3}))
        Assert.IsFalse(TargetDict.ContainsAnyOfInValues({5, 7}))
    End Sub

    ''' <summary>
    ''' Tests seeing if the dictionary contains all of the specified clauses
    ''' </summary>
    <TestMethod>
    Public Sub TestContainsAllOfInValues()
        Dim TargetDict As New Dictionary(Of String, Integer) From {{"Test", 1}, {"Hello and Test", 2}, {"Tester! Hello!", 3}}
        Assert.IsTrue(TargetDict.ContainsAllOfInValues({1, 3}))
        Assert.IsFalse(TargetDict.ContainsAllOfInValues({5, 7}))
    End Sub

    <TestMethod>
    Public Sub TestRenameKey()
        Dim TargetDict As New Dictionary(Of String, String) From {{"Name", "Extensification"}, {"Tyoe", "Library"}}
        TargetDict.RenameKey("Tyoe", "Type")
        Assert.IsTrue(TargetDict.ContainsKey("Type"))
    End Sub

#If NET45 Then
    ''' <summary>
    ''' Tests trying to add an entry to dictionary
    ''' </summary>
    <TestMethod>
    Public Sub TestTryAdd()
        Dim TargetDict As New Dictionary(Of String, Integer)
        Assert.IsTrue(TargetDict.TryAdd("Document number", 12))
        Assert.IsFalse(TargetDict.TryAdd("Document number", 13))
    End Sub
#End If

End Class

