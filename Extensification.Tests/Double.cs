
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
using Extensification.DoubleExts;
using NUnit.Framework;

namespace Extensification.Tests
{

    [TestFixture]
    public class DoubleTests
    {

        #region Manipulation
        /// <summary>
        /// Tests double-precision number incrementation
        /// </summary>
        [Test]
        public void TestIncrement()
        {
            double ExpectedDouble = 5d;
            double TargetDouble = 3d;
            TargetDouble = TargetDouble.Increment(2d);
            Assert.AreEqual(ExpectedDouble, TargetDouble);
        }

        /// <summary>
        /// Tests double-precision number decrementation
        /// </summary>
        [Test]
        public void TestDecrement()
        {
            double ExpectedDouble = 3d;
            double TargetDouble = 5d;
            TargetDouble = TargetDouble.Decrement(2d);
            Assert.AreEqual(ExpectedDouble, TargetDouble);
        }

        /// <summary>
        /// Tests byte swap
        /// </summary>
        [Test]
        public void TestSwap()
        {
            double ExpectedFirstByte = 9d;
            double ExpectedSecondByte = 8d;
            double TargetFirstByte = 8d;
            double TargetSecondByte = 9d;
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
            double ExpectedFirstByte = 8d;
            double ExpectedSecondByte = 10d;
            double TargetFirstByte = 10d;
            double TargetSecondByte = 8d;
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
            double ExpectedFirstByte = 10d;
            double ExpectedSecondByte = 8d;
            double TargetFirstByte = 8d;
            double TargetSecondByte = 10d;
            TargetFirstByte.SwapIfTargetLarger(ref TargetSecondByte);
            Assert.AreEqual(ExpectedFirstByte, TargetFirstByte);
            Assert.AreEqual(ExpectedSecondByte, TargetSecondByte);
        }
        #endregion

        #region Querying
        /// <summary>
        /// Tests double digit listing (before the decimal point)
        /// </summary>
        [Test]
        public void TestListDigitsBeforeDecimal()
        {
            var ExpectedDigits = new double[] { 3d, 2d };
            double TargetNumber = 32.9d;
            Assert.IsTrue(ExpectedDigits.SequenceEqual(TargetNumber.ListDigitsBeforeDecimal()));
        }

        /// <summary>
        /// Tests double digit listing (after the decimal point)
        /// </summary>
        [Test]
        public void TestListDigitsAfterDecimal()
        {
            var ExpectedDigits = new double[] { 9d };
            double TargetNumber = 32.9d;
            Assert.IsTrue(ExpectedDigits.SequenceEqual(TargetNumber.ListDigitsAfterDecimal()));
        }

        /// <summary>
        /// Tests double Armstrong number detection
        /// </summary>
        [Test]
        public void TestIsArmstrong()
        {
            double TargetNumber = 153.4d;
            Assert.IsTrue(TargetNumber.IsArmstrong());
        }
        #endregion

    }
}