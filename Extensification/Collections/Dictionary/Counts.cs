
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

using System.Collections.Generic;
using System.Linq;

namespace Extensification.DictionaryExts
{
    /// <summary>
    /// Provides the dictionary extensions related to counting
    /// </summary>
    public static class Counts
    {

        /// <summary>
        /// Gets how many non-empty values are there (Empty keys are not counted)
        /// </summary>
        /// <typeparam name="TKey">Key</typeparam>
        /// <typeparam name="TValue">Value</typeparam>
        /// <param name="Dict">Target dictionary</param>
        /// <returns>Count of non-empty values</returns>
        public static int CountFullEntries<TKey, TValue>(this Dictionary<TKey, TValue> Dict)
        {
            var FullEntries = default(int);
            for (int i = 0, loopTo = Dict.Count - 1; i <= loopTo; i++)
            {
                if (Dict.Values.ElementAtOrDefault(i) is not null)
                {
                    if (Dict.Values.ElementAtOrDefault(i) is string)
                    {
                        if (!Dict.Values.ElementAtOrDefault(i).Equals(""))
                        {
                            FullEntries += 1;
                        }
                    }
                    else
                    {
                        FullEntries += 1;
                    }
                }
            }
            return FullEntries;
        }

        /// <summary>
        /// Gets how many empty values are there (Empty keys are not counted)
        /// </summary>
        /// <typeparam name="TKey">Key</typeparam>
        /// <typeparam name="TValue">Value</typeparam>
        /// <param name="Dict">Target dictionary</param>
        /// <returns>Count of empty values</returns>
        public static int CountEmptyEntries<TKey, TValue>(this Dictionary<TKey, TValue> Dict)
        {
            var EmptyEntries = default(int);
            for (int i = 0, loopTo = Dict.Count - 1; i <= loopTo; i++)
            {
                if (Dict.Values.ElementAtOrDefault(i) is null)
                {
                    EmptyEntries += 1;
                }
                else if (Dict.Values.ElementAtOrDefault(i) is string & Dict.Values.ElementAtOrDefault(i).Equals(""))
                {
                    EmptyEntries += 1;
                }
            }
            return EmptyEntries;
        }

    }
}