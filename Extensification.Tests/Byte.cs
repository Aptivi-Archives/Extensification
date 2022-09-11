
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
using Extensification.ByteExts;
using NUnit.Framework;

namespace Extensification.Tests
{

    [TestFixture]
    public class ByteTests
    {

        #region Manipulation
        /// <summary>
        /// Tests byte incrementation
        /// </summary>
        [Test]
        public void TestIncrement()
        {
            byte ExpectedByte = 5;
            byte TargetByte = 3;
            TargetByte = TargetByte.Increment(2);
            Assert.AreEqual(ExpectedByte, TargetByte);
        }

        /// <summary>
        /// Tests signed byte incrementation
        /// </summary>
        [Test]
        public void TestIncrementSigned()
        {
            sbyte ExpectedByte = 5;
            sbyte TargetByte = 3;
            TargetByte = TargetByte.Increment(2);
            Assert.AreEqual(ExpectedByte, TargetByte);
        }

        /// <summary>
        /// Tests byte decrementation
        /// </summary>
        [Test]
        public void TestDecrement()
        {
            byte ExpectedByte = 3;
            byte TargetByte = 5;
            TargetByte = TargetByte.Decrement(2);
            Assert.AreEqual(ExpectedByte, TargetByte);
        }

        /// <summary>
        /// Tests signed byte decrementation
        /// </summary>
        [Test]
        public void TestDecrementSigned()
        {
            sbyte ExpectedByte = 3;
            sbyte TargetByte = 5;
            TargetByte = TargetByte.Decrement(2);
            Assert.AreEqual(ExpectedByte, TargetByte);
        }

        /// <summary>
        /// Tests byte swap
        /// </summary>
        [Test]
        public void TestSwap()
        {
            byte ExpectedFirstByte = 9;
            byte ExpectedSecondByte = 8;
            byte TargetFirstByte = 8;
            byte TargetSecondByte = 9;
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
            sbyte ExpectedFirstByte = 9;
            sbyte ExpectedSecondByte = 8;
            sbyte TargetFirstByte = 8;
            sbyte TargetSecondByte = 9;
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
            byte ExpectedFirstByte = 8;
            byte ExpectedSecondByte = 10;
            byte TargetFirstByte = 10;
            byte TargetSecondByte = 8;
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
            sbyte ExpectedFirstByte = 8;
            sbyte ExpectedSecondByte = 10;
            sbyte TargetFirstByte = 10;
            sbyte TargetSecondByte = 8;
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
            byte ExpectedFirstByte = 10;
            byte ExpectedSecondByte = 8;
            byte TargetFirstByte = 8;
            byte TargetSecondByte = 10;
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
            sbyte ExpectedFirstByte = 10;
            sbyte ExpectedSecondByte = 8;
            sbyte TargetFirstByte = 8;
            sbyte TargetSecondByte = 10;
            TargetFirstByte.SwapIfTargetLarger(ref TargetSecondByte);
            Assert.AreEqual(ExpectedFirstByte, TargetFirstByte);
            Assert.AreEqual(ExpectedSecondByte, TargetSecondByte);
        }
        #endregion

        #region Querying
        /// <summary>
        /// Tests byte digit listing
        /// </summary>
        [Test]
        public void TestListDigits()
        {
            var ExpectedDigits = new byte[] { 7, 5 };
            byte TargetNumber = 75;
            Assert.IsTrue(ExpectedDigits.SequenceEqual(TargetNumber.ListDigits()));
        }

        /// <summary>
        /// Tests signed byte digit listing
        /// </summary>
        [Test]
        public void TestListDigitsSigned()
        {
            var ExpectedDigits = new sbyte[] { 7, 5 };
            sbyte TargetNumber = 75;
            Assert.IsTrue(ExpectedDigits.SequenceEqual(TargetNumber.ListDigits()));
        }

        /// <summary>
        /// Tests byte Armstrong number detection
        /// </summary>
        [Test]
        public void TestIsArmstrong()
        {
            byte TargetNumber = 153;
            Assert.IsTrue(TargetNumber.IsArmstrong());
        }

        /// <summary>
        /// Tests signed byte Armstrong number detection
        /// </summary>
        [Test]
        public void TestIsArmstrongSigned()
        {
            sbyte TargetNumber = 1;
            Assert.IsTrue(TargetNumber.IsArmstrong());
        }
        #endregion

    }
}