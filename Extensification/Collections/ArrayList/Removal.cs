using System;
using System.Collections;

namespace Extensification.ArrayListExts
{
    /// <summary>
    /// Provides the array list extensions related to removal
    /// </summary>
    public static class Removal
    {

        /// <summary>
        /// Tries to remove an entry from the array list
        /// </summary>
        /// <param name="TargetArray">Target array list</param>
        /// <param name="Entry">An entry to be removed</param>
        /// <returns>True if successful; False if unsuccessful</returns>
        public static bool TryRemove(this ArrayList TargetArray, object Entry)
        {
            if (Entry is null)
                throw new ArgumentNullException(nameof(Entry));
            if (!TargetArray.Contains(Entry))
                return false;
            try
            {
                TargetArray.Remove(Entry);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}