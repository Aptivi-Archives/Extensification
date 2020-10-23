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

End Class
