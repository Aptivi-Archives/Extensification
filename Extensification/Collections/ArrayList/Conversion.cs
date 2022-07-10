using System;
using System.Collections;
using System.Collections.Generic;

namespace Extensification.ArrayListExts
{
    /// <summary>
    /// Provides the array list extensions related to conversion
    /// </summary>
    public static class Conversion
    {

        /// <summary>
        /// Converts an array list to list of <see cref="Object"/>.
        /// </summary>
        /// <param name="TargetArray">Target array list</param>
        /// <returns>A list from array list</returns>
        public static List<object> ToList(this ArrayList TargetArray)
        {
            if (TargetArray is null)
                throw new ArgumentNullException(nameof(TargetArray));
            var ArrayValues = new List<object>();
            ArrayValues.AddRange(TargetArray.ToArray());
            return ArrayValues;
        }

    }
}