using System;
using System.Linq;

namespace Extensification.ArrayExts
{
    /// <summary>
    /// Provides the array extensions related to querying
    /// </summary>
    public static class Querying
    {

        /// <summary>
        /// Checks to see if the array contains any of the targets.
        /// </summary>
        /// <param name="TargetArray">Source array</param>
        /// <param name="Targets">Target array</param>
        /// <returns>True if all of them are found; else, false.</returns>
        public static bool ContainsAnyOf<T>(this T[] TargetArray, T[] Targets)
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
        public static bool ContainsAllOf<T>(this T[] TargetArray, T[] Targets)
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
                    Addition.Add(ref Done, Target);
            }
            return Done.SequenceEqual(Targets);
        }

    }
}