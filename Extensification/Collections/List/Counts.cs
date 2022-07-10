using System.Collections.Generic;
using Microsoft.VisualBasic.CompilerServices;

namespace Extensification.ListExts
{
    /// <summary>
    /// Provides the list extensions related to counting
    /// </summary>
    public static class Counts
    {

        /// <summary>
        /// Gets how many non-empty items are there
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="TargetList">Target list</param>
        /// <returns>Count of non-empty items</returns>
        public static int CountFullEntries<T>(this List<T> TargetList)
        {
            var FullEntries = default(int);
            for (long i = 0L, loopTo = TargetList.Count - 1; i <= loopTo; i++)
            {
                if (TargetList[(int)i] is not null)
                {
                    if (Conversions.ToBoolean(TargetList[(int)i] is string))
                    {
                        if (!TargetList[(int)i].Equals(""))
                        {
                            FullEntries += 1;
                        }
                    }
                    else
                    {
                        FullEntries += 1;
                    }
                }
            }
            return FullEntries;
        }

        /// <summary>
        /// Gets how many empty items are there
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="TargetList">Target list</param>
        /// <returns>Count of empty items</returns>
        public static int CountEmptyEntries<T>(this List<T> TargetList)
        {
            var EmptyEntries = default(int);
            for (long i = 0L, loopTo = TargetList.Count - 1; i <= loopTo; i++)
            {
                if (TargetList[(int)i] is null)
                {
                    EmptyEntries += 1;
                }
                else if (Conversions.ToBoolean(TargetList[(int)i] is string) & TargetList[(int)i].Equals(""))
                {
                    EmptyEntries += 1;
                }
            }
            return EmptyEntries;
        }

    }
}