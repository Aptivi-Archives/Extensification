Imports System.Runtime.CompilerServices

Namespace ShortExts
    Public Module Extensions

        ''' <summary>
        ''' Increments the number
        ''' </summary>
        ''' <param name="Number">Number</param>
        ''' <param name="IncrementThreshold">How many times to increment</param>
        ''' <returns>Incremented number</returns>
        <Extension>
        Public Function Increment(ByVal Number As Short, ByVal IncrementThreshold As Integer) As Integer
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
        Public Function Decrement(ByVal Number As Short, ByVal DecrementThreshold As Integer) As Integer
            If DecrementThreshold < 0 Then Throw New InvalidOperationException("Threshold is negative. Use Increment().")
            Number -= DecrementThreshold
            Return Number
        End Function

        ''' <summary>
        ''' Increments the number
        ''' </summary>
        ''' <param name="Number">Number</param>
        ''' <param name="IncrementThreshold">How many times to increment</param>
        ''' <returns>Incremented number</returns>
        <Extension>
        Public Function Increment(ByVal Number As UShort, ByVal IncrementThreshold As Integer) As Integer
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
        Public Function Decrement(ByVal Number As UShort, ByVal DecrementThreshold As Integer) As Integer
            If DecrementThreshold < 0 Then Throw New InvalidOperationException("Threshold is negative. Use Increment().")
            Number -= DecrementThreshold
            Return Number
        End Function

    End Module
End Namespace
