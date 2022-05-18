
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
Imports Extensification.StringExts
Imports Extensification.ArrayExts

<TestFixture>
Public Class StringTests

#Region "Conversion"
    ''' <summary>
    ''' Tests parsing VT sequences (normal CSI ones).
    ''' </summary>
    <Test> Public Sub TestConvertVTSequencesNormal()
        Dim TargetString As String = "Hi. We have <38;5;6m>new improvements. <0m>Well, we'll have to do this: <38;5;7m>Yay!<48;5;2m>Colors!"
        TargetString.ConvertVTSequences
        Assert.IsFalse(TargetString.ContainsAnyOf({"<38;5;6m>", "<38;5;7m>", "<0m>", "<48;5;2m>"}))
        Assert.IsTrue(TargetString.Contains(ChrW(&H1B) + "["))
    End Sub

    ''' <summary>
    ''' Tests parsing VT sequences (OSC title one).
    ''' </summary>
    <Test> Public Sub TestConvertVTSequencesOSCTitle()
        Dim TargetString As String = "<0;Hi!>"
        TargetString.ConvertVTSequences
        Assert.IsFalse(TargetString.ContainsAnyOf({"<0;Hi!>"}))
        Assert.IsTrue(TargetString.Contains(ChrW(&H1B) + "]"))
        Assert.IsTrue(TargetString.EndsWith(ChrW(&H7)))
    End Sub

    ''' <summary>
    ''' Tests parsing VT sequences (OSC screen color one).
    ''' </summary>
    <Test> Public Sub TestConvertVTSequencesOSCScreenColor()
        Dim TargetString As String = "<4;15;rgb:ff/ff/ff>"
        TargetString.ConvertVTSequences
        Assert.IsFalse(TargetString.ContainsAnyOf({"<0;Hi!>"}))
        Assert.IsTrue(TargetString.Contains(ChrW(&H1B) + "]"))
        Assert.IsTrue(TargetString.EndsWith(ChrW(&H1B)))
    End Sub

    ''' <summary>
    ''' Tests parsing VT sequences (simple cursor positioning).
    ''' </summary>
    <Test> Public Sub TestConvertVTSequencesSimpleCursorPositioning()
        Dim TargetString As String = "<A>"
        TargetString.ConvertVTSequences
        Assert.IsFalse(TargetString.ContainsAnyOf({"<A>"}))
        Assert.IsTrue(TargetString = ChrW(&H1B) + "A")
    End Sub

    ''' <summary>
    ''' Tests converting from color hex to RGB
    ''' </summary>
    <Test> Public Sub TestConvertFromHexToRgb()
        Dim ExpectedR As Integer = 15
        Dim ExpectedG As Integer = 15
        Dim ExpectedB As Integer = 15
        Dim ActualR, ActualG, ActualB As Integer
        Dim Color As String = "#0F0F0F"
        Color.ConvertFromHexToRgb(ActualR, ActualG, ActualB)
        Assert.AreEqual(ExpectedR, ActualR)
        Assert.AreEqual(ExpectedG, ActualG)
        Assert.AreEqual(ExpectedB, ActualB)
    End Sub
#End Region

#Region "Manipulation"
    ''' <summary>
    ''' Tests replacing last occurrence of a string
    ''' </summary>
    <Test>
    Sub TestReplaceLastOccurrence()
        Dim Source As String = "Extensification is awesome and is great!"
        Dim Target As String = "is"
        Source = Source.ReplaceLastOccurrence(Target, "its features are")
        Assert.AreEqual(Source, "Extensification is awesome and its features are great!", "Replacement failed. Got {0}", Source)
    End Sub

    ''' <summary>
    ''' Tests replacing all specified occurrences of strings with a single string
    ''' </summary>
    <Test> Public Sub TestReplaceAll()
        Dim ExpectedString As String = "Please test Extensification. This sub is a unit test."
        Dim TargetString As String = "Please <replace> Extensification. This sub is a unit <replace2>."
        TargetString = TargetString.ReplaceAll({"<replace>", "<replace2>"}, "test")
        Assert.AreEqual(ExpectedString, TargetString, "String replacement failed. Got ""{0}""", TargetString)
    End Sub

    ''' <summary>
    ''' Tests replacing all specified occurrences of strings with multiple strings
    ''' </summary>
    <Test> Public Sub TestReplaceAllRange()
        Dim ExpectedString As String = "Please test the integrity of Extensification. This sub is a unit test."
        Dim TargetString As String = "Please <replace> Extensification. This sub is a unit <replace2>."
        TargetString = TargetString.ReplaceAllRange({"<replace>", "<replace2>"}, {"test the integrity of", "test"})
        Assert.AreEqual(ExpectedString, TargetString, "String replacement failed. Got ""{0}""", TargetString)
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
    ''' Tests shifting letters backwards in a string
    ''' </summary>
    <Test> Public Sub TestShiftLettersBackwards()
        Dim ExpectedString As String = "Beha"
        Dim TargetString As String = "File"
        TargetString = TargetString.ShiftLetters(-4)
        Assert.AreEqual(ExpectedString, TargetString, "String shift failed. Got ""{0}""", TargetString)
    End Sub

    ''' <summary>
    ''' Tests shifting letters forward in a string
    ''' </summary>
    <Test> Public Sub TestShiftLettersForward()
        Dim ExpectedString As String = "File"
        Dim TargetString As String = "Beha"
        TargetString = TargetString.ShiftLetters(4)
        Assert.AreEqual(ExpectedString, TargetString, "String shift failed. Got ""{0}""", TargetString)
    End Sub

    ''' <summary>
    ''' Tests reserving orders of characters in a string
    ''' </summary>
    <Test> Public Sub TestReverse()
        Dim TargetString As String = "olleH"
        Assert.AreEqual("Hello", TargetString.Reverse)
    End Sub

    ''' <summary>
    ''' Tests repeating the string
    ''' </summary>
    <Test> Public Sub TestRepeat()
        Dim TargetString As String = "Hi! "
        Assert.AreEqual("Hi! Hi! Hi! ", TargetString.Repeat(3))
    End Sub

    ''' <summary>
    ''' Tests repeating the string zero times
    ''' </summary>
    <Test> Public Sub TestRepeatZero()
        Dim TargetString As String = "Hi! "
        Assert.AreEqual("", TargetString.Repeat(0))
    End Sub

    ''' <summary>
    ''' Tests retrieving substring
    ''' </summary>
    <Test> Public Sub TestSubstring()
        Dim TargetString = "Hello!"
        Assert.AreEqual("llo", TargetString.Substring(2, length:=3))
        Assert.AreEqual("llo", TargetString.Substring(2, Finish:=4))
    End Sub

    ''' <summary>
    ''' Tests enclosing a string by double quotes
    ''' </summary>
    <Test> Public Sub TestEncloseByDoubleQuotes()
        Dim TargetString = "Hi!"
        Assert.AreEqual("""Hi!""", TargetString.EncloseByDoubleQuotes)
    End Sub

    ''' <summary>
    ''' Tests releasing a string from double quotes
    ''' </summary>
    <Test> Public Sub TestReleaseDoubleQuotes()
        Dim TargetString = """Hi!"""
        Assert.AreEqual("Hi!", TargetString.ReleaseDoubleQuotes)
    End Sub
#End Region

#Region "Querying"
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
    ''' Tests getting ASCII codes for a string
    ''' </summary>
    <Test> Public Sub TestGetAsciiCodes()
        Dim TargetString As String = "File"
        Dim TargetStringAscii() As Byte = TargetString.GetAsciiCodes
        Assert.IsNotNull(TargetStringAscii, "Array is null.")
        Assert.IsFalse(TargetStringAscii.Length = 0, "Getting ASCII codes failed. Length is zero.")
        Assert.IsTrue(TargetStringAscii.Length = 4, "Expected four entries of ASCII codes of characters. Got {0}", TargetStringAscii.Length)
    End Sub

    ''' <summary>
    ''' Tests getting an ASCII code for a letter in a string
    ''' </summary>
    <Test> Public Sub TestGetAsciiCode()
        Dim TargetString As String = "File"
        Dim TargetStringAscii As Byte = TargetString.GetAsciiCode(3)
        Assert.IsNotNull(TargetStringAscii, "Byte is null.")
        Assert.AreEqual(101, CInt(TargetStringAscii))
    End Sub

    ''' <summary>
    ''' Tests removing letters from a string
    ''' </summary>
    <Test> Public Sub TestGetListOfRepeatedLetters()
        Dim TargetString As String = "Extensification"
        Dim ExpectedReps As New Dictionary(Of String, Integer) From {{"E", 1}, {"x", 1}, {"t", 2}, {"e", 1}, {"n", 2}, {"s", 1}, {"i", 3}, {"f", 1}, {"c", 1}, {"a", 1}, {"o", 1}}
        Assert.IsTrue(TargetString.GetListOfRepeatedLetters.SequenceEqual(ExpectedReps))
    End Sub

    ''' <summary>
    ''' Tests checking if the string contains any of the target strings.
    ''' </summary>
    <Test> Public Sub TestContainsAnyOf()
        Dim TargetString As String = "Hello, Extensification users!"
        Assert.IsTrue(TargetString.ContainsAnyOf({"Extensification", "users"}))
        Assert.IsFalse(TargetString.ContainsAnyOf({"Awesome", "developers"}))
    End Sub

    ''' <summary>
    ''' Tests checking if the string contains all of the target strings.
    ''' </summary>
    <Test> Public Sub TestContainsAllOf()
        Dim TargetString As String = "Hello, Extensification users!"
        Assert.IsTrue(TargetString.ContainsAllOf({"Extensification", "users"}))
        Assert.IsFalse(TargetString.ContainsAllOf({"Awesome", "developers"}))
    End Sub

    ''' <summary>
    ''' Tests getting LRP from string
    ''' </summary>
    <Test> Public Sub TestLRP()
        Dim TargetString = "Hello!"
        Assert.AreEqual(3, TargetString.LRP(4))
    End Sub

    ''' <summary>
    ''' Tests checking to see if the string starts with any of the values
    ''' </summary>
    <Test> Public Sub TestStartsWithAnyOf()
        Dim TargetString As String = "dotnet-hostfxr-3.1 dotnet-hostfxr-5.0 runtime-3.1 runtime-5.0 sdk-3.1 sdk-5.0"
        Assert.IsTrue(TargetString.StartsWithAnyOf({"dotnet", "sdk"}))
    End Sub

    ''' <summary>
    ''' Tests checking to see if the string starts with all of the values
    ''' </summary>
    <Test> Public Sub TestStartsWithAllOf()
        Dim TargetString As String = "dotnet-hostfxr-3.1 dotnet-hostfxr-5.0 runtime-3.1 runtime-5.0 sdk-3.1 sdk-5.0"
        Assert.IsTrue(TargetString.StartsWithAllOf({"dotnet", "dotnet-hostfxr"}))
    End Sub

    ''' <summary>
    ''' Tests checking to see if the string ends with any of the values
    ''' </summary>
    <Test> Public Sub TestEndsWithAnyOf()
        Dim TargetString As String = "dotnet-hostfxr-3.1 dotnet-hostfxr-5.0 runtime-3.1 runtime-5.0 sdk-3.1 sdk-5.0"
        Assert.IsTrue(TargetString.EndsWithAnyOf({"5.0", "3.1"}))
    End Sub

    ''' <summary>
    ''' Tests checking to see if the string ends with all of the values
    ''' </summary>
    <Test> Public Sub TestEndsWithAllOf()
        Dim TargetString As String = "dotnet-hostfxr-3.1 dotnet-hostfxr-5.0 runtime-3.1 runtime-5.0 sdk-3.1 sdk-5.0"
        Assert.IsTrue(TargetString.EndsWithAllOf({"5.0", "sdk-5.0"}))
    End Sub

    ''' <summary>
    ''' Tests splitting a string with new lines (vbCrLf)
    ''' </summary>
    <Test> Public Sub TestSplitNewLinesCrLf()
        Dim TargetString As String = "First line" + vbCrLf + "Second line" + vbCrLf + "Third line"
        Dim TargetArray() As String = TargetString.SplitNewLines
        Assert.IsTrue(TargetArray.Length = 3)
    End Sub

    ''' <summary>
    ''' Tests splitting a string with new lines (vbCr)
    ''' </summary>
    <Test> Public Sub TestSplitNewLinesCr()
        Dim TargetString As String = "First line" + vbCr + "Second line" + vbCr + "Third line"
        Dim TargetArray() As String = TargetString.SplitNewLinesCr
        Assert.IsTrue(TargetArray.Length = 3)
    End Sub

    ''' <summary>
    ''' Tests splitting a string with new lines (vbLf)
    ''' </summary>
    <Test> Public Sub TestSplitNewLinesLf()
        Dim TargetString As String = "First line" + vbLf + "Second line" + vbLf + "Third line"
        Dim TargetArray() As String = TargetString.SplitNewLines
        Assert.IsTrue(TargetArray.Length = 3)
    End Sub

    ''' <summary>
    ''' Tests splitting a string with double quotes enclosed
    ''' </summary>
    <Test> Public Sub TestSplitEncloseDoubleQuotes()
        Dim TargetString As String = "First ""Second Third"" Fourth"
        Dim TargetArray() As String = TargetString.SplitEncloseDoubleQuotes(" ")
        Assert.IsTrue(TargetArray.Length = 3)
    End Sub
