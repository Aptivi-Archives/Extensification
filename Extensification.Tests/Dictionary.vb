Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Extensification.DictionaryExts

<TestClass>
Public Class DictionaryTests

    ''' <summary>
    ''' Tests getting key from value
    ''' </summary>
    <TestMethod>
    Sub TestGetKeyFromValue()
        Dim TargetDictionary As New Dictionary(Of String, Integer) From {{"Extensification", 0}, {"is", 1}, {"awesome!", 2}}
        Dim NeededNumber As Integer = 2
        Dim Returned As String = TargetDictionary.GetKeyFromValue(NeededNumber)
        Assert.AreEqual("awesome!", Returned, "Failed to get key from value. Got {0}", Returned)
    End Sub

    <TestMethod>
    Sub TestGetIndexOfKey()
        Dim TargetDictionary As New Dictionary(Of String, Integer) From {{"Extensification", 0}, {"is", 1}, {"awesome!", 2}}
        Dim NeededKey As String = "awesome!"
        Dim Returned As Integer = TargetDictionary.GetIndexOfKey(NeededKey)
        Assert.AreEqual(2, Returned, "Failed to get index of key. Got {0}", Returned)
    End Sub

    ''' <summary>
    ''' Tests counting full entries
    ''' </summary>
    <TestMethod>
    Public Sub TestCountFullEntries()
        Dim TargetDict As New Dictionary(Of String, String) From {{"Full", ""}, {"", "entry"}, {"Index", "5"}}
        Dim TargetDictObjects As New Dictionary(Of String, String) From {{"Object 1", 68}, {"Object 2", Nothing}}
        Assert.AreEqual(CLng(2), TargetDict.CountFullEntries)
        Assert.AreEqual(CLng(1), TargetDictObjects.CountFullEntries)
    End Sub

    ''' <summary>
    ''' Tests counting empty entries
    ''' </summary>
    <TestMethod>
    Public Sub TestCountEmptyEntries()
        Dim TargetDict As New Dictionary(Of String, String) From {{"Full", ""}, {"", "entry"}, {"Index", "5"}}
        Dim TargetDictObjects As New Dictionary(Of String, Object) From {{"Object 1", 68}, {"Object 2", Nothing}}
        Assert.AreEqual(CLng(1), TargetDict.CountEmptyEntries)
        Assert.AreEqual(CLng(1), TargetDictObjects.CountEmptyEntries)
    End Sub

    ''' <summary>
    ''' Tests getting indexes of full entries
    ''' </summary>
    <TestMethod>
    Public Sub TestGetIndexesOfFullEntries()
        Dim TargetDict As New Dictionary(Of String, String) From {{"Full", ""}, {"", "entry"}, {"Index", "5"}}
        Dim TargetDictObjects As New Dictionary(Of String, Object) From {{"Object 1", 68}, {"Object 2", Nothing}}
        Dim ExpectedIndexes() As Integer = {1, 2}
        Dim ExpectedIndexesObjects() As Integer = {0}
        Assert.IsNotNull(TargetDict.GetIndexesOfFullEntries)
        Assert.IsNotNull(TargetDictObjects.GetIndexesOfFullEntries)
        Assert.IsTrue(TargetDict.GetIndexesOfFullEntries.SequenceEqual(ExpectedIndexes))
        Assert.IsTrue(TargetDictObjects.GetIndexesOfFullEntries.SequenceEqual(ExpectedIndexesObjects))
    End Sub

    ''' <summary>
    ''' Tests getting indexes of empty entries
    ''' </summary>
    <TestMethod>
    Public Sub TestGetIndexesOfEmptyEntries()
        Dim TargetDict As New Dictionary(Of String, String) From {{"Full", ""}, {"", "entry"}, {"Index", "5"}}
        Dim TargetDictObjects As New Dictionary(Of String, Object) From {{"Object 1", 68}, {"Object 2", Nothing}}
        Dim ExpectedIndexes() As Integer = {0}
        Dim ExpectedIndexesObjects() As Integer = {1}
        Assert.IsNotNull(TargetDict.GetIndexesOfEmptyEntries)
        Assert.IsNotNull(TargetDictObjects.GetIndexesOfEmptyEntries)
        Assert.IsTrue(TargetDict.GetIndexesOfEmptyEntries.SequenceEqual(ExpectedIndexes))
        Assert.IsTrue(TargetDictObjects.GetIndexesOfEmptyEntries.SequenceEqual(ExpectedIndexesObjects))
    End Sub

    ''' <summary>
    ''' Tests adding an entry to dictionary if not found
    ''' </summary>
    <TestMethod>
    Public Sub TestAddIfNotFound()
        Dim TargetDict As New Dictionary(Of String, Integer)
        TargetDict.AddIfNotFound("String 1", 64)
        TargetDict.AddIfNotFound("String 1", 128)
        Assert.IsTrue(TargetDict.Count = 1)
    End Sub

#If NET45 Then
    ''' <summary>
    ''' Tests trying to add an entry to dictionary
    ''' </summary>
    <TestMethod>
    Public Sub TestTryAdd()
        Dim TargetDict As New Dictionary(Of String, Integer)
        Assert.IsTrue(TargetDict.TryAdd("Document number", 12))
        Assert.IsFalse(TargetDict.TryAdd("Document number", 13))
    End Sub
#End If

End Class

