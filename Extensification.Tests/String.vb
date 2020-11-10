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

End Class

