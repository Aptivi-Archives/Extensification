using System;

namespace Extensification.CharExts
{
    /// <summary>
    /// Provides the character extensions related to manipulation
    /// </summary>
    public static class Manipulation
    {

        /// <summary>
        /// Increments the character
        /// </summary>
        /// <param name="Character">Character</param>
        /// <param name="IncrementThreshold">How many times to increment</param>
        /// <returns>Incremented character</returns>
        public static char Increment(this char Character, int IncrementThreshold)
        {
            if (IncrementThreshold < 0)
                throw new InvalidOperationException("Threshold is negative. Use Decrement().");
            return Convert.ToChar(Convert.ToInt32(Character) + IncrementThreshold);
        }

        /// <summary>
        /// Decrements the character
        /// </summary>
        /// <param name="Character">Character</param>
        /// <param name="DecrementThreshold">How many times to decrement</param>
        /// <returns>Decremented character</returns>
        public static char Decrement(this char Character, int DecrementThreshold)
        {
            if (DecrementThreshold < 0)
                throw new InvalidOperationException("Threshold is negative. Use Increment().");
            return Convert.ToChar(Convert.ToInt32(Character) - DecrementThreshold);
        }

    }
}