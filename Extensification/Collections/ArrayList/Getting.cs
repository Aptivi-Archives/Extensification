
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
using System.Collections.Generic;

namespace Extensification.ArrayListExts
{
    /// <summary>
    /// Provides the array list extensions related to getting
    /// </summary>
    public static class Getting
    {

        /// <summary>
        /// Gets index of an entry from the list
        /// </summary>
        /// <param name="TargetArray">Target array list</param>
        /// <param name="Entry">An entry found in the list</param>
        /// <returns>List of indexes. If none is found, returns an empty array list</returns>
        public static ArrayList GetIndexOfEntry(this ArrayList TargetArray, object Entry)
        {
            if (TargetArray is null)
                throw new ArgumentNullException(nameof(TargetArray));
            var Indexes = new ArrayList();
            for (int Index = 0, loopTo = TargetArray.Count - 1; Index <= loopTo; Index++)
            {
                var ArrayEntry = TargetArray[Index];
                if (ArrayEntry.Equals(Entry))
                    Indexes.Add(Index);
            }
            return Indexes;
        }

        /// <summary>
        /// Gets indexes of non-empty items
        /// </summary>
        /// <param name="TargetArray">Target array</param>
        /// <returns>Indexes of non-empty items</returns>
        public static int[] GetIndexesOfFullEntries(this ArrayList TargetArray)
        {
            var FullIndexes = new List<int>();
            for (long i = 0L, loopTo = TargetArray.Count - 1; i <= loopTo; i++)
            {
                if (TargetArray[(int)i] is not null)
                {
                    if (TargetArray[(int)i] is string)
                    {
                        if (!TargetArray[(int)i].Equals(""))
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
        /// <param name="TargetArray">Target array</param>
        /// <returns>Indexes of empty items</returns>
        public static int[] GetIndexesOfEmptyEntries(this ArrayList TargetArray)
        {
            var EmptyIndexes = new List<int>();
            for (long i = 0L, loopTo = TargetArray.Count - 1; i <= loopTo; i++)
            {
                if (TargetArray[(int)i] is null)
                {
                    EmptyIndexes.Add((int)i);
                }
                else if (TargetArray[(int)i] is string & TargetArray[(int)i].Equals(""))
                {
                    EmptyIndexes.Add((int)i);
                }
            }
            return EmptyIndexes.ToArray();
        }

    }
}