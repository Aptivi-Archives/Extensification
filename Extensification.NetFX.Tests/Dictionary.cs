
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

using System.Collections.Generic;
using Extensification.NetFX.DictionaryExts;
using NUnit.Framework;

namespace Extensification.NetFX.Tests
{

    [TestFixture]
    public class DictionaryTests
    {

        #region Addition
        /// <summary>
        /// Tests trying to add an entry to dictionary
        /// </summary>
        [Test]
        public static void TestTryAdd()
            {
            Dictionary<string, int> TargetDict = new();
            Assert.IsTrue(TargetDict.TryAdd("Document number", 12));
            Assert.IsFalse(TargetDict.TryAdd("Document number", 13));
        }
        #endregion

    }
}