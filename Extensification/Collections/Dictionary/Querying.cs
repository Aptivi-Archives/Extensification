﻿
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

using Extensification.ArrayExts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Extensification.DictionaryExts
{
    /// <summary>
    /// Provides the dictionary extensions related to querying
    /// </summary>
    public static class Querying
    {

        /// <summary>
        /// Checks to see if the keys in dictionary contains any of the targets.
        /// </summary>
        /// <param name="Dict">Source dictionary</param>
        /// <param name="Targets">Target dictionary</param>
        /// <returns>True if all of them are found; else, false.</returns>
        public static bool ContainsAnyOfInKeys<TKey, TValue>(this Dictionary<TKey, TValue> Dict, TKey[] Targets)
        {
            if (Dict is null)
                throw new ArgumentNullException(nameof(Dict));
            foreach (var Target in Targets)
            {
                if (Dict.ContainsKey(Target))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Checks to see if the values in dictionary contains any of the targets.
        /// </summary>
        /// <param name="Dict">Source dictionary</param>
        /// <param name="Targets">Target dictionary</param>
        /// <returns>True if all of them are found; else, false.</returns>
        public static bool ContainsAnyOfInValues<TKey, TValue>(this Dictionary<TKey, TValue> Dict, TValue[] Targets)
        {
            if (Dict is null)
                throw new ArgumentNullException(nameof(Dict));
            foreach (var Target in Targets)
            {
                if (Dict.ContainsValue(Target))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Checks to see if the keys in dictionary contains all of the targets.
        /// </summary>
        /// <param name="Dict">Source dictionary</param>
        /// <param name="Targets">Target dictionary</param>
        /// <returns>True if all of them are found; else, false.</returns>
        public static bool ContainsAllOfInKeys<TKey, TValue>(this Dictionary<TKey, TValue> Dict, TKey[] Targets)
        {
            if (Dict is null)
                throw new ArgumentNullException(nameof(Dict));
            var Done = Array.Empty<TKey>();
            foreach (var Target in Targets)
            {
                if (Dict.ContainsKey(Target))
                    Done = Done.Add(Target);
            }
            return Done.SequenceEqual(Targets);
        }

        /// <summary>
        /// Checks to see if the values in dictionary contains all of the targets.
        /// </summary>
        /// <param name="Dict">Source dictionary</param>
        /// <param name="Targets">Target dictionary</param>
        /// <returns>True if all of them are found; else, false.</returns>
        public static bool ContainsAllOfInValues<TKey, TValue>(this Dictionary<TKey, TValue> Dict, TValue[] Targets)
        {
            if (Dict is null)
                throw new ArgumentNullException(nameof(Dict));
            var Done = Array.Empty<TValue>();
            foreach (var Target in Targets)
            {
                if (Dict.ContainsValue(Target))
                    Done = Done.Add(Target);
            }
            return Done.SequenceEqual(Targets);
        }

    }
}