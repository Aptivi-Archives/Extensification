
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

namespace Extensification.EnumerableExts
{
    /// <summary>
    /// Provides the enumerable extensions related to manipulation
    /// </summary>
    public static class Manipulation
    {

        /// <summary>
        /// Stringifies the character enumerable (making a string from the character entries found inside the enumerable)
        /// </summary>
        /// <param name="TargetCharArray">Character enumerable</param>
        public static string Stringify(this IEnumerable<char> TargetCharArray)
        {
            return string.Join("", TargetCharArray);
        }

    }
}