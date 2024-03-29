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

using System;
using System.Collections;

namespace Extensification.ArrayExts
{
    /// <summary>
    /// Provides the array extensions related to conversion
    /// </summary>
    public static class Conversion
    {

        /// <summary>
        /// Converts array to array list
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="TargetArray">Target array</param>
        /// <returns>An array list of an array</returns>
        public static ArrayList ToArrayList<T>(this T[] TargetArray)
        {
            if (TargetArray is null)
                throw new ArgumentNullException(nameof(TargetArray));
            var ArrayValues = new ArrayList();
            ArrayValues.AddRange(TargetArray);
            return ArrayValues;
        }

    }
}