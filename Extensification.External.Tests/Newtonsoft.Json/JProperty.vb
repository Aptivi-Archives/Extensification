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
