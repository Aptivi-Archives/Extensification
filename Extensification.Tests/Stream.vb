
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

Imports System.IO
Imports Extensification.StreamExts
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass>
Public Class StreamTests

#Region "Manipulation"
    ''' <summary>
    ''' Tests trying to seek in a stream
    ''' </summary>
    <TestMethod>
    Public Sub TestTrySeek()
        Dim TargetText As String = "Hello! This is Extensification." + Environment.NewLine +
                                   "You've reached the second line!"
        Dim TextStream As New MemoryStream(Text.Encoding.Default.GetBytes(TargetText))
        Assert.IsTrue(TextStream.TrySeek(4, SeekOrigin.Begin))
        Assert.IsTrue(TextStream.Position = 4)
    End Sub

    ''' <summary>
    ''' Tests trying to seek in a stream
    ''' </summary>
    <TestMethod>
    Public Sub TestTrySetLength()
        Dim TextStream As New MemoryStream(8)
        Assert.IsTrue(TextStream.TrySetLength(16))
        Assert.IsTrue(TextStream.Length = 16)
    End Sub

    ''' <summary>
    ''' Tests trying to flush a stream
    ''' </summary>
    <TestMethod>
    Public Sub TestTryFlush()
        Dim TextStream As New MemoryStream(8)
        TextStream.Write(Text.Encoding.Default.GetBytes("Hello!!!"), 0, 8)
        Assert.IsTrue(TextStream.TryFlush)
    End Sub

    ''' <summary>
    ''' Tests trying to get buffer from a stream
    ''' </summary>
    <TestMethod>
    Public Sub TestTryGetBuffer()
        Dim TextStream As New MemoryStream(8)
        Dim TextStreamArray As New ArraySegment(Of Byte)
        TextStream.Write(Text.Encoding.Default.GetBytes("Hello!!!"), 0, 8)
        TextStream.Seek(0, SeekOrigin.Begin)
        Assert.IsTrue(TextStream.TryGetBuffer(TextStreamArray))
        Assert.IsTrue(TextStreamArray.Count = 8)
    End Sub
#End Region
#Region "Reading"
    ''' <summary>
    ''' Tests trying to read from a stream
    ''' </summary>
    <TestMethod>
    Public Sub TestTryRead()
        Dim TargetText As String = "Hello! This is Extensification." + Environment.NewLine +
                                   "You've reached the second line!"
        Dim TextStream As New MemoryStream(Text.Encoding.Default.GetBytes(TargetText))
        Dim ArrayBuffer(8) As Byte
        Assert.IsTrue(TextStream.TryRead(ArrayBuffer, 0, 8))
    End Sub

    ''' <summary>
    ''' Tests trying to read a byte from a stream
    ''' </summary>
    <TestMethod>
    Public Sub TestTryReadByte()
        Dim TargetText As String = "Hello!"
        Dim TextStream As New MemoryStream(Text.Encoding.Default.GetBytes(TargetText))
        Dim ActualByte As Integer = TextStream.TryReadByte
        Assert.AreEqual(72, ActualByte)
    End Sub
#End Region
#Region "Writing"
    ''' <summary>
    ''' Tests trying to write to a stream
    ''' </summary>
    <TestMethod>
    Public Sub TestTryWrite()
        Dim TargetText As String = "Hello! This is Extensification." + Environment.NewLine +
                                   "You've reached the second line!"
        Dim TextStream As New MemoryStream(Text.Encoding.Default.GetBytes(TargetText & "    "))
        Dim ArrayBuffer() As Byte = {1, 2, 3, 4}
        TextStream.Seek(-4, SeekOrigin.End)
        Assert.IsTrue(TextStream.TryWrite(ArrayBuffer, 0, 4))
    End Sub

    ''' <summary>
    ''' Tests trying to write a byte to a stream
    ''' </summary>
    <TestMethod>
    Public Sub TestTryWriteByte()
        Dim TargetText As String = "Hello"
        Dim TextStream As New MemoryStream(Text.Encoding.Default.GetBytes(TargetText & " "))
        TextStream.Seek(-1, SeekOrigin.End)
        Assert.IsTrue(TextStream.TryWriteByte(Text.Encoding.Default.GetBytes({"!"})(0)))
    End Sub
#End Region

End Class
