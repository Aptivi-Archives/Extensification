
// Extensification  Copyright (C) 2020-2021  EoflaOE
// 
// This file is part of Extensification
// 
// Extensification is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// Extensification is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <https://www.gnu.org/licenses/>.

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