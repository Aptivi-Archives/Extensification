
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

using Extensification.External.Newtonsoft.Json.JPropertyExts;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Extensification.External.Tests
{

    [TestFixture]
    public class JPropertyTests
    {

        #region Getting
        /// <summary>
    /// Tests getting property name ending with a specified string
    /// </summary>
        [Test]
        public void TestGetPropertyNameEndingWith()
        {
            string JsonString = My.Resources.Resources.JSON_PropertyTest1;
            var JsonToken = JToken.Parse(JsonString);
            string JsonProperty = JsonToken.First.GetPropertyNameEndingWith("ver");
            Assert.AreEqual("002#0#0#appver", JsonProperty);
        }

        /// <summary>
    /// Tests the logic of getting property name ending with a specified string should return nothing if the property doesn't exist
    /// </summary>
        [Test]
        public void TestGetPropertyNameEndingWithShouldReturnNothingIfNotExists()
        {
            string JsonString = My.Resources.Resources.JSON_PropertyTest1;
            var JsonToken = JToken.Parse(JsonString);
            string JsonProperty = JsonToken.First.GetPropertyNameEndingWith("version");
            Assert.AreEqual("", JsonProperty);
        }

        /// <summary>
    /// Tests getting property name beginning with a specified string
    /// </summary>
        [Test]
        public void TestGetPropertyNameStartingWith()
        {
            string JsonString = My.Resources.Resources.JSON_PropertyTest1;
            var JsonToken = JToken.Parse(JsonString);
            string JsonProperty = JsonToken.First.GetPropertyNameStartingWith("003#0");
            Assert.AreEqual("003#0#0#released", JsonProperty);
        }

        /// <summary>
    /// Tests the logic of getting property name beginning with a specified string should return nothing if the property doesn't exist
    /// </summary>
        [Test]
        public void TestGetPropertyNameStartingWithShouldReturnNothingIfNotExists()
        {
            string JsonString = My.Resources.Resources.JSON_PropertyTest1;
            var JsonToken = JToken.Parse(JsonString);
            string JsonProperty = JsonToken.First.GetPropertyNameStartingWith("003#2");
            Assert.AreEqual("", JsonProperty);
        }

        /// <summary>
    /// Tests getting property name containing a specified string
    /// </summary>
        [Test]
        public void TestGetPropertyNameContaining()
        {
            string JsonString = My.Resources.Resources.JSON_PropertyTest1;
            var JsonToken = JToken.Parse(JsonString);
            string JsonProperty = JsonToken.First.GetPropertyNameContaining("ppv");
            Assert.AreEqual("002#0#0#appver", JsonProperty);
        }

        /// <summary>
    /// Tests the logic of getting property name containing a specified string should return nothing if the property doesn't exist
    /// </summary>
        [Test]
        public void TestGetPropertyNameContainingShouldReturnNothingIfNotExists()
        {
            string JsonString = My.Resources.Resources.JSON_PropertyTest1;
            var JsonToken = JToken.Parse(JsonString);
            string JsonProperty = JsonToken.First.GetPropertyNameContaining("sion");
            Assert.AreEqual("", JsonProperty);
        }

        /// <summary>
    /// Tests the logic of getting properties that has the specific type in value
    /// </summary>
        [Test]
        public void TestGetPropertiesTypeInValue()
        {
            string JsonString = My.Resources.Resources.JSON_PropertyTest1;
            var JsonToken = JToken.Parse(JsonString);
            var JsonProperty = JsonToken.First.GetPropertiesTypeInValue(JTokenType.String);
            Assert.IsTrue(JsonProperty.Count != 0);
        }

        /// <summary>
    /// Tests the logic of getting properties that has the specific type in value should return nothing if the property of specific type doesn't exist
    /// </summary>
        [Test]
        public void TestGetPropertiesTypeInValueShouldReturnNothingIfNotExists()
        {
            string JsonString = My.Resources.Resources.JSON_PropertyTest1;
            var JsonToken = JToken.Parse(JsonString);
            var JsonProperty = JsonToken.First.GetPropertiesTypeInValue(JTokenType.Boolean);
            Assert.IsTrue(JsonProperty.Count == 0);
        }

        /// <summary>
    /// Tests the logic of getting properties that has the specific type in value should return everything if the type is set to <see cref="JTokenType.None"/>
    /// </summary>
        [Test]
        public void TestGetPropertiesTypeInValueShouldReturnEverythingIfNoTokenTypeSpecified()
        {
            string JsonString = My.Resources.Resources.JSON_PropertyTest1;
            var JsonToken = JToken.Parse(JsonString);
            var JsonProperty = JsonToken.First.GetPropertiesTypeInValue(JTokenType.None);
            Assert.IsTrue(JsonProperty.Count == 4);
        }
        #endregion

        #region Querying
        /// <summary>
    /// Tests selecting a token that has its key ending with a specified string
    /// </summary>
        [Test]
        public void TestSelectTokenKeyEndingWith()
        {
            string JsonString = My.Resources.Resources.JSON_PropertyTest1;
            var JsonToken = JToken.Parse(JsonString);
            var JsonProperty = JsonToken.First.SelectTokenKeyEndingWith("ver");
            Assert.IsNotNull(JsonProperty);
        }

        /// <summary>
    /// Tests selecting a token that has its key that contains the whitespace ending with a specified string
    /// </summary>
        [Test]
        public void TestSelectTokenKeyThatHasWhitespaceEndingWith()
        {
            string JsonString = My.Resources.Resources.JSON_InxiExample;
            var JsonToken = JToken.Parse(JsonString);
            var JsonProperty = JsonToken.SelectTokenKeyEndingWith("CPU")[0].SelectTokenKeyEndingWith("L2 cache");
            Assert.IsNotNull(JsonProperty);
        }

        /// <summary>
    /// Tests selecting a token that has its key that contains the special character ending with a specified string
    /// </summary>
        [Test]
        public void TestSelectTokenKeyThatHasSpecialCharacterEndingWith()
        {
            string JsonString = My.Resources.Resources.JSON_PropertyTest2;
            var JsonToken = JToken.Parse(JsonString);
            var JsonProperty = JsonToken.First.SelectTokenKeyEndingWith("hex");
            Assert.IsNotNull(JsonProperty);
        }

        /// <summary>
    /// Tests the logic of selecting a token that has its key ending with a specified string should return nothing if the property doesn't exist
    /// </summary>
        [Test]
        public void TestSelectTokenKeyEndingWithShouldReturnNothingIfNotExists()
        {
            string JsonString = My.Resources.Resources.JSON_PropertyTest1;
            var JsonToken = JToken.Parse(JsonString);
            var JsonProperty = JsonToken.First.SelectTokenKeyEndingWith("version");
            Assert.IsNull(JsonProperty);
        }

        /// <summary>
    /// Tests selecting a token that has its key beginning with a specified string
    /// </summary>
        [Test]
        public void TestSelectTokenKeyStartingWith()
        {
            string JsonString = My.Resources.Resources.JSON_PropertyTest1;
            var JsonToken = JToken.Parse(JsonString);
            var JsonProperty = JsonToken.First.SelectTokenKeyStartingWith("003#0");
            Assert.IsNotNull(JsonProperty);
        }

        /// <summary>
    /// Tests selecting a token that has its key that contains the whitespace beginning with a specified string
    /// </summary>
        [Test]
        public void TestSelectTokenKeyThatHasWhitespaceStartingWith()
        {
            string JsonString = My.Resources.Resources.JSON_InxiExample;
            var JsonToken = JToken.Parse(JsonString);
            var JsonProperty = JsonToken.SelectTokenKeyEndingWith("CPU")[0].SelectTokenKeyStartingWith("006#0");
            Assert.IsNotNull(JsonProperty);
        }

        /// <summary>
    /// Tests selecting a token that has its key that contains the special character beginning with a specified string
    /// </summary>
        [Test]
        public void TestSelectTokenKeyThatHasSpecialCharacterStartingWith()
        {
            string JsonString = My.Resources.Resources.JSON_PropertyTest2;
            var JsonToken = JToken.Parse(JsonString);
            var JsonProperty = JsonToken.First.SelectTokenKeyStartingWith("movie's");
            Assert.IsNotNull(JsonProperty);
        }

        /// <summary>
    /// Tests the logic of selecting a token that has its key beginning with a specified string should return nothing if the property doesn't exist
    /// </summary>
        [Test]
        public void TestSelectTokenKeyStartingWithShouldReturnNothingIfNotExists()
        {
            string JsonString = My.Resources.Resources.JSON_PropertyTest1;
            var JsonToken = JToken.Parse(JsonString);
            var JsonProperty = JsonToken.First.SelectTokenKeyStartingWith("003#2");
            Assert.IsNull(JsonProperty);
        }

        /// <summary>
    /// Tests selecting a token that has its key containing the specified string
    /// </summary>
        [Test]
        public void TestSelectTokenKeyContaining()
        {
            string JsonString = My.Resources.Resources.JSON_PropertyTest1;
            var JsonToken = JToken.Parse(JsonString);
            var JsonProperty = JsonToken.First.SelectTokenKeyContaining("ppv");
            Assert.IsNotNull(JsonProperty);
        }

        /// <summary>
    /// Tests selecting a token that has its key that contains the whitespace containing the specified string
    /// </summary>
        [Test]
        public void TestSelectTokenKeyThatHasWhitespaceContaining()
        {
            string JsonString = My.Resources.Resources.JSON_InxiExample;
            var JsonToken = JToken.Parse(JsonString);
            var JsonProperty = JsonToken.SelectTokenKeyEndingWith("CPU")[0].SelectTokenKeyContaining("L2");
            Assert.IsNotNull(JsonProperty);
        }

        /// <summary>
    /// Tests selecting a token that has its key that contains the special character containing the specified string
    /// </summary>
        [Test]
        public void TestSelectTokenKeyThatHasSpecialCharacterContaining()
        {
            string JsonString = My.Resources.Resources.JSON_PropertyTest2;
            var JsonToken = JToken.Parse(JsonString);
            var JsonProperty = JsonToken.First.SelectTokenKeyContaining("e's");
            Assert.IsNotNull(JsonProperty);
        }

        /// <summary>
    /// Tests the logic of selecting a token that has its key containing the specified string should return nothing if the property doesn't exist
    /// </summary>
        [Test]
        public void TestSelectTokenKeyContainingShouldReturnNothingIfNotExists()
        {
            string JsonString = My.Resources.Resources.JSON_PropertyTest1;
            var JsonToken = JToken.Parse(JsonString);
            var JsonProperty = JsonToken.First.SelectTokenKeyContaining("sion");
            Assert.IsNull(JsonProperty);
        }
        #endregion

    }
}