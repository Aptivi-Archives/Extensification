using System;
using System.Collections.Generic;

namespace Extensification.ListExts
{
    /// <summary>
    /// Provides the list extensions related to removal
    /// </summary>
    public static class Removal
    {

        /// <summary>
        /// Tries to remove an entry from the list
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="TargetList">Target list</param>
        /// <param name="Entry">An entry to be removed</param>
        /// <returns>True if successful; False if unsuccessful</returns>
        public static bool TryRemove<T>(this List<T> TargetList, T Entry)
        {
            if (Entry is null)
                throw new ArgumentNullException(nameof(Entry));
            try
            {
                return TargetList.Remove(Entry);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}