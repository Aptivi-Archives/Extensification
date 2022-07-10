using System;
using System.Collections;
using System.Linq;
using Extensification.ArrayListExts;

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
    public class ArrayListTests
    {

        #region Conversion
        /// <summary>
    /// Tests converting array list to list
    /// </summary>
        [Test]
        public void TestToArrayList()
        {
            var TargetArrayList = new ArrayList() { "Test converting", "target array list", "to list." };
            var TargetList = TargetArrayList.ToList();
            Assert.IsNotNull(TargetList);
            Assert.IsTrue(TargetList.Count > 0);
        }
        #endregion

        #region Counts
        /// <summary>
    /// Tests counting full entries
    /// </summary>
        [Test]
        public void TestCountFullEntries()
        {
            var TargetArray = new ArrayList() { "", "Full", "", "Entry", "" };
            var TargetArrayObjects = new ArrayList() { 4, null, null };
            Assert.AreEqual(2, TargetArray.CountFullEntries());
            Assert.AreEqual(1, TargetArrayObjects.CountFullEntries());
        }

        /// <summary>
    /// Tests counting empty entries
    /// </summary>
        [Test]
        public void TestCountEmptyEntries()
        {
            var TargetArray = new ArrayList() { "", "Full", "", "Entry", "" };
            var TargetArrayObjects = new ArrayList() { 4, null, null };
            Assert.AreEqual(3, TargetArray.CountEmptyEntries());
            Assert.AreEqual(2, TargetArrayObjects.CountEmptyEntries());
        }
        #endregion

        #region Getting
        /// <summary>
    /// Tests getting index from entry
    /// </summary>
        [Test]
        public void TestGetIndexOfEntry()
        {
            var TargetList = new ArrayList() { "Test getting", "index from", "array list entry." };
            int ExpectedIndex = 1;
            Assert.AreEqual(ExpectedIndex, TargetList.GetIndexOfEntry("index from")[0]);
        }

        /// <summary>
    /// Tests getting indexes of full entries
    /// </summary>
        [Test]
        public void TestGetIndexesOfFullEntries()
        {
            var TargetArray = new ArrayList() { "", "Full", "", "Entry", "" };
            var TargetArrayObjects = new ArrayList() { 4, null, null };
            var ExpectedIndexes = new int[] { 1, 3 };
            var ExpectedIndexesObjects = new int[] { 0 };
            Assert.IsNotNull(TargetArray.GetIndexesOfFullEntries());
            Assert.IsNotNull(TargetArrayObjects.GetIndexesOfFullEntries());
            Assert.IsTrue(TargetArray.GetIndexesOfFullEntries().SequenceEqual(ExpectedIndexes));
            Assert.IsTrue(TargetArrayObjects.GetIndexesOfFullEntries().SequenceEqual(ExpectedIndexesObjects));
        }

        /// <summary>
    /// Tests getting indexes of empty entries
    /// </summary>
        [Test]
        public void TestGetIndexesOfEmptyEntries()
        {
            var TargetArray = new ArrayList() { "", "Full", "", "Entry", "" };
            var TargetArrayObjects = new ArrayList() { 4, null, null };
            var ExpectedIndexes = new int[] { 0, 2, 4 };
            var ExpectedIndexesObjects = new int[] { 1, 2 };
            Assert.IsNotNull(TargetArray.GetIndexesOfEmptyEntries());
            Assert.IsNotNull(TargetArrayObjects.GetIndexesOfEmptyEntries());
            Assert.IsTrue(TargetArray.GetIndexesOfEmptyEntries().SequenceEqual(ExpectedIndexes));
            Assert.IsTrue(TargetArrayObjects.GetIndexesOfEmptyEntries().SequenceEqual(ExpectedIndexesObjects));
        }
        #endregion

        #region Querying
        /// <summary>
    /// Tests seeing if the array list contains any of the specified clauses
    /// </summary>
        [Test]
        public void TestContainsAnyOf()
        {
            var TargetArray = new ArrayList() { "Test", "Hello and Test", "Tester! Hello!" };
            Assert.IsTrue(TargetArray.ContainsAnyOf(new ArrayList() { "Hello and Test", "Test" }));
            Assert.IsFalse(TargetArray.ContainsAnyOf(new ArrayList() { "Goodbye", "Works" }));
        }

        /// <summary>
    /// Tests seeing if the array list contains all of the specified clauses
    /// </summary>
        [Test]
        public void TestContainsAllOf()
        {
            var TargetArray = new ArrayList() { "Test", "Hello and Test", "Tester! Hello!" };
            Assert.IsTrue(TargetArray.ContainsAllOf(new ArrayList() { "Hello and Test", "Test" }));
            Assert.IsFalse(TargetArray.ContainsAllOf(new ArrayList() { "Goodbye", "Works" }));
        }
        #endregion

        #region Removal
        /// <summary>
    /// Tests trying to remove an entry from array list
    /// </summary>
        [Test]
        public void TestTryRemove()
        {
            var TargetArray = new ArrayList() { "Test" };
            Assert.IsTrue(TargetArray.TryRemove("Test"));
            Assert.IsFalse(TargetArray.TryRemove("Test2"));
        }
        #endregion

    }
}