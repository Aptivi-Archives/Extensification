
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
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Extensification.DictionaryExts;
using NotVisualBasic.FileIO;

namespace Extensification.StringExts
{
    /// <summary>
    /// Provides the string extensions related to querying
    /// </summary>
    public static class Querying
    {

        /// <summary>
        /// Get all indexes of a value in string
        /// </summary>
        /// <param name="Str">Source string</param>
        /// <param name="value">A value</param>
        /// <returns>Indexes of strings</returns>
        public static IEnumerable<int> AllIndexesOf(this string Str, string value)
        {
            if (Str is null)
                throw new ArgumentNullException(nameof(Str));
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Empty string specified", nameof(value));
            }
            int index = 0;
            do
            {
                index = Str.IndexOf(value, index);
                if (index == -1)
                {
                    break;
                }
                yield return index;
                index += value.Length;
            }
            while (true);
        }

        /// <summary>
        /// Gets list of ASCII codes from a string
        /// </summary>
        public static byte[] GetAsciiCodes(this string Str)
        {
            if (Str is null)
                throw new ArgumentNullException(nameof(Str));
            var StrChars = Str.ToCharArray();
            /* TODO ERROR: Skipped IfDirectiveTrivia
            #If NET45 Then
            *//* TODO ERROR: Skipped DisabledTextTrivia
                        Dim StrAscii As Byte() = {}
            *//* TODO ERROR: Skipped ElseDirectiveTrivia
            #Else
            */
            var StrAscii = Array.Empty<byte>();
            /* TODO ERROR: Skipped EndIfDirectiveTrivia
            #End If
            */
            for (int Character = 0, loopTo = StrChars.Length - 1; Character <= loopTo; Character++)
            {
                int AsciiCode = Convert.ToInt32(StrChars[Character]);
                ArrayExts.Addition.Add(ref StrAscii, (byte)AsciiCode);
            }
            return StrAscii;
        }

        /// <summary>
        /// Gets an ASCII code for a character
        /// </summary>
        /// <param name="CharacterNum">A zero-based character number</param>
        public static byte GetAsciiCode(this string Str, int CharacterNum)
        {
            if (Str is null)
                throw new ArgumentNullException(nameof(Str));
            var StrChars = Str.ToCharArray();
            return (byte)Convert.ToInt32(StrChars[CharacterNum]);
        }

        /// <summary>
        /// Gets the list of repeated letters
        /// </summary>
        /// <param name="Str">Target string</param>
        public static Dictionary<char, int> GetListOfRepeatedLetters(this string Str)
        {
            if (Str is null)
                throw new ArgumentNullException(nameof(Str));
            var Letters = new Dictionary<char, int>();
            var StrChars = Str.ToCharArray();
            foreach (char Chr in StrChars)
                Letters.IncrementNumber(Chr);
            return Letters;
        }

