
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
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Extensification.StreamReaderExts
{
    /// <summary>
    /// Provides reading extenstions to <see cref="StreamReader"/>
    /// </summary>
    public static class Reading
    {

        /// <summary>
        /// Reads a line from the stream with the newline characters
        /// </summary>
        /// <param name="reader">The stream reader</param>
        public static string ReadLineWithNewLine(this StreamReader reader)
        {
            // Define a new string builder
            var strBuilder = new StringBuilder();

            // Read files as character numbers and convert them to string
            while (!reader.EndOfStream)
            {
                int readFile = reader.Read();
                strBuilder.Append(Convert.ToChar(readFile));
                if (readFile == 10)
                {
                    break;
                }
            }

            // Return the final result
            return strBuilder.ToString();
        }

        /// <summary>
        /// Reads all the lines and returns the string array
        /// </summary>
        /// <param name="reader">The stream reader</param>
        public static string[] ReadLines(this StreamReader reader)
        {
            var StreamLines = new List<string>();

            // Read the lines while not end of stream
            while (!reader.EndOfStream)
                StreamLines.Add(reader.ReadLine());

            // Return the final result
            return StreamLines.ToArray();
        }

        /// <summary>
        /// Reads all the characters in the stream until the end and seeks the stream to the beginning, if possible.
        /// </summary>
        /// <param name="reader">The stream reader</param>
        public static string ReadToEndAndSeek(this StreamReader reader)
        {
            string StreamString = reader.ReadToEnd();
            if (reader.BaseStream.CanSeek)
                reader.BaseStream.Seek(0L, SeekOrigin.Begin);
            return StreamString;
        }

    }
}