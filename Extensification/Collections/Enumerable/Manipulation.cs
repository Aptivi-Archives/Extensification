using System.Collections.Generic;

namespace Extensification.EnumerableExts
{
    /// <summary>
    /// Provides the enumerable extensions related to manipulation
    /// </summary>
    public static class Manipulation
    {

        /// <summary>
        /// Stringifies the character enumerable (making a string from the character entries found inside the enumerable)
        /// </summary>
        /// <param name="TargetCharArray">Character enumerable</param>
        public static string Stringify(ref IEnumerable<char> TargetCharArray)
        {
            return string.Join("", TargetCharArray);
        }

    }
}