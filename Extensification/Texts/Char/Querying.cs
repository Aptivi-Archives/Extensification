using System;
using System.Collections.Generic;

namespace Extensification.CharExts
{
    /// <summary>
    /// Provides the character extensions related to querying
    /// </summary>
    public static class Querying
    {

        /// <summary>
		/// 		''' Gets an ASCII code of a character
		/// 		''' </summary>
		/// 		''' <param name="Character">Character</param>
		/// 		''' <returns>ASCII code of a character</returns>
        public static int GetAsciiCode(this char Character)
        {
            return Convert.ToInt32(Character);
        }

        /// <summary>
		/// 		''' Converts the character to the instance of ConsoleKeyInfo
		/// 		''' </summary>
		/// 		''' <param name="c">The character</param>
        public static ConsoleKeyInfo ToConsoleKeyInfo(this char c)
        {
            return c.ToConsoleKeyInfo(null);
        }

        /// <summary>
		/// 		''' Converts the character to the instance of ConsoleKeyInfo
		/// 		''' </summary>
		/// 		''' <param name="c">The character</param>
		/// 		''' <param name="KeyCharMap">Key character map</param>
        public static ConsoleKeyInfo ToConsoleKeyInfo(this char c, Dictionary<char, Tuple<ConsoleKey, ConsoleModifiers>> KeyCharMap)
        {
            // Parse the key information
            var ParsedInfo = c.ParseKeyInfo(KeyCharMap);

            // Check to see if any modifiers are pressed
            bool ctrl = ParsedInfo.Item2.HasFlag(ConsoleModifiers.Control);
            bool shift = ParsedInfo.Item2.HasFlag(ConsoleModifiers.Shift);
            bool alt = ParsedInfo.Item2.HasFlag(ConsoleModifiers.Alt);

            // Return the new instance
            return new ConsoleKeyInfo(c, ParsedInfo.Item1, shift, alt, ctrl);
        }

        /// <summary>
		/// 		''' Parses the key information
		/// 		''' </summary>
		/// 		''' <param name="c">Character to parse</param>
        private static Tuple<ConsoleKey, ConsoleModifiers> ParseKeyInfo(this char c)
        {
            return c.ParseKeyInfo(null);
        }

        /// <summary>
		/// 		''' Parses the key information
		/// 		''' </summary>
		/// 		''' <param name="c">Character to parse</param>
		/// 		''' <param name="KeyCharMap">Key character map</param>
        private static Tuple<ConsoleKey, ConsoleModifiers> ParseKeyInfo(this char c, Dictionary<char, Tuple<ConsoleKey, ConsoleModifiers>> KeyCharMap)
        {
            // Try to get the ConsoleKey from the character
            if (c >= char.MinValue)
            {
                ConsoleKey result;
                bool success = Enum.TryParse(c.ToString().ToUpper(), out result);
                if (success)
                {
                    return Tuple.Create(result, (ConsoleModifiers)0);
                }
            }

            // Try to get the tuple of the special key character from the character map defined
            if (KeyCharMap is not null)
            {
                var result = new Tuple<ConsoleKey, ConsoleModifiers>(0, 0);
                bool success = KeyCharMap.TryGetValue(c, out result);
                if (success)
                {
                    return result;
                }
            }

            // If all else fails, return the default
            return Tuple.Create(default, (ConsoleModifiers)0);
        }


    }
}