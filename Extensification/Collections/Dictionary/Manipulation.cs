
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
using Extensification.StringExts;

namespace Extensification.DictionaryExts
{
    /// <summary>
    /// Provides the dictionary extensions related to manipulation
    /// </summary>
    public static class Manipulation
    {

        /// <summary>
        /// Renames a key in a dictionary that has the key type of string
        /// </summary>
        /// <typeparam name="TValue">Value</typeparam>
        /// <param name="Dict">Target dictionary</param>
        /// <param name="OldName">Original key name</param>
        /// <param name="NewName">New key name</param>
        /// <exception cref="KeyNotFoundException"></exception>
        public static void RenameKey<TValue>(this Dictionary<string, TValue> Dict, string OldName, string NewName)
        {
            if (Dict.ContainsKey(OldName))
            {
                var KeyValue = Dict[OldName];
                Dict.Remove(OldName);
                Dict.Add(NewName, KeyValue);
            }
            else
            {
                throw new KeyNotFoundException("Key {0} not found".FormatString(OldName));
            }
        }

        /// <summary>
        /// Increments number value in key. The key will be created if not found.
        /// </summary>
        /// <typeparam name="TKey">Key</typeparam>
        /// <param name="Dict">Target dictionary</param>
        /// <param name="EntryKey">A key entry to be incremented</param>
        public static void IncrementNumber<TKey>(this Dictionary<TKey, int> Dict, TKey EntryKey)
        {
            if (EntryKey is null)
                throw new ArgumentNullException(nameof(EntryKey));
            if (!Dict.ContainsKey(EntryKey))
                Dict.Add(EntryKey, 0);
            Dict[EntryKey] += 1;
        }

        /// <summary>
        /// Increments number value in key. The key will be created if not found.
        /// </summary>
        /// <typeparam name="TKey">Key</typeparam>
        /// <param name="Dict">Target dictionary</param>
        /// <param name="EntryKey">A key entry to be incremented</param>
        public static void IncrementNumber<TKey>(this Dictionary<TKey, uint> Dict, TKey EntryKey)
        {
            if (EntryKey is null)
                throw new ArgumentNullException(nameof(EntryKey));
            if (!Dict.ContainsKey(EntryKey))
                Dict.Add(EntryKey, 0U);
            Dict[EntryKey] = (uint)(Dict[EntryKey] + 1L);
        }

        /// <summary>
        /// Increments number value in key. The key will be created if not found.
        /// </summary>
        /// <typeparam name="TKey">Key</typeparam>
        /// <param name="Dict">Target dictionary</param>
        /// <param name="EntryKey">A key entry to be incremented</param>
        public static void IncrementNumber<TKey>(this Dictionary<TKey, long> Dict, TKey EntryKey)
        {
            if (EntryKey is null)
                throw new ArgumentNullException(nameof(EntryKey));
            if (!Dict.ContainsKey(EntryKey))
                Dict.Add(EntryKey, 0L);
            Dict[EntryKey] += 1L;
        }

        /// <summary>
        /// Increments number value in key. The key will be created if not found.
        /// </summary>
        /// <typeparam name="TKey">Key</typeparam>
        /// <param name="Dict">Target dictionary</param>
        /// <param name="EntryKey">A key entry to be incremented</param>
        public static void IncrementNumber<TKey>(this Dictionary<TKey, ulong> Dict, TKey EntryKey)
        {
            if (EntryKey is null)
                throw new ArgumentNullException(nameof(EntryKey));
            if (!Dict.ContainsKey(EntryKey))
                Dict.Add(EntryKey, 0UL);
            Dict[EntryKey] = (ulong)Math.Round(Dict[EntryKey] + 1m);
        }

        /// <summary>
        /// Increments number value in key. The key will be created if not found.
        /// </summary>
        /// <typeparam name="TKey">Key</typeparam>
        /// <param name="Dict">Target dictionary</param>
        /// <param name="EntryKey">A key entry to be incremented</param>
        public static void IncrementNumber<TKey>(this Dictionary<TKey, short> Dict, TKey EntryKey)
        {
            if (EntryKey is null)
                throw new ArgumentNullException(nameof(EntryKey));
            if (!Dict.ContainsKey(EntryKey))
                Dict.Add(EntryKey, 0);
            Dict[EntryKey] = (short)(Dict[EntryKey] + 1);
        }

        /// <summary>
        /// Increments number value in key. The key will be created if not found.
        /// </summary>
        /// <typeparam name="TKey">Key</typeparam>
        /// <param name="Dict">Target dictionary</param>
        /// <param name="EntryKey">A key entry to be incremented</param>
        public static void IncrementNumber<TKey>(this Dictionary<TKey, ushort> Dict, TKey EntryKey)
        {
            if (EntryKey is null)
                throw new ArgumentNullException(nameof(EntryKey));
            if (!Dict.ContainsKey(EntryKey))
                Dict.Add(EntryKey, 0);
            Dict[EntryKey] = (ushort)(Dict[EntryKey] + 1);
        }

