using System;

namespace Extensification.SingleExts
{
    /// <summary>
    /// Provides the single-precision number extensions related to manipulation
    /// </summary>
    public static class Manipulation
    {

        /// <summary>
        /// Increments the number
        /// </summary>
        /// <param name="Number">Number</param>
        /// <param name="IncrementThreshold">How many times to increment</param>
        /// <returns>Incremented number</returns>
        public static float Increment(this float Number, float IncrementThreshold)
        {
            if (IncrementThreshold < 0f)
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
        public static float Decrement(this float Number, float DecrementThreshold)
        {
            if (DecrementThreshold < 0f)
                throw new InvalidOperationException("Threshold is negative. Use Increment().");
            Number -= DecrementThreshold;
            return Number;
        }

        /// <summary>
        /// Swaps the two numbers
        /// </summary>
        /// <param name="SourceNumber">Number</param>
        /// <param name="TargetNumber">Number</param>
        public static void Swap(this ref float SourceNumber, ref float TargetNumber)
        {
            float Source = SourceNumber;
            float Target = TargetNumber;
            SourceNumber = Target;
            TargetNumber = Source;
        }

        /// <summary>
        /// Swaps the two numbers if the source is larger than the target
        /// </summary>
        /// <param name="SourceNumber">Number</param>
        /// <param name="TargetNumber">Number</param>
        public static void SwapIfSourceLarger(this ref float SourceNumber, ref float TargetNumber)
        {
            float Source = SourceNumber;
            float Target = TargetNumber;
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
        public static void SwapIfTargetLarger(this ref float SourceNumber, ref float TargetNumber)
        {
            float Source = SourceNumber;
            float Target = TargetNumber;
            if (SourceNumber < TargetNumber)
            {
                SourceNumber = Target;
                TargetNumber = Source;
            }
        }

    }
}