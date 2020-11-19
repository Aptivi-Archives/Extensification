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

End Class

