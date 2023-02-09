
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
using System.IO;
using System.Linq;
using Extensification.DictionaryExts;
using NUnit.Framework;

namespace Extensification.Tests
{

    [TestFixture]
    public class DictionaryTests
    {

        #region Addition
        /// <summary>
        /// Tests adding an entry to dictionary if not found
        /// </summary>
        [Test]
        public void TestAddIfNotFound()
        {
            var TargetDict = new Dictionary<string, int>();
            TargetDict.AddIfNotFound("String 1", 64);
            TargetDict.AddIfNotFound("String 1", 128);
            Assert.IsTrue(TargetDict.Count == 1);
        }

        /// <summary>
        /// Tests adding or modifying an entry to dictionary
        /// </summary>
        [Test]
        public void TestAddOrModify()
        {
            var TargetDict = new Dictionary<string, int>();
            TargetDict.AddOrModify("String 1", 64);
            TargetDict.AddOrModify("String 1", 128);
            Assert.IsTrue(TargetDict["String 1"] == 128);
        }

        /// <summary>
        /// Tests adding or renaming an entry to dictionary
        /// </summary>
        [Test]
        public void TestAddOrRename()
        {
            var TargetDict = new Dictionary<string, int>();
            TargetDict.AddOrRename("String 1", 64);
            TargetDict.AddOrRename("String 1", 128);
            Assert.IsTrue(TargetDict.ContainsKey("String 1 [2]"));
        }

        /// <summary>
        /// Tests adding an entry or incrementing a value of an already-existing entry to dictionary
        /// </summary>
        [Test]
        public void TestAddOrIncrement()
        {
            var TargetDict = new Dictionary<string, int>();
            TargetDict.AddOrIncrement("String 1", 64);
            TargetDict.AddOrIncrement("String 1", 128);
            Assert.IsTrue(TargetDict["String 1"] == 192);
        }

        /// <summary>
        /// Tests adding an entry or incrementing a value of an already-existing entry to dictionary
        /// </summary>
        [Test]
        public void TestAddOrIncrementUInteger()
        {
            var TargetDict = new Dictionary<string, uint>();
            TargetDict.AddOrIncrement("String 1", 64U);
            TargetDict.AddOrIncrement("String 1", 128U);
            Assert.IsTrue(TargetDict["String 1"] == 192L);
        }

        /// <summary>
        /// Tests adding an entry or incrementing a value of an already-existing entry to dictionary
        /// </summary>
        [Test]
        public void TestAddOrIncrementByte()
        {
            var TargetDict = new Dictionary<string, byte>();
            TargetDict.AddOrIncrement("String 1", 64);
            TargetDict.AddOrIncrement("String 1", 128);
            Assert.IsTrue(TargetDict["String 1"] == 192);
        }

        /// <summary>
        /// Tests adding an entry or incrementing a value of an already-existing entry to dictionary
        /// </summary>
        [Test]
        public void TestAddOrIncrementSByte()
        {
            var TargetDict = new Dictionary<string, sbyte>();
            TargetDict.AddOrIncrement("String 1", 16);
            TargetDict.AddOrIncrement("String 1", 16);
            Assert.IsTrue(TargetDict["String 1"] == 32);
        }

        /// <summary>
        /// Tests adding an entry or incrementing a value of an already-existing entry to dictionary
        /// </summary>
        [Test]
        public void TestAddOrIncrementDouble()
        {
            var TargetDict = new Dictionary<string, double>();
            TargetDict.AddOrIncrement("String 1", 64d);
            TargetDict.AddOrIncrement("String 1", 128d);
            Assert.IsTrue(TargetDict["String 1"] == 192d);
        }

        /// <summary>
        /// Tests adding an entry or incrementing a value of an already-existing entry to dictionary
        /// </summary>
        [Test]
        public void TestAddOrIncrementLong()
        {
            var TargetDict = new Dictionary<string, long>();
            TargetDict.AddOrIncrement("String 1", 64L);
            TargetDict.AddOrIncrement("String 1", 128L);
            Assert.IsTrue(TargetDict["String 1"] == 192L);
        }

