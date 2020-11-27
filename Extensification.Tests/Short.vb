Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Extensification.ShortExts

<TestClass>
Public Class ShortTests

    ''' <summary>
    ''' Tests short integer incrementation
    ''' </summary>
    <TestMethod>
    Public Sub TestIncrement()
        Dim ExpectedShort As Short = 5
        Dim TargetShort As Short = 3
        TargetShort = TargetShort.Increment(2)
        Assert.AreEqual(ExpectedShort, TargetShort)
    End Sub

    ''' <summary>
    ''' Tests short integer decrementation
    ''' </summary>
    <TestMethod>
    Public Sub TestDecrement()
        Dim ExpectedShort As Short = 3
        Dim TargetShort As Short = 5
        TargetShort = TargetShort.Decrement(2)
        Assert.AreEqual(ExpectedShort, TargetShort)
    End Sub

    ''' <summary>
    ''' Tests unsigned short integer incrementation
    ''' </summary>
    <TestMethod>
    Public Sub TestIncrementUnsigned()
        Dim ExpectedUShort As UShort = 5
        Dim TargetUShort As UShort = 3
        TargetUShort = TargetUShort.Increment(2)
        Assert.AreEqual(ExpectedUShort, TargetUShort)
    End Sub

    ''' <summary>
    ''' Tests unsigned short integer decrementation
    ''' </summary>
    <TestMethod>
    Public Sub TestDecrementUnsigned()
        Dim ExpectedUShort As UShort = 3
        Dim TargetUShort As UShort = 5
        TargetUShort = TargetUShort.Decrement(2)
        Assert.AreEqual(ExpectedUShort, TargetUShort)
    End Sub

End Class
