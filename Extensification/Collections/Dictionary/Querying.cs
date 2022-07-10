﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Extensification.DictionaryExts
{
    /// <summary>
    /// Provides the dictionary extensions related to querying
    /// </summary>
    public static class Querying
    {

        /// <summary>
        /// Checks to see if the keys in dictionary contains any of the targets.
        /// </summary>
        /// <param name="Dict">Source dictionary</param>
        /// <param name="Targets">Target dictionary</param>
        /// <returns>True if all of them are found; else, false.</returns>
        public static bool ContainsAnyOfInKeys<TKey, TValue>(this Dictionary<TKey, TValue> Dict, TKey[] Targets)
        {
            if (Dict is null)
                throw new ArgumentNullException(nameof(Dict));
            foreach (var Target in Targets)
            {
                if (Dict.ContainsKey(Target))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Checks to see if the values in dictionary contains any of the targets.
        /// </summary>
        /// <param name="Dict">Source dictionary</param>
        /// <param name="Targets">Target dictionary</param>
        /// <returns>True if all of them are found; else, false.</returns>
        public static bool ContainsAnyOfInValues<TKey, TValue>(this Dictionary<TKey, TValue> Dict, TValue[] Targets)
        {
            if (Dict is null)
                throw new ArgumentNullException(nameof(Dict));
            foreach (var Target in Targets)
            {
                if (Dict.ContainsValue(Target))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Checks to see if the keys in dictionary contains all of the targets.
        /// </summary>
        /// <param name="Dict">Source dictionary</param>
        /// <param name="Targets">Target dictionary</param>
        /// <returns>True if all of them are found; else, false.</returns>
        public static bool ContainsAllOfInKeys<TKey, TValue>(this Dictionary<TKey, TValue> Dict, TKey[] Targets)
        {
            if (Dict is null)
                throw new ArgumentNullException(nameof(Dict));
            /* TODO ERROR: Skipped IfDirectiveTrivia
            #If NET45 Then
            *//* TODO ERROR: Skipped DisabledTextTrivia
                        Dim Done() As TKey = {}
            *//* TODO ERROR: Skipped ElseDirectiveTrivia
            #Else
            */
            var Done = Array.Empty<TKey>();
            /* TODO ERROR: Skipped EndIfDirectiveTrivia
            #End If
            */
            foreach (var Target in Targets)
            {
                if (Dict.ContainsKey(Target))
                    ArrayExts.Addition.Add(ref Done, Target);
            }
            return Done.SequenceEqual(Targets);
        }

        /// <summary>
        /// Checks to see if the values in dictionary contains all of the targets.
        /// </summary>
        /// <param name="Dict">Source dictionary</param>
        /// <param name="Targets">Target dictionary</param>
        /// <returns>True if all of them are found; else, false.</returns>
        public static bool ContainsAllOfInValues<TKey, TValue>(this Dictionary<TKey, TValue> Dict, TValue[] Targets)
        {
            if (Dict is null)
                throw new ArgumentNullException(nameof(Dict));
            /* TODO ERROR: Skipped IfDirectiveTrivia
            #If NET45 Then
            *//* TODO ERROR: Skipped DisabledTextTrivia
                        Dim Done() As TValue = {}
            *//* TODO ERROR: Skipped ElseDirectiveTrivia
            #Else
            */
            var Done = Array.Empty<TValue>();
            /* TODO ERROR: Skipped EndIfDirectiveTrivia
            #End If
            */
            foreach (var Target in Targets)
            {
                if (Dict.ContainsValue(Target))
                    ArrayExts.Addition.Add(ref Done, Target);
            }
            return Done.SequenceEqual(Targets);
        }

    }
}