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
            ''' Body measurements in metric units (mm, cm, dm (Decimeters), m, dcm (Dekameters), hm (Hectometers), km, ...)
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
            Select Case Type
                Case HumanFormats.DataSize

                Case HumanFormats.MeasurementsImperial

                Case HumanFormats.MeasurementsMetric

                Case HumanFormats.MeasurementsMetricUnusual

                Case HumanFormats.VolumeImperial

                Case HumanFormats.VolumeMetric

            End Select
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

    End Module
End Namespace