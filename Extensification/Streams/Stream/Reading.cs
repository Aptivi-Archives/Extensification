
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
    /// <summary>
    /// Provides reading extenstions to <see cref="Stream"/>
    /// </summary>
    public static class Reading
    {

        /// <summary>
        /// Tries reading from the stream
        /// </summary>
        /// <returns>True if successful; False if unsuccessful</returns>
        public static bool TryRead(this Stream TargetStream, byte[] Buffer, int Offset, int Count)
        {
            bool Success = true;

            // Try to read
            try
            {
                TargetStream.Read(Buffer, Offset, Count);
            }
            catch
            {
                Success = false;
            }

            // Return the result
            return Success;
        }

        /// <summary>
        /// Reads from the stream and seeks the stream to the beginning, if possible.
        /// </summary>
        /// <returns>True if successful; False if unsuccessful</returns>
        public static int ReadAndSeek(this Stream TargetStream, byte[] Buffer, int Offset, int Count)
        {
            int Result = TargetStream.Read(Buffer, Offset, Count);
            if (TargetStream.CanSeek)
                TargetStream.Seek(0L, SeekOrigin.Begin);
            return Result;
        }

        /// <summary>
        /// Tries reading a byte from the stream
        /// </summary>
        /// <returns>Byte number if successful; -1 if at end of stream; -2 if error occurred</returns>
        public static int TryReadByte(this Stream TargetStream)
        {
            int ByteNumber;

            // Try to read a byte
            try
            {
                ByteNumber = TargetStream.ReadByte();
            }
            catch
            {
                return -2;
            }

            // Return the result
            return ByteNumber;
        }

    }
}