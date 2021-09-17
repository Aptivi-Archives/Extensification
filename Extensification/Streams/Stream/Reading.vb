
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
    Public Module Reading

        ''' <summary>
        ''' Tries reading from the stream
        ''' </summary>
        ''' <returns>True if successful; False if unsuccessful</returns>
        <Extension>
        Public Function TryRead(TargetStream As Stream, Buffer() As Byte, Offset As Integer, Count As Integer) As Boolean
            Dim Success As Boolean = True

            'Try to read
            Try
                TargetStream.Read(Buffer, Offset, Count)
            Catch ex As Exception
                Success = False
            End Try

            'Return the result
            Return Success
        End Function

        ''' <summary>
        ''' Reads from the stream and seeks the stream to the beginning, if possible.
        ''' </summary>
        ''' <returns>True if successful; False if unsuccessful</returns>
        <Extension>
        Public Function ReadAndSeek(TargetStream As Stream, Buffer() As Byte, Offset As Integer, Count As Integer) As Integer
            Dim Result As Integer = TargetStream.Read(Buffer, Offset, Count)
            If TargetStream.CanSeek Then TargetStream.Seek(0, SeekOrigin.Begin)
            Return Result
        End Function

        ''' <summary>
        ''' Tries reading a byte from the stream
        ''' </summary>
        ''' <returns>Byte number if successful; -1 if at end of stream; -2 if error occurred</returns>
        <Extension>
        Public Function TryReadByte(TargetStream As Stream) As Integer
            Dim ByteNumber As Integer

            'Try to read a byte
            Try
                ByteNumber = TargetStream.ReadByte()
            Catch ex As Exception
                Return -2
            End Try

            'Return the result
            Return ByteNumber
        End Function

    End Module
End Namespace