        /// <summary>
        /// Tests adding an entry or incrementing a value of an already-existing entry to dictionary
        /// </summary>
        [Test]
        public void TestAddOrIncrementULong()
        {
            var TargetDict = new Dictionary<string, ulong>();
            TargetDict.AddOrIncrement("String 1", 64UL);
            TargetDict.AddOrIncrement("String 1", 128UL);
            Assert.IsTrue(TargetDict["String 1"] == 192m);
        }

        /// <summary>
        /// Tests adding an entry or incrementing a value of an already-existing entry to dictionary
        /// </summary>
        [Test]
        public void TestAddOrIncrementShort()
        {
            var TargetDict = new Dictionary<string, short>();
            TargetDict.AddOrIncrement("String 1", 64);
            TargetDict.AddOrIncrement("String 1", 128);
            Assert.IsTrue(TargetDict["String 1"] == 192);
        }

        /// <summary>
        /// Tests adding an entry or incrementing a value of an already-existing entry to dictionary
        /// </summary>
        [Test]
        public void TestAddOrIncrementUShort()
        {
            var TargetDict = new Dictionary<string, ushort>();
            TargetDict.AddOrIncrement("String 1", 64);
            TargetDict.AddOrIncrement("String 1", 128);
            Assert.IsTrue(TargetDict["String 1"] == 192);
        }

        /// <summary>
        /// Tests adding an entry or incrementing a value of an already-existing entry to dictionary
        /// </summary>
        [Test]
        public void TestAddOrIncrementSingle()
        {
            var TargetDict = new Dictionary<string, float>();
            TargetDict.AddOrIncrement("String 1", 64f);
            TargetDict.AddOrIncrement("String 1", 128f);
            Assert.IsTrue(TargetDict["String 1"] == 192f);
        }

        /// <summary>
        /// Tests adding an entry or decrementing a value of an already-existing entry to dictionary
        /// </summary>
        [Test]
        public void TestAddOrDecrement()
        {
            var TargetDict = new Dictionary<string, int>();
            TargetDict.AddOrDecrement("String 1", 64);
            TargetDict.AddOrDecrement("String 1", 32);
            Assert.IsTrue(TargetDict["String 1"] == 32);
        }

        /// <summary>
        /// Tests adding an entry or decrementing a value of an already-existing entry to dictionary
        /// </summary>
        [Test]
        public void TestAddOrDecrementUInteger()
        {
            var TargetDict = new Dictionary<string, uint>();
            TargetDict.AddOrDecrement("String 1", 64U);
            TargetDict.AddOrDecrement("String 1", 32U);
            Assert.IsTrue(TargetDict["String 1"] == 32L);
        }

        /// <summary>
        /// Tests adding an entry or decrementing a value of an already-existing entry to dictionary
        /// </summary>
        [Test]
        public void TestAddOrDecrementByte()
        {
            var TargetDict = new Dictionary<string, byte>();
            TargetDict.AddOrDecrement("String 1", 64);
            TargetDict.AddOrDecrement("String 1", 32);
            Assert.IsTrue(TargetDict["String 1"] == 32);
        }

        /// <summary>
        /// Tests adding an entry or decrementing a value of an already-existing entry to dictionary
        /// </summary>
        [Test]
        public void TestAddOrDecrementSByte()
        {
            var TargetDict = new Dictionary<string, sbyte>();
            TargetDict.AddOrDecrement("String 1", 16);
            TargetDict.AddOrDecrement("String 1", 8);
            Assert.IsTrue(TargetDict["String 1"] == 8);
        }

        /// <summary>
        /// Tests adding an entry or decrementing a value of an already-existing entry to dictionary
        /// </summary>
        [Test]
        public void TestAddOrDecrementDouble()
        {
            var TargetDict = new Dictionary<string, double>();
            TargetDict.AddOrDecrement("String 1", 64d);
            TargetDict.AddOrDecrement("String 1", 32d);
            Assert.IsTrue(TargetDict["String 1"] == 32d);
        }

        /// <summary>
        /// Tests adding an entry or decrementing a value of an already-existing entry to dictionary
        /// </summary>
        [Test]
        public void TestAddOrDecrementLong()
        {
            var TargetDict = new Dictionary<string, long>();
            TargetDict.AddOrDecrement("String 1", 64L);
            TargetDict.AddOrDecrement("String 1", 32L);
            Assert.IsTrue(TargetDict["String 1"] == 32L);
        }

