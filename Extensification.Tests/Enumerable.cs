
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

using Extensification.EnumerableExts;
using System.Collections.Generic;
using NUnit.Framework;

namespace Extensification.Tests
{

    [TestFixture]
    public class EnumerableTests
    {

        #region Addition
        /* TODO ERROR: Skipped IfDirectiveTrivia
        #If Not NETCOREAPP Then
        *//* TODO ERROR: Skipped DisabledTextTrivia
            /// <summary>
            /// Tests appending a value to the end of a list
            /// </summary>
            <Test>
            Public Sub TestAppendList()
                Dim TargetEnum As New List(Of String) From {"Welcome", "to"}
                TargetEnum = TargetEnum.Append("Extensification").ToList
                Assert.IsTrue(TargetEnum.Contains("Extensification"))
            End Sub

            /// <summary>
            /// Tests appending a value to the end of a string
            /// </summary>
            <Test>
            Public Sub TestAppendString()
                Dim TargetString As String = "Welcom"
                TargetString = String.Join("", TargetString.Append("e"))
                Assert.IsTrue(TargetString = "Welcome")
            End Sub
        *//* TODO ERROR: Skipped EndIfDirectiveTrivia
        #End If
        */
        #endregion

        #region Manipulation
        /// <summary>
        /// Tests stringifying a char enumerable
        /// </summary>
        [Test]
        public void TestStringify()
        {
            IEnumerable<char> TargetArray = new[] { 'H', 'e', 'l', 'l', 'o' };
            Assert.AreEqual("Hello", TargetArray.Stringify());
        }
        #endregion

    }
}