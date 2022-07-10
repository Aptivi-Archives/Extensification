using System.Collections.Generic;

namespace Extensification.ListExts
{
    /// <summary>
    /// Provides the list extensions related to manipulation
    /// </summary>
    public static class Manipulation
    {

        /// <summary>
        /// Stringifies the character array (making a string from the character entries found inside the array)
        /// </summary>
        /// <param name="TargetCharArray">Character array</param>
        public static string Stringify(ref List<char> TargetCharArray)
        {
            return string.Join("", TargetCharArray);
        }

    }
}