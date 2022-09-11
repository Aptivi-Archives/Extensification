
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
using Extensification.IntegerExts;
using NUnit.Framework;

namespace Extensification.Tests
{

    [TestFixture]
    public class IntegerTests
    {

        #region Manipulation
        /// <summary>
        /// Tests integer incrementation
        /// </summary>
        [Test]
        public void TestIncrement()
        {
            int ExpectedInteger = 5;
            int TargetInteger = 3;
            TargetInteger = TargetInteger.Increment(2);
            Assert.AreEqual(ExpectedInteger, TargetInteger);
        }

        /// <summary>
        /// Tests unsigned integer incrementation
        /// </summary>
        [Test]
        public void TestIncrementUnsigned()
        {
            uint ExpectedUInteger = 5U;
            uint TargetUInteger = 3U;
            TargetUInteger = TargetUInteger.Increment(2U);
            Assert.AreEqual(ExpectedUInteger, TargetUInteger);
        }

        /// <summary>
        /// Tests integer decrementation
        /// </summary>
        [Test]
        public void TestDecrement()
        {
            int ExpectedInteger = 3;
            int TargetInteger = 5;
            TargetInteger = TargetInteger.Decrement(2);
            Assert.AreEqual(ExpectedInteger, TargetInteger);
        }

        /// <summary>
        /// Tests unsigned integer decrementation
        /// </summary>
        [Test]
        public void TestDecrementUnsigned()
        {
            uint ExpectedUInteger = 3U;
            uint TargetUInteger = 5U;
            TargetUInteger = TargetUInteger.Decrement(2U);
            Assert.AreEqual(ExpectedUInteger, TargetUInteger);
        }

        /// <summary>
        /// Tests byte swap
        /// </summary>
        [Test]
        public void TestSwap()
        {
            int ExpectedFirstByte = 9;
            int ExpectedSecondByte = 8;
            int TargetFirstByte = 8;
            int TargetSecondByte = 9;
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
            uint ExpectedFirstByte = 9U;
            uint ExpectedSecondByte = 8U;
            uint TargetFirstByte = 8U;
            uint TargetSecondByte = 9U;
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
            int ExpectedFirstByte = 8;
            int ExpectedSecondByte = 10;
            int TargetFirstByte = 10;
            int TargetSecondByte = 8;
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
            uint ExpectedFirstByte = 8U;
            uint ExpectedSecondByte = 10U;
            uint TargetFirstByte = 10U;
            uint TargetSecondByte = 8U;
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
            int ExpectedFirstByte = 10;
            int ExpectedSecondByte = 8;
            int TargetFirstByte = 8;
            int TargetSecondByte = 10;
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
            uint ExpectedFirstByte = 10U;
            uint ExpectedSecondByte = 8U;
            uint TargetFirstByte = 8U;
            uint TargetSecondByte = 10U;
            TargetFirstByte.SwapIfTargetLarger(ref TargetSecondByte);
            Assert.AreEqual(ExpectedFirstByte, TargetFirstByte);
            Assert.AreEqual(ExpectedSecondByte, TargetSecondByte);
        }
        #endregion

        #region Querying
        /// <summary>
        /// Tests integer digit listing
        /// </summary>
        [Test]
        public void TestListDigits()
        {
            var ExpectedDigits = new int[] { 7, 5 };
            int TargetNumber = 75;
            Assert.IsTrue(ExpectedDigits.SequenceEqual(TargetNumber.ListDigits()));
        }

        /// <summary>
        /// Tests unsigned integer digit listing
        /// </summary>
        [Test]
        public void TestListDigitsUnsigned()
        {
            var ExpectedDigits = new uint[] { 7U, 5U };
            uint TargetNumber = 75U;
            Assert.IsTrue(ExpectedDigits.SequenceEqual(TargetNumber.ListDigits()));
        }

        /// <summary>
        /// Tests integer Armstrong number detection
        /// </summary>
        [Test]
        public void TestIsArmstrong()
        {
            int TargetNumber = 153;
            Assert.IsTrue(TargetNumber.IsArmstrong());
        }

        /// <summary>
        /// Tests unsigned integer Armstrong number detection
        /// </summary>
        [Test]
        public void TestIsArmstrongUnsigned()
        {
            uint TargetNumber = 153U;
            Assert.IsTrue(TargetNumber.IsArmstrong());
        }
        #endregion

    }
}