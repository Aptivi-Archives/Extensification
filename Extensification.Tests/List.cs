
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
using System.Collections.Generic;
using System.Linq;
using Extensification.ListExts;
using NUnit.Framework;

namespace Extensification.Tests
{

    [TestFixture]
    public class ListTests
    {

        #region Addition
        /// <summary>
    /// Tests adding an entry to list if not found
    /// </summary>
        [Test]
        public void TestAddIfNotFound()
        {
            var TargetList = new List<string>();
            TargetList.AddIfNotFound("String 1");
            TargetList.AddIfNotFound("String 1");
            Assert.IsTrue(TargetList.Count == 1);
        }
        #endregion

        #region Conversion
        /// <summary>
    /// Tests converting list to array list
    /// </summary>
        [Test]
        public void TestToArrayList()
        {
            var TargetList = new List<string>() { "Test converting", "target list", "to array list." };
            var TargetArrayList = TargetList.ToArrayList();
            Assert.IsNotNull(TargetArrayList);
            Assert.IsTrue(TargetArrayList.Count > 0);
        }
        #endregion

        #region Counts
        /// <summary>
    /// Tests counting full entries
    /// </summary>
        [Test]
        public void TestCountFullEntries()
        {
            var TargetList = new List<string>() { "Full", "", "", "entry", "", "5" };
            var TargetListObjects = new List<object>() { 12, null, 32, 48 };
            Assert.AreEqual(3, TargetList.CountFullEntries());
            Assert.AreEqual(3, TargetListObjects.CountFullEntries());
        }

        /// <summary>
    /// Tests counting empty entries
    /// </summary>
        [Test]
        public void TestCountEmptyEntries()
        {
            var TargetList = new List<string>() { "Full", "", "", "entry", "", "", "6" };
            var TargetListObjects = new List<object>() { 12, null, 32, 48 };
            Assert.AreEqual(4, TargetList.CountEmptyEntries());
            Assert.AreEqual(1, TargetListObjects.CountEmptyEntries());
        }
        #endregion

        #region Getting
        /// <summary>
    /// Tests getting index from entry
    /// </summary>
        [Test]
        public void TestGetIndexFromEntry()
        {
            var TargetList = new List<string>() { "Test getting", "index from", "array list entry." };
            int ExpectedIndex = 1;
            Assert.AreEqual(ExpectedIndex, TargetList.GetIndexFromEntry("index from")[0]);
        }

        /// <summary>
    /// Tests getting indexes of full entries
    /// </summary>
        [Test]
        public void TestGetIndexesOfFullEntries()
        {
            var TargetList = new List<string>() { "", "Full", "", "Entry", "" };
            var TargetListObjects = new List<object>() { 4, null, null };
            var ExpectedIndexes = new int[] { 1, 3 };
            var ExpectedIndexesObjects = new int[] { 0 };
            Assert.IsNotNull(TargetList.GetIndexesOfFullEntries());
            Assert.IsNotNull(TargetListObjects.GetIndexesOfFullEntries());
            Assert.IsTrue(TargetList.GetIndexesOfFullEntries().SequenceEqual(ExpectedIndexes));
            Assert.IsTrue(TargetListObjects.GetIndexesOfFullEntries().SequenceEqual(ExpectedIndexesObjects));
        }

        /// <summary>
    /// Tests getting indexes of empty entries
    /// </summary>
        [Test]
        public void TestGetIndexesOfEmptyEntries()
        {
            var TargetList = new List<string>() { "", "Full", "", "Entry", "" };
            var TargetListObjects = new List<object>() { 4, null, null };
            var ExpectedIndexes = new int[] { 0, 2, 4 };
            var ExpectedIndexesObjects = new int[] { 1, 2 };
            Assert.IsNotNull(TargetList.GetIndexesOfEmptyEntries());
            Assert.IsNotNull(TargetListObjects.GetIndexesOfEmptyEntries());
            Assert.IsTrue(TargetList.GetIndexesOfEmptyEntries().SequenceEqual(ExpectedIndexes));
            Assert.IsTrue(TargetListObjects.GetIndexesOfEmptyEntries().SequenceEqual(ExpectedIndexesObjects));
        }
        #endregion

        #region Manipulation
        /// <summary>
    /// Tests stringifying a char array
    /// </summary>
        [Test]
        public void TestStringify()
        {
            var TargetArray = new List<char>() { 'H', 'e', 'l', 'l', 'o' };
            Assert.AreEqual("Hello", TargetArray.Stringify());
        }
        #endregion

        #region Querying
        /// <summary>
    /// Tests seeing if the list contains any of the specified clauses
    /// </summary>
        [Test]
        public void TestContainsAnyOf()
        {
            var TargetList = new List<string>() { "Test", "Hello and Test", "Tester! Hello!" };
            Assert.IsTrue(TargetList.ContainsAnyOf(new[] { "Hello and Test", "Test" }));
            Assert.IsFalse(TargetList.ContainsAnyOf(new[] { "Goodbye", "Works" }));
        }

        /// <summary>
    /// Tests seeing if the list contains all of the specified clauses
    /// </summary>
        [Test]
        public void TestContainsAllOf()
        {
            var TargetList = new List<string>() { "Test", "Hello and Test", "Tester! Hello!" };
            Assert.IsTrue(TargetList.ContainsAllOf(new[] { "Hello and Test", "Test" }));
            Assert.IsFalse(TargetList.ContainsAllOf(new[] { "Goodbye", "Works" }));
        }
        #endregion

        #region Removal
        /// <summary>
    /// Tests trying to remove an entry from list
    /// </summary>
        [Test]
        public void TestTryRemove()
        {
            var TargetList = new List<string>() { "Test" };
            Assert.IsTrue(TargetList.TryRemove("Test"));
            Assert.IsFalse(TargetList.TryRemove("Test2"));
        }
        #endregion

    }
}