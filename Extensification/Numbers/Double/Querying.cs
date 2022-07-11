
// Extensification  Copyright (C) 2020-2021  EoflaOE
// 
// This file is part of Extensification
// 
// Extensification is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// Extensification is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <https://www.gnu.org/licenses/>.

using System;
using Extensification.IntegerExts;

namespace Extensification.DoubleExts
{
    /// <summary>
    /// Provides the double-precision number extensions related to querying
    /// </summary>
    public static class Querying
    {

        /// <summary>
        /// Makes a list of digits before the decimal point
        /// </summary>
        /// <param name="Number">Number</param>
        /// <returns>Array of digits</returns>
        public static double[] ListDigitsBeforeDecimal(this double Number)
        {
            string StrNum = Number.ToString().Substring(0, Number.ToString().IndexOf("."));
            var NumList = Array.ConvertAll(StrNum.ToCharArray(), x => Convert.ToDouble(x.ToString()));
            return NumList;
        }

        /// <summary>
        /// Makes a list of digits after the decimal point
        /// </summary>
        /// <param name="Number">Number</param>
        /// <returns>Array of digits</returns>
        public static double[] ListDigitsAfterDecimal(this double Number)
        {
            string StrNum = Number.ToString().Substring(Number.ToString().IndexOf(".") + 1);
            var NumList = Array.ConvertAll(StrNum.ToCharArray(), x => Convert.ToDouble(x.ToString()));
            return NumList;
        }

        /// <summary>
        /// Checks to see if the number is an Armstrong number (sum of cube of each digit of number equals the number itself)
        /// </summary>
        /// <param name="Number">Number</param>
        /// <returns>True if the number is an Armstrong number; False if not.</returns>
        public static bool IsArmstrong(this double Number)
        {
            int IntNum = (int)Math.Round(Number);
            var NumberDigits = IntNum.ListDigits();
            var SumOfCubesOfDigits = default(int);
            for (int i = 0, loopTo = NumberDigits.Length - 1; i <= loopTo; i++)
                SumOfCubesOfDigits = (int)Math.Round(SumOfCubesOfDigits + Math.Pow(NumberDigits[i], 3d));
            return IntNum == SumOfCubesOfDigits;
        }

    }
}