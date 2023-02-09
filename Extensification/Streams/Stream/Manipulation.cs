
// Extensification  Copyright (C) 2020-2021  Aptivi
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
using System.Collections.Generic;
using System.IO;

namespace Extensification.StreamExts
{
    /// <summary>
    /// Provides manipulation extenstions to <see cref="Stream"/>
    /// </summary>
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
            catch
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
            catch
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
            catch
            {
                Success = false;
            }

            // Return the result
            return Success;
        }
    }
}