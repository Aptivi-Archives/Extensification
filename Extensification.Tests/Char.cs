using System;
using System.Collections.Generic;
using Extensification.CharExts;

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

using NUnit.Framework;

namespace Extensification.Tests
{

    [TestFixture]
    public class CharTests
    {

        #region Manipulation
        /// <summary>
    /// Tests character incrementation
    /// </summary>
        [Test]
        public void TestIncrement()
        {
            char Target = 'A';
            Target = Target.Increment(4);
            Assert.AreEqual('E', Target);
        }

        /// <summary>
    /// Tests character decrementation
    /// </summary>
        [Test]
        public void TestDecrement()
        {
            char Target = 'E';
            Target = Target.Decrement(4);
            Assert.AreEqual('A', Target);
        }
        #endregion

        #region Querying
        /// <summary>
    /// Tests character ASCII code fetching
    /// </summary>
        [Test]
        public void TestGetAsciiCode()
        {
            char Target = 'E';
            Assert.AreEqual(69, Target.GetAsciiCode());
        }

        /// <summary>
    /// Tests converting character to console key info
    /// </summary>
        [Test]
        public void TestToConsoleKeyInfo()
        {
            var ExpectedKeyInfo = new ConsoleKeyInfo('E', ConsoleKey.E, false, false, false);
            var ActualConsoleKeyInfo = 'E'.ToConsoleKeyInfo();
            Assert.IsTrue(ExpectedKeyInfo.Equals(ActualConsoleKeyInfo));
        }

        /// <summary>
    /// Tests converting character to console key info with custom handler
    /// </summary>
        [Test]
        public void TestToConsoleKeyInfoWithCustomHandler()
        {
            var CustomHandler = new Dictionary<char, Tuple<ConsoleKey, ConsoleModifiers>>() { { Convert.ToChar(10), Tuple.Create(ConsoleKey.Enter, ConsoleModifiers.Control) } };
            var ExpectedKeyInfo = new ConsoleKeyInfo(Convert.ToChar(10), ConsoleKey.Enter, false, false, true);
            var ActualConsoleKeyInfo = Convert.ToChar(10).ToConsoleKeyInfo(CustomHandler);
            Assert.IsTrue(ExpectedKeyInfo.Equals(ActualConsoleKeyInfo));
        }
        #endregion

    }
}