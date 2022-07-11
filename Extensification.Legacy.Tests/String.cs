
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

using Extensification.Legacy.StringExts;
using NUnit.Framework;

namespace Extensification.Legacy.Tests.Extensification.Legacy.Tests
{

    [TestFixture]
    public class StringTests
    {

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

        /* TODO ERROR: Skipped IfDirectiveTrivia
        #If NET45 Then
        *//* TODO ERROR: Skipped DisabledTextTrivia
                ''' <summary>
                ''' Tests removing letters from a string
                ''' </summary>
                <Test> Public Sub TestEvaluate()
                    Dim TargetString As String = "2 + 5"
                    Dim ExpectedEvaluated As Integer = 7
                    Assert.AreEqual(ExpectedEvaluated, TargetString.Evaluate)
                End Sub
        *//* TODO ERROR: Skipped EndIfDirectiveTrivia
        #End If
        */
    }

}