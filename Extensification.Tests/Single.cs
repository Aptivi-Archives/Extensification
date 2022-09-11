
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
using Extensification.SingleExts;
using NUnit.Framework;

namespace Extensification.Tests
{

    [TestFixture]
    public class SingleTests
    {

        #region Manipulation
        /// <summary>
        /// Tests Single-precision number incrementation
        /// </summary>
        [Test]
        public void TestIncrement()
        {
            float ExpectedSingle = 5f;
            float TargetSingle = 3f;
            TargetSingle = TargetSingle.Increment(2f);
            Assert.AreEqual(ExpectedSingle, TargetSingle);
        }

        /// <summary>
        /// Tests Single-precision number decrementation
        /// </summary>
        [Test]
        public void TestDecrement()
        {
            float ExpectedSingle = 3f;
            float TargetSingle = 5f;
            TargetSingle = TargetSingle.Decrement(2f);
            Assert.AreEqual(ExpectedSingle, TargetSingle);
        }

        /// <summary>
        /// Tests byte swap
        /// </summary>
        [Test]
        public void TestSwap()
        {
            float ExpectedFirstByte = 9f;
            float ExpectedSecondByte = 8f;
            float TargetFirstByte = 8f;
            float TargetSecondByte = 9f;
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
            float ExpectedFirstByte = 8f;
            float ExpectedSecondByte = 10f;
            float TargetFirstByte = 10f;
            float TargetSecondByte = 8f;
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
            float ExpectedFirstByte = 10f;
            float ExpectedSecondByte = 8f;
            float TargetFirstByte = 8f;
            float TargetSecondByte = 10f;
            TargetFirstByte.SwapIfTargetLarger(ref TargetSecondByte);
            Assert.AreEqual(ExpectedFirstByte, TargetFirstByte);
            Assert.AreEqual(ExpectedSecondByte, TargetSecondByte);
        }
        #endregion

        #region Querying
        /// <summary>
        /// Tests Single digit listing (before the decimal point)
        /// </summary>
        [Test]
        public void TestListDigitsBeforeDecimal()
        {
            var ExpectedDigits = new float[] { 3f, 2f };
            float TargetNumber = 32.9f;
            Assert.IsTrue(ExpectedDigits.SequenceEqual(TargetNumber.ListDigitsBeforeDecimal()));
        }

        /// <summary>
        /// Tests Single digit listing (after the decimal point)
        /// </summary>
        [Test]
        public void TestListDigitsAfterDecimal()
        {
            var ExpectedDigits = new float[] { 9f };
            float TargetNumber = 32.9f;
            Assert.IsTrue(ExpectedDigits.SequenceEqual(TargetNumber.ListDigitsAfterDecimal()));
        }

        /// <summary>
        /// Tests Single Armstrong number detection
        /// </summary>
        [Test]
        public void TestIsArmstrong()
        {
            float TargetNumber = 153.4f;
            Assert.IsTrue(TargetNumber.IsArmstrong());
        }
        #endregion

    }
}