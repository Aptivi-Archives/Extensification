
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
        Public Function TrySeek(ByVal TargetStream As Stream, Offset As Long, Origin As SeekOrigin) As Boolean
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

    End Module
End Namespace