        /// <summary>
        /// Tests adding an entry or decrementing a value of an already-existing entry to dictionary
        /// </summary>
        [Test]
        public void TestAddOrDecrementULong()
        {
            var TargetDict = new Dictionary<string, ulong>();
            TargetDict.AddOrDecrement("String 1", 64UL);
            TargetDict.AddOrDecrement("String 1", 32UL);
            Assert.IsTrue(TargetDict["String 1"] == 32m);
        }

        /// <summary>
        /// Tests adding an entry or decrementing a value of an already-existing entry to dictionary
        /// </summary>
        [Test]
        public void TestAddOrDecrementShort()
        {
            var TargetDict = new Dictionary<string, short>();
            TargetDict.AddOrDecrement("String 1", 64);
            TargetDict.AddOrDecrement("String 1", 32);
            Assert.IsTrue(TargetDict["String 1"] == 32);
        }

        /// <summary>
        /// Tests adding an entry or decrementing a value of an already-existing entry to dictionary
        /// </summary>
        [Test]
        public void TestAddOrDecrementUShort()
        {
            var TargetDict = new Dictionary<string, ushort>();
            TargetDict.AddOrDecrement("String 1", 64);
            TargetDict.AddOrDecrement("String 1", 32);
            Assert.IsTrue(TargetDict["String 1"] == 32);
        }

        /// <summary>
        /// Tests adding an entry or decrementing a value of an already-existing entry to dictionary
        /// </summary>
        [Test]
        public void TestAddOrDecrementSingle()
        {
            var TargetDict = new Dictionary<string, float>();
            TargetDict.AddOrDecrement("String 1", 64f);
            TargetDict.AddOrDecrement("String 1", 32f);
            Assert.IsTrue(TargetDict["String 1"] == 32f);
        }
        #endregion

        #region Counts
        /// <summary>
        /// Tests counting full entries
        /// </summary>
        [Test]
        public void TestCountFullEntries()
        {
            var TargetDict = new Dictionary<string, string>() { { "Full", "" }, { "", "entry" }, { "Index", "5" } };
            var TargetDictObjects = new Dictionary<string, string>() { { "Object 1", 68.ToString() }, { "Object 2", null } };
            Assert.AreEqual(2, TargetDict.CountFullEntries());
            Assert.AreEqual(1, TargetDictObjects.CountFullEntries());
        }

        /// <summary>
        /// Tests counting empty entries
        /// </summary>
        [Test]
        public void TestCountEmptyEntries()
        {
            var TargetDict = new Dictionary<string, string>() { { "Full", "" }, { "", "entry" }, { "Index", "5" } };
            var TargetDictObjects = new Dictionary<string, object>() { { "Object 1", 68 }, { "Object 2", null } };
            Assert.AreEqual(1, TargetDict.CountEmptyEntries());
            Assert.AreEqual(1, TargetDictObjects.CountEmptyEntries());
        }
        #endregion

        #region Getting
        /// <summary>
        /// Tests getting key from value
        /// </summary>
        [Test]
        public void TestGetKeyFromValue()
        {
            var TargetDictionary = new Dictionary<string, int>() { { "Extensification", 0 }, { "is", 1 }, { "awesome!", 2 } };
            int NeededNumber = 2;
            string Returned = TargetDictionary.GetKeyFromValue(NeededNumber);
            Assert.AreEqual("awesome!", Returned, "Failed to get key from value. Got {0}", Returned);
        }

        /// <summary>
        /// Tests getting index of a key in dictionary that has keys of type <see cref="string"/>
        /// </summary>
        [Test]
        public void TestGetIndexOfKey()
        {
            var TargetDictionary = new Dictionary<string, int>() { { "Extensification", 0 }, { "is", 1 }, { "awesome!", 2 } };
            string NeededKey = "awesome!";
            int Returned = TargetDictionary.GetIndexOfKey(NeededKey);
            Assert.AreEqual(2, Returned, "Failed to get index of key. Got {0}", Returned);
        }

        /// <summary>
        /// Tests getting index of a value in dictionary that has keys of type <see cref="string"/>
        /// </summary>
        [Test]
        public void TestGetIndexOfValue()
        {
            var TargetDictionary = new Dictionary<string, int>() { { "Extensification", 0 }, { "is", 1 }, { "awesome!", 2 } };
            int NeededValue = 1;
            int Returned = TargetDictionary.GetIndexOfValue(NeededValue);
            Assert.AreEqual(1, Returned, "Failed to get index of key. Got {0}", Returned);
        }

