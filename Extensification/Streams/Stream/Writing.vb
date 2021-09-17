
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
    Public Module Writing

        ''' <summary>
        ''' Tries writing to the stream
        ''' </summary>
        ''' <returns>True if successful; False if unsuccessful</returns>
        <Extension>
        Public Function TryWrite(TargetStream As Stream, Buffer() As Byte, Offset As Integer, Count As Integer) As Boolean
            Dim Success As Boolean = True

            'Try to read
            Try
                TargetStream.Write(Buffer, Offset, Count)
            Catch ex As Exception
                Success = False
            End Try

            'Return the result
            Return Success
        End Function

        ''' <summary>
        ''' Writes to the stream and seeks the stream to the beginning, if possible.
        ''' </summary>
        <Extension>
        Public Sub WriteAndSeek(TargetStream As Stream, Buffer() As Byte, Offset As Integer, Count As Integer)
            TargetStream.Write(Buffer, Offset, Count)
            If TargetStream.CanSeek Then TargetStream.Seek(0, SeekOrigin.Begin)
        End Sub

        ''' <summary>
        ''' Tries writing to the stream
        ''' </summary>
        ''' <returns>True if successful; False if unsuccessful</returns>
        <Extension>
        Public Function TryWriteByte(TargetStream As Stream, Value As Byte) As Boolean
            Dim Success As Boolean = True

            'Try to read
            Try
                TargetStream.WriteByte(Value)
            Catch ex As Exception
                Success = False
            End Try

            'Return the result
            Return Success
        End Function

    End Module
End Namespace
