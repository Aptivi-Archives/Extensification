
// Extensification  Copyright (C) 2020-2021  Aptivi
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
    /// Provides the string extensions related to manipulation
    /// </summary>
    public static class Manipulation
    {

        /// <summary>
        /// Replaces last occurrence of a text in source string with the replacement
        /// </summary>
        /// <param name="source">A string which has the specified text to replace</param>
        /// <param name="searchText">A string to be replaced</param>
        /// <param name="replace">A string to replace</param>
        /// <returns>String that has its last occurrence of text replaced</returns>
        public static string ReplaceLastOccurrence(this string source, string searchText, string replace)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));
            if (searchText is null)
                throw new ArgumentNullException(nameof(searchText));
            int position = source.LastIndexOf(searchText);
            if (position == -1)
                return source;
            string result = source.Remove(position, searchText.Length).Insert(position, replace);
            return result;
        }

        /// <summary>
        /// Replaces all the instances of strings with a string
        /// </summary>
        /// <param name="Str">Target string</param>
        /// <param name="ToBeReplaced">Strings to be replaced</param>
        /// <param name="ToReplace">String to replace with</param>
        /// <returns>Modified string</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static string ReplaceAll(this string Str, string[] ToBeReplaced, string ToReplace)
        {
            if (Str is null)
                throw new ArgumentNullException(nameof(Str));
            if (ToBeReplaced is null)
                throw new ArgumentNullException(nameof(ToBeReplaced));
            if (ToBeReplaced.Length == 0)
                throw new ArgumentNullException(nameof(ToBeReplaced));
            foreach (string ReplaceTarget in ToBeReplaced)
                Str = Str.Replace(ReplaceTarget, ToReplace);
            return Str;
        }

        /// <summary>
        /// Replaces all the instances of strings with a string assigned to each entry
        /// </summary>
        /// <param name="Str">Target string</param>
        /// <param name="ToBeReplaced">Strings to be replaced</param>
        /// <param name="ToReplace">Strings to replace with</param>
        /// <returns>Modified string</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static string ReplaceAllRange(this string Str, string[] ToBeReplaced, string[] ToReplace)
        {
            if (Str is null)
                throw new ArgumentNullException(nameof(Str));
            if (ToBeReplaced is null)
                throw new ArgumentNullException(nameof(ToBeReplaced));
            if (ToBeReplaced.Length == 0)
                throw new ArgumentNullException(nameof(ToBeReplaced));
            if (ToReplace is null)
                throw new ArgumentNullException(nameof(ToReplace));
            if (ToReplace.Length == 0)
                throw new ArgumentNullException(nameof(ToReplace));
            if (ToBeReplaced.Length != ToBeReplaced.Length)
                throw new ArgumentException("Array length of which strings to be replaced doesn't equal the array length of which strings to replace.");
            for (int i = 0, loopTo = ToBeReplaced.Length - 1; i <= loopTo; i++)
                Str = Str.Replace(ToBeReplaced[i], ToReplace[i]);
            return Str;
        }

        /// <summary>
        /// Truncates the string if the string is larger than the threshold, otherwise, returns an unchanged string
        /// </summary>
        /// <param name="str">Source string to truncate</param>
        /// <param name="threshold">Max number of string characters</param>
        /// <returns>Truncated string</returns>
        public static string Truncate(this string str, int threshold)
        {
            if (str is null)
                throw new ArgumentNullException(nameof(str));
            string result;
            if (str.Length > threshold)
            {
                result = str.Substring(0, threshold - 1) + "...";
                return result;
            }
            else
            {
                return str;
            }
        }

        /// <summary>
        /// Formats the string
        /// </summary>
        /// <param name="Str">Target string that has {0}, {1}, ...</param>
        /// <param name="Variables">Variables being used</param>
        /// <returns>Formatted string</returns>
        public static string FormatString(this string Str, params object[] Variables)
        {
            if (Str is null)
                throw new ArgumentNullException(nameof(Str));
            if (Variables is null)
                throw new ArgumentNullException(nameof(Variables));
            for (int v = 0, loopTo = Variables.Length - 1; v <= loopTo; v++)
            {
                if (Variables[v] is not null)
                {
                    Str = Str.Replace("{" + v.ToString() + "}", Variables[v].ToString());
                }
                else
                {
                    Str = Str.Replace("{" + v.ToString() + "}", "((Null))");
                }
            }
            return Str;
        }

        /// <summary>
        /// Shifts letters in a string either backwards or forward.
        /// </summary>
        /// <param name="Str">Target string</param>
        /// <param name="ShiftThreshold">How many times to shift. If the threshold is negative, the shifting will go backwards. If the threshold is positive, the shifting will go forward.</param>
        /// <returns>Shifted string</returns>
        public static string ShiftLetters(this string Str, int ShiftThreshold)
        {
            if (Str is null)
                throw new ArgumentNullException(nameof(Str));
            var StrChars = Str.ToCharArray();
            for (int Character = 0, loopTo = StrChars.Length - 1; Character <= loopTo; Character++)
                StrChars[Character] = Convert.ToChar(Convert.ToInt32(StrChars[Character]) + ShiftThreshold);
            return string.Join("", StrChars);
        }

        /// <summary>
        /// Reverses the order of characters in a string
        /// </summary>
        /// <param name="Str">Target string</param>
        public static string Reverse(this string Str)
        {
            if (Str is null)
                throw new ArgumentNullException(nameof(Str));
            return string.Join("", Str.ToCharArray().Reverse());
        }

        /// <summary>
        /// Repeats a string 'n' times
        /// </summary>
        /// <param name="Str">Target string</param>
        /// <param name="Times">Number of times to be repeated</param>
        public static string Repeat(this string Str, long Times)
        {
            if (Str is null)
                throw new ArgumentNullException(nameof(Str));
            if (Times < 0L)
                throw new ArgumentException("Negative times isn't allowed.", nameof(Str));
            string Target = "";
            for (long i = 0L, loopTo = Times - 1L; i <= loopTo; i++)
                Target += Str;
            return Target;
        }

        /// <summary>
        /// Retrieves a substring from this instance. The substring starts at a specified starting position and ends at a specified ending position
        /// </summary>
        /// <param name="Str">Target string</param>
        /// <param name="Start">Start position</param>
        /// <param name="Finish">Finish position</param>
        public static string Substring(this string Str, int Start, int Finish)
        {
            if (Finish < Start)
                throw new ArgumentException("Finish position couldn't be before the start position");
            int Length = Finish - Start;
            return Str.Substring(Start, length: Length + 1);
        }

        /// <summary>
        /// Encloses a string by double quotations
        /// </summary>
        /// <param name="Str">Target string</param>
        /// <returns>Enclosed string</returns>
        public static string EncloseByDoubleQuotes(this string Str)
        {
            return "\"" + Str + "\"";
        }

        /// <summary>
        /// Releases a string from double quotations
        /// </summary>
        /// <param name="Str">Target string</param>
        /// <returns>Released string</returns>
        public static string ReleaseDoubleQuotes(this string Str)
        {
            string ReleasedString = Str;
            if (Str.StartsWith("\"") & Str.EndsWith("\""))
            {
                ReleasedString = ReleasedString.Remove(0, 1);
                ReleasedString = ReleasedString.Remove(ReleasedString.Length - 1);
            }
            return ReleasedString;
        }

        /// <summary>
        /// Makes the first character of the string uppercase
        /// </summary>
        /// <param name="Str">The target string</param>
        /// <returns>A string that has its first character being made uppercase</returns>
        public static string UpperFirst(this string Str)
        {
            char[] chars = Str.ToCharArray();
            chars[0] = char.ToUpper(chars[0]);
            return string.Join("", chars);
        }

        /// <summary>
        /// Makes the first character of the string lowercase
        /// </summary>
        /// <param name="Str">The target string</param>
        /// <returns>A string that has its first character being made lowercase</returns>
        public static string LowerFirst(this string Str)
        {
            char[] chars = Str.ToCharArray();
            chars[0] = char.ToLower(chars[0]);
            return string.Join("", chars);
        }

        /// <summary>
        /// Makes the string have the title case
        /// </summary>
        /// <param name="Str">String to be titled</param>
        /// <returns>The titled string</returns>
        public static string ToTitleCase(this string Str)
        {
            // TODO: Add more exclusions
            string[] exclusions = new[] { "of", "the", "a", "an", "in", "on", "to", "from" };

            // Split the string to words and make them the titlecase
            string[] words = Str.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i];

                // If the word isn't in the exclusions list, uppercase the first character
                if (!exclusions.Contains(word))
                    words[i] = word.UpperFirst();
            }

            // Form a final string
            return string.Join(" ", words);
        }

        /// <summary>
        /// Makes the string have the MoCk CaSE
        /// </summary>
        /// <param name="Str">String to be MoCKeD</param>
        /// <returns>The mOcKEd string</returns>
        public static string ToMockCase(this string Str) => ToMockCase(Str, 25);

        /// <summary>
        /// Makes the string have the MoCk CaSE
        /// </summary>
        /// <param name="Str">String to be MoCKeD</param>
        /// <param name="mockProbability">Mock probability in percent (0-100)</param>
        /// <returns>The mOcKEd string</returns>
        public static string ToMockCase(this string Str, int mockProbability)
        {
            // Split the characters and process them
            char[] chars = Str.ToCharArray();
            Random randomDriver = new();
            for (int i = 0; i < chars.Length; i++)
            {
                // Select whether to mock or not randomly
                double Probability = (mockProbability > 100 ? 25 : mockProbability) / 100d;
                bool MockGuaranteed = randomDriver.NextDouble() < Probability;

                // If mocking, uppercase the character
                if (MockGuaranteed)
                    chars[i] = char.ToUpper(chars[i]);
            }

            // Form a final string
            return string.Join("", chars);
        }

    }
}