        /// <summary>
        /// Tests getting index of a key in dictionary that has keys of a type that can't be compared using the "=" operator.
        /// </summary>
        [Test]
        public void TestGetIndexOfKeyNonString()
        {
            var NeededKey = new MemoryStream(16);
            var TargetDictionary = new Dictionary<Stream, int>() { { new MemoryStream(8), 0 }, { NeededKey, 1 }, { new MemoryStream(32), 2 } };
            int Returned = TargetDictionary.GetIndexOfKey(NeededKey);
            Assert.AreEqual(1, Returned, "Failed to get index of key. Got {0}", Returned);
        }

        /// <summary>
        /// Tests getting indexes of full entries
        /// </summary>
        [Test]
        public void TestGetIndexesOfFullEntries()
        {
            var TargetDict = new Dictionary<string, string>() { { "Full", "" }, { "", "entry" }, { "Index", "5" } };
            var TargetDictObjects = new Dictionary<string, object>() { { "Object 1", 68 }, { "Object 2", null } };
            var ExpectedIndexes = new int[] { 1, 2 };
            var ExpectedIndexesObjects = new int[] { 0 };
            Assert.IsNotNull(TargetDict.GetIndexesOfFullEntries());
            Assert.IsNotNull(TargetDictObjects.GetIndexesOfFullEntries());
            Assert.IsTrue(TargetDict.GetIndexesOfFullEntries().SequenceEqual(ExpectedIndexes));
            Assert.IsTrue(TargetDictObjects.GetIndexesOfFullEntries().SequenceEqual(ExpectedIndexesObjects));
        }

        /// <summary>
        /// Tests getting indexes of empty entries
        /// </summary>
        [Test]
        public void TestGetIndexesOfEmptyEntries()
        {
            var TargetDict = new Dictionary<string, string>() { { "Full", "" }, { "", "entry" }, { "Index", "5" } };
            var TargetDictObjects = new Dictionary<string, object>() { { "Object 1", 68 }, { "Object 2", null } };
            var ExpectedIndexes = new int[] { 0 };
            var ExpectedIndexesObjects = new int[] { 1 };
            Assert.IsNotNull(TargetDict.GetIndexesOfEmptyEntries());
            Assert.IsNotNull(TargetDictObjects.GetIndexesOfEmptyEntries());
            Assert.IsTrue(TargetDict.GetIndexesOfEmptyEntries().SequenceEqual(ExpectedIndexes));
            Assert.IsTrue(TargetDictObjects.GetIndexesOfEmptyEntries().SequenceEqual(ExpectedIndexesObjects));
        }
        #endregion

        #region Manipulation
        /// <summary>
        /// Tests incrementing a number
        /// </summary>
        [Test]
        public void TestIncrementNumber()
        {
            var TargetDict = new Dictionary<string, int>();
            for (int t = 1; t <= 10; t++)
                TargetDict.IncrementNumber("Counter");
            Assert.IsTrue(TargetDict["Counter"] == 10);
        }

        /// <summary>
        /// Tests decrementing a number
        /// </summary>
        [Test]
        public void TestDecrementNumber()
        {
            var TargetDict = new Dictionary<string, int>();
            for (int t = 1; t <= 10; t++)
                TargetDict.DecrementNumber("Counter");
            Assert.IsTrue(TargetDict["Counter"] == -10);
        }

        /// <summary>
        /// Tests incrementing a number
        /// </summary>
        [Test]
        public void TestIncrementNumberUInteger()
        {
            var TargetDict = new Dictionary<string, uint>();
            for (int t = 1; t <= 10; t++)
                TargetDict.IncrementNumber("Counter");
            Assert.IsTrue(TargetDict["Counter"] == 10L);
        }

        /// <summary>
        /// Tests decrementing a number
        /// </summary>
        [Test]
        public void TestDecrementNumberUInteger()
        {
            var TargetDict = new Dictionary<string, uint>() { { "Counter", 10U } };
            for (int t = 1; t <= 10; t++)
                TargetDict.DecrementNumber("Counter");
            Assert.IsTrue(TargetDict["Counter"] == 0L);
        }

