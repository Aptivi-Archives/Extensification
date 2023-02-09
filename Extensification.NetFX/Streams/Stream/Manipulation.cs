
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

namespace Extensification.NetFX.StreamExts
{
    /// <summary>
    /// Provides manipulation extenstions to <see cref="Stream"/>
    /// </summary>
    public static class Manipulation
    {
        /// <summary>
        /// Tries to return the array of unsigned bytes from which this stream was created.
        /// </summary>
        /// <returns>True if successful; False if unsuccessful</returns>
        public static bool TryGetBuffer(this Stream TargetStream, ref ArraySegment<byte> Buffer)
        {
            bool Success = true;

            // Try to seek
            try
            {
                List<byte> Chars = new List<byte>();
                int CharByte = 0;
                while (!(CharByte == -1))
                {
                    CharByte = TargetStream.ReadByte();
                    if (!(CharByte == -1))
                    {
                        Chars.Add(Convert.ToByte(CharByte));
                    }
                }
                Buffer = new ArraySegment<byte>(Chars.ToArray());
            }
            catch
            {
                Success = false;
            }

            //Return the result
            return Success;
        }
    }
}