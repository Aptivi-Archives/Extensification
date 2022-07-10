using System;

namespace Extensification.ByteExts
{
    /// <summary>
    /// Provides the byte extensions related to manipulation
    /// </summary>
    public static class Manipulation
    {

        /// <summary>
        /// Increments the number
        /// </summary>
        /// <param name="Number">Number</param>
        /// <param name="IncrementThreshold">How many times to increment</param>
        /// <returns>Incremented number</returns>
        public static byte Increment(this byte Number, byte IncrementThreshold)
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
        public static sbyte Increment(this sbyte Number, sbyte IncrementThreshold)
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
        public static byte Decrement(this byte Number, byte DecrementThreshold)
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
        public static sbyte Decrement(this sbyte Number, sbyte DecrementThreshold)
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
        public static void Swap(this ref byte SourceNumber, ref byte TargetNumber)
        {
            byte Source = SourceNumber;
            byte Target = TargetNumber;
            SourceNumber = Target;
            TargetNumber = Source;
        }

        /// <summary>
        /// Swaps the two numbers if the source is larger than the target
        /// </summary>
        /// <param name="SourceNumber">Number</param>
        /// <param name="TargetNumber">Number</param>
        public static void SwapIfSourceLarger(this ref byte SourceNumber, ref byte TargetNumber)
        {
            byte Source = SourceNumber;
            byte Target = TargetNumber;
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
        public static void SwapIfTargetLarger(this ref byte SourceNumber, ref byte TargetNumber)
        {
            byte Source = SourceNumber;
            byte Target = TargetNumber;
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
        public static void Swap(this ref sbyte SourceNumber, ref sbyte TargetNumber)
        {
            sbyte Source = SourceNumber;
            sbyte Target = TargetNumber;
            SourceNumber = Target;
            TargetNumber = Source;
        }

        /// <summary>
        /// Swaps the two numbers if the source is larger than the target
        /// </summary>
        /// <param name="SourceNumber">Number</param>
        /// <param name="TargetNumber">Number</param>
        public static void SwapIfSourceLarger(this ref sbyte SourceNumber, ref sbyte TargetNumber)
        {
            sbyte Source = SourceNumber;
            sbyte Target = TargetNumber;
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
        public static void SwapIfTargetLarger(this ref sbyte SourceNumber, ref sbyte TargetNumber)
        {
            sbyte Source = SourceNumber;
            sbyte Target = TargetNumber;
            if (SourceNumber < TargetNumber)
            {
                SourceNumber = Target;
                TargetNumber = Source;
            }
        }

    }
}