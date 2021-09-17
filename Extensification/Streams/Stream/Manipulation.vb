
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

Namespace StreamExts
    Public Module Manipulation

        ''' <summary>
        ''' Tries seeking the stream
        ''' </summary>
        ''' <returns>True if successful; False if unsuccessful</returns>
        <Extension>
        Public Function TrySeek(TargetStream As Stream, Offset As Long, Origin As SeekOrigin) As Boolean
            Dim Success As Boolean = True

            'Try to seek
            Try
                TargetStream.Seek(Offset, Origin)
            Catch ex As Exception
                Success = False
            End Try

            'Return the result
            Return Success
        End Function

        ''' <summary>
        ''' Tries setting the length of the stream
        ''' </summary>
        ''' <returns>True if successful; False if unsuccessful</returns>
        <Extension>
        Public Function TrySetLength(TargetStream As Stream, Length As Long) As Boolean
            Dim Success As Boolean = True

            'Try to set the length
            Try
                TargetStream.SetLength(Length)
            Catch ex As Exception
                Success = False
            End Try

            'Return the result
            Return Success
        End Function

        ''' <summary>
        ''' Tries flushing the stream
        ''' </summary>
        ''' <returns>True if successful; False if unsuccessful</returns>
        <Extension>
        Public Function TryFlush(TargetStream As Stream) As Boolean
            Dim Success As Boolean = True

            'Try to seek
            Try
                TargetStream.Flush()
            Catch ex As Exception
                Success = False
            End Try

            'Return the result
            Return Success
        End Function

#If NET45 Then
        ''' <summary>
        ''' Tries to return the array of unsigned bytes from which this stream was created.
        ''' </summary>
        ''' <returns>True if successful; False if unsuccessful</returns>
        <Extension>
        Public Function TryGetBuffer(TargetStream As Stream, ByRef Buffer As ArraySegment(Of Byte)) As Boolean
            Dim Success As Boolean = True

            'Try to seek
            Try
                Dim Chars As New List(Of Byte)
                Dim CharByte As Integer
                Do Until CharByte = -1
                    CharByte = TargetStream.ReadByte()
                    If Not CharByte = -1 Then Chars.Add(Convert.ToByte(CharByte))
                Loop
                Buffer = New ArraySegment(Of Byte)(Chars.ToArray)
            Catch ex As Exception
                Success = False
            End Try

            'Return the result
            Return Success
        End Function
#End If
    End Module
End Namespace
