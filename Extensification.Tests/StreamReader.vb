
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
Imports Extensification.StreamReaderExts
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass>
Public Class StreamReaderTests

#Region "Reading"
    ''' <summary>
    ''' Tests reading a line from the stream reader with the newline characters
    ''' </summary>
    <TestMethod>
    Public Sub TestReadLineWithNewLine()
        Dim TargetText As String = "Hello! This is Extensification." + Environment.NewLine +
                                   "You've reached the second line!"
        Dim TextStream As New MemoryStream(Text.Encoding.Default.GetBytes(TargetText))
        Dim TextStreamReader As New StreamReader(TextStream)
        Dim ParsedText As String = TextStreamReader.ReadLineWithNewLine
        Assert.IsTrue(ParsedText.EndsWith(Environment.NewLine))
    End Sub

    ''' <summary>
    ''' Tests reading lines
    ''' </summary>
    <TestMethod>
    Public Sub TestReadLines()
        Dim TargetText As String = "Hello! This is Extensification." + Environment.NewLine +
                                   "You've reached the second line!"
        Dim TextStream As New MemoryStream(Text.Encoding.Default.GetBytes(TargetText))
        Dim TextStreamReader As New StreamReader(TextStream)
        Dim ParsedText As String() = TextStreamReader.ReadLines
        Assert.IsTrue(ParsedText.Length = 2)
    End Sub

    ''' <summary>
    ''' Tests reading to end and seeking
    ''' </summary>
    <TestMethod>
    Public Sub TestReadToEndAndSeek()
        Dim TargetText As String = "Hello! This is Extensification."
        Dim TextStream As New MemoryStream(Text.Encoding.Default.GetBytes(TargetText))
        Dim TextStreamReader As New StreamReader(TextStream)
        Dim ParsedText As String = TextStreamReader.ReadToEndAndSeek
        Assert.IsTrue(TextStreamReader.BaseStream.Position = 0)
    End Sub
#End Region

End Class
