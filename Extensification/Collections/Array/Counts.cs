using Microsoft.VisualBasic.CompilerServices;

namespace Extensification.ArrayExts
{
    /// <summary>
    /// Provides the array extensions related to counting
    /// </summary>
    public static class Counts
    {

        /// <summary>
        /// Gets how many non-empty items are there
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="TargetArray">Target array</param>
        /// <returns>Count of non-empty items</returns>
        public static long CountFullEntries<T>(this T[] TargetArray)
        {
            var FullEntries = default(long);
            for (long i = 0L, loopTo = TargetArray.LongLength - 1L; i <= loopTo; i++)
            {
                if (TargetArray[(int)i] is not null)
                {
                    if (Conversions.ToBoolean(TargetArray[(int)i] is string))
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
        /// <typeparam name="T">Type</typeparam>
        /// <param name="TargetArray">Target array</param>
        /// <returns>Count of empty items</returns>
        public static long CountEmptyEntries<T>(this T[] TargetArray)
        {
            var EmptyEntries = default(long);
            for (long i = 0L, loopTo = TargetArray.LongLength - 1L; i <= loopTo; i++)
            {
                if (TargetArray[(int)i] is null)
                {
                    EmptyEntries += 1L;
                }
                else if (Conversions.ToBoolean(TargetArray[(int)i] is string) & TargetArray[(int)i].Equals(""))
                {
                    EmptyEntries += 1L;
                }
            }
            return EmptyEntries;
        }

    }
}