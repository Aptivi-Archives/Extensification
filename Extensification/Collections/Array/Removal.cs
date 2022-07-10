using System;
using System.Linq;

namespace Extensification.ArrayExts
{
    /// <summary>
    /// Provides the array extensions related to removal
    /// </summary>
    public static class Removal
    {

        /// <summary>
        /// Removes an entry from array
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="TargetArray">Target array</param>
        /// <param name="Item">Any item</param>
        public static void Remove<T>(ref T[] TargetArray, T Item)
        {
            if (TargetArray is null)
                throw new ArgumentNullException(nameof(TargetArray));
            var TargetArrayList = TargetArray.ToList();
            TargetArrayList.Remove(Item);
            TargetArray = TargetArrayList.ToArray();
        }

    }
}