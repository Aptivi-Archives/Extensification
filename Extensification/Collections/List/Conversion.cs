
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

using System.Collections;
using System.Collections.Generic;

namespace Extensification.ListExts
{
    /// <summary>
    /// Provides the list extensions related to conversion
    /// </summary>
    public static class Conversion
    {

        /// <summary>
        /// Converts list to array list
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="TargetList">Target list</param>
        public static ArrayList ToArrayList<T>(this List<T> TargetList)
        {
            var ResultList = new ArrayList();
            ResultList.AddRange(TargetList);
            return ResultList;
        }

    }
}