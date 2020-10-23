Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Extensification.IntegerExts

<TestClass>
Public Class IntegerTests

    ''' <summary>
    ''' Tests integer incrementation
    ''' </summary>
    <TestMethod>
    Public Sub TestIncrement()
        Dim ExpectedInteger As Integer = 5
        Dim TargetInteger As Integer = 3
        TargetInteger = TargetInteger.Increment(2)
        Assert.AreEqual(ExpectedInteger, TargetInteger)
    End Sub

    ''' <summary>
    ''' Tests integer decrementation
    ''' </summary>
    <TestMethod>
    Public Sub TestDecrement()
        Dim ExpectedInteger As Integer = 3
        Dim TargetInteger As Integer = 5
        TargetInteger = TargetInteger.Decrement(2)
        Assert.AreEqual(ExpectedInteger, TargetInteger)
    End Sub

End Class
