
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
    /// Provides writing extenstions to <see cref="Stream"/>
    /// </summary>
    public static class Writing
    {

        /// <summary>
        /// Tries writing to the stream
        /// </summary>
        /// <returns>True if successful; False if unsuccessful</returns>
        public static bool TryWrite(this Stream TargetStream, byte[] Buffer, int Offset, int Count)
        {
            bool Success = true;

            // Try to read
            try
            {
                TargetStream.Write(Buffer, Offset, Count);
            }
            catch 
            {
                Success = false;
            }

            // Return the result
            return Success;
        }

        /// <summary>
        /// Writes to the stream and seeks the stream to the beginning, if possible.
        /// </summary>
        public static void WriteAndSeek(this Stream TargetStream, byte[] Buffer, int Offset, int Count)
        {
            TargetStream.Write(Buffer, Offset, Count);
            if (TargetStream.CanSeek)
                TargetStream.Seek(0L, SeekOrigin.Begin);
        }

        /// <summary>
        /// Tries writing to the stream
        /// </summary>
        /// <returns>True if successful; False if unsuccessful</returns>
        public static bool TryWriteByte(this Stream TargetStream, byte Value)
        {
            bool Success = true;

            // Try to read
            try
            {
                TargetStream.WriteByte(Value);
            }
            catch 
            {
                Success = false;
            }

            // Return the result
            return Success;
        }

    }
}