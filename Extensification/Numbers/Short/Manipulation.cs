using System;

namespace Extensification.ShortExts
{
    /// <summary>
    /// Provides the 16-bit integer extensions related to manipulation
    /// </summary>
    public static class Manipulation
    {

        /// <summary>
        /// Increments the number
        /// </summary>
        /// <param name="Number">Number</param>
        /// <param name="IncrementThreshold">How many times to increment</param>
        /// <returns>Incremented number</returns>
        public static short Increment(this short Number, short IncrementThreshold)
        {
            if (IncrementThreshold < 0)
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
        public static ushort Increment(this ushort Number, ushort IncrementThreshold)
        {
            if (IncrementThreshold < 0)
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
        public static short Decrement(this short Number, short DecrementThreshold)
        {
            if (DecrementThreshold < 0)
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
        public static ushort Decrement(this ushort Number, ushort DecrementThreshold)
        {
            if (DecrementThreshold < 0)
                throw new InvalidOperationException("Threshold is negative. Use Increment().");
            Number -= DecrementThreshold;
            return Number;
        }

        /// <summary>
        /// Swaps the two numbers
        /// </summary>
        /// <param name="SourceNumber">Number</param>
        /// <param name="TargetNumber">Number</param>
        public static void Swap(this ref short SourceNumber, ref short TargetNumber)
        {
            short Source = SourceNumber;
            short Target = TargetNumber;
            SourceNumber = Target;
            TargetNumber = Source;
        }

        /// <summary>
        /// Swaps the two numbers if the source is larger than the target
        /// </summary>
        /// <param name="SourceNumber">Number</param>
        /// <param name="TargetNumber">Number</param>
        public static void SwapIfSourceLarger(this ref short SourceNumber, ref short TargetNumber)
        {
            short Source = SourceNumber;
            short Target = TargetNumber;
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
        public static void SwapIfTargetLarger(this ref short SourceNumber, ref short TargetNumber)
        {
            short Source = SourceNumber;
            short Target = TargetNumber;
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
        public static void Swap(this ref ushort SourceNumber, ref ushort TargetNumber)
        {
            ushort Source = SourceNumber;
            ushort Target = TargetNumber;
            SourceNumber = Target;
            TargetNumber = Source;
        }

        /// <summary>
        /// Swaps the two numbers if the source is larger than the target
        /// </summary>
        /// <param name="SourceNumber">Number</param>
        /// <param name="TargetNumber">Number</param>
        public static void SwapIfSourceLarger(this ref ushort SourceNumber, ref ushort TargetNumber)
        {
            ushort Source = SourceNumber;
            ushort Target = TargetNumber;
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
        public static void SwapIfTargetLarger(this ref ushort SourceNumber, ref ushort TargetNumber)
        {
            ushort Source = SourceNumber;
            ushort Target = TargetNumber;
            if (SourceNumber < TargetNumber)
            {
                SourceNumber = Target;
                TargetNumber = Source;
            }
        }

    }
}