        /// <summary>
        /// Increments number value in key. The key will be created if not found.
        /// </summary>
        /// <typeparam name="TKey">Key</typeparam>
        /// <param name="Dict">Target dictionary</param>
        /// <param name="EntryKey">A key entry to be incremented</param>
        public static void IncrementNumber<TKey>(this Dictionary<TKey, byte> Dict, TKey EntryKey)
        {
            if (EntryKey is null)
                throw new ArgumentNullException(nameof(EntryKey));
            if (!Dict.ContainsKey(EntryKey))
                Dict.Add(EntryKey, 0);
            Dict[EntryKey] = (byte)(Dict[EntryKey] + 1);
        }

        /// <summary>
        /// Increments number value in key. The key will be created if not found.
        /// </summary>
        /// <typeparam name="TKey">Key</typeparam>
        /// <param name="Dict">Target dictionary</param>
        /// <param name="EntryKey">A key entry to be incremented</param>
        public static void IncrementNumber<TKey>(this Dictionary<TKey, sbyte> Dict, TKey EntryKey)
        {
            if (EntryKey is null)
                throw new ArgumentNullException(nameof(EntryKey));
            if (!Dict.ContainsKey(EntryKey))
                Dict.Add(EntryKey, 0);
            Dict[EntryKey] = (sbyte)(Dict[EntryKey] + 1);
        }

        /// <summary>
        /// Increments number value in key. The key will be created if not found.
        /// </summary>
        /// <typeparam name="TKey">Key</typeparam>
        /// <param name="Dict">Target dictionary</param>
        /// <param name="EntryKey">A key entry to be incremented</param>
        public static void IncrementNumber<TKey>(this Dictionary<TKey, float> Dict, TKey EntryKey)
        {
            if (EntryKey is null)
                throw new ArgumentNullException(nameof(EntryKey));
            if (!Dict.ContainsKey(EntryKey))
                Dict.Add(EntryKey, 0f);
            Dict[EntryKey] += 1f;
        }

        /// <summary>
        /// Increments number value in key. The key will be created if not found.
        /// </summary>
        /// <typeparam name="TKey">Key</typeparam>
        /// <param name="Dict">Target dictionary</param>
        /// <param name="EntryKey">A key entry to be incremented</param>
        public static void IncrementNumber<TKey>(this Dictionary<TKey, double> Dict, TKey EntryKey)
        {
            if (EntryKey is null)
                throw new ArgumentNullException(nameof(EntryKey));
            if (!Dict.ContainsKey(EntryKey))
                Dict.Add(EntryKey, 0d);
            Dict[EntryKey] += 1d;
        }

        /// <summary>
        /// Decrements number value in key. The key will be created if not found.
        /// </summary>
        /// <typeparam name="TKey">Key</typeparam>
        /// <param name="Dict">Target dictionary</param>
        /// <param name="EntryKey">A key entry to be decremented</param>
        public static void DecrementNumber<TKey>(this Dictionary<TKey, int> Dict, TKey EntryKey)
        {
            if (EntryKey is null)
                throw new ArgumentNullException(nameof(EntryKey));
            if (!Dict.ContainsKey(EntryKey))
                Dict.Add(EntryKey, 0);
            Dict[EntryKey] -= 1;
        }

        /// <summary>
        /// Decrements number value in key. The key will be created if not found.
        /// </summary>
        /// <typeparam name="TKey">Key</typeparam>
        /// <param name="Dict">Target dictionary</param>
        /// <param name="EntryKey">A key entry to be decremented</param>
        public static void DecrementNumber<TKey>(this Dictionary<TKey, uint> Dict, TKey EntryKey)
        {
            if (EntryKey is null)
                throw new ArgumentNullException(nameof(EntryKey));
            if (!Dict.ContainsKey(EntryKey))
                Dict.Add(EntryKey, 0U);
            Dict[EntryKey] = (uint)(Dict[EntryKey] - 1L);
        }

        /// <summary>
        /// Decrements number value in key. The key will be created if not found.
        /// </summary>
        /// <typeparam name="TKey">Key</typeparam>
        /// <param name="Dict">Target dictionary</param>
        /// <param name="EntryKey">A key entry to be decremented</param>
        public static void DecrementNumber<TKey>(this Dictionary<TKey, long> Dict, TKey EntryKey)
        {
            if (EntryKey is null)
                throw new ArgumentNullException(nameof(EntryKey));
            if (!Dict.ContainsKey(EntryKey))
                Dict.Add(EntryKey, 0L);
            Dict[EntryKey] -= 1L;
        }

