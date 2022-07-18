
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
using System.Linq;

namespace Extensification.StringExts
{
    /// <summary>
    /// Provides the string extensions related to removal
    /// </summary>
    public static class Removal
    {

        /// <summary>
        /// Removes spaces from the beginning of the string
        /// </summary>
        /// <param name="Str">Target string</param>
        /// <returns>Modified string</returns>
        public static string RemoveSpacesFromBeginning(this string Str)
        {
            if (Str is null)
                throw new ArgumentNullException(nameof(Str));
            var StrChars = Str.ToCharArray();
            int CharNum = 0;
            while (StrChars[CharNum] == ' ')
            {
                StrChars[CharNum] = default;
                CharNum += 1;
            }
            return string.Join("", StrChars).Replace(Convert.ToChar(0), default);
        }

        /// <summary>
        /// Removes a letter from a string
        /// </summary>
        /// <param name="CharacterNum">A zero-based character number</param>
        public static string RemoveLetter(this string Str, int CharacterNum)
        {
            if (Str is null)
                throw new ArgumentNullException(nameof(Str));
            var StrChars = Str.ToCharArray().ToList();
            StrChars.RemoveAt(CharacterNum);
            return string.Join("", StrChars);
        }

        /// <summary>
        /// Removes a range of letters from a string
        /// </summary>
        /// <param name="Characters">Array of characters to be remove</param>
        public static string RemoveLettersRange(this string Str, char[] Characters)
        {
            if (Str is null)
                throw new ArgumentNullException(nameof(Str));
            if (Characters is null)
                throw new ArgumentNullException(nameof(Characters));
            var StrChars = Str.ToCharArray().ToList();
            StrChars.RemoveAll(Characters.Contains);
            return string.Join("", StrChars);
        }

        /// <summary>
        /// Removes null characters or whitespaces at the end of the string
        /// </summary>
        /// <param name="Str">Target string</param>
        public static void RemoveNullsOrWhitespacesAtTheEnd(this string Str)
        {
            if (Str is null)
                throw new ArgumentNullException(nameof(Str));
            var StrList = Str.ToCharArray().ToList();
            int CharIndex = Str.Length - 1;
            if (!(StrList.Count == 0))
            {
                while (char.IsWhiteSpace(StrList[CharIndex]) | StrList[CharIndex] == default)
                {
                    StrList.RemoveAt(CharIndex);
                    CharIndex -= 1;
                }
            }
            Str = string.Join("", StrList);
        }

        /// <summary>
        /// Removes null characters or whitespaces at the beginning of the string
        /// </summary>
        /// <param name="Str">Target string</param>
        public static void RemoveNullsOrWhitespacesAtTheBeginning(this string Str)
        {
            if (Str is null)
                throw new ArgumentNullException(nameof(Str));
            var StrList = Str.ToCharArray().ToList();
            if (!(StrList.Count == 0))
            {
                while (char.IsWhiteSpace(StrList[0]) | StrList[0] == default)
                    StrList.RemoveAt(0);
            }
            Str = string.Join("", StrList);
        }

    }
}