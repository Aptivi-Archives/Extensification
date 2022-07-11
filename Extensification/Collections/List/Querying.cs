
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
using System.Collections.Generic;
using System.Linq;

namespace Extensification.ListExts
{
    /// <summary>
    /// Provides the list extensions related to querying
    /// </summary>
    public static class Querying
    {

        /// <summary>
        /// Checks to see if the array contains any of the targets.
        /// </summary>
        /// <param name="TargetArray">Source array</param>
        /// <param name="Targets">Target array</param>
        /// <returns>True if all of them are found; else, false.</returns>
        public static bool ContainsAnyOf<T>(this List<T> TargetArray, T[] Targets)
        {
            if (TargetArray is null)
                throw new ArgumentNullException(nameof(TargetArray));
            foreach (T Target in Targets)
            {
                if (TargetArray.Contains(Target))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Checks to see if the array contains all of the targets.
        /// </summary>
        /// <param name="TargetArray">Source array</param>
        /// <param name="Targets">Target array</param>
        /// <returns>True if all of them are found; else, false.</returns>
        public static bool ContainsAllOf<T>(this List<T> TargetArray, T[] Targets)
        {
            if (TargetArray is null)
                throw new ArgumentNullException(nameof(TargetArray));
            /* TODO ERROR: Skipped IfDirectiveTrivia
            #If NET45 Then
            *//* TODO ERROR: Skipped DisabledTextTrivia
                        Dim Done() As T = {}
            *//* TODO ERROR: Skipped ElseDirectiveTrivia
            #Else
            */
            var Done = Array.Empty<T>();
            /* TODO ERROR: Skipped EndIfDirectiveTrivia
            #End If
            */
            foreach (T Target in Targets)
            {
                if (TargetArray.Contains(Target))
                    ArrayExts.Addition.Add(ref Done, Target);
            }
            return Done.SequenceEqual(Targets);
        }

    }
}