#End Region

#Region "Removal"
    ''' <summary>
    ''' Tests removing spaces from the beginning of the string
    ''' </summary>
    <Test> Public Sub TestRemoveSpacesFromBeginning()
        Dim ExpectedString As String = "Extensification is awesome and is great!"
        Dim TargetString As String = "     Extensification is awesome and is great!"
        TargetString = TargetString.RemoveSpacesFromBeginning
        Assert.AreEqual(ExpectedString, TargetString, "Removing space from beginning of string failed. Got ""{0}""", TargetString)
    End Sub

    ''' <summary>
    ''' Tests removing a letter from a string
    ''' </summary>
    <Test> Public Sub TestRemoveLetter()
        Dim TargetString As String = "Helllo"
        TargetString = TargetString.RemoveLetter(4)
        Assert.AreEqual("Hello", TargetString)
    End Sub

    ''' <summary>
    ''' Tests removing letters from a string
    ''' </summary>
    <Test> Public Sub TestRemoveLettersRange()
        Dim TargetString As String = "Helllo"
        Dim CharRange() As Char = {"l"c, "o"c}
        TargetString = TargetString.RemoveLettersRange(CharRange)
        Assert.AreEqual("He", TargetString)
    End Sub

    ''' <summary>
    ''' Tests removing null characters or whitespaces at the end of the string
    ''' </summary>
    <Test> Public Sub TestRemoveNullsOrWhitespacesAtTheEnd()
        Dim TargetString As String = "Hi!   "
        TargetString.RemoveNullsOrWhitespacesAtTheEnd
        Assert.AreEqual("Hi!", TargetString)
    End Sub

    ''' <summary>
    ''' Tests removing null characters or whitespaces at the end of the empty string
    ''' </summary>
    <Test> Public Sub TestRemoveNullsOrWhitespacesAtTheEndOnEmptyString()
        Dim TargetString As String = ""
        TargetString.RemoveNullsOrWhitespacesAtTheEnd
    End Sub

    ''' <summary>
    ''' Tests removing null characters or whitespaces at the beginning of the string
    ''' </summary>
    <Test> Public Sub TestRemoveNullsOrWhitespacesAtTheBeginning()
        Dim TargetString As String = "   Hi!"
        TargetString.RemoveNullsOrWhitespacesAtTheBeginning
        Assert.AreEqual("Hi!", TargetString)
    End Sub

    ''' <summary>
    ''' Tests removing null characters or whitespaces at the beginning of the empty string
    ''' </summary>
    <Test> Public Sub TestRemoveNullsOrWhitespacesAtTheBeginningOnEmptyString()
        Dim TargetString As String = ""
        TargetString.RemoveNullsOrWhitespacesAtTheBeginning
    End Sub
#End Region

End Class

