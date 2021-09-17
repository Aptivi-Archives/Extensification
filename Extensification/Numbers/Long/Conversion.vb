
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
    ''' <summary>
    ''' Provides the 64-bit integer extensions related to conversion
    ''' </summary>
    Public Module Conversion

        ''' <summary>
        ''' Converts number to a human readable format with units used
        ''' </summary>
        ''' <param name="Num">Number</param>
        ''' <param name="Type">Measurement types</param>
        ''' <returns>A string containing the processed number and unit</returns>
        <Extension>
        Public Function ToHumanReadable(Num As Long, Type As HumanFormats) As String
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
        ''' Converts number to a human readable format with units used
        ''' </summary>
        ''' <param name="Num">Number</param>
        ''' <param name="Type">Measurement types</param>
        ''' <returns>A string containing the processed number and unit</returns>
        <Extension>
        Public Function ToHumanReadable(Num As ULong, Type As HumanFormats) As String
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

    End Module
End Namespace