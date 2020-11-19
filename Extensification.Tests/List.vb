Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Extensification.ListExts

<TestClass>
Public Class ListTests

    ''' <summary>
    ''' Tests converting list to array list
    ''' </summary>
    <TestMethod>
    Public Sub TestToArrayList()
        Dim TargetList As New List(Of String) From {"Test converting", "target list", "to array list."}
        Dim TargetArrayList As ArrayList = TargetList.ToArrayList
        Assert.IsNotNull(TargetArrayList)
        Assert.IsTrue(TargetArrayList.Count > 0)
    End Sub

    ''' <summary>
    ''' Tests getting index from entry
    ''' </summary>
    <TestMethod>
    Public Sub TestGetIndexFromEntry()
        Dim TargetList As New List(Of String) From {"Test getting", "index from", "array list entry."}
        Dim ExpectedIndex As Integer = 1
        Assert.AreEqual(ExpectedIndex, TargetList.GetIndexFromEntry("index from")(0))
    End Sub

    ''' <summary>
    ''' Tests counting full entries
    ''' </summary>
    <TestMethod>
    Public Sub TestCountFullEntries()
        Dim TargetList As New List(Of String) From {"Full", "", "", "entry", "", "5"}
        Dim TargetListObjects As New List(Of Object) From {12, Nothing, 32, 48}
        Assert.AreEqual(CLng(3), TargetList.CountFullEntries)
        Assert.AreEqual(CLng(3), TargetListObjects.CountFullEntries)
    End Sub

    ''' <summary>
    ''' Tests counting empty entries
    ''' </summary>
    <TestMethod>
    Public Sub TestCountEmptyEntries()
        Dim TargetList As New List(Of String) From {"Full", "", "", "entry", "", "", "6"}
        Dim TargetListObjects As New List(Of Object) From {12, Nothing, 32, 48}
        Assert.AreEqual(CLng(4), TargetList.CountEmptyEntries)
        Assert.AreEqual(CLng(1), TargetListObjects.CountEmptyEntries)
    End Sub

End Class
