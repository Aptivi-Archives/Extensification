
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
using Extensification.StreamExts;
using NUnit.Framework;

namespace Extensification.Tests
{

    [TestFixture]
    public class StreamTests
    {

        #region Manipulation
        /// <summary>
        /// Tests trying to seek in a stream
        /// </summary>
        [Test]
        public void TestTrySeek()
        {
            string TargetText = "Hello! This is Extensification." + Environment.NewLine + "You've reached the second line!";
            var TextStream = new MemoryStream(System.Text.Encoding.Default.GetBytes(TargetText));
            Assert.IsTrue(TextStream.TrySeek(4L, SeekOrigin.Begin));
            Assert.IsTrue(TextStream.Position == 4L);
        }

        /// <summary>
        /// Tests trying to seek in a stream
        /// </summary>
        [Test]
        public void TestTrySetLength()
        {
            var TextStream = new MemoryStream(8);
            Assert.IsTrue(TextStream.TrySetLength(16L));
            Assert.IsTrue(TextStream.Length == 16L);
        }

        /// <summary>
        /// Tests trying to flush a stream
        /// </summary>
        [Test]
        public void TestTryFlush()
        {
            var TextStream = new MemoryStream(8);
            TextStream.Write(System.Text.Encoding.Default.GetBytes("Hello!!!"), 0, 8);
            Assert.IsTrue(TextStream.TryFlush());
        }

        /// <summary>
        /// Tests trying to get buffer from a stream
        /// </summary>
        [Test]
        public void TestTryGetBuffer()
        {
            var TextStream = new MemoryStream(8);
            var TextStreamArray = new ArraySegment<byte>();
            TextStream.Write(System.Text.Encoding.Default.GetBytes("Hello!!!"), 0, 8);
            TextStream.Seek(0L, SeekOrigin.Begin);
            Assert.IsTrue(TextStream.TryGetBuffer(out TextStreamArray));
            Assert.IsTrue(TextStreamArray.Count == 8);
        }
        #endregion
        #region Reading
        /// <summary>
        /// Tests trying to read from a stream
        /// </summary>
        [Test]
        public void TestTryRead()
        {
            string TargetText = "Hello! This is Extensification." + Environment.NewLine + "You've reached the second line!";
            var TextStream = new MemoryStream(System.Text.Encoding.Default.GetBytes(TargetText));
            var ArrayBuffer = new byte[9];
            Assert.IsTrue(TextStream.TryRead(ArrayBuffer, 0, 8));
        }

        /// <summary>
        /// Tests reading and seeking
        /// </summary>
        [Test]
        public void TestReadAndSeek()
        {
            string TargetText = "Hello! This is Extensification." + Environment.NewLine + "You've reached the second line!";
            var TextStream = new MemoryStream(System.Text.Encoding.Default.GetBytes(TargetText));
            var ArrayBuffer = new byte[9];
            TextStream.ReadAndSeek(ArrayBuffer, 0, 8);
            Assert.IsTrue(TextStream.Position == 0L);
        }

        /// <summary>
        /// Tests trying to read a byte from a stream
        /// </summary>
        [Test]
        public void TestTryReadByte()
        {
            string TargetText = "Hello!";
            var TextStream = new MemoryStream(System.Text.Encoding.Default.GetBytes(TargetText));
            int ActualByte = TextStream.TryReadByte();
            Assert.AreEqual(72, ActualByte);
        }
        #endregion
        #region Writing
        /// <summary>
        /// Tests trying to write to a stream
        /// </summary>
        [Test]
        public void TestTryWrite()
        {
            string TargetText = "Hello! This is Extensification." + Environment.NewLine + "You've reached the second line!";
            var TextStream = new MemoryStream(System.Text.Encoding.Default.GetBytes(TargetText + "    "));
            var ArrayBuffer = new byte[] { 1, 2, 3, 4 };
            TextStream.Seek(-4, SeekOrigin.End);
            Assert.IsTrue(TextStream.TryWrite(ArrayBuffer, 0, 4));
        }

        /// <summary>
        /// Tests writing and seeking
        /// </summary>
        [Test]
        public void TestWriteAndSeek()
        {
            string TargetText = "Hello! This is Extensification." + Environment.NewLine + "You've reached the second line!";
            var TextStream = new MemoryStream(System.Text.Encoding.Default.GetBytes(TargetText));
            var ArrayBuffer = new byte[9];
            TextStream.WriteAndSeek(ArrayBuffer, 0, 8);
            Assert.IsTrue(TextStream.Position == 0L);
        }

        /// <summary>
        /// Tests trying to write a byte to a stream
        /// </summary>
        [Test]
        public void TestTryWriteByte()
        {
            string TargetText = "Hello";
            var TextStream = new MemoryStream(System.Text.Encoding.Default.GetBytes(TargetText + " "));
            TextStream.Seek(-1, SeekOrigin.End);
            Assert.IsTrue(TextStream.TryWriteByte(System.Text.Encoding.Default.GetBytes(new[] { '!' })[0]));
        }
        #endregion

    }
}