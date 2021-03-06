
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

Imports System.Runtime.CompilerServices

Namespace LongExts
    Public Module Enums

        ''' <summary>
        ''' Human-readable formats
        ''' </summary>
        Public Enum HumanFormats
            ''' <summary>
            ''' Computer data size (KB, MB, GB, TB, PB, EB, ...)
            ''' </summary>
            DataSize
            ''' <summary>
            ''' Body measurements in metric units (mm, cm, m, km, ...)
            ''' </summary>
            MeasurementsMetric
            ''' <summary>
            ''' Body measurements in metric units (mm, cm, dm (Decimeters), m, dcm (Decameters), hm (Hectameters), km, ...)
            ''' </summary>
            MeasurementsMetricUnusual
            ''' <summary>
            ''' Body measurements in imperial units (feet, yards, miles, ...)
            ''' </summary>
            MeasurementsImperial
            ''' <summary>
            ''' Body volume in metric units (mL, L, kL (Kiloliters))
            ''' </summary>
            VolumeMetric
            ''' <summary>
            ''' Body volume in imperial units (pints, quarts, gallons, ...)
            ''' </summary>
            VolumeImperial
        End Enum

    End Module

    Public Module Extensions

        ''' <summary>
        ''' Converts number to a human readable format with units used
        ''' </summary>
        ''' <param name="Num">Number</param>
        ''' <param name="Type">Measurement types</param>
        ''' <returns>A string containing the processed number and unit</returns>
        <Extension>
        Public Function ToHumanReadable(ByVal Num As Long, ByVal Type As HumanFormats) As String
            Dim HumanString As String = ""
            Dim HumanNum As Double
            Select Case Type
                Case HumanFormats.DataSize
                    If Num >= 1000000000000000000 Then 'EB
                        HumanNum = Num / 1000000000000000000
                        HumanString = HumanNum & " EB"
                    ElseIf Num >= 1000000000000000 Then 'PB
                        HumanNum = Num / 1000000000000000
                        HumanString = HumanNum & " PB"
                    ElseIf Num >= 1000000000000 Then 'TB
                        HumanNum = Num / 1000000000000
                        HumanString = HumanNum & " TB"
                    ElseIf Num >= 1000000000 Then 'GB
                        HumanNum = Num / 1000000000
                        HumanString = HumanNum & " GB"
                    ElseIf Num >= 1000000 Then 'MB
                        HumanNum = Num / 1000000
                        HumanString = HumanNum & " MB"
                    ElseIf Num >= 1000 Then 'KB
                        HumanNum = Num / 1000
                        HumanString = HumanNum & " KB"
                    Else 'bytes
                        HumanString = HumanNum & " bytes"
                    End If
                Case HumanFormats.MeasurementsImperial
                    If Num >= 63360 Then 'miles
                        HumanNum = Num / 63360
                        HumanString = HumanNum & " miles"
                    ElseIf Num >= 36 Then 'yards
                        HumanNum = Num / 36
                        HumanString = HumanNum & " yards"
                    ElseIf Num >= 12 Then 'feet
                        HumanNum = Num / 12
                        HumanString = HumanNum & " feet"
                    Else 'inches
                        HumanString = Num & " inches"
                    End If
                Case HumanFormats.MeasurementsMetric
                    If Num >= 1000000 Then 'km
                        HumanNum = Num / 1000000
                        HumanString = HumanNum & " kilometers"
                    ElseIf Num >= 1000 Then 'm
                        HumanNum = Num / 1000
                        HumanString = HumanNum & " meters"
                    ElseIf Num >= 10 Then 'cm
                        HumanNum = Num / 10
                        HumanString = HumanNum & " centimeters"
                    Else 'mm
                        HumanString = Num & " millimeters"
                    End If
                Case HumanFormats.MeasurementsMetricUnusual
                    If Num >= 1000000 Then 'km
                        HumanNum = Num / 1000000
                        HumanString = HumanNum & " kilometers"
                    ElseIf Num >= 100000 Then 'hm
                        HumanNum = Num / 100000
                        HumanString = HumanNum & " hectameters"
                    ElseIf Num >= 10000 Then 'dcm
                        HumanNum = Num / 10000
                        HumanString = HumanNum & " decameters"
                    ElseIf Num >= 1000 Then 'm
                        HumanNum = Num / 1000
                        HumanString = HumanNum & " meters"
                    ElseIf Num >= 100 Then 'dm
                        HumanNum = Num / 100
                        HumanString = HumanNum & " decimeters"
                    ElseIf Num >= 10 Then 'cm
                        HumanNum = Num / 10
                        HumanString = HumanNum & " centimeters"
                    Else 'mm
                        HumanString = Num & " millimeters"
                    End If
                Case HumanFormats.VolumeMetric
                    If Num >= 1000000 Then 'kL
                        HumanNum = Num / 1000000
                        HumanString = HumanNum & " kiloliters"
                    ElseIf Num >= 1000 Then 'L
                        HumanNum = Num / 1000
                        HumanString = HumanNum & " liters"
                    Else 'mL
                        HumanString = Num & " milliliters"
                    End If
                Case HumanFormats.VolumeImperial
                    If Num >= 8 Then 'gallons
                        HumanNum = Num / 8
                        HumanString = HumanNum & " gallons"
                    ElseIf Num >= 2 Then 'quarts
                        HumanNum = Num / 2
                        HumanString = HumanNum & " quarts"
                    Else 'pints
                        HumanString = Num & " pints"
                    End If
            End Select
            Return HumanString
        End Function

        ''' <summary>
        ''' Increments the number
        ''' </summary>
        ''' <param name="Number">Number</param>
        ''' <param name="IncrementThreshold">How many times to increment</param>
        ''' <returns>Incremented number</returns>
        <Extension>
        Public Function Increment(ByVal Number As Long, ByVal IncrementThreshold As Long) As Long
            If IncrementThreshold < 0 Then Throw New InvalidOperationException("Threshold is negative. Use Decrement().")
            Number += IncrementThreshold
            Return Number
        End Function

        ''' <summary>
        ''' Decrements the number
        ''' </summary>
        ''' <param name="Number">Number</param>
        ''' <param name="DecrementThreshold">How many times to decrement</param>
        ''' <returns>Decremented number</returns>
        <Extension>
        Public Function Decrement(ByVal Number As Long, ByVal DecrementThreshold As Long) As Long
            If DecrementThreshold < 0 Then Throw New InvalidOperationException("Threshold is negative. Use Increment().")
            Number -= DecrementThreshold
            Return Number
        End Function

        ''' <summary>
        ''' Converts number to a human readable format with units used
        ''' </summary>
        ''' <param name="Num">Number</param>
        ''' <param name="Type">Measurement types</param>
        ''' <returns>A string containing the processed number and unit</returns>
        <Extension>
        Public Function ToHumanReadable(ByVal Num As ULong, ByVal Type As HumanFormats) As String
            Dim HumanString As String = ""
            Dim HumanNum As Double
            Select Case Type
                Case HumanFormats.DataSize
                    If Num >= 1000000000000000000 Then 'EB
                        HumanNum = Num / 1000000000000000000
                        HumanString = HumanNum & " EB"
                    ElseIf Num >= 1000000000000000 Then 'PB
                        HumanNum = Num / 1000000000000000
                        HumanString = HumanNum & " PB"
                    ElseIf Num >= 1000000000000 Then 'TB
                        HumanNum = Num / 1000000000000
                        HumanString = HumanNum & " TB"
                    ElseIf Num >= 1000000000 Then 'GB
                        HumanNum = Num / 1000000000
                        HumanString = HumanNum & " GB"
                    ElseIf Num >= 1000000 Then 'MB
                        HumanNum = Num / 1000000
                        HumanString = HumanNum & " MB"
                    ElseIf Num >= 1000 Then 'KB
                        HumanNum = Num / 1000
                        HumanString = HumanNum & " KB"
                    Else 'bytes
                        HumanString = HumanNum & " bytes"
                    End If
                Case HumanFormats.MeasurementsImperial
                    If Num >= 63360 Then 'miles
                        HumanNum = Num / 63360
                        HumanString = HumanNum & " miles"
                    ElseIf Num >= 36 Then 'yards
                        HumanNum = Num / 36
                        HumanString = HumanNum & " yards"
                    ElseIf Num >= 12 Then 'feet
                        HumanNum = Num / 12
                        HumanString = HumanNum & " feet"
                    Else 'inches
                        HumanString = Num & " inches"
                    End If
                Case HumanFormats.MeasurementsMetric
                    If Num >= 1000000 Then 'km
                        HumanNum = Num / 1000000
                        HumanString = HumanNum & " kilometers"
                    ElseIf Num >= 1000 Then 'm
                        HumanNum = Num / 1000
                        HumanString = HumanNum & " meters"
                    ElseIf Num >= 10 Then 'cm
                        HumanNum = Num / 10
                        HumanString = HumanNum & " centimeters"
                    Else 'mm
                        HumanString = Num & " millimeters"
                    End If
                Case HumanFormats.MeasurementsMetricUnusual
                    If Num >= 1000000 Then 'km
                        HumanNum = Num / 1000000
                        HumanString = HumanNum & " kilometers"
                    ElseIf Num >= 100000 Then 'hm
                        HumanNum = Num / 100000
                        HumanString = HumanNum & " hectameters"
                    ElseIf Num >= 10000 Then 'dcm
                        HumanNum = Num / 10000
                        HumanString = HumanNum & " decameters"
                    ElseIf Num >= 1000 Then 'm
                        HumanNum = Num / 1000
                        HumanString = HumanNum & " meters"
                    ElseIf Num >= 100 Then 'dm
                        HumanNum = Num / 100
                        HumanString = HumanNum & " decimeters"
                    ElseIf Num >= 10 Then 'cm
                        HumanNum = Num / 10
                        HumanString = HumanNum & " centimeters"
                    Else 'mm
                        HumanString = Num & " millimeters"
                    End If
                Case HumanFormats.VolumeMetric
                    If Num >= 1000000 Then 'kL
                        HumanNum = Num / 1000000
                        HumanString = HumanNum & " kiloliters"
                    ElseIf Num >= 1000 Then 'L
                        HumanNum = Num / 1000
                        HumanString = HumanNum & " liters"
                    Else 'mL
                        HumanString = Num & " milliliters"
                    End If
                Case HumanFormats.VolumeImperial
                    If Num >= 8 Then 'gallons
                        HumanNum = Num / 8
                        HumanString = HumanNum & " gallons"
                    ElseIf Num >= 2 Then 'quarts
                        HumanNum = Num / 2
                        HumanString = HumanNum & " quarts"
                    Else 'pints
                        HumanString = Num & " pints"
                    End If
            End Select
            Return HumanString
        End Function

        ''' <summary>
        ''' Increments the number
        ''' </summary>
        ''' <param name="Number">Number</param>
        ''' <param name="IncrementThreshold">How many times to increment</param>
        ''' <returns>Incremented number</returns>
        <Extension>
        Public Function Increment(ByVal Number As ULong, ByVal IncrementThreshold As Long) As Long
            If IncrementThreshold < 0 Then Throw New InvalidOperationException("Threshold is negative. Use Decrement().")
            Number += IncrementThreshold
            Return Number
        End Function

        ''' <summary>
        ''' Decrements the number
        ''' </summary>
        ''' <param name="Number">Number</param>
        ''' <param name="DecrementThreshold">How many times to decrement</param>
        ''' <returns>Decremented number</returns>
        <Extension>
        Public Function Decrement(ByVal Number As ULong, ByVal DecrementThreshold As Long) As Long
            If DecrementThreshold < 0 Then Throw New InvalidOperationException("Threshold is negative. Use Increment().")
            Number -= DecrementThreshold
            Return Number
        End Function

        ''' <summary>
        ''' Makes a list of digits
        ''' </summary>
        ''' <param name="Number">Number</param>
        ''' <returns>Array of digits</returns>
        <Extension>
        Public Function ListDigits(ByVal Number As Long) As Long()
            Dim StrNum As String = Number.ToString
            Dim NumList As Long() = Array.ConvertAll(StrNum.ToCharArray, Function(x) Convert.ToInt64(x.ToString))
            Return NumList
        End Function

        ''' <summary>
        ''' Makes a list of digits
        ''' </summary>
        ''' <param name="Number">Number</param>
        ''' <returns>Array of digits</returns>
        <Extension>
        Public Function ListDigits(ByVal Number As ULong) As ULong()
            Dim StrNum As String = Number.ToString
            Dim NumList As ULong() = Array.ConvertAll(StrNum.ToCharArray, Function(x) Convert.ToUInt64(x.ToString))
            Return NumList
        End Function

        ''' <summary>
        ''' Checks to see if the number is an Armstrong number (sum of cube of each digit of number equals the number itself)
        ''' </summary>
        ''' <param name="Number">Number</param>
        ''' <returns>True if the number is an Armstrong number; False if not.</returns>
        <Extension>
        Public Function IsArmstrong(ByVal Number As Long) As Boolean
            Dim Num As Long = Number
            Dim NumberDigits() As Long = Num.ListDigits
            Dim SumOfCubesOfDigits As Long
            For i As Integer = 0 To NumberDigits.Length - 1
                SumOfCubesOfDigits += Math.Pow(NumberDigits(i), 3)
            Next
            Return Num = SumOfCubesOfDigits
        End Function

        ''' <summary>
        ''' Checks to see if the number is an Armstrong number (sum of cube of each digit of number equals the number itself)
        ''' </summary>
        ''' <param name="Number">Number</param>
        ''' <returns>True if the number is an Armstrong number; False if not.</returns>
        <Extension>
        Public Function IsArmstrong(ByVal Number As ULong) As Boolean
            Dim Num As ULong = Number
            Dim NumberDigits() As ULong = Num.ListDigits
            Dim SumOfCubesOfDigits As ULong
            For i As Integer = 0 To NumberDigits.Length - 1
                SumOfCubesOfDigits += Math.Pow(NumberDigits(i), 3)
            Next
            Return Num = SumOfCubesOfDigits
        End Function

    End Module
End Namespace