        /// <summary>
        /// Decrements number value in key. The key will be created if not found.
        /// </summary>
        /// <typeparam name="TKey">Key</typeparam>
        /// <param name="Dict">Target dictionary</param>
        /// <param name="EntryKey">A key entry to be decremented</param>
        public static void DecrementNumber<TKey>(this Dictionary<TKey, ulong> Dict, TKey EntryKey)
        {
            if (EntryKey is null)
                throw new ArgumentNullException(nameof(EntryKey));
            if (!Dict.ContainsKey(EntryKey))
                Dict.Add(EntryKey, 0UL);
            Dict[EntryKey] = (ulong)Math.Round(Dict[EntryKey] - 1m);
        }

        /// <summary>
        /// Decrements number value in key. The key will be created if not found.
        /// </summary>
        /// <typeparam name="TKey">Key</typeparam>
        /// <param name="Dict">Target dictionary</param>
        /// <param name="EntryKey">A key entry to be decremented</param>
        public static void DecrementNumber<TKey>(this Dictionary<TKey, short> Dict, TKey EntryKey)
        {
            if (EntryKey is null)
                throw new ArgumentNullException(nameof(EntryKey));
            if (!Dict.ContainsKey(EntryKey))
                Dict.Add(EntryKey, 0);
            Dict[EntryKey] = (short)(Dict[EntryKey] - 1);
        }

        /// <summary>
        /// Decrements number value in key. The key will be created if not found.
        /// </summary>
        /// <typeparam name="TKey">Key</typeparam>
        /// <param name="Dict">Target dictionary</param>
        /// <param name="EntryKey">A key entry to be decremented</param>
        public static void DecrementNumber<TKey>(this Dictionary<TKey, ushort> Dict, TKey EntryKey)
        {
            if (EntryKey is null)
                throw new ArgumentNullException(nameof(EntryKey));
            if (!Dict.ContainsKey(EntryKey))
                Dict.Add(EntryKey, 0);
            Dict[EntryKey] = (ushort)(Dict[EntryKey] - 1);
        }

        /// <summary>
        /// Decrements number value in key. The key will be created if not found.
        /// </summary>
        /// <typeparam name="TKey">Key</typeparam>
        /// <param name="Dict">Target dictionary</param>
        /// <param name="EntryKey">A key entry to be decremented</param>
        public static void DecrementNumber<TKey>(this Dictionary<TKey, byte> Dict, TKey EntryKey)
        {
            if (EntryKey is null)
                throw new ArgumentNullException(nameof(EntryKey));
            if (!Dict.ContainsKey(EntryKey))
                Dict.Add(EntryKey, 0);
            Dict[EntryKey] = (byte)(Dict[EntryKey] - 1);
        }

        /// <summary>
        /// Decrements number value in key. The key will be created if not found.
        /// </summary>
        /// <typeparam name="TKey">Key</typeparam>
        /// <param name="Dict">Target dictionary</param>
        /// <param name="EntryKey">A key entry to be decremented</param>
        public static void DecrementNumber<TKey>(this Dictionary<TKey, sbyte> Dict, TKey EntryKey)
        {
            if (EntryKey is null)
                throw new ArgumentNullException(nameof(EntryKey));
            if (!Dict.ContainsKey(EntryKey))
                Dict.Add(EntryKey, 0);
            Dict[EntryKey] = (sbyte)(Dict[EntryKey] - 1);
        }

        /// <summary>
        /// Decrements number value in key. The key will be created if not found.
        /// </summary>
        /// <typeparam name="TKey">Key</typeparam>
        /// <param name="Dict">Target dictionary</param>
        /// <param name="EntryKey">A key entry to be decremented</param>
        public static void DecrementNumber<TKey>(this Dictionary<TKey, float> Dict, TKey EntryKey)
        {
            if (EntryKey is null)
                throw new ArgumentNullException(nameof(EntryKey));
            if (!Dict.ContainsKey(EntryKey))
                Dict.Add(EntryKey, 0f);
            Dict[EntryKey] -= 1f;
        }

        /// <summary>
        /// Decrements number value in key. The key will be created if not found.
        /// </summary>
        /// <typeparam name="TKey">Key</typeparam>
        /// <param name="Dict">Target dictionary</param>
        /// <param name="EntryKey">A key entry to be decremented</param>
        public static void DecrementNumber<TKey>(this Dictionary<TKey, double> Dict, TKey EntryKey)
        {
            if (EntryKey is null)
                throw new ArgumentNullException(nameof(EntryKey));
            if (!Dict.ContainsKey(EntryKey))
                Dict.Add(EntryKey, 0d);
            Dict[EntryKey] -= 1d;
        }

    }
}