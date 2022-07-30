
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
using Extensification.ArrayExts;
using NUnit.Framework;

namespace Extensification.Tests
{

    [TestFixture]
    public class ArrayTests
    {

        #region Addition
        /// <summary>
        /// Tests adding an entry to array
        /// </summary>
        [Test]
        public void TestAdd()
        {
            var TargetArray = new int[] { 2, 3 };
            TargetArray = TargetArray.Add(4);
            Assert.IsTrue(TargetArray.Length == 3);
        }

        /// <summary>
        /// Tests adding a range of entries to array
        /// </summary>
        [Test]
        public void TestAddRange()
        {
            int[] TargetArray = { 2, 3 };
            int[] Range = { 4, 5, 6, 7, 8, 9 };
            TargetArray = TargetArray.AddRange(Range);
            Assert.IsTrue(TargetArray.Length == 8);
        }
        #endregion

        #region Removal
        /// <summary>
        /// Tests removing an entry to array
        /// </summary>
        [Test]
        public void TestRemove()
        {
            var TargetArray = new int[] { 2, 3, 4 };
            TargetArray = TargetArray.Remove(4);
            Assert.IsTrue(TargetArray.Length == 2);
        }
        #endregion

        #region Conversion
        /// <summary>
    /// Tests converting array to array list
    /// </summary>
        [Test]
        public void TestToArrayList()
        {
            var TargetArray = new[] { "Test converting", "target array", "to array list." };
            var TargetList = TargetArray.ToArrayList();
            Assert.IsNotNull(TargetList);
            Assert.IsTrue(TargetList.Count > 0);
        }
        #endregion

        #region Getting
        /// <summary>
    /// Tests getting index from entry
    /// </summary>
        [Test]
        public void TestGetIndexFromEntry()
        {
            var TargetArray = new[] { "Test getting", "index from", "array entry." };
            int ExpectedIndex = 1;
            var ActualIndex = TargetArray.GetIndexFromEntry("index from");
            Assert.AreEqual(ExpectedIndex, ActualIndex[0]);
        }

        /// <summary>
    /// Tests getting indexes of full entries
    /// </summary>
        [Test]
        public void TestGetIndexesOfFullEntries()
        {
            var TargetArray = new string[] { "", "Full", "", "Entry", "" };
            var TargetArrayObjects = new[] { (object)4, null, null };
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
            var TargetArray = new string[] { "", "Full", "", "Entry", "" };
            var TargetArrayObjects = new[] { (object)4, null, null };
            var ExpectedIndexes = new int[] { 0, 2, 4 };
            var ExpectedIndexesObjects = new int[] { 1, 2 };
            Assert.IsNotNull(TargetArray.GetIndexesOfEmptyEntries());
            Assert.IsNotNull(TargetArrayObjects.GetIndexesOfEmptyEntries());
            Assert.IsTrue(TargetArray.GetIndexesOfEmptyEntries().SequenceEqual(ExpectedIndexes));
            Assert.IsTrue(TargetArrayObjects.GetIndexesOfEmptyEntries().SequenceEqual(ExpectedIndexesObjects));
        }
        #endregion

        #region Counts
        /// <summary>
    /// Tests counting full entries
    /// </summary>
        [Test]
        public void TestCountFullEntries()
        {
            var TargetArray = new string[] { "", "Full", "", "Entry", "" };
            var TargetArrayObjects = new[] { (object)4, null, null };
            Assert.AreEqual(2, TargetArray.CountFullEntries());
            Assert.AreEqual(1, TargetArrayObjects.CountFullEntries());
        }

        /// <summary>
    /// Tests counting empty entries
    /// </summary>
        [Test]
        public void TestCountEmptyEntries()
        {
            var TargetArray = new string[] { "", "Full", "", "Entry", "" };
            var TargetArrayObjects = new[] { (object)4, null, null };
            Assert.AreEqual(3, TargetArray.CountEmptyEntries());
            Assert.AreEqual(2, TargetArrayObjects.CountEmptyEntries());
        }
        #endregion

        #region Querying
        /// <summary>
    /// Tests seeing if the array contains any of the specified clauses
    /// </summary>
        [Test]
        public void TestContainsAnyOf()
        {
            var TargetArray = new string[] { "Test", "Hello and Test", "Tester! Hello!" };
            Assert.IsTrue(TargetArray.ContainsAnyOf(new[] { "Hello and Test", "Test" }));
            Assert.IsFalse(TargetArray.ContainsAnyOf(new[] { "Goodbye", "Works" }));
        }

        /// <summary>
    /// Tests seeing if the array contains all of the specified clauses
    /// </summary>
        [Test]
        public void TestContainsAllOf()
        {
            var TargetArray = new string[] { "Test", "Hello and Test", "Tester! Hello!" };
            Assert.IsTrue(TargetArray.ContainsAllOf(new[] { "Hello and Test", "Test" }));
            Assert.IsFalse(TargetArray.ContainsAllOf(new[] { "Goodbye", "Works" }));
        }
        #endregion

        #region Manipulation
        /// <summary>
    /// Tests stringifying a char array
    /// </summary>
        [Test]
        public void TestStringify()
        {
            var TargetArray = new char[] { 'H', 'e', 'l', 'l', 'o' };
            Assert.AreEqual("Hello", TargetArray.Stringify());
        }
        #endregion

    }
}