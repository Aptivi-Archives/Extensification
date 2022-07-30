
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
using System.Collections;

namespace Extensification.ArrayListExts
{
    /// <summary>
    /// Provides the array list extensions related to removal
    /// </summary>
    public static class Removal
    {

        /// <summary>
        /// Tries to remove an entry from the array list
        /// </summary>
        /// <param name="TargetArray">Target array list</param>
        /// <param name="Entry">An entry to be removed</param>
        /// <returns>True if successful; False if unsuccessful</returns>
        public static bool TryRemove(this ArrayList TargetArray, object Entry)
        {
            if (Entry is null)
                throw new ArgumentNullException(nameof(Entry));
            if (!TargetArray.Contains(Entry))
                return false;
            try
            {
                TargetArray.Remove(Entry);
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}