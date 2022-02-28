Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Extensification.Legacy.StringExts

Namespace Extensification.Legacy.Tests

    <TestClass>
    Public Class StringTests
        ''' <summary>
        ''' Tests splitting a string with double quotes enclosed
        ''' </summary>
        <TestMethod> Public Sub TestSplitEncloseDoubleQuotes()
            Dim TargetString As String = "First ""Second Third"" Fourth"
            Dim TargetArray() As String = TargetString.SplitEncloseDoubleQuotes(" ")
            Assert.IsTrue(TargetArray.Length = 3)
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

End Namespace

