using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualBasic.CompilerServices;

namespace Extensification.DictionaryExts
{
    /// <summary>
    /// Provides the dictionary extensions related to counting
    /// </summary>
    public static class Counts
    {

        /// <summary>
        /// Gets how many non-empty values are there (Empty keys are not counted)
        /// </summary>
        /// <typeparam name="TKey">Key</typeparam>
        /// <typeparam name="TValue">Value</typeparam>
        /// <param name="Dict">Target dictionary</param>
        /// <returns>Count of non-empty values</returns>
        public static int CountFullEntries<TKey, TValue>(this Dictionary<TKey, TValue> Dict)
        {
            var FullEntries = default(int);
            for (int i = 0, loopTo = Dict.Count - 1; i <= loopTo; i++)
            {
                if (Dict.Values.ElementAtOrDefault(i) is not null)
                {
                    if (Conversions.ToBoolean(Dict.Values.ElementAtOrDefault(i) is string))
                    {
                        if (!Dict.Values.ElementAtOrDefault(i).Equals(""))
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
        /// Gets how many empty values are there (Empty keys are not counted)
        /// </summary>
        /// <typeparam name="TKey">Key</typeparam>
        /// <typeparam name="TValue">Value</typeparam>
        /// <param name="Dict">Target dictionary</param>
        /// <returns>Count of empty values</returns>
        public static int CountEmptyEntries<TKey, TValue>(this Dictionary<TKey, TValue> Dict)
        {
            var EmptyEntries = default(int);
            for (int i = 0, loopTo = Dict.Count - 1; i <= loopTo; i++)
            {
                if (Dict.Values.ElementAtOrDefault(i) is null)
                {
                    EmptyEntries += 1;
                }
                else if (Conversions.ToBoolean(Dict.Values.ElementAtOrDefault(i) is string) & Dict.Values.ElementAtOrDefault(i).Equals(""))
                {
                    EmptyEntries += 1;
                }
            }
            return EmptyEntries;
        }

    }
}