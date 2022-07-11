
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
    /// Provides the list extensions related to counting
    /// </summary>
    public static class Counts
    {

        /// <summary>
        /// Gets how many non-empty items are there
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="TargetList">Target list</param>
        /// <returns>Count of non-empty items</returns>
        public static int CountFullEntries<T>(this List<T> TargetList)
        {
            var FullEntries = default(int);
            for (long i = 0L, loopTo = TargetList.Count - 1; i <= loopTo; i++)
            {
                if (TargetList[(int)i] is not null)
                {
                    if (TargetList[(int)i] is string)
                    {
                        if (!TargetList[(int)i].Equals(""))
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
        /// Gets how many empty items are there
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="TargetList">Target list</param>
        /// <returns>Count of empty items</returns>
        public static int CountEmptyEntries<T>(this List<T> TargetList)
        {
            var EmptyEntries = default(int);
            for (long i = 0L, loopTo = TargetList.Count - 1; i <= loopTo; i++)
            {
                if (TargetList[(int)i] is null)
                {
                    EmptyEntries += 1;
                }
                else if (TargetList[(int)i] is string & TargetList[(int)i].Equals(""))
                {
                    EmptyEntries += 1;
                }
            }
            return EmptyEntries;
        }

    }
}