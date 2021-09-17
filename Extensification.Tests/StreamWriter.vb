
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
Imports Extensification.StreamWriterExts
Imports Extensification.StreamReaderExts
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass>
Public Class StreamWriterTests

#Region "Writing"
    ''' <summary>
    ''' Tests reading lines
    ''' </summary>
    <TestMethod>
    Public Sub TestWriteLines()
        Dim NewTexts As String() = {"One, two", "three, four"}
        Dim TextStream As New MemoryStream()
        Dim TextStreamWriter As New StreamWriter(TextStream)
        TextStreamWriter.WriteLines(NewTexts)
        Dim TextStreamReader As New StreamReader(TextStreamWriter.BaseStream)
        Assert.IsTrue(TextStreamReader.ReadLines.Length = 2)
    End Sub
    ''' <summary>
    ''' Tests reading lines
    ''' </summary>
    <TestMethod>
    Public Sub TestWriteLineAndSeek()
        Dim NewText As String = "One, two"
        Dim TextStream As New MemoryStream()
        Dim TextStreamWriter As New StreamWriter(TextStream)
        TextStreamWriter.WriteLineAndSeek(NewText)
        Dim TextStreamReader As New StreamReader(TextStreamWriter.BaseStream)
        Assert.IsTrue(TextStreamReader.ReadLine.Length = NewText.Length)
    End Sub
#End Region

End Class
