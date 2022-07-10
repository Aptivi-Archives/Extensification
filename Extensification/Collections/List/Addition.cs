using System.Collections.Generic;

namespace Extensification.ListExts
{
    /// <summary>
    /// Provides the list extensions related to addition
    /// </summary>
    public static class Addition
    {

        /// <summary>
        /// Adds an entry to list if not found
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="TargetList">Target list</param>
        /// <param name="Entry">An entry to be added</param>
        public static void AddIfNotFound<T>(this List<T> TargetList, T Entry)
        {
            if (!TargetList.Contains(Entry))
            {
                TargetList.Add(Entry);
            }
        }

    }
}