
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

using System;
using System.Collections;
using System.Collections.Generic;

namespace Extensification.ArrayListExts
{
    /// <summary>
    /// Provides the array list extensions related to conversion
    /// </summary>
    public static class Conversion
    {

        /// <summary>
        /// Converts an array list to list of <see cref="Object"/>.
        /// </summary>
        /// <param name="TargetArray">Target array list</param>
        /// <returns>A list from array list</returns>
        public static List<object> ToList(this ArrayList TargetArray)
        {
            if (TargetArray is null)
                throw new ArgumentNullException(nameof(TargetArray));
            var ArrayValues = new List<object>();
            ArrayValues.AddRange(TargetArray.ToArray());
            return ArrayValues;
        }

    }
}