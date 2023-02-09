
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

namespace Extensification.NetFX.EnumerableExts
{
    /// <summary>
    /// Provides the enumerable extensions related to addition
    /// </summary>
    public static class Addition
    {
        /// <summary>
        /// Appends a value to the end of the sequence
        /// </summary>
        /// <typeparam name="Source">Source type</typeparam>
        /// <param name="TargetEnumerable">Source</param>
        /// <param name="Value">Value</param>
        public static IEnumerable<Source> Append<Source>(this IEnumerable<Source> TargetEnumerable, Source Value)
        {
            return TargetEnumerable.Concat(new[] { Value });
        }
    }
}