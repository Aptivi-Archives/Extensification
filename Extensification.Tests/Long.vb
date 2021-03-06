
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

    ''' <summary>
    ''' Tests unsigned long integer incrementation
    ''' </summary>
    <TestMethod>
    Public Sub TestIncrementUnsigned()
        Dim ExpectedULong As ULong = 5
        Dim TargetULong As ULong = 3
        TargetULong = TargetULong.Increment(2)
        Assert.AreEqual(ExpectedULong, TargetULong)
    End Sub

    ''' <summary>
    ''' Tests unsigned long integer decrementation
    ''' </summary>
    <TestMethod>
    Public Sub TestDecrementUnsigned()
        Dim ExpectedULong As ULong = 3
        Dim TargetULong As ULong = 5
        TargetULong = TargetULong.Decrement(2)
        Assert.AreEqual(ExpectedULong, TargetULong)
    End Sub

    ''' <summary>
    ''' Tests converting data size to human readable (Unsigned long)
    ''' </summary>
    <TestMethod>
    Public Sub TestDataToHumanReadableUnsigned()
        Dim Expected As String = "4.2 MB"
        Dim Number As ULong = 4200000
        Assert.AreEqual(Expected, Number.ToHumanReadable(HumanFormats.DataSize))
    End Sub

    ''' <summary>
    ''' Tests converting metric measurement without unusual measurements to human readable (Unsigned long)
    ''' </summary>
    <TestMethod>
    Public Sub TestMetricMeasurementToHumanReadableUnsigned()
        Dim Expected As String = "12.5 centimeters"
        Dim Number As ULong = 125
        Assert.AreEqual(Expected, Number.ToHumanReadable(HumanFormats.MeasurementsMetric))
    End Sub

    ''' <summary>
    ''' Tests converting metric measurement with unusual measurements to human readable (Unsigned long)
    ''' </summary>
    <TestMethod>
    Public Sub TestMetricMeasurementUnusualToHumanReadableUnsigned()
        Dim Expected As String = "1.25 decimeters"
        Dim Number As ULong = 125
        Assert.AreEqual(Expected, Number.ToHumanReadable(HumanFormats.MeasurementsMetricUnusual))
    End Sub

    ''' <summary>
    ''' Tests converting imperial measurement to human readable (Unsigned long)
    ''' </summary>
    <TestMethod>
    Public Sub TestImperialMeasurementToHumanReadableUnsigned()
        Dim Expected As String = "1.10479797979798 miles"
        Dim Number As ULong = 70000
        Assert.AreEqual(Expected, Number.ToHumanReadable(HumanFormats.MeasurementsImperial))
    End Sub

    ''' <summary>
    ''' Tests converting metric volume measurement to human readable (Unsigned long)
    ''' </summary>
    <TestMethod>
    Public Sub TestMetricVolumeToHumanReadableUnsigned()
        Dim Expected As String = "2.5 liters"
        Dim Number As ULong = 2500
        Assert.AreEqual(Expected, Number.ToHumanReadable(HumanFormats.VolumeMetric))
    End Sub

    ''' <summary>
    ''' Tests converting metric volume measurement to human readable (Unsigned long)
    ''' </summary>
    <TestMethod>
    Public Sub TestImperialVolumeToHumanReadableUnsigned()
        Dim Expected As String = "2 quarts"
        Dim Number As ULong = 4
        Assert.AreEqual(Expected, Number.ToHumanReadable(HumanFormats.VolumeImperial))
    End Sub

    ''' <summary>
    ''' Tests long integer digit listing
    ''' </summary>
    <TestMethod>
    Public Sub TestListDigits()
        Dim ExpectedDigits() As Long = {7, 5}
        Dim TargetNumber As Long = 75
        Assert.IsTrue(ExpectedDigits.SequenceEqual(TargetNumber.ListDigits))
    End Sub

    ''' <summary>
    ''' Tests unsigned long integer digit listing
    ''' </summary>
    <TestMethod>
    Public Sub TestListDigitsUnsigned()
        Dim ExpectedDigits() As ULong = {7, 5}
        Dim TargetNumber As ULong = 75
        Assert.IsTrue(ExpectedDigits.SequenceEqual(TargetNumber.ListDigits))
    End Sub

    ''' <summary>
    ''' Tests long integer Armstrong number detection
    ''' </summary>
    <TestMethod>
    Public Sub TestIsArmstrong()
        Dim TargetNumber As Long = 153
        Assert.IsTrue(TargetNumber.IsArmstrong)
    End Sub

    ''' <summary>
    ''' Tests unsigned long integer Armstrong number detection
    ''' </summary>
    <TestMethod>
    Public Sub TestIsArmstrongUnsigned()
        Dim TargetNumber As ULong = 153
        Assert.IsTrue(TargetNumber.IsArmstrong)
    End Sub

End Class
