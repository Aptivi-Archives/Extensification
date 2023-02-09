
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

namespace Extensification.NetFX.DictionaryExts
{
    /// <summary>
    /// Provides the dictionary extensions related to addition
    /// </summary>
    public static class Addition
    {
        /// <summary>
        /// Attempts to add the specified key and value to the dictionary
        /// </summary>
        /// <typeparam name="TKey">Key</typeparam>
        /// <typeparam name="TValue">Value</typeparam>
        /// <param name="Dict">Target dictionary</param>
        /// <param name="EntryKey">A key entry to be added</param>
        /// <param name="EntryValue">A value of entry</param>
        /// <returns>True if successful; False if unsuccessful</returns>
        public static bool TryAdd<TKey, TValue>(this Dictionary<TKey, TValue> Dict, TKey EntryKey, TValue EntryValue)
        {
            if (EntryKey is null)
                throw new ArgumentNullException(nameof(EntryKey));

            try
            {
                Dict.Add(EntryKey, EntryValue);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}