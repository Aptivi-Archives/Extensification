﻿using System;
using System.Collections;
using System.Linq;
using Extensification.ArrayExts;

namespace Extensification.ArrayListExts
{
    /// <summary>
    /// Provides the array list extensions related to querying
    /// </summary>
    public static class Querying
    {

        /// <summary>
        /// Checks to see if the array contains any of the targets.
        /// </summary>
        /// <param name="TargetArray">Source array</param>
        /// <param name="Targets">Target array</param>
        /// <returns>True if all of them are found; else, false.</returns>
        public static bool ContainsAnyOf(this ArrayList TargetArray, ArrayList Targets)
        {
            if (TargetArray is null)
                throw new ArgumentNullException(nameof(TargetArray));
            foreach (var Target in Targets)
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
        public static bool ContainsAllOf(this ArrayList TargetArray, ArrayList Targets)
        {
            if (TargetArray is null)
                throw new ArgumentNullException(nameof(TargetArray));
            /* TODO ERROR: Skipped IfDirectiveTrivia
            #If NET45 Then
            *//* TODO ERROR: Skipped DisabledTextTrivia
                        Dim Done() As Object = {}
            *//* TODO ERROR: Skipped ElseDirectiveTrivia
            #Else
            */
            var Done = Array.Empty<object>();
            /* TODO ERROR: Skipped EndIfDirectiveTrivia
            #End If
            */
            foreach (var Target in Targets)
            {
                if (TargetArray.Contains(Target))
                    Addition.Add(ref Done, Target);
            }
            return Done.SequenceEqual(Targets.ToArray());
        }

    }
}