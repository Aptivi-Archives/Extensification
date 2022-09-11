
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
using System.IO;
using Extensification.StreamReaderExts;
using NUnit.Framework;

namespace Extensification.Tests
{

    [TestFixture]
    public class StreamReaderTests
    {

        #region Reading
        /// <summary>
        /// Tests reading a line from the stream reader with the newline characters
        /// </summary>
        [Test]
        public void TestReadLineWithNewLine()
        {
            string TargetText = "Hello! This is Extensification." + Environment.NewLine + "You've reached the second line!";
            var TextStream = new MemoryStream(System.Text.Encoding.Default.GetBytes(TargetText));
            var TextStreamReader = new StreamReader(TextStream);
            string ParsedText = TextStreamReader.ReadLineWithNewLine();
            Assert.IsTrue(ParsedText.EndsWith(Environment.NewLine));
        }

        /// <summary>
        /// Tests reading lines
        /// </summary>
        [Test]
        public void TestReadLines()
        {
            string TargetText = "Hello! This is Extensification." + Environment.NewLine + "You've reached the second line!";
            var TextStream = new MemoryStream(System.Text.Encoding.Default.GetBytes(TargetText));
            var TextStreamReader = new StreamReader(TextStream);
            var ParsedText = TextStreamReader.ReadLines();
            Assert.IsTrue(ParsedText.Length == 2);
        }

        /// <summary>
        /// Tests reading to end and seeking
        /// </summary>
        [Test]
        public void TestReadToEndAndSeek()
        {
            string TargetText = "Hello! This is Extensification.";
            var TextStream = new MemoryStream(System.Text.Encoding.Default.GetBytes(TargetText));
            var TextStreamReader = new StreamReader(TextStream);
            string ParsedText = TextStreamReader.ReadToEndAndSeek();
            Assert.IsTrue(TextStreamReader.BaseStream.Position == 0L);
        }
        #endregion

    }
}