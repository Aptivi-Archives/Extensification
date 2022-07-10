using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualBasic.CompilerServices;

namespace Extensification.ArrayListExts
{
    /// <summary>
    /// Provides the array list extensions related to getting
    /// </summary>
    public static class Getting
    {

        /// <summary>
        /// Gets index of an entry from the list
        /// </summary>
        /// <param name="TargetArray">Target array list</param>
        /// <param name="Entry">An entry found in the list</param>
        /// <returns>List of indexes. If none is found, returns an empty array list</returns>
        public static ArrayList GetIndexOfEntry(this ArrayList TargetArray, object Entry)
        {
            if (TargetArray is null)
                throw new ArgumentNullException(nameof(TargetArray));
            var Indexes = new ArrayList();
            for (int Index = 0, loopTo = TargetArray.Count - 1; Index <= loopTo; Index++)
            {
                var ArrayEntry = TargetArray[Index];
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(ArrayEntry, Entry, false)))
                {
                    Indexes.Add(Index);
                }
            }
            return Indexes;
        }

        /// <summary>
        /// Gets indexes of non-empty items
        /// </summary>
        /// <param name="TargetArray">Target array</param>
        /// <returns>Indexes of non-empty items</returns>
        public static int[] GetIndexesOfFullEntries(this ArrayList TargetArray)
        {
            var FullIndexes = new List<int>();
            for (long i = 0L, loopTo = TargetArray.Count - 1; i <= loopTo; i++)
            {
                if (TargetArray[(int)i] is not null)
                {
                    if (TargetArray[(int)i] is string)
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
        /// <param name="TargetArray">Target array</param>
        /// <returns>Indexes of empty items</returns>
        public static int[] GetIndexesOfEmptyEntries(this ArrayList TargetArray)
        {
            var EmptyIndexes = new List<int>();
            for (long i = 0L, loopTo = TargetArray.Count - 1; i <= loopTo; i++)
            {
                if (TargetArray[(int)i] is null)
                {
                    EmptyIndexes.Add((int)i);
                }
                else if (TargetArray[(int)i] is string & TargetArray[(int)i].Equals(""))
                {
                    EmptyIndexes.Add((int)i);
                }
            }
            return EmptyIndexes.ToArray();
        }

    }
}