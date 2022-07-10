using System;

namespace Extensification.LongExts
{
    /// <summary>
    /// Provides the 64-bit integer extensions related to querying
    /// </summary>
    public static class Querying
    {

        /// <summary>
        /// Makes a list of digits
        /// </summary>
        /// <param name="Number">Number</param>
        /// <returns>Array of digits</returns>
        public static long[] ListDigits(this long Number)
        {
            string StrNum = Number.ToString();
            var NumList = Array.ConvertAll(StrNum.ToCharArray(), x => Convert.ToInt64(x.ToString()));
            return NumList;
        }

        /// <summary>
        /// Makes a list of digits
        /// </summary>
        /// <param name="Number">Number</param>
        /// <returns>Array of digits</returns>
        public static ulong[] ListDigits(this ulong Number)
        {
            string StrNum = Number.ToString();
            var NumList = Array.ConvertAll(StrNum.ToCharArray(), x => Convert.ToUInt64(x.ToString()));
            return NumList;
        }

        /// <summary>
        /// Checks to see if the number is an Armstrong number (sum of cube of each digit of number equals the number itself)
        /// </summary>
        /// <param name="Number">Number</param>
        /// <returns>True if the number is an Armstrong number; False if not.</returns>
        public static bool IsArmstrong(this long Number)
        {
            long Num = Number;
            var NumberDigits = Num.ListDigits();
            var SumOfCubesOfDigits = default(long);
            for (int i = 0, loopTo = NumberDigits.Length - 1; i <= loopTo; i++)
                SumOfCubesOfDigits = (long)Math.Round(SumOfCubesOfDigits + Math.Pow(NumberDigits[i], 3d));
            return Num == SumOfCubesOfDigits;
        }

        /// <summary>
        /// Checks to see if the number is an Armstrong number (sum of cube of each digit of number equals the number itself)
        /// </summary>
        /// <param name="Number">Number</param>
        /// <returns>True if the number is an Armstrong number; False if not.</returns>
        public static bool IsArmstrong(this ulong Number)
        {
            ulong Num = Number;
            var NumberDigits = Num.ListDigits();
            var SumOfCubesOfDigits = default(ulong);
            for (int i = 0, loopTo = NumberDigits.Length - 1; i <= loopTo; i++)
                SumOfCubesOfDigits = (ulong)Math.Round(SumOfCubesOfDigits + Math.Pow(NumberDigits[i], 3d));
            return Num == SumOfCubesOfDigits;
        }

    }
}