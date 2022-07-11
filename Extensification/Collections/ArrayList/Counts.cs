
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

using System.Collections;

namespace Extensification.ArrayListExts
{
    /// <summary>
    /// Provides the array list extensions related to counting
    /// </summary>
    public static class Counts
    {

        /// <summary>
        /// Gets how many non-empty items are there
        /// </summary>
        /// <param name="TargetArray">Target array</param>
        /// <returns>Count of non-empty items</returns>
        public static long CountFullEntries(this ArrayList TargetArray)
        {
            var FullEntries = default(long);
            for (long i = 0L, loopTo = TargetArray.Count - 1; i <= loopTo; i++)
            {
                if (TargetArray[(int)i] is not null)
                {
                    if (TargetArray[(int)i] is string)
                    {
                        if (!TargetArray[(int)i].Equals(""))
                        {
                            FullEntries += 1L;
                        }
                    }
                    else
                    {
                        FullEntries += 1L;
                    }
                }
            }
            return FullEntries;
        }

        /// <summary>
        /// Gets how many empty items are there
        /// </summary>
        /// <param name="TargetArray">Target array</param>
        /// <returns>Count of empty items</returns>
        public static long CountEmptyEntries(this ArrayList TargetArray)
        {
            var EmptyEntries = default(long);
            for (long i = 0L, loopTo = TargetArray.Count - 1; i <= loopTo; i++)
            {
                if (TargetArray[(int)i] is null)
                {
                    EmptyEntries += 1L;
                }
                else if (TargetArray[(int)i] is string & TargetArray[(int)i].Equals(""))
                {
                    EmptyEntries += 1L;
                }
            }
            return EmptyEntries;
        }

    }
}