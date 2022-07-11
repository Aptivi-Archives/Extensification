
// Extensification  Copyright (C) 2020-2021  EoflaOE
// 
// This file is part of Extensification
// 
// Extensification is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// Extensification is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <https://www.gnu.org/licenses/>.

using System;
using System.IO;

namespace Extensification.StreamExts
{
    public static class Manipulation
    {

        /// <summary>
        /// Tries seeking the stream
        /// </summary>
        /// <returns>True if successful; False if unsuccessful</returns>
        public static bool TrySeek(this Stream TargetStream, long Offset, SeekOrigin Origin)
        {
            bool Success = true;

            // Try to seek
            try
            {
                TargetStream.Seek(Offset, Origin);
            }
            catch (Exception ex)
            {
                Success = false;
            }

            // Return the result
            return Success;
        }

        /// <summary>
        /// Tries setting the length of the stream
        /// </summary>
        /// <returns>True if successful; False if unsuccessful</returns>
        public static bool TrySetLength(this Stream TargetStream, long Length)
        {
            bool Success = true;

            // Try to set the length
            try
            {
                TargetStream.SetLength(Length);
            }
            catch (Exception ex)
            {
                Success = false;
            }

            // Return the result
            return Success;
        }

        /// <summary>
        /// Tries flushing the stream
        /// </summary>
        /// <returns>True if successful; False if unsuccessful</returns>
        public static bool TryFlush(this Stream TargetStream)
        {
            bool Success = true;

            // Try to seek
            try
            {
                TargetStream.Flush();
            }
            catch (Exception ex)
            {
                Success = false;
            }

            // Return the result
            return Success;
        }

        /* TODO ERROR: Skipped IfDirectiveTrivia
        #If NET45 Then
        *//* TODO ERROR: Skipped DisabledTextTrivia
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
        *//* TODO ERROR: Skipped EndIfDirectiveTrivia
        #End If
        */
    }
}