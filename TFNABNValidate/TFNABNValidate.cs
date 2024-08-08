namespace TFNABNValidate
{
    public static class TFNABNValidate
    {
        /// <summary>
        /// Returns TRUE if string passed in is a valid TFN
        /// Performs validation on the string removing spaces and hyphens and checking if it contains only digits and is between 8 and 9 characters long
        /// </summary>/// <param name="value"></param>
        public static bool IsValidTFN(this string value)
        {
            value = value.RemoveSpaceAndHyphen();
            if (!value.IsDigits() || value.Length < 8 || value.Length > 9)
                return false;
            int runningTotal = 0;
            var TFN9Digits = new int[] { 1, 4, 3, 7, 5, 8, 6, 9, 10 };
            var TFN8Digits = new int[] { 10, 7, 8, 4, 6, 3, 5, 1, 0 };
            var multiples = value.Length == 9 ? TFN9Digits : TFN8Digits;

            for (int i = 0; i < value.Length; i++)
                runningTotal += (int)(Char.GetNumericValue(value[i])) * multiples[i];
            if (runningTotal % 11 == 0) return true;

            return false;
        }

        /// <summary>
        /// Returns TRUE if int passed in is a valid TFN
        /// Performs validation on the int passed in checking if it is 8 or 9 digits long
        /// </summary>
        /// <param name="value"></param>
        public static bool IsValidTFN(this int value)
        {
            var numberOfDigits = Math.Floor(Math.Log10(value) + 1);
            if (numberOfDigits != 9 || numberOfDigits != 8)
                return false;
            int runningTotal = 0;
            var TFN9Digits = new int[] { 1, 4, 3, 7, 5, 8, 6, 9, 10 };
            var TFN8Digits = new int[] { 10, 7, 8, 4, 6, 3, 5, 1, 0 };
            var multiples = numberOfDigits == 9 ? TFN9Digits : TFN8Digits;
            var valueString = value.ToString();

            for (int i = 0; i < numberOfDigits; i++)
                runningTotal += (int)(Char.GetNumericValue(valueString[i])) * multiples[i];
            if (runningTotal % 11 == 0) return true;

            return false;
        }


        /// <summary>
        /// Returns TRUE if string passed in is a valid ABN
        /// Performs validation on input string checking if correct length and only contains digits
        /// </summary>
        /// <param name="value"></param>
        /// <returns>True if ABN is valid</returns>
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
        /// Returns TRUE if value passed in is a valid ABN
        /// </summary>
        /// <param name="value"></param>
        /// <returns>True if ABN is valid</returns>
        public static bool IsValidABN(this int value)
        {
            var numberOfDigits = Math.Floor(Math.Log10(value) + 1);
            if (numberOfDigits != 11)
                return false;
            var abnWeights = new int[] { 10, 1, 3, 5, 7, 9, 11, 13, 15, 17, 19 };
            int runningTotal = 0;
            var valueString = value.ToString();

            for (int i = 0; i < 11; i++)
            {
                if (i == 0)
                    runningTotal += (int)(Char.GetNumericValue(valueString[i]) - 1) * abnWeights[i];
                else
                    runningTotal += (int)Char.GetNumericValue(valueString[i]) * abnWeights[i];
            }
            if (runningTotal % 89 == 0) return true;
            return false;
        }

        /// <summary>
        /// Returns TRUE if value passed in contains only digits
        /// </summary>
        private static bool IsDigits(this string value)
        {
            foreach (char c in value)
                if (!char.IsDigit(c))
                    return false;
            return true;
        }

        /// <summary>
        /// Returns a string with spaces and hyphens removed
        /// </summary>
        private static string RemoveSpaceAndHyphen(this string value)
        {
            value = value.Replace(" ", "").Replace("-", "");
            return value;
        }
    }
}
