
// Extensification  Copyright (C) 2020-2021  Aptivi
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

namespace Extensification.ByteExts
{
    /// <summary>
    /// Provides the byte extensions related to querying
    /// </summary>
    public static class Querying
    {

        /// <summary>
        /// Makes a list of digits
        /// </summary>
        /// <param name="Number">Number</param>
        /// <returns>Array of digits</returns>
        public static byte[] ListDigits(this byte Number)
        {
            string StrNum = Number.ToString();
            var NumList = Array.ConvertAll(StrNum.ToCharArray(), x => Convert.ToByte(x.ToString()));
            return NumList;
        }

        /// <summary>
        /// Makes a list of digits
        /// </summary>
        /// <param name="Number">Number</param>
        /// <returns>Array of digits</returns>
        public static sbyte[] ListDigits(this sbyte Number)
        {
            string StrNum = Number.ToString();
            var NumList = Array.ConvertAll(StrNum.ToCharArray(), x => Convert.ToSByte(x.ToString()));
            return NumList;
        }

        /// <summary>
        /// Checks to see if the number is an Armstrong number (sum of cube of each digit of number equals the number itself)
        /// </summary>
        /// <param name="Number">Number</param>
        /// <returns>True if the number is an Armstrong number; False if not.</returns>
        public static bool IsArmstrong(this byte Number)
        {
            byte IntNum = Number;
            var NumberDigits = IntNum.ListDigits();
            var SumOfCubesOfDigits = default(byte);
            for (byte i = 0, loopTo = (byte)(NumberDigits.Length - 1); i <= loopTo; i++)
                SumOfCubesOfDigits = (byte)Math.Round(SumOfCubesOfDigits + Math.Pow(NumberDigits[i], 3d));
            return IntNum == SumOfCubesOfDigits;
        }

        /// <summary>
        /// Checks to see if the number is an Armstrong number (sum of cube of each digit of number equals the number itself)
        /// </summary>
        /// <param name="Number">Number</param>
        /// <returns>True if the number is an Armstrong number; False if not.</returns>
        public static bool IsArmstrong(this sbyte Number)
        {
            sbyte IntNum = Number;
            var NumberDigits = IntNum.ListDigits();
            var SumOfCubesOfDigits = default(sbyte);
            for (sbyte i = 0, loopTo = (sbyte)(NumberDigits.Length - 1); i <= loopTo; i++)
                SumOfCubesOfDigits = (sbyte)Math.Round(SumOfCubesOfDigits + Math.Pow(NumberDigits[i], 3d));
            return IntNum == SumOfCubesOfDigits;
        }

    }
}