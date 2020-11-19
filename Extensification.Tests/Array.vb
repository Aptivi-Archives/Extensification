Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Extensification.ArrayExts

<TestClass>
Public Class ArrayTests

    ''' <summary>
    ''' Tests adding an entry to array
    ''' </summary>
    <TestMethod>
    Public Sub TestAdd()
        Dim TargetArray() As Integer = {2, 3}
        TargetArray = TargetArray.Add(4)
        Assert.IsTrue(TargetArray.Count = 3)
    End Sub

    ''' <summary>
    ''' Tests removing an entry to array
    ''' </summary>
    <TestMethod>
    Public Sub TestRemove()
        Dim TargetArray() As Integer = {2, 3, 4}
        TargetArray = TargetArray.Remove(4)
        Assert.IsTrue(TargetArray.Count = 2)
    End Sub

    ''' <summary>
    ''' Tests converting array to array list
    ''' </summary>
    <TestMethod>
    Public Sub TestToArrayList()
        Dim TargetArray As String() = {"Test converting", "target array", "to array list."}
        Dim TargetList As ArrayList = TargetArray.ToArrayList
        Assert.IsNotNull(TargetList)
        Assert.IsTrue(TargetList.Count > 0)
    End Sub

    ''' <summary>
    ''' Tests getting index from entry
    ''' </summary>
    <TestMethod>
    Public Sub TestGetIndexFromEntry()
        Dim TargetArray As String() = {"Test getting", "index from", "array entry."}
        Dim ExpectedIndex As Integer = 1
        Dim ActualIndex As String() = TargetArray.GetIndexFromEntry("index from")
        Assert.AreEqual(ExpectedIndex, ActualIndex(0))
    End Sub

    ''' <summary>
    ''' Tests counting full entries
    ''' </summary>
    <TestMethod>
    Public Sub TestCountFullEntries()
        Dim TargetArray() As String = {"", "Full", "", "Entry", ""}
        Dim TargetArrayObjects As String() = {4, Nothing, Nothing}
        Assert.AreEqual(CLng(2), TargetArray.CountFullEntries)
        Assert.AreEqual(CLng(1), TargetArrayObjects.CountFullEntries)
    End Sub

    ''' <summary>
    ''' Tests counting empty entries
    ''' </summary>
    <TestMethod>
    Public Sub TestCountEmptyEntries()
        Dim TargetArray() As String = {"", "Full", "", "Entry", ""}
        Dim TargetArrayObjects As String() = {4, Nothing, Nothing}
        Assert.AreEqual(CLng(3), TargetArray.CountEmptyEntries)
        Assert.AreEqual(CLng(2), TargetArrayObjects.CountEmptyEntries)
    End Sub

End Class
