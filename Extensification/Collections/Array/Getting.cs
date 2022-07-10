using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualBasic.CompilerServices;

namespace Extensification.ArrayExts
{
    /// <summary>
    /// Provides the array extensions related to getting
    /// </summary>
    public static class Getting
    {

        /// <summary>
        /// Gets index from entry
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="TargetArray">Target array</param>
        /// <param name="Entry">An entry from array</param>
        /// <returns>List of indexes. If none is found, returns an empty array list</returns>
        public static int[] GetIndexFromEntry<T>(this T[] TargetArray, T Entry)
        {
            if (TargetArray is null)
                throw new ArgumentNullException(nameof(TargetArray));
            var Indexes = new ArrayList();
            for (int Index = 0, loopTo = TargetArray.Length - 1; Index <= loopTo; Index++)
            {
                object ArrayEntry = TargetArray[Index];
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(ArrayEntry, Entry, false)))
                {
                    Indexes.Add(Index);
                }
            }
            return (int[])Indexes.ToArray(typeof(int));
        }

        /// <summary>
        /// Gets indexes of non-empty items
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="TargetArray">Target array</param>
        /// <returns>Indexes of non-empty items</returns>
        public static int[] GetIndexesOfFullEntries<T>(this T[] TargetArray)
        {
            var FullIndexes = new List<int>();
            for (long i = 0L, loopTo = TargetArray.LongLength - 1L; i <= loopTo; i++)
            {
                if (TargetArray[(int)i] is not null)
                {
                    if (Conversions.ToBoolean(TargetArray[(int)i] is string))
                    {
                        if (!TargetArray[(int)i].Equals(""))
                        {
                            FullIndexes.Add((int)i);
                        }
                    }
                    else
                    {
                        FullIndexes.Add((int)i);
                    }
                }
            }
            return FullIndexes.ToArray();
        }

        /// <summary>
        /// Gets indexes of empty items
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="TargetArray">Target array</param>
        /// <returns>Indexes of empty items</returns>
        public static int[] GetIndexesOfEmptyEntries<T>(this T[] TargetArray)
        {
            var EmptyIndexes = new List<int>();
            for (long i = 0L, loopTo = TargetArray.LongLength - 1L; i <= loopTo; i++)
            {
                if (TargetArray[(int)i] is null)
                {
                    EmptyIndexes.Add((int)i);
                }
                else if (Conversions.ToBoolean(TargetArray[(int)i] is string) & TargetArray[(int)i].Equals(""))
                {
                    EmptyIndexes.Add((int)i);
                }
            }
            return EmptyIndexes.ToArray();
        }

    }
}