        /// <summary>
        /// Tests incrementing a number
        /// </summary>
        [Test]
        public void TestIncrementNumberShort()
        {
            var TargetDict = new Dictionary<string, short>();
            for (int t = 1; t <= 10; t++)
                TargetDict.IncrementNumber("Counter");
            Assert.IsTrue(TargetDict["Counter"] == 10);
        }

        /// <summary>
        /// Tests decrementing a number
        /// </summary>
        [Test]
        public void TestDecrementNumberShort()
        {
            var TargetDict = new Dictionary<string, short>();
            for (int t = 1; t <= 10; t++)
                TargetDict.DecrementNumber("Counter");
            Assert.IsTrue(TargetDict["Counter"] == -10);
        }

        /// <summary>
        /// Tests incrementing a number
        /// </summary>
        [Test]
        public void TestIncrementNumberUShort()
        {
            var TargetDict = new Dictionary<string, ushort>();
            for (int t = 1; t <= 10; t++)
                TargetDict.IncrementNumber("Counter");
            Assert.IsTrue(TargetDict["Counter"] == 10);
        }

        /// <summary>
        /// Tests decrementing a number
        /// </summary>
        [Test]
        public void TestDecrementNumberUShort()
        {
            var TargetDict = new Dictionary<string, ushort>() { { "Counter", 10 } };
            for (int t = 1; t <= 10; t++)
                TargetDict.DecrementNumber("Counter");
            Assert.IsTrue(TargetDict["Counter"] == 0);
        }

        /// <summary>
        /// Tests incrementing a number
        /// </summary>
        [Test]
        public void TestIncrementNumberLong()
        {
            var TargetDict = new Dictionary<string, long>();
            for (int t = 1; t <= 10; t++)
                TargetDict.IncrementNumber("Counter");
            Assert.IsTrue(TargetDict["Counter"] == 10L);
        }

        /// <summary>
        /// Tests decrementing a number
        /// </summary>
        [Test]
        public void TestDecrementNumberLong()
        {
            var TargetDict = new Dictionary<string, long>();
            for (int t = 1; t <= 10; t++)
                TargetDict.DecrementNumber("Counter");
            Assert.IsTrue(TargetDict["Counter"] == -10);
        }

        /// <summary>
        /// Tests incrementing a number
        /// </summary>
        [Test]
        public void TestIncrementNumberULong()
        {
            var TargetDict = new Dictionary<string, ulong>();
            for (int t = 1; t <= 10; t++)
                TargetDict.IncrementNumber("Counter");
            Assert.IsTrue(TargetDict["Counter"] == 10m);
        }

        /// <summary>
        /// Tests decrementing a number
        /// </summary>
        [Test]
        public void TestDecrementNumberULong()
        {
            var TargetDict = new Dictionary<string, ulong>() { { "Counter", 10UL } };
            for (int t = 1; t <= 10; t++)
                TargetDict.DecrementNumber("Counter");
            Assert.IsTrue(TargetDict["Counter"] == 0m);
        }

        /// <summary>
        /// Tests incrementing a number
        /// </summary>
        [Test]
        public void TestIncrementNumberByte()
        {
            var TargetDict = new Dictionary<string, byte>();
            for (int t = 1; t <= 10; t++)
                TargetDict.IncrementNumber("Counter");
            Assert.IsTrue(TargetDict["Counter"] == 10);
        }

        /// <summary>
        /// Tests decrementing a number
        /// </summary>
        [Test]
        public void TestDecrementNumberByte()
        {
            var TargetDict = new Dictionary<string, byte>() { { "Counter", 10 } };
            for (int t = 1; t <= 10; t++)
                TargetDict.DecrementNumber("Counter");
            Assert.IsTrue(TargetDict["Counter"] == 0);
        }

        /// <summary>
        /// Tests incrementing a number
        /// </summary>
        [Test]
        public void TestIncrementNumberSByte()
        {
            var TargetDict = new Dictionary<string, sbyte>();
            for (int t = 1; t <= 10; t++)
                TargetDict.IncrementNumber("Counter");
            Assert.IsTrue(TargetDict["Counter"] == 10);
        }

        /// <summary>
        /// Tests decrementing a number
        /// </summary>
        [Test]
        public void TestDecrementNumberSByte()
        {
            var TargetDict = new Dictionary<string, sbyte>() { { "Counter", 10 } };
            for (int t = 1; t <= 10; t++)
                TargetDict.DecrementNumber("Counter");
            Assert.IsTrue(TargetDict["Counter"] == 0);
        }

