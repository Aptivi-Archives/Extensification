Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Extensification.DoubleExts

<TestClass>
Public Class DoubleTests

    ''' <summary>
    ''' Tests double-precision number incrementation
    ''' </summary>
    <TestMethod>
    Public Sub TestIncrement()
        Dim ExpectedDouble As Double = 5
        Dim TargetDouble As Double = 3
        TargetDouble = TargetDouble.Increment(2)
        Assert.AreEqual(ExpectedDouble, TargetDouble)
    End Sub

    ''' <summary>
    ''' Tests double-precision number decrementation
    ''' </summary>
    <TestMethod>
    Public Sub TestDecrement()
        Dim ExpectedDouble As Double = 3
        Dim TargetDouble As Double = 5
        TargetDouble = TargetDouble.Decrement(2)
        Assert.AreEqual(ExpectedDouble, TargetDouble)
    End Sub

End Class