        /// <summary>
        /// Checks to see if the string contains any of the target strings.
        /// </summary>
        /// <param name="Str">Source string</param>
        /// <param name="Targets">Target strings</param>
        /// <returns>True if one of them is found; else, false.</returns>
        public static bool ContainsAnyOf(this string Str, string[] Targets)
        {
            if (Str is null)
                throw new ArgumentNullException(nameof(Str));
            foreach (string Target in Targets)
            {
                if (Str.Contains(Target))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Checks to see if the string contains all of the target strings.
        /// </summary>
        /// <param name="Str">Source string</param>
        /// <param name="Targets">Target strings</param>
        /// <returns>True if all of them are found; else, false.</returns>
        public static bool ContainsAllOf(this string Str, string[] Targets)
        {
            if (Str is null)
                throw new ArgumentNullException(nameof(Str));
            /* TODO ERROR: Skipped IfDirectiveTrivia
            #If NET45 Then
            *//* TODO ERROR: Skipped DisabledTextTrivia
                        Dim Done() As String = {}
            *//* TODO ERROR: Skipped ElseDirectiveTrivia
            #Else
            */
            var Done = Array.Empty<string>();
            /* TODO ERROR: Skipped EndIfDirectiveTrivia
            #End If
            */
            foreach (string Target in Targets)
            {
                if (Str.Contains(Target))
                    ArrayExts.Addition.Add(ref Done, Target);
            }
            return Done.SequenceEqual(Targets);
        }

        /// <summary>
        /// Gets how many times does the program need to step n times on the string until it reaches the end of string.
        /// </summary>
        /// <param name="Str">Target string</param>
        /// <param name="Steps">Number of characters to step on</param>
        public static int LRP(this string Str, int Steps)
        {
            if (Steps <= 0)
                throw new ArgumentException("Can't step zero or negative characters.", nameof(Steps));
            var LastPosition = default(int);
            int StringLength = Str.Length;
            var RepeatTimes = default(int);
            int LoopStep;
            var Step = default(int);
            while (true)
            {
                var loopTo = Steps + LastPosition;
                for (LoopStep = LastPosition; LoopStep <= loopTo; LoopStep++)
                {
                    Step = LoopStep;
                    while (Step > StringLength)
                        Step -= StringLength;
                }
                LastPosition = Step;
                RepeatTimes += 1;
                if (LastPosition == StringLength)
                    return RepeatTimes;
            }
            return 0;
        }

        /// <summary>
        /// Checks to see if the string starts with any of the values
        /// </summary>
        /// <param name="Str">Target string</param>
        /// <param name="Values">Values</param>
        public static bool StartsWithAnyOf(this string Str, string[] Values)
        {
            if (Str is null)
                throw new ArgumentNullException(nameof(Str));
            var Started = default(bool);
            foreach (string Value in Values)
            {
                if (Str.StartsWith(Value))
                    Started = true;
            }
            return Started;
        }

        /// <summary>
        /// Checks to see if the string starts with all of the values
        /// </summary>
        /// <param name="Str">Target string</param>
        /// <param name="Values">Values</param>
        public static bool StartsWithAllOf(this string Str, string[] Values)
        {
            if (Str is null)
                throw new ArgumentNullException(nameof(Str));
            /* TODO ERROR: Skipped IfDirectiveTrivia
            #If NET45 Then
            *//* TODO ERROR: Skipped DisabledTextTrivia
                        Dim Done() As String = {}
            *//* TODO ERROR: Skipped ElseDirectiveTrivia
            #Else
            */
            var Done = Array.Empty<string>();
            /* TODO ERROR: Skipped EndIfDirectiveTrivia
            #End If
            */
            foreach (string Value in Values)
            {
                if (Str.StartsWith(Value))
                    ArrayExts.Addition.Add(ref Done, Value);
            }
            return Done.SequenceEqual(Values);
        }

        /// <summary>
        /// Checks to see if the string ends with any of the values
        /// </summary>
        /// <param name="Str">Target string</param>
        /// <param name="Values">Values</param>
        public static bool EndsWithAnyOf(this string Str, string[] Values)
        {
            if (Str is null)
                throw new ArgumentNullException(nameof(Str));
            var Started = default(bool);
            foreach (string Value in Values)
            {
                if (Str.EndsWith(Value))
                    Started = true;
            }
            return Started;
        }

        /// <summary>
        /// Checks to see if the string ends with all of the values
        /// </summary>
        /// <param name="Str">Target string</param>
        /// <param name="Values">Values</param>
        public static bool EndsWithAllOf(this string Str, string[] Values)
        {
            if (Str is null)
                throw new ArgumentNullException(nameof(Str));
            /* TODO ERROR: Skipped IfDirectiveTrivia
            #If NET45 Then
            *//* TODO ERROR: Skipped DisabledTextTrivia
                        Dim Done() As String = {}
            *//* TODO ERROR: Skipped ElseDirectiveTrivia
            #Else
            */
            var Done = Array.Empty<string>();
            /* TODO ERROR: Skipped EndIfDirectiveTrivia
            #End If
            */
            foreach (string Value in Values)
            {
                if (Str.EndsWith(Value))
                    ArrayExts.Addition.Add(ref Done, Value);
            }
            return Done.SequenceEqual(Values);
        }

        /// <summary>
        /// Makes a string array with new line as delimiter
        /// </summary>
        /// <param name="Str">Target string</param>
        /// <returns></returns>
        public static string[] SplitNewLines(this string Str)
        {
            return Str.Replace(Convert.ToChar(13), default).Split(Convert.ToChar(10));
        }

        /// <summary>
        /// Makes a string array with new line (vbCr) as delimiter
        /// </summary>
        /// <param name="Str">Target string</param>
        /// <returns></returns>
        public static string[] SplitNewLinesCr(this string Str)
        {
            return Str.Replace(Convert.ToChar(10), default).Split(Convert.ToChar(13));
        }

        /// <summary>
        /// Splits the string enclosed in double quotes
        /// </summary>
        /// <param name="Str">Target string</param>
        /// <param name="Delims">Delimiters</param>
        public static string[] SplitEncloseDoubleQuotes(this string Str, params string[] Delims)
        {
            string[] Result;
            var TStream = new MemoryStream(Encoding.Default.GetBytes(Str));
            var Parser = new CsvTextFieldParser(TStream)
            {
                Delimiters = Delims,
                HasFieldsEnclosedInQuotes = true,
                TrimWhiteSpace = false
            };
            Result = Parser.ReadFields();
            if (Result is not null)
            {
                for (int i = 0, loopTo = Result.Length - 1; i <= loopTo; i++)
                    Result[i].Replace("\"", "");
            }
            return Result;
        }

    }
}