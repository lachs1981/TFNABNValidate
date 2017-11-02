using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFNABNChecker
{
    public static class Tools
    {
        /// <summary>
        /// Returns TRUE if value passed in is a valid TFN
        /// </summary>
        public static bool IsValidTFN(this string value)
        {
            value = value.RemoveSpaceAndHyphen();
            if (!value.IsDigits() || value.Length < 8 || value.Length > 9)
                return false;
            int runningTotal = 0;
            var TFN9Digit = new int[] { 1, 4, 3, 7, 5, 8, 6, 9, 10 };
            var TFN8Digit = new int[] { 10, 7, 8, 4, 6, 3, 5, 1, 0 };
            var multiples = value.Length == 9 ? TFN9Digit : TFN8Digit;

            for (int i = 0; i < value.Length; i++)
                runningTotal += (int)(Char.GetNumericValue(value[i])) * multiples[i];
            if (runningTotal % 11 == 0) return true;

            return false;
        }

        /// <summary>
        /// Returns TRUE if value passed in is a valid ABN
        /// </summary>
        public static bool IsValidABN(this string value)
        {
            value = value.RemoveSpaceAndHyphen();
            if (value.Length != 11 || !value.IsDigits()) return false;
            var abnWeights = new int[] { 10, 1, 3, 5, 7, 9, 11, 13, 15, 17, 19 };
            int runningTotal = 0;

            for (int i = 0; i < 11; i++)
            {
                if (i == 0)
                    runningTotal += (int)(Char.GetNumericValue(value[i]) - 1) * abnWeights[i];
                else
                    runningTotal += (int)Char.GetNumericValue(value[i]) * abnWeights[i];
            }
            if (runningTotal % 89 == 0) return true;
            return false;
        }

        /// <summary>
        /// Returns TRUE if value passed in contains only digits
        /// </summary>
        public static bool IsDigits(this string value)
        {
            foreach (char c in value)
                if (!char.IsDigit(c))
                    return false;
            return true;
        }

        /// <summary>
        /// Returns a string with spaces and hyphens removed
        /// </summary>
        public static string RemoveSpaceAndHyphen(this string value)
        {
            value = value.Replace(" ", "").Replace("-", "");
            return value;
        }
    }
}