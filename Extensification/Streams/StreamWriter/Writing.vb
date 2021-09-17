
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
Imports System.Runtime.CompilerServices
Imports System.Text

Namespace StreamWriterExts
    Public Module Writing

        ''' <summary>
        ''' Writes all the lines to the stream and seeks to the beginning, if possible.
        ''' </summary>
        ''' <param name="writer">The stream writer</param>
        <Extension>
        Public Sub WriteLines(ByRef writer As StreamWriter, Lines() As String)
            For Each Line As String In Lines
                writer.WriteLine(Line)
                If Not writer.AutoFlush Then writer.Flush()
            Next
            If writer.BaseStream.CanSeek Then writer.BaseStream.Seek(0, SeekOrigin.Begin)
        End Sub

        ''' <summary>
        ''' Writes the line to the stream and seeks to the beginning, if possible.
        ''' </summary>
        ''' <param name="writer">The stream writer</param>
        <Extension>
        Public Sub WriteLineAndSeek(ByRef writer As StreamWriter, Line As String)
            writer.WriteLine(Line)
            If Not writer.AutoFlush Then writer.Flush()
            If writer.BaseStream.CanSeek Then writer.BaseStream.Seek(0, SeekOrigin.Begin)
        End Sub

    End Module
End Namespace
