
'    Extensification  Copyright (C) 2020-2021  EoflaOE
'
'    This file is part of Extensification
'
'    Extensification is free software: you can redistribute it and/or modify
'    it under the terms of the GNU General Public License as published by
'    the Free Software Foundation, either version 3 of the License, or
'    (at your option) any later version.
'
'    Extensification is distributed in the hope that it will be useful,
'    but WITHOUT ANY WARRANTY; without even the implied warranty of
'    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
'    GNU General Public License for more details.
'
'    You should have received a copy of the GNU General Public License
'    along with this program.  If not, see <https://www.gnu.org/licenses/>.

Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Newtonsoft.Json.Linq
Imports Extensification.External.Newtonsoft.Json.JPropertyExts

<TestClass>
Public Class JPropertyTests

    ''' <summary>
    ''' Tests getting property name ending with a specified string
    ''' </summary>
    <TestMethod>
    Sub TestGetPropertyNameEndingWith()
        Dim JsonString As String = My.Resources.JSON_PropertyTest1
        Dim JsonToken As JToken = JToken.Parse(JsonString)
        Dim JsonProperty As String = JsonToken.First.GetPropertyNameEndingWith("ver")
        Assert.AreEqual("002#0#0#appver", JsonProperty)
    End Sub

    ''' <summary>
    ''' Tests the logic of getting property name ending with a specified string should return nothing if the property doesn't exist
    ''' </summary>
    <TestMethod>
    Sub TestGetPropertyNameEndingWithShouldReturnNothingIfNotExists()
        Dim JsonString As String = My.Resources.JSON_PropertyTest1
        Dim JsonToken As JToken = JToken.Parse(JsonString)
        Dim JsonProperty As String = JsonToken.First.GetPropertyNameEndingWith("version")
        Assert.AreEqual("", JsonProperty)
    End Sub

    ''' <summary>
    ''' Tests getting property name beginning with a specified string
    ''' </summary>
    <TestMethod>
    Sub TestGetPropertyNameStartingWith()
        Dim JsonString As String = My.Resources.JSON_PropertyTest1
        Dim JsonToken As JToken = JToken.Parse(JsonString)
        Dim JsonProperty As String = JsonToken.First.GetPropertyNameStartingWith("003#0")
        Assert.AreEqual("003#0#0#released", JsonProperty)
    End Sub

    ''' <summary>
    ''' Tests the logic of getting property name beginning with a specified string should return nothing if the property doesn't exist
    ''' </summary>
    <TestMethod>
    Sub TestGetPropertyNameStartingWithShouldReturnNothingIfNotExists()
        Dim JsonString As String = My.Resources.JSON_PropertyTest1
        Dim JsonToken As JToken = JToken.Parse(JsonString)
        Dim JsonProperty As String = JsonToken.First.GetPropertyNameStartingWith("003#2")
        Assert.AreEqual("", JsonProperty)
    End Sub

    ''' <summary>
    ''' Tests getting property name containing a specified string
    ''' </summary>
    <TestMethod>
    Sub TestGetPropertyNameContaining()
        Dim JsonString As String = My.Resources.JSON_PropertyTest1
        Dim JsonToken As JToken = JToken.Parse(JsonString)
        Dim JsonProperty As String = JsonToken.First.GetPropertyNameContaining("ppv")
        Assert.AreEqual("002#0#0#appver", JsonProperty)
    End Sub

    ''' <summary>
    ''' Tests the logic of getting property name containing a specified string should return nothing if the property doesn't exist
    ''' </summary>
    <TestMethod>
    Sub TestGetPropertyNameContainingShouldReturnNothingIfNotExists()
        Dim JsonString As String = My.Resources.JSON_PropertyTest1
        Dim JsonToken As JToken = JToken.Parse(JsonString)
        Dim JsonProperty As String = JsonToken.First.GetPropertyNameContaining("sion")
        Assert.AreEqual("", JsonProperty)
    End Sub

    ''' <summary>
    ''' Tests selecting a token that has its key ending with a specified string
    ''' </summary>
    <TestMethod>
    Sub TestSelectTokenKeyEndingWith()
        Dim JsonString As String = My.Resources.JSON_PropertyTest1
        Dim JsonToken As JToken = JToken.Parse(JsonString)
        Dim JsonProperty As JToken = JsonToken.First.SelectTokenKeyEndingWith("ver")
        Assert.IsNotNull(JsonProperty)
    End Sub

    ''' <summary>
    ''' Tests selecting a token that has its key that contains the whitespace ending with a specified string
    ''' </summary>
    <TestMethod>
    Sub TestSelectTokenKeyThatHasWhitespaceEndingWith()
        Dim JsonString As String = My.Resources.JSON_InxiExample
        Dim JsonToken As JToken = JToken.Parse(JsonString)
        Dim JsonProperty As JToken = JsonToken.SelectTokenKeyEndingWith("CPU")(0).SelectTokenKeyEndingWith("L2 cache")
        Assert.IsNotNull(JsonProperty)
    End Sub

    ''' <summary>
    ''' Tests the logic of selecting a token that has its key ending with a specified string should return nothing if the property doesn't exist
    ''' </summary>
    <TestMethod>
    Sub TestSelectTokenKeyEndingWithShouldReturnNothingIfNotExists()
        Dim JsonString As String = My.Resources.JSON_PropertyTest1
        Dim JsonToken As JToken = JToken.Parse(JsonString)
        Dim JsonProperty As JToken = JsonToken.First.SelectTokenKeyEndingWith("version")
        Assert.IsNull(JsonProperty)
    End Sub

    ''' <summary>
    ''' Tests selecting a token that has its key beginning with a specified string
    ''' </summary>
    <TestMethod>
    Sub TestSelectTokenKeyStartingWith()
        Dim JsonString As String = My.Resources.JSON_PropertyTest1
        Dim JsonToken As JToken = JToken.Parse(JsonString)
        Dim JsonProperty As JToken = JsonToken.First.SelectTokenKeyStartingWith("003#0")
        Assert.IsNotNull(JsonProperty)
    End Sub

    ''' <summary>
    ''' Tests selecting a token that has its key that contains the whitespace beginning with a specified string
    ''' </summary>
    <TestMethod>
    Sub TestSelectTokenKeyThatHasWhitespaceStartingWith()
        Dim JsonString As String = My.Resources.JSON_InxiExample
        Dim JsonToken As JToken = JToken.Parse(JsonString)
        Dim JsonProperty As JToken = JsonToken.SelectTokenKeyEndingWith("CPU")(0).SelectTokenKeyStartingWith("006#0")
        Assert.IsNotNull(JsonProperty)
    End Sub

    ''' <summary>
    ''' Tests the logic of selecting a token that has its key beginning with a specified string should return nothing if the property doesn't exist
    ''' </summary>
    <TestMethod>
    Sub TestSelectTokenKeyStartingWithShouldReturnNothingIfNotExists()
        Dim JsonString As String = My.Resources.JSON_PropertyTest1
        Dim JsonToken As JToken = JToken.Parse(JsonString)
        Dim JsonProperty As JToken = JsonToken.First.SelectTokenKeyStartingWith("003#2")
        Assert.IsNull(JsonProperty)
    End Sub

    ''' <summary>
    ''' Tests selecting a token that has its key containing the specified string
    ''' </summary>
    <TestMethod>
    Sub TestSelectTokenKeyContaining()
        Dim JsonString As String = My.Resources.JSON_PropertyTest1
        Dim JsonToken As JToken = JToken.Parse(JsonString)
        Dim JsonProperty As JToken = JsonToken.First.SelectTokenKeyContaining("ppv")
        Assert.IsNotNull(JsonProperty)
    End Sub

    ''' <summary>
    ''' Tests selecting a token that has its key that contains the whitespace containing the specified string
    ''' </summary>
    <TestMethod>
    Sub TestSelectTokenKeyThatHasWhitespaceContaining()
        Dim JsonString As String = My.Resources.JSON_InxiExample
        Dim JsonToken As JToken = JToken.Parse(JsonString)
        Dim JsonProperty As JToken = JsonToken.SelectTokenKeyEndingWith("CPU")(0).SelectTokenKeyContaining("L2")
        Assert.IsNotNull(JsonProperty)
    End Sub

    ''' <summary>
    ''' Tests the logic of selecting a token that has its key containing the specified string should return nothing if the property doesn't exist
    ''' </summary>
    <TestMethod>
    Sub TestSelectTokenKeyContainingShouldReturnNothingIfNotExists()
        Dim JsonString As String = My.Resources.JSON_PropertyTest1
        Dim JsonToken As JToken = JToken.Parse(JsonString)
        Dim JsonProperty As JToken = JsonToken.First.SelectTokenKeyContaining("sion")
        Assert.IsNull(JsonProperty)
    End Sub

End Class
