
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

namespace Extensification.DictionaryExts
{
    /// <summary>
    /// Provides the dictionary extensions related to addition
    /// </summary>
    public static class Addition
    {

        /// <summary>
        /// Adds an entry to dictionary if not found
        /// </summary>
        /// <typeparam name="TKey">Key</typeparam>
        /// <typeparam name="TValue">Value</typeparam>
        /// <param name="Dict">Target dictionary</param>
        /// <param name="EntryKey">A key entry to be added</param>
        /// <param name="EntryValue">A value of entry</param>
        public static void AddIfNotFound<TKey, TValue>(this Dictionary<TKey, TValue> Dict, TKey EntryKey, TValue EntryValue)
        {
            if (EntryKey is null)
                throw new ArgumentNullException(nameof(EntryKey));
            if (!Dict.ContainsKey(EntryKey))
            {
                Dict.Add(EntryKey, EntryValue);
            }
        }

        /// <summary>
        /// Adds or modifies an entry to dictionary
        /// </summary>
        /// <typeparam name="TKey">Key</typeparam>
        /// <typeparam name="TValue">Value</typeparam>
        /// <param name="Dict">Target dictionary</param>
        /// <param name="EntryKey">A key entry to be added</param>
        /// <param name="EntryValue">A value of entry</param>
        public static void AddOrModify<TKey, TValue>(this Dictionary<TKey, TValue> Dict, TKey EntryKey, TValue EntryValue)
        {
            if (EntryKey is null)
                throw new ArgumentNullException(nameof(EntryKey));
            if (!Dict.ContainsKey(EntryKey))
            {
                Dict.Add(EntryKey, EntryValue);
            }
            else
            {
                Dict[EntryKey] = EntryValue;
            }
        }

        /// <summary>
        /// Adds or renames an entry to dictionary to identify the copy number
        /// </summary>
        /// <typeparam name="TValue">Value</typeparam>
        /// <param name="Dict">Target dictionary</param>
        /// <param name="EntryKey">A key entry to be added</param>
        /// <param name="EntryValue">A value of entry</param>
        public static void AddOrRename<TValue>(this Dictionary<string, TValue> Dict, string EntryKey, TValue EntryValue)
        {
            if (EntryKey is null)
                throw new ArgumentNullException(nameof(EntryKey));
            if (!Dict.ContainsKey(EntryKey))
            {
                Dict.Add(EntryKey, EntryValue);
            }
            else
            {
                Dict.Add(EntryKey + " [" + (Dict.Count + 1) + "]", EntryValue);
            }
        }

        /// <summary>
        /// Adds an entry or increments a value of an already-existing entry to dictionary
        /// </summary>
        /// <typeparam name="TKey">Key</typeparam>
        /// <param name="Dict">Target dictionary</param>
        /// <param name="EntryKey">A key entry to be added</param>
        /// <param name="EntryValue">A value of entry, or a value to add to an already-existing entry</param>
        public static void AddOrIncrement<TKey>(this Dictionary<TKey, int> Dict, TKey EntryKey, int EntryValue)
        {
            if (EntryKey is null)
                throw new ArgumentNullException(nameof(EntryKey));
            if (!Dict.ContainsKey(EntryKey))
            {
                Dict.Add(EntryKey, EntryValue);
            }
            else
            {
                Dict[EntryKey] += EntryValue;
            }
        }

        /// <summary>
        /// Adds an entry or increments a value of an already-existing entry to dictionary
        /// </summary>
        /// <typeparam name="TKey">Key</typeparam>
        /// <param name="Dict">Target dictionary</param>
        /// <param name="EntryKey">A key entry to be added</param>
        /// <param name="EntryValue">A value of entry, or a value to add to an already-existing entry</param>
        public static void AddOrIncrement<TKey>(this Dictionary<TKey, uint> Dict, TKey EntryKey, uint EntryValue)
        {
            if (EntryKey is null)
                throw new ArgumentNullException(nameof(EntryKey));
            if (!Dict.ContainsKey(EntryKey))
            {
                Dict.Add(EntryKey, EntryValue);
            }
            else
            {
                Dict[EntryKey] += EntryValue;
            }
        }

        /// <summary>
        /// Adds an entry or increments a value of an already-existing entry to dictionary
        /// </summary>
        /// <typeparam name="TKey">Key</typeparam>
        /// <param name="Dict">Target dictionary</param>
        /// <param name="EntryKey">A key entry to be added</param>
        /// <param name="EntryValue">A value of entry, or a value to add to an already-existing entry</param>
        public static void AddOrIncrement<TKey>(this Dictionary<TKey, byte> Dict, TKey EntryKey, byte EntryValue)
        {
            if (EntryKey is null)
                throw new ArgumentNullException(nameof(EntryKey));
            if (!Dict.ContainsKey(EntryKey))
            {
                Dict.Add(EntryKey, EntryValue);
            }
            else
            {
                Dict[EntryKey] += EntryValue;
            }
        }

