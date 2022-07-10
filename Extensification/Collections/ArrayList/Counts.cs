using System.Collections;

namespace Extensification.ArrayListExts
{
    /// <summary>
    /// Provides the array list extensions related to counting
    /// </summary>
    public static class Counts
    {

        /// <summary>
        /// Gets how many non-empty items are there
        /// </summary>
        /// <param name="TargetArray">Target array</param>
        /// <returns>Count of non-empty items</returns>
        public static long CountFullEntries(this ArrayList TargetArray)
        {
            var FullEntries = default(long);
            for (long i = 0L, loopTo = TargetArray.Count - 1; i <= loopTo; i++)
            {
                if (TargetArray[(int)i] is not null)
                {
                    if (TargetArray[(int)i] is string)
                    {
                        if (!TargetArray[(int)i].Equals(""))
                        {
                            FullEntries += 1L;
                        }
                    }
                    else
                    {
                        FullEntries += 1L;
                    }
                }
            }
            return FullEntries;
        }

        /// <summary>
        /// Gets how many empty items are there
        /// </summary>
        /// <param name="TargetArray">Target array</param>
        /// <returns>Count of empty items</returns>
        public static long CountEmptyEntries(this ArrayList TargetArray)
        {
            var EmptyEntries = default(long);
            for (long i = 0L, loopTo = TargetArray.Count - 1; i <= loopTo; i++)
            {
                if (TargetArray[(int)i] is null)
                {
                    EmptyEntries += 1L;
                }
                else if (TargetArray[(int)i] is string & TargetArray[(int)i].Equals(""))
                {
                    EmptyEntries += 1L;
                }
            }
            return EmptyEntries;
        }

    }
}