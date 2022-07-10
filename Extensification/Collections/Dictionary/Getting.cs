using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualBasic.CompilerServices;

namespace Extensification.DictionaryExts
{
    /// <summary>
    /// Provides the dictionary extensions related to getting
    /// </summary>
    public static class Getting
    {

        /// <summary>
        /// Gets a key from a value in the dictionary
        /// </summary>
        /// <typeparam name="TKey">Key</typeparam>
        /// <typeparam name="TValue">Value</typeparam>
        /// <param name="Dict">Source dictionary</param>
        /// <param name="Value">Value</param>
        /// <returns>Key from value</returns>
        public static TKey GetKeyFromValue<TKey, TValue>(this Dictionary<TKey, TValue> Dict, TValue Value)
        {
            if (Dict is null)
                throw new ArgumentNullException(nameof(Dict));
            foreach (TKey DictKey in Dict.Keys)
            {
                if (Dict[DictKey].Equals(Value))
                {
                    return DictKey;
                }
            }
            return default;
        }

        /// <summary>
        /// Gets an index from a key in the dictionary
        /// </summary>
        /// <typeparam name="TKey">Key</typeparam>
        /// <typeparam name="TValue">Value</typeparam>
        /// <param name="Dict">Source dictionary</param>
        /// <param name="Key">Key</param>
        /// <returns>Index of key</returns>
        public static int GetIndexOfKey<TKey, TValue>(this Dictionary<TKey, TValue> Dict, TKey Key)
        {
            if (Dict is null)
                throw new ArgumentNullException(nameof(Dict));
            int DetectedIndex = 0;
            for (int Index = 0, loopTo = Dict.Count - 1; Index <= loopTo; Index++)
            {
                object ListEntry = Dict.Keys.ElementAtOrDefault(Index);
                if (ListEntry.Equals(Key))
                {
                    DetectedIndex = Index;
                }
            }
            return DetectedIndex;
        }

        /// <summary>
        /// Gets an index from a value in the dictionary
        /// </summary>
        /// <typeparam name="TKey">Key</typeparam>
        /// <typeparam name="TValue">Value</typeparam>
        /// <param name="Dict">Source dictionary</param>
        /// <param name="Value">Value</param>
        /// <returns>Index of value</returns>
        public static int GetIndexOfValue<TKey, TValue>(this Dictionary<TKey, TValue> Dict, TValue Value)
        {
            if (Dict is null)
                throw new ArgumentNullException(nameof(Dict));
            int DetectedIndex = 0;
            for (int Index = 0, loopTo = Dict.Count - 1; Index <= loopTo; Index++)
            {
                object ListEntry = Dict.Values.ElementAtOrDefault(Index);
                if (ListEntry.Equals(Value))
                {
                    DetectedIndex = Index;
                }
            }
            return DetectedIndex;
        }

        /// <summary>
        /// Gets indexes of non-empty items
        /// </summary>
        /// <typeparam name="TKey">Key</typeparam>
        /// <typeparam name="TValue">Value</typeparam>
        /// <param name="Dict">Target dictionary</param>
        /// <returns>Indexes of non-empty items</returns>
        public static int[] GetIndexesOfFullEntries<TKey, TValue>(this Dictionary<TKey, TValue> Dict)
        {
            var FullIndexes = new List<int>();
            for (int i = 0, loopTo = Dict.Count - 1; i <= loopTo; i++)
            {
                if (Dict.Values.ElementAtOrDefault(i) is not null)
                {
                    if (Conversions.ToBoolean(Dict.Values.ElementAtOrDefault(i) is string))
                    {
                        if (!Dict.Values.ElementAtOrDefault(i).Equals(""))
                        {
                            FullIndexes.Add(i);
                        }
                    }
                    else
                    {
                        FullIndexes.Add(i);
                    }
                }
            }
            return FullIndexes.ToArray();
        }

        /// <summary>
        /// Gets indexes of empty items
        /// </summary>
        /// <typeparam name="TKey">Key</typeparam>
        /// <typeparam name="TValue">Value</typeparam>
        /// <param name="Dict">Target dictionary</param>
        /// <returns>Indexes of empty items</returns>
        public static int[] GetIndexesOfEmptyEntries<TKey, TValue>(this Dictionary<TKey, TValue> Dict)
        {
            var EmptyIndexes = new List<int>();
            for (int i = 0, loopTo = Dict.Count - 1; i <= loopTo; i++)
            {
                if (Dict.Values.ElementAtOrDefault(i) is null)
                {
                    EmptyIndexes.Add(i);
                }
                else if (Conversions.ToBoolean(Dict.Values.ElementAtOrDefault(i) is string) & Dict.Values.ElementAtOrDefault(i).Equals(""))
                {
                    EmptyIndexes.Add(i);
                }
            }
            return EmptyIndexes.ToArray();
        }

    }
}