        /// <summary>
        /// Adds an entry or increments a value of an already-existing entry to dictionary
        /// </summary>
        /// <typeparam name="TKey">Key</typeparam>
        /// <param name="Dict">Target dictionary</param>
        /// <param name="EntryKey">A key entry to be added</param>
        /// <param name="EntryValue">A value of entry, or a value to add to an already-existing entry</param>
        public static void AddOrIncrement<TKey>(this Dictionary<TKey, sbyte> Dict, TKey EntryKey, sbyte EntryValue)
        {
            if (EntryKey is null)
                throw new ArgumentNullException(nameof(EntryKey));
            if (!Dict.ContainsKey(EntryKey))
            {
                Dict.Add(EntryKey, EntryValue);
            }
            else
            {
                Dict[EntryKey] += EntryValue;
            }
        }

        /// <summary>
        /// Adds an entry or increments a value of an already-existing entry to dictionary
        /// </summary>
        /// <typeparam name="TKey">Key</typeparam>
        /// <param name="Dict">Target dictionary</param>
        /// <param name="EntryKey">A key entry to be added</param>
        /// <param name="EntryValue">A value of entry, or a value to add to an already-existing entry</param>
        public static void AddOrIncrement<TKey>(this Dictionary<TKey, double> Dict, TKey EntryKey, double EntryValue)
        {
            if (EntryKey is null)
                throw new ArgumentNullException(nameof(EntryKey));
            if (!Dict.ContainsKey(EntryKey))
            {
                Dict.Add(EntryKey, EntryValue);
            }
            else
            {
                Dict[EntryKey] += EntryValue;
            }
        }

        /// <summary>
        /// Adds an entry or increments a value of an already-existing entry to dictionary
        /// </summary>
        /// <typeparam name="TKey">Key</typeparam>
        /// <param name="Dict">Target dictionary</param>
        /// <param name="EntryKey">A key entry to be added</param>
        /// <param name="EntryValue">A value of entry, or a value to add to an already-existing entry</param>
        public static void AddOrIncrement<TKey>(this Dictionary<TKey, long> Dict, TKey EntryKey, long EntryValue)
        {
            if (EntryKey is null)
                throw new ArgumentNullException(nameof(EntryKey));
            if (!Dict.ContainsKey(EntryKey))
            {
                Dict.Add(EntryKey, EntryValue);
            }
            else
            {
                Dict[EntryKey] += EntryValue;
            }
        }

        /// <summary>
        /// Adds an entry or increments a value of an already-existing entry to dictionary
        /// </summary>
        /// <typeparam name="TKey">Key</typeparam>
        /// <param name="Dict">Target dictionary</param>
        /// <param name="EntryKey">A key entry to be added</param>
        /// <param name="EntryValue">A value of entry, or a value to add to an already-existing entry</param>
        public static void AddOrIncrement<TKey>(this Dictionary<TKey, ulong> Dict, TKey EntryKey, ulong EntryValue)
        {
            if (EntryKey is null)
                throw new ArgumentNullException(nameof(EntryKey));
            if (!Dict.ContainsKey(EntryKey))
            {
                Dict.Add(EntryKey, EntryValue);
            }
            else
            {
                Dict[EntryKey] += EntryValue;
            }
        }

        /// <summary>
        /// Adds an entry or increments a value of an already-existing entry to dictionary
        /// </summary>
        /// <typeparam name="TKey">Key</typeparam>
        /// <param name="Dict">Target dictionary</param>
        /// <param name="EntryKey">A key entry to be added</param>
        /// <param name="EntryValue">A value of entry, or a value to add to an already-existing entry</param>
        public static void AddOrIncrement<TKey>(this Dictionary<TKey, short> Dict, TKey EntryKey, short EntryValue)
        {
            if (EntryKey is null)
                throw new ArgumentNullException(nameof(EntryKey));
            if (!Dict.ContainsKey(EntryKey))
            {
                Dict.Add(EntryKey, EntryValue);
            }
            else
            {
                Dict[EntryKey] += EntryValue;
            }
        }

