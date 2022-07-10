using System;
using System.Collections;

namespace Extensification.ArrayExts
{
    /// <summary>
    /// Provides the array extensions related to conversion
    /// </summary>
    public static class Conversion
    {

        /// <summary>
        /// Converts array to array list
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="TargetArray">Target array</param>
        /// <returns>An array list of an array</returns>
        public static ArrayList ToArrayList<T>(this T[] TargetArray)
        {
            if (TargetArray is null)
                throw new ArgumentNullException(nameof(TargetArray));
            var ArrayValues = new ArrayList();
            ArrayValues.AddRange(TargetArray);
            return ArrayValues;
        }

    }
}