using System.Collections;
using System.Collections.Generic;

namespace Extensification.ListExts
{
    /// <summary>
    /// Provides the list extensions related to conversion
    /// </summary>
    public static class Conversion
    {

        /// <summary>
        /// Converts list to array list
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="TargetList">Target list</param>
        public static ArrayList ToArrayList<T>(this List<T> TargetList)
        {
            var ResultList = new ArrayList();
            ResultList.AddRange(TargetList);
            return ResultList;
        }

    }
}