
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
using Extensification.LongExts;
using NUnit.Framework;

namespace Extensification.Tests
{

    [TestFixture]
    public class LongTests
    {

        #region Manipulation
        /// <summary>
        /// Tests long integer incrementation
        /// </summary>
        [Test]
        public void TestIncrement()
        {
            long ExpectedLong = 5L;
            long TargetLong = 3L;
            TargetLong = TargetLong.Increment(2L);
            Assert.AreEqual(ExpectedLong, TargetLong);
        }

        /// <summary>
        /// Tests unsigned long integer incrementation
        /// </summary>
        [Test]
        public void TestIncrementUnsigned()
        {
            ulong ExpectedULong = 5UL;
            ulong TargetULong = 3UL;
            TargetULong = TargetULong.Increment(2UL);
            Assert.AreEqual(ExpectedULong, TargetULong);
        }

        /// <summary>
        /// Tests long integer decrementation
        /// </summary>
        [Test]
        public void TestDecrement()
        {
            long ExpectedLong = 3L;
            long TargetLong = 5L;
            TargetLong = TargetLong.Decrement(2L);
            Assert.AreEqual(ExpectedLong, TargetLong);
        }

        /// <summary>
        /// Tests unsigned long integer decrementation
        /// </summary>
        [Test]
        public void TestDecrementUnsigned()
        {
            ulong ExpectedULong = 3UL;
            ulong TargetULong = 5UL;
            TargetULong = TargetULong.Decrement(2UL);
            Assert.AreEqual(ExpectedULong, TargetULong);
        }

        /// <summary>
        /// Tests byte swap
        /// </summary>
        [Test]
        public void TestSwap()
        {
            long ExpectedFirstByte = 9L;
            long ExpectedSecondByte = 8L;
            long TargetFirstByte = 8L;
            long TargetSecondByte = 9L;
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
            ulong ExpectedFirstByte = 9UL;
            ulong ExpectedSecondByte = 8UL;
            ulong TargetFirstByte = 8UL;
            ulong TargetSecondByte = 9UL;
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
            long ExpectedFirstByte = 8L;
            long ExpectedSecondByte = 10L;
            long TargetFirstByte = 10L;
            long TargetSecondByte = 8L;
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
            ulong ExpectedFirstByte = 8UL;
            ulong ExpectedSecondByte = 10UL;
            ulong TargetFirstByte = 10UL;
            ulong TargetSecondByte = 8UL;
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
            long ExpectedFirstByte = 10L;
            long ExpectedSecondByte = 8L;
            long TargetFirstByte = 8L;
            long TargetSecondByte = 10L;
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
            ulong ExpectedFirstByte = 10UL;
            ulong ExpectedSecondByte = 8UL;
            ulong TargetFirstByte = 8UL;
            ulong TargetSecondByte = 10UL;
            TargetFirstByte.SwapIfTargetLarger(ref TargetSecondByte);
            Assert.AreEqual(ExpectedFirstByte, TargetFirstByte);
            Assert.AreEqual(ExpectedSecondByte, TargetSecondByte);
        }
        #endregion

        #region Conversion
        /// <summary>
        /// Tests converting data size to human readable
        /// </summary>
        [Test]
        public void TestDataToHumanReadable()
        {
            string Expected = "4.2 MB";
            long Number = 4200000L;
            Assert.AreEqual(Expected, Number.ToHumanReadable(HumanFormats.DataSize));
        }

        /// <summary>
        /// Tests converting metric measurement without unusual measurements to human readable
        /// </summary>
        [Test]
        public void TestMetricMeasurementToHumanReadable()
        {
            string Expected = "12.5 centimeters";
            long Number = 125L;
            Assert.AreEqual(Expected, Number.ToHumanReadable(HumanFormats.MeasurementsMetric));
        }

        /// <summary>
        /// Tests converting metric measurement with unusual measurements to human readable
        /// </summary>
        [Test]
        public void TestMetricMeasurementUnusualToHumanReadable()
        {
            string Expected = "1.25 decimeters";
            long Number = 125L;
            Assert.AreEqual(Expected, Number.ToHumanReadable(HumanFormats.MeasurementsMetricUnusual));
        }

        /// <summary>
        /// Tests converting imperial measurement to human readable
        /// </summary>
        [Test]
        public void TestImperialMeasurementToHumanReadable()
        {
            string Expected = "1.10479797979798 miles";
            long Number = 70000L;
            Assert.AreEqual(Expected, Number.ToHumanReadable(HumanFormats.MeasurementsImperial));
        }

