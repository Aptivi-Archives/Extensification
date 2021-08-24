﻿
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

Namespace StreamReaderExts
    Public Module Reading

        ''' <summary>
        ''' Reads a line from the stream with the newline characters
        ''' </summary>
        ''' <param name="reader">The stream reader</param>
        <Extension>
        Public Function ReadLineWithNewLine(ByVal reader As StreamReader) As String
            'Define a new string builder
            Dim strBuilder As New StringBuilder()

            'Read files as character numbers and convert them to string
            While Not reader.EndOfStream
                Dim readFile As Integer = reader.Read
                strBuilder.Append(ChrW(readFile))
                If readFile = 10 Then
                    Exit While
                End If
            End While

            'Return the final result
            Return strBuilder.ToString()
        End Function

        ''' <summary>
        ''' Reads all the lines and returns the string array
        ''' </summary>
        ''' <param name="reader">The stream reader</param>
        <Extension>
        Public Function ReadLines(ByVal reader As StreamReader) As String()
            Dim StreamLines As New List(Of String)

            'Read the lines while not end of stream
            While Not reader.EndOfStream
                StreamLines.Add(reader.ReadLine)
            End While

            'Return the final result
            Return StreamLines.ToArray
        End Function

        ''' <summary>
        ''' Reads all the characters in the stream until the end and seek the stream to the beginning, if possible.
        ''' </summary>
        ''' <param name="reader">The stream reader</param>
        <Extension>
        Public Function ReadToEndAndSeek(ByVal reader As StreamReader) As String
            Dim StreamString As String = reader.ReadToEnd
            If reader.BaseStream.CanSeek Then reader.BaseStream.Seek(0, SeekOrigin.Begin)
            Return StreamString
        End Function

    End Module
End Namespace