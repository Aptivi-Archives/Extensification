
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

namespace Extensification.StringExts
{
    /// <summary>
    /// Provides the string extensions related to conversion
    /// </summary>
    public static class Conversion
    {

        /// <summary>
        /// Converts all of the VT sequence numbers enclosed in &lt; and &gt; marks to their appropriate VT sequence.
        /// For example, &lt;38;5;5&gt; will be converted to Convert.ToChar(&amp;H1B)[38;5;5. Note that if you write spaces between &lt; and &gt; marks,
        /// it will not parse it.
        /// </summary>
        /// <param name="Str">Target string</param>
        public static string ConvertVTSequences(this string Str)
        {
            if (Str is null)
                throw new ArgumentNullException(nameof(Str));
            var StrArrayWords = Str.Split(' ');
            string Sequence;
            for (int WordNumber = 0, loopTo = StrArrayWords.Length - 1; WordNumber <= loopTo; WordNumber++)
            {
                if (StrArrayWords[WordNumber].ContainsAllOf(new[] { "<", ">" }))
                {
                    ParseSequence:
                    ;

                    // Get sequence that is enclosed between < and > quotes.
                    int StartIndex = StrArrayWords[WordNumber].IndexOf("<");
                    int EndIndex = StrArrayWords[WordNumber].IndexOf(">") + 1;

                    // Replace placeholder sequence with the parsable sequence.
                    if (StartIndex != -1 & EndIndex != -1)
                    {
                        Sequence = StrArrayWords[WordNumber].Substring(StartIndex, EndIndex - StartIndex);

                        // Check if the sequence needs special beginning
                        if (Sequence.StartsWithAnyOf(new[] { "<A", "<B", "<C", "<D", "<M", "<E", "<7", "<8", "<=", "<>", "<H", "<N", "<O", "<5n", "<6n" }) & !Sequence.EndsWithAnyOf(new[] { "F>", "G>", "H>", "d>", "f>", "S>", "T>", "@>", "P>", "X>", "L>", "M>", "J>", "K>", "m>", "I>", "Z>", "r>" }))
                        {
                            // These sequences don't need any of '[' and ']'.
                            StrArrayWords[WordNumber] = StrArrayWords[WordNumber].Replace(Sequence, Convert.ToChar(0x1B).ToString() + Sequence.ReplaceAll(new[] { "<", ">" }, ""));
                        }
                        else if (Sequence.StartsWithAnyOf(new[] { "<4", "<0", "<2" }) & (!Sequence.StartsWithAnyOf(new[] { "<2~", "<20", "<21", "<23", "<24", "<48" }) & !Sequence.EndsWith("0m>")))
                        {
                            // These sequences need ']' as they are OSC sequences.
                            if (Sequence.StartsWithAnyOf(new[] { "<0", "<2" }))
                            {
                                // They each need a BELL character &H07
                                StrArrayWords[WordNumber] = StrArrayWords[WordNumber].Replace(Sequence, Convert.ToChar(0x1B).ToString() + "]" + Sequence.ReplaceAll(new[] { "<", ">" }, "") + Convert.ToChar(0x7).ToString());
                            }
                            else if (Sequence.StartsWith("<4"))
                            {
                                // This needs an ESC character &H1B
                                StrArrayWords[WordNumber] = StrArrayWords[WordNumber].Replace(Sequence, Convert.ToChar(0x1B).ToString() + "]" + Sequence.ReplaceAll(new[] { "<", ">" }, "") + Convert.ToChar(0x1B).ToString());
                            }
                            else
                            {
                                // No special suffixes needed
                                StrArrayWords[WordNumber] = StrArrayWords[WordNumber].Replace(Sequence, Convert.ToChar(0x1B).ToString() + "]" + Sequence.ReplaceAll(new[] { "<", ">" }, ""));
                            }
                        }
                        else
                        {
                            // These sequences need '[' as they are CSI sequences.
                            StrArrayWords[WordNumber] = StrArrayWords[WordNumber].Replace(Sequence, Convert.ToChar(0x1B).ToString() + "[" + Sequence.ReplaceAll(new[] { "<", ">" }, ""));
                        }
                    }

                    // Check if there are any more sequences.
                    if (StrArrayWords[WordNumber].ContainsAllOf(new[] { "<", ">" }))
                    {
                        goto ParseSequence;
                    }
                }
            }
            return string.Join(" ", StrArrayWords);
        }

        /// <summary>
        /// Converts from hexadecimal string representation of color to RGB values
        /// </summary>
        /// <param name="source">A string which has the specified text to replace</param>
        /// <param name="R">Red level to be filled</param>
        /// <param name="G">Green level to be filled</param>
        /// <param name="B">Blue level to be filled</param>
        public static void ConvertFromHexToRgb(this string source, ref int R, ref int G, ref int B)
        {
            if (source.StartsWith("#"))
            {
                // Get the color decimal number
                int ColorDecimal = Convert.ToInt32(source.RemoveLetter(0), 16);

                // Convert the RGB values to numbers
                R = (byte)((ColorDecimal & 0xFF0000) >> 0x10);
                G = (byte)((ColorDecimal & 0xFF00) >> 8);
                B = (byte)(ColorDecimal & 0xFF);
            }
        }

    }
}