
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

using Extensification.Legacy.StringExts;
using NUnit.Framework;

namespace Extensification.Legacy.Tests.Extensification.Legacy.Tests
{

    [TestFixture]
    public class StringTests
    {
#if NET48
        /// <summary>
        /// Tests removing letters from a string
        /// </summary>
        [Test]
        public void TestEvaluate()
        {
            string TargetString = "2 + 5";
            int ExpectedEvaluated = 7;
            Assert.AreEqual(ExpectedEvaluated, TargetString.Evaluate());
        }
#endif
    }

}