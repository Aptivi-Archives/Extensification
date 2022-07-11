
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

using System.Collections.Generic;

namespace Extensification.ListExts
{
    /// <summary>
    /// Provides the list extensions related to getting
    /// </summary>
    public static class Getting
    {

        /// <summary>
        /// Gets indexes from entry
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="TargetList">Target list</param>
        /// <param name="Entry">An entry</param>
        /// <returns>List of indexes from entry</returns>
        public static List<int> GetIndexFromEntry<T>(this List<T> TargetList, T Entry)
        {
            var Indexes = new List<int>();
            for (int Index = 0, loopTo = TargetList.Count - 1; Index <= loopTo; Index++)
            {
                if (TargetList[Index].Equals(Entry))
                {
                    Indexes.Add(Index);
                }
            }
            return Indexes;
        }

        /// <summary>
        /// Gets indexes of non-empty items
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="TargetList">Target list</param>
        /// <returns>Indexes of non-empty items</returns>
        public static int[] GetIndexesOfFullEntries<T>(this List<T> TargetList)
        {
            var FullIndexes = new List<int>();
            for (long i = 0L, loopTo = TargetList.Count - 1; i <= loopTo; i++)
            {
                if (TargetList[(int)i] is not null)
                {
                    if (TargetList[(int)i] is string)
                    {
                        if (!TargetList[(int)i].Equals(""))
                        {
                            FullIndexes.Add((int)i);
                        }
                    }
                    else
                    {
                        FullIndexes.Add((int)i);
                    }
                }
            }
            return FullIndexes.ToArray();
        }

        /// <summary>
        /// Gets indexes of empty items
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="TargetList">Target list</param>
        /// <returns>Indexes of empty items</returns>
        public static int[] GetIndexesOfEmptyEntries<T>(this List<T> TargetList)
        {
            var EmptyIndexes = new List<int>();
            for (long i = 0L, loopTo = TargetList.Count - 1; i <= loopTo; i++)
            {
                if (TargetList[(int)i] is null)
                {
                    EmptyIndexes.Add((int)i);
                }
                else if (TargetList[(int)i] is string & TargetList[(int)i].Equals(""))
                {
                    EmptyIndexes.Add((int)i);
                }
            }
            return EmptyIndexes.ToArray();
        }

    }
}