        /// <summary>
        /// Adds an entry or increments a value of an already-existing entry to dictionary
        /// </summary>
        /// <typeparam name="TKey">Key</typeparam>
        /// <param name="Dict">Target dictionary</param>
        /// <param name="EntryKey">A key entry to be added</param>
        /// <param name="EntryValue">A value of entry, or a value to add to an already-existing entry</param>
        public static void AddOrIncrement<TKey>(this Dictionary<TKey, ushort> Dict, TKey EntryKey, ushort EntryValue)
        {
            if (EntryKey is null)
                throw new ArgumentNullException(nameof(EntryKey));
            if (!Dict.ContainsKey(EntryKey))
            {
                Dict.Add(EntryKey, EntryValue);
            }
            else
            {
                Dict[EntryKey] += EntryValue;
            }
        }

        /// <summary>
        /// Adds an entry or increments a value of an already-existing entry to dictionary
        /// </summary>
        /// <typeparam name="TKey">Key</typeparam>
        /// <param name="Dict">Target dictionary</param>
        /// <param name="EntryKey">A key entry to be added</param>
        /// <param name="EntryValue">A value of entry, or a value to add to an already-existing entry</param>
        public static void AddOrIncrement<TKey>(this Dictionary<TKey, float> Dict, TKey EntryKey, float EntryValue)
        {
            if (EntryKey is null)
                throw new ArgumentNullException(nameof(EntryKey));
            if (!Dict.ContainsKey(EntryKey))
            {
                Dict.Add(EntryKey, EntryValue);
            }
            else
            {
                Dict[EntryKey] += EntryValue;
            }
        }

        /// <summary>
        /// Adds an entry or decrements a value of an already-existing entry to dictionary
        /// </summary>
        /// <typeparam name="TKey">Key</typeparam>
        /// <param name="Dict">Target dictionary</param>
        /// <param name="EntryKey">A key entry to be added</param>
        /// <param name="EntryValue">A value of entry, or a value to subtract from an already-existing entry</param>
        public static void AddOrDecrement<TKey>(this Dictionary<TKey, int> Dict, TKey EntryKey, int EntryValue)
        {
            if (EntryKey is null)
                throw new ArgumentNullException(nameof(EntryKey));
            if (!Dict.ContainsKey(EntryKey))
            {
                Dict.Add(EntryKey, EntryValue);
            }
            else
            {
                Dict[EntryKey] -= EntryValue;
            }
        }

        /// <summary>
        /// Adds an entry or decrements a value of an already-existing entry to dictionary
        /// </summary>
        /// <typeparam name="TKey">Key</typeparam>
        /// <param name="Dict">Target dictionary</param>
        /// <param name="EntryKey">A key entry to be added</param>
        /// <param name="EntryValue">A value of entry, or a value to subtract from an already-existing entry</param>
        public static void AddOrDecrement<TKey>(this Dictionary<TKey, uint> Dict, TKey EntryKey, uint EntryValue)
        {
            if (EntryKey is null)
                throw new ArgumentNullException(nameof(EntryKey));
            if (!Dict.ContainsKey(EntryKey))
            {
                Dict.Add(EntryKey, EntryValue);
            }
            else
            {
                Dict[EntryKey] -= EntryValue;
            }
        }

        /// <summary>
        /// Adds an entry or decrements a value of an already-existing entry to dictionary
        /// </summary>
        /// <typeparam name="TKey">Key</typeparam>
        /// <param name="Dict">Target dictionary</param>
        /// <param name="EntryKey">A key entry to be added</param>
        /// <param name="EntryValue">A value of entry, or a value to subtract from an already-existing entry</param>
        public static void AddOrDecrement<TKey>(this Dictionary<TKey, byte> Dict, TKey EntryKey, byte EntryValue)
        {
            if (EntryKey is null)
                throw new ArgumentNullException(nameof(EntryKey));
            if (!Dict.ContainsKey(EntryKey))
            {
                Dict.Add(EntryKey, EntryValue);
            }
            else
            {
                Dict[EntryKey] -= EntryValue;
            }
        }

        /// <summary>
        /// Adds an entry or decrements a value of an already-existing entry to dictionary
        /// </summary>
        /// <typeparam name="TKey">Key</typeparam>
        /// <param name="Dict">Target dictionary</param>
        /// <param name="EntryKey">A key entry to be added</param>
        /// <param name="EntryValue">A value of entry, or a value to subtract from an already-existing entry</param>
        public static void AddOrDecrement<TKey>(this Dictionary<TKey, sbyte> Dict, TKey EntryKey, sbyte EntryValue)
        {
            if (EntryKey is null)
                throw new ArgumentNullException(nameof(EntryKey));
            if (!Dict.ContainsKey(EntryKey))
            {
                Dict.Add(EntryKey, EntryValue);
            }
            else
            {
                Dict[EntryKey] -= EntryValue;
            }
        }

