﻿using System;
using Extensification.IntegerExts;

namespace Extensification.ShortExts
{
    /// <summary>
    /// Provides the 16-bit integer extensions related to querying
    /// </summary>
    public static class Querying
    {

        /// <summary>
        /// Makes a list of digits
        /// </summary>
        /// <param name="Number">Number</param>
        /// <returns>Array of digits</returns>
        public static short[] ListDigits(this short Number)
        {
            string StrNum = Number.ToString();
            var NumList = Array.ConvertAll(StrNum.ToCharArray(), x => Convert.ToInt16(x.ToString()));
            return NumList;
        }

        /// <summary>
        /// Makes a list of digits
        /// </summary>
        /// <param name="Number">Number</param>
        /// <returns>Array of digits</returns>
        public static ushort[] ListDigits(this ushort Number)
        {
            string StrNum = Number.ToString();
            var NumList = Array.ConvertAll(StrNum.ToCharArray(), x => Convert.ToUInt16(x.ToString()));
            return NumList;
        }

        /// <summary>
        /// Checks to see if the number is an Armstrong number (sum of cube of each digit of number equals the number itself)
        /// </summary>
        /// <param name="Number">Number</param>
        /// <returns>True if the number is an Armstrong number; False if not.</returns>
        public static bool IsArmstrong(this short Number)
        {
            int IntNum = Number;
            var NumberDigits = IntNum.ListDigits();
            var SumOfCubesOfDigits = default(int);
            for (int i = 0, loopTo = NumberDigits.Length - 1; i <= loopTo; i++)
                SumOfCubesOfDigits = (int)Math.Round(SumOfCubesOfDigits + Math.Pow(NumberDigits[i], 3d));
            return IntNum == SumOfCubesOfDigits;
        }

        /// <summary>
        /// Checks to see if the number is an Armstrong number (sum of cube of each digit of number equals the number itself)
        /// </summary>
        /// <param name="Number">Number</param>
        /// <returns>True if the number is an Armstrong number; False if not.</returns>
        public static bool IsArmstrong(this ushort Number)
        {
            uint IntNum = Number;
            var NumberDigits = IntNum.ListDigits();
            var SumOfCubesOfDigits = default(uint);
            for (uint i = 0U, loopTo = (uint)(NumberDigits.Length - 1); i <= loopTo; i++)
                SumOfCubesOfDigits = (uint)Math.Round(SumOfCubesOfDigits + Math.Pow(NumberDigits[(int)i], 3d));
            return IntNum == SumOfCubesOfDigits;
        }

    }
}