        /// <summary>
        /// Tests incrementing a number
        /// </summary>
        [Test]
        public void TestIncrementNumberSingle()
        {
            var TargetDict = new Dictionary<string, float>();
            for (int t = 1; t <= 10; t++)
                TargetDict.IncrementNumber("Counter");
            Assert.IsTrue(TargetDict["Counter"] == 10f);
        }

        /// <summary>
        /// Tests decrementing a number
        /// </summary>
        [Test]
        public void TestDecrementNumberSingle()
        {
            var TargetDict = new Dictionary<string, float>();
            for (int t = 1; t <= 10; t++)
                TargetDict.DecrementNumber("Counter");
            Assert.IsTrue(TargetDict["Counter"] == -10);
        }

        /// <summary>
        /// Tests incrementing a number
        /// </summary>
        [Test]
        public void TestIncrementNumberDouble()
        {
            var TargetDict = new Dictionary<string, double>();
            for (int t = 1; t <= 10; t++)
                TargetDict.IncrementNumber("Counter");
            Assert.IsTrue(TargetDict["Counter"] == 10d);
        }

        /// <summary>
        /// Tests decrementing a number
        /// </summary>
        [Test]
        public void TestDecrementNumberDouble()
        {
            var TargetDict = new Dictionary<string, double>();
            for (int t = 1; t <= 10; t++)
                TargetDict.DecrementNumber("Counter");
            Assert.IsTrue(TargetDict["Counter"] == -10);
        }

        /// <summary>
        /// Tests renaming key
        /// </summary>
        [Test]
        public void TestRenameKey()
        {
            var TargetDict = new Dictionary<string, string>() { { "Name", "Extensification" }, { "Tyoe", "Library" } };
            TargetDict.RenameKey("Tyoe", "Type");
            Assert.IsTrue(TargetDict.ContainsKey("Type"));
        }
        #endregion

        #region Querying
        /// <summary>
        /// Tests seeing if the dictionary contains any of the specified clauses
        /// </summary>
        [Test]
        public void TestContainsAnyOfInKeys()
        {
            var TargetDict = new Dictionary<string, int>() { { "Test", 1 }, { "Hello and Test", 2 }, { "Tester! Hello!", 3 } };
            Assert.IsTrue(TargetDict.ContainsAnyOfInKeys(new[] { "Hello and Test", "Test" }));
            Assert.IsFalse(TargetDict.ContainsAnyOfInKeys(new[] { "Goodbye", "Works" }));
        }

        /// <summary>
        /// Tests seeing if the dictionary contains all of the specified clauses
        /// </summary>
        [Test]
        public void TestContainsAllOfInKeys()
        {
            var TargetDict = new Dictionary<string, int>() { { "Test", 1 }, { "Hello and Test", 2 }, { "Tester! Hello!", 3 } };
            Assert.IsTrue(TargetDict.ContainsAllOfInKeys(new[] { "Hello and Test", "Test" }));
            Assert.IsFalse(TargetDict.ContainsAllOfInKeys(new[] { "Goodbye", "Works" }));
        }

        /// <summary>
        /// Tests seeing if the dictionary contains any of the specified clauses
        /// </summary>
        [Test]
        public void TestContainsAnyOfInValues()
        {
            var TargetDict = new Dictionary<string, int>() { { "Test", 1 }, { "Hello and Test", 2 }, { "Tester! Hello!", 3 } };
            Assert.IsTrue(TargetDict.ContainsAnyOfInValues(new[] { 1, 3 }));
            Assert.IsFalse(TargetDict.ContainsAnyOfInValues(new[] { 5, 7 }));
        }

        /// <summary>
        /// Tests seeing if the dictionary contains all of the specified clauses
        /// </summary>
        [Test]
        public void TestContainsAllOfInValues()
        {
            var TargetDict = new Dictionary<string, int>() { { "Test", 1 }, { "Hello and Test", 2 }, { "Tester! Hello!", 3 } };
            Assert.IsTrue(TargetDict.ContainsAllOfInValues(new[] { 1, 3 }));
            Assert.IsFalse(TargetDict.ContainsAllOfInValues(new[] { 5, 7 }));
        }
        #endregion

    }
}