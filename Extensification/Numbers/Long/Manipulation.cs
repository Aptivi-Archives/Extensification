using System;

namespace Extensification.LongExts
{
    /// <summary>
    /// Provides the 64-bit integer extensions related to manipulation
    /// </summary>
    public static class Manipulation
    {

        /// <summary>
        /// Increments the number
        /// </summary>
        /// <param name="Number">Number</param>
        /// <param name="IncrementThreshold">How many times to increment</param>
        /// <returns>Incremented number</returns>
        public static long Increment(this long Number, long IncrementThreshold)
        {
            if (IncrementThreshold < 0L)
                throw new InvalidOperationException("Threshold is negative. Use Decrement().");
            Number += IncrementThreshold;
            return Number;
        }

        /// <summary>
        /// Increments the number
        /// </summary>
        /// <param name="Number">Number</param>
        /// <param name="IncrementThreshold">How many times to increment</param>
        /// <returns>Incremented number</returns>
        public static ulong Increment(this ulong Number, ulong IncrementThreshold)
        {
            if (IncrementThreshold < 0m)
                throw new InvalidOperationException("Threshold is negative. Use Decrement().");
            Number += IncrementThreshold;
            return Number;
        }

        /// <summary>
        /// Decrements the number
        /// </summary>
        /// <param name="Number">Number</param>
        /// <param name="DecrementThreshold">How many times to decrement</param>
        /// <returns>Decremented number</returns>
        public static long Decrement(this long Number, long DecrementThreshold)
        {
            if (DecrementThreshold < 0L)
                throw new InvalidOperationException("Threshold is negative. Use Increment().");
            Number -= DecrementThreshold;
            return Number;
        }

        /// <summary>
        /// Decrements the number
        /// </summary>
        /// <param name="Number">Number</param>
        /// <param name="DecrementThreshold">How many times to decrement</param>
        /// <returns>Decremented number</returns>
        public static ulong Decrement(this ulong Number, ulong DecrementThreshold)
        {
            if (DecrementThreshold < 0m)
                throw new InvalidOperationException("Threshold is negative. Use Increment().");
            Number -= DecrementThreshold;
            return Number;
        }

        /// <summary>
        /// Swaps the two numbers
        /// </summary>
        /// <param name="SourceNumber">Number</param>
        /// <param name="TargetNumber">Number</param>
        public static void Swap(this ref long SourceNumber, ref long TargetNumber)
        {
            long Source = SourceNumber;
            long Target = TargetNumber;
            SourceNumber = Target;
            TargetNumber = Source;
        }

        /// <summary>
        /// Swaps the two numbers if the source is larger than the target
        /// </summary>
        /// <param name="SourceNumber">Number</param>
        /// <param name="TargetNumber">Number</param>
        public static void SwapIfSourceLarger(this ref long SourceNumber, ref long TargetNumber)
        {
            long Source = SourceNumber;
            long Target = TargetNumber;
            if (SourceNumber > TargetNumber)
            {
                SourceNumber = Target;
                TargetNumber = Source;
            }
        }

        /// <summary>
        /// Swaps the two numbers if the target is larger than the target
        /// </summary>
        /// <param name="SourceNumber">Number</param>
        /// <param name="TargetNumber">Number</param>
        public static void SwapIfTargetLarger(this ref long SourceNumber, ref long TargetNumber)
        {
            long Source = SourceNumber;
            long Target = TargetNumber;
            if (SourceNumber < TargetNumber)
            {
                SourceNumber = Target;
                TargetNumber = Source;
            }
        }

        /// <summary>
        /// Swaps the two numbers
        /// </summary>
        /// <param name="SourceNumber">Number</param>
        /// <param name="TargetNumber">Number</param>
        public static void Swap(this ref ulong SourceNumber, ref ulong TargetNumber)
        {
            ulong Source = SourceNumber;
            ulong Target = TargetNumber;
            SourceNumber = Target;
            TargetNumber = Source;
        }

        /// <summary>
        /// Swaps the two numbers if the source is larger than the target
        /// </summary>
        /// <param name="SourceNumber">Number</param>
        /// <param name="TargetNumber">Number</param>
        public static void SwapIfSourceLarger(this ref ulong SourceNumber, ref ulong TargetNumber)
        {
            ulong Source = SourceNumber;
            ulong Target = TargetNumber;
            if (SourceNumber > TargetNumber)
            {
                SourceNumber = Target;
                TargetNumber = Source;
            }
        }

        /// <summary>
        /// Swaps the two numbers if the target is larger than the target
        /// </summary>
        /// <param name="SourceNumber">Number</param>
        /// <param name="TargetNumber">Number</param>
        public static void SwapIfTargetLarger(this ref ulong SourceNumber, ref ulong TargetNumber)
        {
            ulong Source = SourceNumber;
            ulong Target = TargetNumber;
            if (SourceNumber < TargetNumber)
            {
                SourceNumber = Target;
                TargetNumber = Source;
            }
        }

    }
}