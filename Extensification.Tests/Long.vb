Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Extensification.LongExts

<TestClass>
Public Class LongTests

    ''' <summary>
    ''' Tests long integer incrementation
    ''' </summary>
    <TestMethod>
    Public Sub TestIncrement()
        Dim ExpectedLong As Long = 5
        Dim TargetLong As Long = 3
        TargetLong = TargetLong.Increment(2)
        Assert.AreEqual(ExpectedLong, TargetLong)
    End Sub

    ''' <summary>
    ''' Tests long integer decrementation
    ''' </summary>
    <TestMethod>
    Public Sub TestDecrement()
        Dim ExpectedLong As Long = 3
        Dim TargetLong As Long = 5
        TargetLong = TargetLong.Decrement(2)
        Assert.AreEqual(ExpectedLong, TargetLong)
    End Sub

    ''' <summary>
    ''' Tests converting data size to human readable
    ''' </summary>
    <TestMethod>
    Public Sub TestDataToHumanReadable()
        Dim Expected As String = "4.2 MB"
        Dim Number As Long = 4200000
        Assert.AreEqual(Expected, Number.ToHumanReadable(HumanFormats.DataSize))
    End Sub

    ''' <summary>
    ''' Tests converting metric measurement without unusual measurements to human readable
    ''' </summary>
    <TestMethod>
    Public Sub TestMetricMeasurementToHumanReadable()
        Dim Expected As String = "12.5 centimeters"
        Dim Number As Long = 125
        Assert.AreEqual(Expected, Number.ToHumanReadable(HumanFormats.MeasurementsMetric))
    End Sub

    ''' <summary>
    ''' Tests converting metric measurement with unusual measurements to human readable
    ''' </summary>
    <TestMethod>
    Public Sub TestMetricMeasurementUnusualToHumanReadable()
        Dim Expected As String = "1.25 decimeters"
        Dim Number As Long = 125
        Assert.AreEqual(Expected, Number.ToHumanReadable(HumanFormats.MeasurementsMetricUnusual))
    End Sub

    ''' <summary>
    ''' Tests converting imperial measurement to human readable
    ''' </summary>
    <TestMethod>
    Public Sub TestImperialMeasurementToHumanReadable()
        Dim Expected As String = "1.10479797979798 miles"
        Dim Number As Long = 70000
        Assert.AreEqual(Expected, Number.ToHumanReadable(HumanFormats.MeasurementsImperial))
    End Sub

    ''' <summary>
    ''' Tests converting metric volume measurement to human readable
    ''' </summary>
    <TestMethod>
    Public Sub TestMetricVolumeToHumanReadable()
        Dim Expected As String = "2.5 liters"
        Dim Number As Long = 2500
        Assert.AreEqual(Expected, Number.ToHumanReadable(HumanFormats.VolumeMetric))
    End Sub

    ''' <summary>
    ''' Tests converting metric volume measurement to human readable
    ''' </summary>
    <TestMethod>
    Public Sub TestImperialVolumeToHumanReadable()
        Dim Expected As String = "2 quarts"
        Dim Number As Long = 4
        Assert.AreEqual(Expected, Number.ToHumanReadable(HumanFormats.VolumeImperial))
    End Sub

End Class