        /// <summary>
        /// Tests converting metric volume measurement to human readable
        /// </summary>
        [Test]
        public void TestMetricVolumeToHumanReadable()
        {
            string Expected = "2.5 liters";
            long Number = 2500L;
            Assert.AreEqual(Expected, Number.ToHumanReadable(HumanFormats.VolumeMetric));
        }

        /// <summary>
        /// Tests converting metric volume measurement to human readable
        /// </summary>
        [Test]
        public void TestImperialVolumeToHumanReadable()
        {
            string Expected = "2 quarts";
            long Number = 4L;
            Assert.AreEqual(Expected, Number.ToHumanReadable(HumanFormats.VolumeImperial));
        }

        /// <summary>
        /// Tests converting data size to human readable (Unsigned long)
        /// </summary>
        [Test]
        public void TestDataToHumanReadableUnsigned()
        {
            string Expected = "4.2 MB";
            ulong Number = 4200000UL;
            Assert.AreEqual(Expected, Number.ToHumanReadable(HumanFormats.DataSize));
        }

        /// <summary>
        /// Tests converting metric measurement without unusual measurements to human readable (Unsigned long)
        /// </summary>
        [Test]
        public void TestMetricMeasurementToHumanReadableUnsigned()
        {
            string Expected = "12.5 centimeters";
            ulong Number = 125UL;
            Assert.AreEqual(Expected, Number.ToHumanReadable(HumanFormats.MeasurementsMetric));
        }

        /// <summary>
        /// Tests converting metric measurement with unusual measurements to human readable (Unsigned long)
        /// </summary>
        [Test]
        public void TestMetricMeasurementUnusualToHumanReadableUnsigned()
        {
            string Expected = "1.25 decimeters";
            ulong Number = 125UL;
            Assert.AreEqual(Expected, Number.ToHumanReadable(HumanFormats.MeasurementsMetricUnusual));
        }

        /// <summary>
        /// Tests converting imperial measurement to human readable (Unsigned long)
        /// </summary>
        [Test]
        public void TestImperialMeasurementToHumanReadableUnsigned()
        {
            string Expected = "1.10479797979798 miles";
            ulong Number = 70000UL;
            Assert.AreEqual(Expected, Number.ToHumanReadable(HumanFormats.MeasurementsImperial));
        }

        /// <summary>
        /// Tests converting metric volume measurement to human readable (Unsigned long)
        /// </summary>
        [Test]
        public void TestMetricVolumeToHumanReadableUnsigned()
        {
            string Expected = "2.5 liters";
            ulong Number = 2500UL;
            Assert.AreEqual(Expected, Number.ToHumanReadable(HumanFormats.VolumeMetric));
        }

        /// <summary>
        /// Tests converting metric volume measurement to human readable (Unsigned long)
        /// </summary>
        [Test]
        public void TestImperialVolumeToHumanReadableUnsigned()
        {
            string Expected = "2 quarts";
            ulong Number = 4UL;
            Assert.AreEqual(Expected, Number.ToHumanReadable(HumanFormats.VolumeImperial));
        }
        #endregion

        #region Querying
        /// <summary>
        /// Tests long integer digit listing
        /// </summary>
        [Test]
        public void TestListDigits()
        {
            var ExpectedDigits = new long[] { 7L, 5L };
            long TargetNumber = 75L;
            Assert.IsTrue(ExpectedDigits.SequenceEqual(TargetNumber.ListDigits()));
        }

        /// <summary>
        /// Tests unsigned long integer digit listing
        /// </summary>
        [Test]
        public void TestListDigitsUnsigned()
        {
            var ExpectedDigits = new ulong[] { 7UL, 5UL };
            ulong TargetNumber = 75UL;
            Assert.IsTrue(ExpectedDigits.SequenceEqual(TargetNumber.ListDigits()));
        }

        /// <summary>
        /// Tests long integer Armstrong number detection
        /// </summary>
        [Test]
        public void TestIsArmstrong()
        {
            long TargetNumber = 153L;
            Assert.IsTrue(TargetNumber.IsArmstrong());
        }

        /// <summary>
        /// Tests unsigned long integer Armstrong number detection
        /// </summary>
        [Test]
        public void TestIsArmstrongUnsigned()
        {
            ulong TargetNumber = 153UL;
            Assert.IsTrue(TargetNumber.IsArmstrong());
        }
        #endregion

    }
}