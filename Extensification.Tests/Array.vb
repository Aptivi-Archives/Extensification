Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Extensification.ArrayExts

<TestClass>
Public Class ArrayTests

    ''' <summary>
    ''' Tests counting full entries
    ''' </summary>
    <TestMethod>
    Public Sub TestCountFullEntries()
        Dim TargetArray() As String = {"", "Full", "", "Entry", ""}
        Dim TargetArrayObjects As String() = {4, Nothing, Nothing}
        Assert.AreEqual(CLng(2), TargetArray.CountFullEntries)
        Assert.AreEqual(CLng(1), TargetArrayObjects.CountFullEntries)
    End Sub

    ''' <summary>
    ''' Tests counting empty entries
    ''' </summary>
    <TestMethod>
    Public Sub TestCountEmptyEntries()
        Dim TargetArray() As String = {"", "Full", "", "Entry", ""}
        Dim TargetArrayObjects As String() = {4, Nothing, Nothing}
        Assert.AreEqual(CLng(3), TargetArray.CountEmptyEntries)
        Assert.AreEqual(CLng(2), TargetArrayObjects.CountEmptyEntries)
    End Sub

End Class
