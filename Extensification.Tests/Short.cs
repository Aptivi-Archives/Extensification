
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
using Extensification.ShortExts;
using NUnit.Framework;

namespace Extensification.Tests
{

    [TestFixture]
    public class ShortTests
    {

        #region Manipulation
        /// <summary>
    /// Tests short integer incrementation
    /// </summary>
        [Test]
        public void TestIncrement()
        {
            short ExpectedShort = 5;
            short TargetShort = 3;
            TargetShort = TargetShort.Increment(2);
            Assert.AreEqual(ExpectedShort, TargetShort);
        }

        /// <summary>
    /// Tests unsigned short integer incrementation
    /// </summary>
        [Test]
        public void TestIncrementUnsigned()
        {
            ushort ExpectedUShort = 5;
            ushort TargetUShort = 3;
            TargetUShort = TargetUShort.Increment(2);
            Assert.AreEqual(ExpectedUShort, TargetUShort);
        }

        /// <summary>
    /// Tests short integer decrementation
    /// </summary>
        [Test]
        public void TestDecrement()
        {
            short ExpectedShort = 3;
            short TargetShort = 5;
            TargetShort = TargetShort.Decrement(2);
            Assert.AreEqual(ExpectedShort, TargetShort);
        }

        /// <summary>
    /// Tests unsigned short integer decrementation
    /// </summary>
        [Test]
        public void TestDecrementUnsigned()
        {
            ushort ExpectedUShort = 3;
            ushort TargetUShort = 5;
            TargetUShort = TargetUShort.Decrement(2);
            Assert.AreEqual(ExpectedUShort, TargetUShort);
        }

        /// <summary>
    /// Tests byte swap
    /// </summary>
        [Test]
        public void TestSwap()
        {
            short ExpectedFirstByte = 9;
            short ExpectedSecondByte = 8;
            short TargetFirstByte = 8;
            short TargetSecondByte = 9;
            TargetFirstByte.Swap(ref TargetSecondByte);
            Assert.AreEqual(ExpectedFirstByte, TargetFirstByte);
            Assert.AreEqual(ExpectedSecondByte, TargetSecondByte);
        }

        /// <summary>
    /// Tests signed byte swap
    /// </summary>
        [Test]
        public void TestSwapSigned()
        {
            ushort ExpectedFirstByte = 9;
            ushort ExpectedSecondByte = 8;
            ushort TargetFirstByte = 8;
            ushort TargetSecondByte = 9;
            TargetFirstByte.Swap(ref TargetSecondByte);
            Assert.AreEqual(ExpectedFirstByte, TargetFirstByte);
            Assert.AreEqual(ExpectedSecondByte, TargetSecondByte);
        }

        /// <summary>
    /// Tests byte swap if source is larger
    /// </summary>
        [Test]
        public void TestSwapIfSourceLarger()
        {
            short ExpectedFirstByte = 8;
            short ExpectedSecondByte = 10;
            short TargetFirstByte = 10;
            short TargetSecondByte = 8;
            TargetFirstByte.SwapIfSourceLarger(ref TargetSecondByte);
            Assert.AreEqual(ExpectedFirstByte, TargetFirstByte);
            Assert.AreEqual(ExpectedSecondByte, TargetSecondByte);
        }

        /// <summary>
    /// Tests signed byte swap if source is larger
    /// </summary>
        [Test]
        public void TestSwapIfSourceLargerSigned()
        {
            ushort ExpectedFirstByte = 8;
            ushort ExpectedSecondByte = 10;
            ushort TargetFirstByte = 10;
            ushort TargetSecondByte = 8;
            TargetFirstByte.SwapIfSourceLarger(ref TargetSecondByte);
            Assert.AreEqual(ExpectedFirstByte, TargetFirstByte);
            Assert.AreEqual(ExpectedSecondByte, TargetSecondByte);
        }

        /// <summary>
    /// Tests byte swap if target is larger
    /// </summary>
        [Test]
        public void TestSwapIfTargetLarger()
        {
            short ExpectedFirstByte = 10;
            short ExpectedSecondByte = 8;
            short TargetFirstByte = 8;
            short TargetSecondByte = 10;
            TargetFirstByte.SwapIfTargetLarger(ref TargetSecondByte);
            Assert.AreEqual(ExpectedFirstByte, TargetFirstByte);
            Assert.AreEqual(ExpectedSecondByte, TargetSecondByte);
        }

        /// <summary>
    /// Tests signed byte swap if target is larger
    /// </summary>
        [Test]
        public void TestSwapIfTargetLargerSigned()
        {
            ushort ExpectedFirstByte = 10;
            ushort ExpectedSecondByte = 8;
            ushort TargetFirstByte = 8;
            ushort TargetSecondByte = 10;
            TargetFirstByte.SwapIfTargetLarger(ref TargetSecondByte);
            Assert.AreEqual(ExpectedFirstByte, TargetFirstByte);
            Assert.AreEqual(ExpectedSecondByte, TargetSecondByte);
        }
        #endregion

        #region Querying
        /// <summary>
    /// Tests short integer digit listing
    /// </summary>
        [Test]
        public void TestListDigits()
        {
            var ExpectedDigits = new short[] { 7, 5 };
            short TargetNumber = 75;
            Assert.IsTrue(ExpectedDigits.SequenceEqual(TargetNumber.ListDigits()));
        }

        /// <summary>
    /// Tests unsigned short integer digit listing
    /// </summary>
        [Test]
        public void TestListDigitsUnsigned()
        {
            var ExpectedDigits = new ushort[] { 7, 5 };
            ushort TargetNumber = 75;
            Assert.IsTrue(ExpectedDigits.SequenceEqual(TargetNumber.ListDigits()));
        }

        /// <summary>
    /// Tests short integer Armstrong number detection
    /// </summary>
        [Test]
        public void TestIsArmstrong()
        {
            short TargetNumber = 153;
            Assert.IsTrue(TargetNumber.IsArmstrong());
        }

        /// <summary>
    /// Tests unsigned short integer Armstrong number detection
    /// </summary>
        [Test]
        public void TestIsArmstrongUnsigned()
        {
            ushort TargetNumber = 153;
            Assert.IsTrue(TargetNumber.IsArmstrong());
        }
        #endregion

    }
}