        /// <summary>
        /// Adds an entry or decrements a value of an already-existing entry to dictionary
        /// </summary>
        /// <typeparam name="TKey">Key</typeparam>
        /// <param name="Dict">Target dictionary</param>
        /// <param name="EntryKey">A key entry to be added</param>
        /// <param name="EntryValue">A value of entry, or a value to subtract from an already-existing entry</param>
        public static void AddOrDecrement<TKey>(this Dictionary<TKey, double> Dict, TKey EntryKey, double EntryValue)
        {
            if (EntryKey is null)
                throw new ArgumentNullException(nameof(EntryKey));
            if (!Dict.ContainsKey(EntryKey))
            {
                Dict.Add(EntryKey, EntryValue);
            }
            else
            {
                Dict[EntryKey] -= EntryValue;
            }
        }

        /// <summary>
        /// Adds an entry or decrements a value of an already-existing entry to dictionary
        /// </summary>
        /// <typeparam name="TKey">Key</typeparam>
        /// <param name="Dict">Target dictionary</param>
        /// <param name="EntryKey">A key entry to be added</param>
        /// <param name="EntryValue">A value of entry, or a value to subtract from an already-existing entry</param>
        public static void AddOrDecrement<TKey>(this Dictionary<TKey, long> Dict, TKey EntryKey, long EntryValue)
        {
            if (EntryKey is null)
                throw new ArgumentNullException(nameof(EntryKey));
            if (!Dict.ContainsKey(EntryKey))
            {
                Dict.Add(EntryKey, EntryValue);
            }
            else
            {
                Dict[EntryKey] -= EntryValue;
            }
        }

        /// <summary>
        /// Adds an entry or decrements a value of an already-existing entry to dictionary
        /// </summary>
        /// <typeparam name="TKey">Key</typeparam>
        /// <param name="Dict">Target dictionary</param>
        /// <param name="EntryKey">A key entry to be added</param>
        /// <param name="EntryValue">A value of entry, or a value to subtract from an already-existing entry</param>
        public static void AddOrDecrement<TKey>(this Dictionary<TKey, ulong> Dict, TKey EntryKey, ulong EntryValue)
        {
            if (EntryKey is null)
                throw new ArgumentNullException(nameof(EntryKey));
            if (!Dict.ContainsKey(EntryKey))
            {
                Dict.Add(EntryKey, EntryValue);
            }
            else
            {
                Dict[EntryKey] -= EntryValue;
            }
        }

        /// <summary>
        /// Adds an entry or decrements a value of an already-existing entry to dictionary
        /// </summary>
        /// <typeparam name="TKey">Key</typeparam>
        /// <param name="Dict">Target dictionary</param>
        /// <param name="EntryKey">A key entry to be added</param>
        /// <param name="EntryValue">A value of entry, or a value to subtract from an already-existing entry</param>
        public static void AddOrDecrement<TKey>(this Dictionary<TKey, short> Dict, TKey EntryKey, short EntryValue)
        {
            if (EntryKey is null)
                throw new ArgumentNullException(nameof(EntryKey));
            if (!Dict.ContainsKey(EntryKey))
            {
                Dict.Add(EntryKey, EntryValue);
            }
            else
            {
                Dict[EntryKey] -= EntryValue;
            }
        }

        /// <summary>
        /// Adds an entry or decrements a value of an already-existing entry to dictionary
        /// </summary>
        /// <typeparam name="TKey">Key</typeparam>
        /// <param name="Dict">Target dictionary</param>
        /// <param name="EntryKey">A key entry to be added</param>
        /// <param name="EntryValue">A value of entry, or a value to subtract from an already-existing entry</param>
        public static void AddOrDecrement<TKey>(this Dictionary<TKey, ushort> Dict, TKey EntryKey, ushort EntryValue)
        {
            if (EntryKey is null)
                throw new ArgumentNullException(nameof(EntryKey));
            if (!Dict.ContainsKey(EntryKey))
            {
                Dict.Add(EntryKey, EntryValue);
            }
            else
            {
                Dict[EntryKey] -= EntryValue;
            }
        }

        /// <summary>
        /// Adds an entry or decrements a value of an already-existing entry to dictionary
        /// </summary>
        /// <typeparam name="TKey">Key</typeparam>
        /// <param name="Dict">Target dictionary</param>
        /// <param name="EntryKey">A key entry to be added</param>
        /// <param name="EntryValue">A value of entry, or a value to subtract from an already-existing entry</param>
        public static void AddOrDecrement<TKey>(this Dictionary<TKey, float> Dict, TKey EntryKey, float EntryValue)
        {
            if (EntryKey is null)
                throw new ArgumentNullException(nameof(EntryKey));
            if (!Dict.ContainsKey(EntryKey))
            {
                Dict.Add(EntryKey, EntryValue);
            }
            else
            {
                Dict[EntryKey] -= EntryValue;
            }
        }
    }
}