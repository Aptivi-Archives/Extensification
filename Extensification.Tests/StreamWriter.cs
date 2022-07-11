
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

using System.IO;
using Extensification.StreamReaderExts;
using Extensification.StreamWriterExts;
using NUnit.Framework;

namespace Extensification.Tests
{

    [TestFixture]
    public class StreamWriterTests
    {

        #region Writing
        /// <summary>
    /// Tests reading lines
    /// </summary>
        [Test]
        public void TestWriteLines()
        {
            var NewTexts = new[] { "One, two", "three, four" };
            var TextStream = new MemoryStream();
            var TextStreamWriter = new StreamWriter(TextStream);
            Writing.WriteLines(ref TextStreamWriter, NewTexts);
            var TextStreamReader = new StreamReader(TextStreamWriter.BaseStream);
            Assert.IsTrue(TextStreamReader.ReadLines().Length == 2);
        }
        /// <summary>
    /// Tests reading lines
    /// </summary>
        [Test]
        public void TestWriteLineAndSeek()
        {
            string NewText = "One, two";
            var TextStream = new MemoryStream();
            var TextStreamWriter = new StreamWriter(TextStream);
            Writing.WriteLineAndSeek(ref TextStreamWriter, NewText);
            var TextStreamReader = new StreamReader(TextStreamWriter.BaseStream);
            Assert.IsTrue(TextStreamReader.ReadLine().Length == NewText.Length);
        }
        #endregion

    }
}