﻿
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

using System.IO;

namespace Extensification.StreamWriterExts
{
    /// <summary>
    /// Provides writing extenstions to <see cref="StreamWriter"/>
    /// </summary>
    public static class Writing
    {

        /// <summary>
        /// Writes all the lines to the stream and seeks to the beginning, if possible.
        /// </summary>
        /// <param name="writer">The stream writer</param>
        /// <param name="Lines">Lines to write</param>
        public static void WriteLines(this StreamWriter writer, string[] Lines)
        {
            foreach (string Line in Lines)
            {
                writer.WriteLine(Line);
                if (!writer.AutoFlush)
                    writer.Flush();
            }
            if (writer.BaseStream.CanSeek)
                writer.BaseStream.Seek(0L, SeekOrigin.Begin);
        }

        /// <summary>
        /// Writes the line to the stream and seeks to the beginning, if possible.
        /// </summary>
        /// <param name="writer">The stream writer</param>
        /// <param name="Line">Line to write</param>
        public static void WriteLineAndSeek(this StreamWriter writer, string Line)
        {
            writer.WriteLine(Line);
            if (!writer.AutoFlush)
                writer.Flush();
            if (writer.BaseStream.CanSeek)
                writer.BaseStream.Seek(0L, SeekOrigin.Begin);
        }

    }
}