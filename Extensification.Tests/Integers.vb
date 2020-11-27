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

    ''' <summary>
    ''' Tests unsigned integer incrementation
    ''' </summary>
    <TestMethod>
    Public Sub TestIncrementUnsigned()
        Dim ExpectedUInteger As UInteger = 5
        Dim TargetUInteger As UInteger = 3
        TargetUInteger = TargetUInteger.Increment(2)
        Assert.AreEqual(ExpectedUInteger, TargetUInteger)
    End Sub

    ''' <summary>
    ''' Tests unsigned integer decrementation
    ''' </summary>
    <TestMethod>
    Public Sub TestDecrementUnsigned()
        Dim ExpectedUInteger As UInteger = 3
        Dim TargetUInteger As UInteger = 5
        TargetUInteger = TargetUInteger.Decrement(2)
        Assert.AreEqual(ExpectedUInteger, TargetUInteger)
    End Sub

End Class
