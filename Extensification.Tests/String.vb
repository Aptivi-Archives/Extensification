
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
Imports Extensification.StringExts
Imports Extensification.ArrayExts

<TestClass>
Public Class StringTests

    ''' <summary>
    ''' Tests replacing last occurrence of a string
    ''' </summary>
    <TestMethod>
    Sub TestReplaceLastOccurrence()
        Dim Source As String = "Extensification is awesome and is great!"
        Dim Target As String = "is"
        Source = Source.ReplaceLastOccurrence(Target, "its features are")
        Assert.AreEqual(Source, "Extensification is awesome and its features are great!", "Replacement failed. Got {0}", Source)
    End Sub

    ''' <summary>
    ''' Tests getting all indexes of a character
    ''' </summary>
    <TestMethod()> Public Sub TestAllIndexesOf()
        Dim Source As String = "Extensification is awesome and is great!"
        Dim Target As String = "a"
        Dim Indexes As Integer = Source.AllIndexesOf(Target).Count
        Assert.AreEqual(Indexes, 4, "Getting all indexes of a character failed. Expected 4, got {0}", Indexes)
    End Sub

    ''' <summary>
    ''' Tests truncating...
    ''' </summary>
    <TestMethod()> Public Sub TestTruncate()
        Dim Source As String = "Extensification is awesome and is great!"
        Dim Target As Integer = 20
        Source = Source.Truncate(Target)
        Assert.AreEqual(Source, "Extensification is ...", "Truncation failed. Got {0}", Source)
    End Sub

    ''' <summary>
    ''' Tests string formatting
    ''' </summary>
    <TestMethod()> Public Sub TestFormatString()
        Dim Expected As String = "Kernel Simulator 0.0.1 first launched 2/22/2018."
        Dim Actual As String = "Kernel Simulator 0.0.1 first launched {0}/{1}/{2}."
        Dim Day As Integer = 22
        Dim Year As Integer = 2018
        Dim Month As Integer = 2
        Actual = Actual.FormatString(Month, Day, Year)
        Assert.AreEqual(Expected, Actual, "Format failed. Got {0}", Actual)
    End Sub

    ''' <summary>
    ''' Tests string formatting with reference to null
    ''' </summary>
    <TestMethod()> Public Sub TestFormatStringNullReference()
        Dim Expected As String = "Nothing is ((Null))"
        Dim Actual As String = "{0} is {1}"
        Actual = Actual.FormatString("Nothing", Nothing)
        Assert.AreEqual(Expected, Actual, "Format failed. Got {0}", Actual)
    End Sub

    ''' <summary>
    ''' Tests removing spaces from the beginning of the string
    ''' </summary>
    <TestMethod> Public Sub TestRemoveSpacesFromBeginning()
        Dim ExpectedString As String = "Extensification is awesome and is great!"
        Dim TargetString As String = "     Extensification is awesome and is great!"
        TargetString = TargetString.RemoveSpacesFromBeginning
        Assert.AreEqual(ExpectedString, TargetString, "Removing space from beginning of string failed. Got ""{0}""", TargetString)
    End Sub

    ''' <summary>
    ''' Tests replacing all specified occurrences of strings with a single string
    ''' </summary>
    <TestMethod> Public Sub TestReplaceAll()
        Dim ExpectedString As String = "Please test Extensification. This sub is a unit test."
        Dim TargetString As String = "Please <replace> Extensification. This sub is a unit <replace2>."
        TargetString = TargetString.ReplaceAll({"<replace>", "<replace2>"}, "test")
        Assert.AreEqual(ExpectedString, TargetString, "String replacement failed. Got ""{0}""", TargetString)
    End Sub

    ''' <summary>
    ''' Tests shifting letters backwards in a string
    ''' </summary>
    <TestMethod> Public Sub TestShiftLettersBackwards()
        Dim ExpectedString As String = "Beha"
        Dim TargetString As String = "File"
        TargetString = TargetString.ShiftLetters(-4)
        Assert.AreEqual(ExpectedString, TargetString, "String shift failed. Got ""{0}""", TargetString)
    End Sub

    ''' <summary>
    ''' Tests shifting letters forward in a string
    ''' </summary>
    <TestMethod> Public Sub TestShiftLettersForward()
        Dim ExpectedString As String = "File"
        Dim TargetString As String = "Beha"
        TargetString = TargetString.ShiftLetters(4)
        Assert.AreEqual(ExpectedString, TargetString, "String shift failed. Got ""{0}""", TargetString)
    End Sub

    ''' <summary>
    ''' Tests getting ASCII codes for a string
    ''' </summary>
    <TestMethod> Public Sub TestGetAsciiCodes()
        Dim TargetString As String = "File"
        Dim TargetStringAscii() As Byte = TargetString.GetAsciiCodes
        Assert.IsNotNull(TargetStringAscii, "Array is null.")
        Assert.IsFalse(TargetStringAscii.Length = 0, "Getting ASCII codes failed. Length is zero.")
        Assert.IsTrue(TargetStringAscii.Length = 4, "Expected four entries of ASCII codes of characters. Got {0}", TargetStringAscii.Length)
    End Sub

    ''' <summary>
    ''' Tests getting an ASCII code for a letter in a string
    ''' </summary>
    <TestMethod> Public Sub TestGetAsciiCode()
        Dim TargetString As String = "File"
        Dim TargetStringAscii As Byte = TargetString.GetAsciiCode(3)
        Assert.IsNotNull(TargetStringAscii, "Byte is null.")
        Assert.AreEqual(101, CInt(TargetStringAscii))
    End Sub

    ''' <summary>
    ''' Tests removing a letter from a string
    ''' </summary>
    <TestMethod> Public Sub TestRemoveLetter()
        Dim TargetString As String = "Helllo"
        TargetString = TargetString.RemoveLetter(4)
        Assert.AreEqual("Hello", TargetString)
    End Sub

    ''' <summary>
    ''' Tests removing letters from a string
    ''' </summary>
    <TestMethod> Public Sub TestRemoveLettersRange()
        Dim TargetString As String = "Helllo"
        Dim CharRange() As Char = {"l"c, "o"c}
        TargetString = TargetString.RemoveLettersRange(CharRange)
        Assert.AreEqual("He", TargetString)
    End Sub

    ''' <summary>
    ''' Tests removing letters from a string
    ''' </summary>
    <TestMethod> Public Sub TestGetListOfRepeatedLetters()
        Dim TargetString As String = "Extensification"
        Dim ExpectedReps As New Dictionary(Of String, Integer) From {{"E", 1}, {"x", 1}, {"t", 2}, {"e", 1}, {"n", 2}, {"s", 1}, {"i", 3}, {"f", 1}, {"c", 1}, {"a", 1}, {"o", 1}}
        Assert.IsTrue(TargetString.GetListOfRepeatedLetters.SequenceEqual(ExpectedReps))
    End Sub

    ''' <summary>
    ''' Tests checking if the string contains any of the target strings.
    ''' </summary>
    <TestMethod> Public Sub TestContainsAnyOf()
        Dim TargetString As String = "Hello, Extensification users!"
        Assert.IsTrue(TargetString.ContainsAnyOf({"Extensification", "users"}))
        Assert.IsFalse(TargetString.ContainsAnyOf({"Awesome", "developers"}))
    End Sub

    ''' <summary>
    ''' Tests checking if the string contains all of the target strings.
    ''' </summary>
    <TestMethod> Public Sub TestContainsAllOf()
        Dim TargetString As String = "Hello, Extensification users!"
        Assert.IsTrue(TargetString.ContainsAllOf({"Extensification", "users"}))
        Assert.IsFalse(TargetString.ContainsAllOf({"Awesome", "developers"}))
    End Sub

    ''' <summary>
    ''' Tests parsing VT sequences.
    ''' </summary>
    <TestMethod> Public Sub TestConvertVTSequences()
        Dim TargetString As String = "Hi. We have <38;5;6>new improvements. <0>Well, we'll have to do this: <38;5;7>Yay!<38;5;2>Colors!"
        TargetString.ConvertVTSequences
        Assert.IsFalse(TargetString.ContainsAnyOf({"<38;5;6>", "<38;5;7>", "<0>", "<38;5;2>"}))
    End Sub

    ''' <summary>
    ''' Tests reserving orders of characters in a string
    ''' </summary>
    <TestMethod> Public Sub TestReverse()
        Dim TargetString As String = "olleH"
        Assert.AreEqual("Hello", TargetString.Reverse)
    End Sub

    ''' <summary>
    ''' Tests reserving orders of characters in a string
    ''' </summary>
    <TestMethod> Public Sub TestRepeat()
        Dim TargetString As String = "Hi! "
        Assert.AreEqual("Hi! Hi! Hi! ", TargetString.Repeat(3))
    End Sub

    ''' <summary>
    ''' Tests removing null characters or whitespaces at the end of the string
    ''' </summary>
    <TestMethod> Public Sub TestRemoveNullsOrWhitespacesAtTheEnd()
        Dim TargetString As String = "Hi!   "
        TargetString.RemoveNullsOrWhitespacesAtTheEnd
        Assert.AreEqual("Hi!", TargetString)
    End Sub

    ''' <summary>
    ''' Tests removing null characters or whitespaces at the beginning of the string
    ''' </summary>
    <TestMethod> Public Sub TestRemoveNullsOrWhitespacesAtTheBeginning()
        Dim TargetString As String = "   Hi!"
        TargetString.RemoveNullsOrWhitespacesAtTheBeginning
        Assert.AreEqual("Hi!", TargetString)
    End Sub

    ''' <summary>
    ''' Tests retrieving substring
    ''' </summary>
    <TestMethod> Public Sub TestSubstring()
        Dim TargetString = "Hello!"
        Assert.AreEqual("llo", TargetString.Substring(2, length:=3))
        Assert.AreEqual("llo", TargetString.Substring(2, Finish:=4))
    End Sub

    ''' <summary>
    ''' Tests getting LRP from string
    ''' </summary>
    <TestMethod> Public Sub TestLRP()
        Dim TargetString = "Hello!"
        Assert.AreEqual(3, TargetString.LRP(4))
    End Sub

#If NET45 Then
    ''' <summary>
    ''' Tests removing letters from a string
    ''' </summary>
    <TestMethod> Public Sub TestEvaluate()
        Dim TargetString As String = "2 + 5"
        Dim ExpectedEvaluated As Integer = 7
        Assert.AreEqual(ExpectedEvaluated, TargetString.Evaluate)
    End Sub
#End If

End Class

