Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Extensification.ArrayListExts

<TestClass>
Public Class ArrayListTests

    ''' <summary>
    ''' Tests converting array list to list
    ''' </summary>
    <TestMethod>
    Public Sub TestToArrayList()
        Dim TargetArrayList As New ArrayList From {"Test converting", "target array list", "to list."}
        Dim TargetList As List(Of Object) = TargetArrayList.ToList
        Assert.IsNotNull(TargetList)
        Assert.IsTrue(TargetList.Count > 0)
    End Sub

    ''' <summary>
    ''' Tests getting index from entry
    ''' </summary>
    <TestMethod>
    Public Sub TestGetIndexOfEntry()
        Dim TargetList As New ArrayList From {"Test getting", "index from", "array list entry."}
        Dim ExpectedIndex As Integer = 1
        Assert.AreEqual(ExpectedIndex, TargetList.GetIndexOfEntry("index from")(0))
    End Sub

    ''' <summary>
    ''' Tests counting full entries
    ''' </summary>
    <TestMethod>
    Public Sub TestCountFullEntries()
        Dim TargetArray As New ArrayList From {"", "Full", "", "Entry", ""}
        Dim TargetArrayObjects As New ArrayList From {4, Nothing, Nothing}
        Assert.AreEqual(CLng(2), TargetArray.CountFullEntries)
        Assert.AreEqual(CLng(1), TargetArrayObjects.CountFullEntries)
    End Sub

    ''' <summary>
    ''' Tests counting empty entries
    ''' </summary>
    <TestMethod>
    Public Sub TestCountEmptyEntries()
        Dim TargetArray As New ArrayList From {"", "Full", "", "Entry", ""}
        Dim TargetArrayObjects As New ArrayList From {4, Nothing, Nothing}
        Assert.AreEqual(CLng(3), TargetArray.CountEmptyEntries)
        Assert.AreEqual(CLng(2), TargetArrayObjects.CountEmptyEntries)
    End Sub

    ''' <summary>
    ''' Tests getting indexes of full entries
    ''' </summary>
    <TestMethod>
    Public Sub TestGetIndexesOfFullEntries()
        Dim TargetArray As New ArrayList From {"", "Full", "", "Entry", ""}
        Dim TargetArrayObjects As New ArrayList From {4, Nothing, Nothing}
        Dim ExpectedIndexes() As Integer = {1, 3}
        Dim ExpectedIndexesObjects() As Integer = {0}
        Assert.IsNotNull(TargetArray.GetIndexesOfFullEntries)
        Assert.IsNotNull(TargetArrayObjects.GetIndexesOfFullEntries)
        Assert.IsTrue(TargetArray.GetIndexesOfFullEntries.SequenceEqual(ExpectedIndexes))
        Assert.IsTrue(TargetArrayObjects.GetIndexesOfFullEntries.SequenceEqual(ExpectedIndexesObjects))
    End Sub

    ''' <summary>
    ''' Tests getting indexes of empty entries
    ''' </summary>
    <TestMethod>
    Public Sub TestGetIndexesOfEmptyEntries()
        Dim TargetArray As New ArrayList From {"", "Full", "", "Entry", ""}
        Dim TargetArrayObjects As New ArrayList From {4, Nothing, Nothing}
        Dim ExpectedIndexes() As Integer = {0, 2, 4}
        Dim ExpectedIndexesObjects() As Integer = {1, 2}
        Assert.IsNotNull(TargetArray.GetIndexesOfEmptyEntries)
        Assert.IsNotNull(TargetArrayObjects.GetIndexesOfEmptyEntries)
        Assert.IsTrue(TargetArray.GetIndexesOfEmptyEntries.SequenceEqual(ExpectedIndexes))
        Assert.IsTrue(TargetArrayObjects.GetIndexesOfEmptyEntries.SequenceEqual(ExpectedIndexesObjects))
    End Sub

End Class
