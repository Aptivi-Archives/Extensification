using System;
using System.Collections.Generic;
using System.Linq;
using Extensification.ArrayExts;
using Extensification.StringExts;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

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
    public class StringTests
    {

        #region Conversion
        /// <summary>
    /// Tests parsing VT sequences (normal CSI ones).
    /// </summary>
        [Test]
        public void TestConvertVTSequencesNormal()
        {
            string TargetString = "Hi. We have <38;5;6m>new improvements. <0m>Well, we'll have to do this: <38;5;7m>Yay!<48;5;2m>Colors!";
            StringExts.Conversion.ConvertVTSequences(ref TargetString);
            Assert.IsFalse(TargetString.ContainsAnyOf(new[] { "<38;5;6m>", "<38;5;7m>", "<0m>", "<48;5;2m>" }));
            Assert.IsTrue(TargetString.Contains(Conversions.ToString('\u001b') + "["));
        }

        /// <summary>
    /// Tests parsing VT sequences (OSC title one).
    /// </summary>
        [Test]
        public void TestConvertVTSequencesOSCTitle()
        {
            string TargetString = "<0;Hi!>";
            StringExts.Conversion.ConvertVTSequences(ref TargetString);
            Assert.IsFalse(TargetString.ContainsAnyOf(new[] { "<0;Hi!>" }));
            Assert.IsTrue(TargetString.Contains(Conversions.ToString('\u001b') + "]"));
            Assert.IsTrue(TargetString.EndsWith('\a'));
        }

        /// <summary>
    /// Tests parsing VT sequences (OSC screen color one).
    /// </summary>
        [Test]
        public void TestConvertVTSequencesOSCScreenColor()
        {
            string TargetString = "<4;15;rgb:ff/ff/ff>";
            StringExts.Conversion.ConvertVTSequences(ref TargetString);
            Assert.IsFalse(TargetString.ContainsAnyOf(new[] { "<0;Hi!>" }));
            Assert.IsTrue(TargetString.Contains(Conversions.ToString('\u001b') + "]"));
            Assert.IsTrue(TargetString.EndsWith('\u001b'));
        }

        /// <summary>
    /// Tests parsing VT sequences (simple cursor positioning).
    /// </summary>
        [Test]
        public void TestConvertVTSequencesSimpleCursorPositioning()
        {
            string TargetString = "<A>";
            StringExts.Conversion.ConvertVTSequences(ref TargetString);
            Assert.IsFalse(TargetString.ContainsAnyOf(new[] { "<A>" }));
            Assert.IsTrue((TargetString ?? "") == Conversions.ToString('\u001b') + "A");
        }

        /// <summary>
    /// Tests converting from color hex to RGB
    /// </summary>
        [Test]
        public void TestConvertFromHexToRgb()
        {
            int ExpectedR = 15;
            int ExpectedG = 15;
            int ExpectedB = 15;
            int ActualR = default, ActualG = default, ActualB = default;
            string Color = "#0F0F0F";
            Color.ConvertFromHexToRgb(ref ActualR, ref ActualG, ref ActualB);
            Assert.AreEqual(ExpectedR, ActualR);
            Assert.AreEqual(ExpectedG, ActualG);
            Assert.AreEqual(ExpectedB, ActualB);
        }
        #endregion

        #region Manipulation
        /// <summary>
    /// Tests replacing last occurrence of a string
    /// </summary>
        [Test]
        public void TestReplaceLastOccurrence()
        {
            string Source = "Extensification is awesome and is great!";
            string Target = "is";
            Source = Source.ReplaceLastOccurrence(Target, "its features are");
            Assert.AreEqual(Source, "Extensification is awesome and its features are great!", "Replacement failed. Got {0}", Source);
        }

        /// <summary>
    /// Tests replacing all specified occurrences of strings with a single string
    /// </summary>
        [Test]
        public void TestReplaceAll()
        {
            string ExpectedString = "Please test Extensification. This sub is a unit test.";
            string TargetString = "Please <replace> Extensification. This sub is a unit <replace2>.";
            TargetString = TargetString.ReplaceAll(new[] { "<replace>", "<replace2>" }, "test");
            Assert.AreEqual(ExpectedString, TargetString, "String replacement failed. Got \"{0}\"", TargetString);
        }

        /// <summary>
    /// Tests replacing all specified occurrences of strings with multiple strings
    /// </summary>
        [Test]
        public void TestReplaceAllRange()
        {
            string ExpectedString = "Please test the integrity of Extensification. This sub is a unit test.";
            string TargetString = "Please <replace> Extensification. This sub is a unit <replace2>.";
            TargetString = TargetString.ReplaceAllRange(new[] { "<replace>", "<replace2>" }, new[] { "test the integrity of", "test" });
            Assert.AreEqual(ExpectedString, TargetString, "String replacement failed. Got \"{0}\"", TargetString);
        }

        /// <summary>
    /// Tests truncating...
    /// </summary>
        [Test]
        public void TestTruncate()
        {
            string Source = "Extensification is awesome and is great!";
            int Target = 20;
            Source = Source.Truncate(Target);
            Assert.AreEqual(Source, "Extensification is ...", "Truncation failed. Got {0}", Source);
        }

        /// <summary>
    /// Tests string formatting
    /// </summary>
        [Test]
        public void TestFormatString()
        {
            string Expected = "Kernel Simulator 0.0.1 first launched 2/22/2018.";
            string Actual = "Kernel Simulator 0.0.1 first launched {0}/{1}/{2}.";
            int Day = 22;
            int Year = 2018;
            int Month = 2;
            Actual = Actual.FormatString(Month, Day, Year);
            Assert.AreEqual(Expected, Actual, "Format failed. Got {0}", Actual);
        }

        /// <summary>
    /// Tests string formatting with reference to null
    /// </summary>
        [Test]
        public void TestFormatStringNullReference()
        {
            string Expected = "Nothing is ((Null))";
            string Actual = "{0} is {1}";
            Actual = Actual.FormatString("Nothing", null);
            Assert.AreEqual(Expected, Actual, "Format failed. Got {0}", Actual);
        }

        /// <summary>
    /// Tests shifting letters backwards in a string
    /// </summary>
        [Test]
        public void TestShiftLettersBackwards()
        {
            string ExpectedString = "Beha";
            string TargetString = "File";
            TargetString = TargetString.ShiftLetters(-4);
            Assert.AreEqual(ExpectedString, TargetString, "String shift failed. Got \"{0}\"", TargetString);
        }

        /// <summary>
    /// Tests shifting letters forward in a string
    /// </summary>
        [Test]
        public void TestShiftLettersForward()
        {
            string ExpectedString = "File";
            string TargetString = "Beha";
            TargetString = TargetString.ShiftLetters(4);
            Assert.AreEqual(ExpectedString, TargetString, "String shift failed. Got \"{0}\"", TargetString);
        }

        /// <summary>
    /// Tests reserving orders of characters in a string
    /// </summary>
        [Test]
        public void TestReverse()
        {
            string TargetString = "olleH";
            Assert.AreEqual("Hello", TargetString.Reverse());
        }

        /// <summary>
    /// Tests repeating the string
    /// </summary>
        [Test]
        public void TestRepeat()
        {
            string TargetString = "Hi! ";
            Assert.AreEqual("Hi! Hi! Hi! ", TargetString.Repeat(3L));
        }

        /// <summary>
    /// Tests repeating the string zero times
    /// </summary>
        [Test]
        public void TestRepeatZero()
        {
            string TargetString = "Hi! ";
            Assert.AreEqual("", TargetString.Repeat(0L));
        }

        /// <summary>
    /// Tests retrieving substring
    /// </summary>
        [Test]
        public void TestSubstring()
        {
            string TargetString = "Hello!";
            Assert.AreEqual("llo", TargetString.Substring(2, length: 3));
            Assert.AreEqual("llo", TargetString.Substring(2, Finish: 4));
        }

        /// <summary>
    /// Tests enclosing a string by double quotes
    /// </summary>
        [Test]
        public void TestEncloseByDoubleQuotes()
        {
            string TargetString = "Hi!";
            Assert.AreEqual("\"Hi!\"", TargetString.EncloseByDoubleQuotes());
        }

        /// <summary>
    /// Tests releasing a string from double quotes
    /// </summary>
        [Test]
        public void TestReleaseDoubleQuotes()
        {
            string TargetString = "\"Hi!\"";
            Assert.AreEqual("Hi!", TargetString.ReleaseDoubleQuotes());
        }
        #endregion

        #region Querying
        /// <summary>
    /// Tests getting all indexes of a character
    /// </summary>
        [Test]
        public void TestAllIndexesOf()
        {
            string Source = "Extensification is awesome and is great!";
            string Target = "a";
            int Indexes = Source.AllIndexesOf(Target).Count();
            Assert.AreEqual(Indexes, 4, "Getting all indexes of a character failed. Expected 4, got {0}", Indexes);
        }

        /// <summary>
    /// Tests getting ASCII codes for a string
    /// </summary>
        [Test]
        public void TestGetAsciiCodes()
        {
            string TargetString = "File";
            var TargetStringAscii = TargetString.GetAsciiCodes();
            Assert.IsNotNull(TargetStringAscii, "Array is null.");
            Assert.IsFalse(TargetStringAscii.Length == 0, "Getting ASCII codes failed. Length is zero.");
            Assert.IsTrue(TargetStringAscii.Length == 4, "Expected four entries of ASCII codes of characters. Got {0}", TargetStringAscii.Length);
        }

        /// <summary>
    /// Tests getting an ASCII code for a letter in a string
    /// </summary>
        [Test]
        public void TestGetAsciiCode()
        {
            string TargetString = "File";
            byte TargetStringAscii = TargetString.GetAsciiCode(3);
            Assert.IsNotNull(TargetStringAscii, "Byte is null.");
            Assert.AreEqual(101, (int)TargetStringAscii);
        }

        /// <summary>
    /// Tests removing letters from a string
    /// </summary>
        [Test]
        public void TestGetListOfRepeatedLetters()
        {
            string TargetString = "Extensification";
            var ExpectedReps = new Dictionary<string, int>() { { "E", 1 }, { "x", 1 }, { "t", 2 }, { "e", 1 }, { "n", 2 }, { "s", 1 }, { "i", 3 }, { "f", 1 }, { "c", 1 }, { "a", 1 }, { "o", 1 } };
            Assert.IsTrue(TargetString.GetListOfRepeatedLetters().SequenceEqual(ExpectedReps));
        }

        /// <summary>
    /// Tests checking if the string contains any of the target strings.
    /// </summary>
        [Test]
        public void TestContainsAnyOf()
        {
            string TargetString = "Hello, Extensification users!";
            Assert.IsTrue(TargetString.ContainsAnyOf(new[] { "Extensification", "users" }));
            Assert.IsFalse(TargetString.ContainsAnyOf(new[] { "Awesome", "developers" }));
        }

        /// <summary>
    /// Tests checking if the string contains all of the target strings.
    /// </summary>
        [Test]
        public void TestContainsAllOf()
        {
            string TargetString = "Hello, Extensification users!";
            Assert.IsTrue(TargetString.ContainsAllOf(new[] { "Extensification", "users" }));
            Assert.IsFalse(TargetString.ContainsAllOf(new[] { "Awesome", "developers" }));
        }

        /// <summary>
    /// Tests getting LRP from string
    /// </summary>
        [Test]
        public void TestLRP()
        {
            string TargetString = "Hello!";
            Assert.AreEqual(3, TargetString.LRP(4));
        }

        /// <summary>
    /// Tests checking to see if the string starts with any of the values
    /// </summary>
        [Test]
        public void TestStartsWithAnyOf()
        {
            string TargetString = "dotnet-hostfxr-3.1 dotnet-hostfxr-5.0 runtime-3.1 runtime-5.0 sdk-3.1 sdk-5.0";
            Assert.IsTrue(TargetString.StartsWithAnyOf(new[] { "dotnet", "sdk" }));
        }

        /// <summary>
    /// Tests checking to see if the string starts with all of the values
    /// </summary>
        [Test]
        public void TestStartsWithAllOf()
        {
            string TargetString = "dotnet-hostfxr-3.1 dotnet-hostfxr-5.0 runtime-3.1 runtime-5.0 sdk-3.1 sdk-5.0";
            Assert.IsTrue(TargetString.StartsWithAllOf(new[] { "dotnet", "dotnet-hostfxr" }));
        }

        /// <summary>
    /// Tests checking to see if the string ends with any of the values
    /// </summary>
        [Test]
        public void TestEndsWithAnyOf()
        {
            string TargetString = "dotnet-hostfxr-3.1 dotnet-hostfxr-5.0 runtime-3.1 runtime-5.0 sdk-3.1 sdk-5.0";
            Assert.IsTrue(TargetString.EndsWithAnyOf(new[] { "5.0", "3.1" }));
        }

        /// <summary>
    /// Tests checking to see if the string ends with all of the values
    /// </summary>
        [Test]
        public void TestEndsWithAllOf()
        {
            string TargetString = "dotnet-hostfxr-3.1 dotnet-hostfxr-5.0 runtime-3.1 runtime-5.0 sdk-3.1 sdk-5.0";
            Assert.IsTrue(TargetString.EndsWithAllOf(new[] { "5.0", "sdk-5.0" }));
        }

        /// <summary>
    /// Tests splitting a string with new lines (vbCrLf)
    /// </summary>
        [Test]
        public void TestSplitNewLinesCrLf()
        {
            string TargetString = "First line" + Constants.vbCrLf + "Second line" + Constants.vbCrLf + "Third line";
            var TargetArray = TargetString.SplitNewLines();
            Assert.IsTrue(TargetArray.Length == 3);
        }

        /// <summary>
    /// Tests splitting a string with new lines (vbCr)
    /// </summary>
        [Test]
        public void TestSplitNewLinesCr()
        {
            string TargetString = "First line" + Constants.vbCr + "Second line" + Constants.vbCr + "Third line";
            var TargetArray = TargetString.SplitNewLinesCr();
            Assert.IsTrue(TargetArray.Length == 3);
        }

        /// <summary>
    /// Tests splitting a string with new lines (vbLf)
    /// </summary>
        [Test]
        public void TestSplitNewLinesLf()
        {
            string TargetString = "First line" + Constants.vbLf + "Second line" + Constants.vbLf + "Third line";
            var TargetArray = TargetString.SplitNewLines();
            Assert.IsTrue(TargetArray.Length == 3);
        }

        /// <summary>
    /// Tests splitting a string with double quotes enclosed
    /// </summary>
        [Test]
        public void TestSplitEncloseDoubleQuotes()
        {
            string TargetString = "First \"Second Third\" Fourth";
            var TargetArray = TargetString.SplitEncloseDoubleQuotes(" ");
            Assert.IsTrue(TargetArray.Length == 3);
        }
        #endregion

        #region Removal
        /// <summary>
    /// Tests removing spaces from the beginning of the string
    /// </summary>
        [Test]
        public void TestRemoveSpacesFromBeginning()
        {
            string ExpectedString = "Extensification is awesome and is great!";
            string TargetString = "     Extensification is awesome and is great!";
            TargetString = TargetString.RemoveSpacesFromBeginning();
            Assert.AreEqual(ExpectedString, TargetString, "Removing space from beginning of string failed. Got \"{0}\"", TargetString);
        }

        /// <summary>
    /// Tests removing a letter from a string
    /// </summary>
        [Test]
        public void TestRemoveLetter()
        {
            string TargetString = "Helllo";
            TargetString = TargetString.RemoveLetter(4);
            Assert.AreEqual("Hello", TargetString);
        }

        /// <summary>
    /// Tests removing letters from a string
    /// </summary>
        [Test]
        public void TestRemoveLettersRange()
        {
            string TargetString = "Helllo";
            var CharRange = new char[] { 'l', 'o' };
            TargetString = TargetString.RemoveLettersRange(CharRange);
            Assert.AreEqual("He", TargetString);
        }

        /// <summary>
    /// Tests removing null characters or whitespaces at the end of the string
    /// </summary>
        [Test]
        public void TestRemoveNullsOrWhitespacesAtTheEnd()
        {
            string TargetString = "Hi!   ";
            StringExts.Removal.RemoveNullsOrWhitespacesAtTheEnd(ref TargetString);
            Assert.AreEqual("Hi!", TargetString);
        }

        /// <summary>
    /// Tests removing null characters or whitespaces at the end of the empty string
    /// </summary>
        [Test]
        public void TestRemoveNullsOrWhitespacesAtTheEndOnEmptyString()
        {
            string TargetString = "";
            StringExts.Removal.RemoveNullsOrWhitespacesAtTheEnd(ref TargetString);
        }

        /// <summary>
    /// Tests removing null characters or whitespaces at the beginning of the string
    /// </summary>
        [Test]
        public void TestRemoveNullsOrWhitespacesAtTheBeginning()
        {
            string TargetString = "   Hi!";
            StringExts.Removal.RemoveNullsOrWhitespacesAtTheBeginning(ref TargetString);
            Assert.AreEqual("Hi!", TargetString);
        }

        /// <summary>
    /// Tests removing null characters or whitespaces at the beginning of the empty string
    /// </summary>
        [Test]
        public void TestRemoveNullsOrWhitespacesAtTheBeginningOnEmptyString()
        {
            string TargetString = "";
            StringExts.Removal.RemoveNullsOrWhitespacesAtTheBeginning(ref TargetString);
        }
        #endregion

    }
}