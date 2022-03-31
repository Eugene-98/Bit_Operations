namespace Bit_Operations
{
	public static class IntegerExtensions
    {
        /// <summary>
        /// Obtains formalized information in the form of an enum <see cref="ComparisonSigns"/>
        /// about the relationship of the order of two adjacent digits for all digits of a given number. 
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <returns>Information in the form of an enum <see cref="ComparisonSigns"/>
        /// about the relationship of the order of two adjacent digits for all digits of a given number
        /// or null if the information is not defined.</returns>
        public static ComparisonSigns? GetTypeComparisonSigns(this long number)
        {
            int result = 0;
            if (number / 10 == 0)
            {
                return null;
            }

            long x = number % 10;
            number /= 10;
            while (number / 10 != 0)
            {
                long y = number % 10;
                number /= 10;
                if (x > y)
                {
                    result |= 1;
                }

                if (x < y)
                {
                    result |= 2;
                }

                if (x == y)
                {
                    result |= 4;
                }

                x = y;
            }

            return (ComparisonSigns)result;
        }

        /// <summary>
        /// Gets information in the form of a string about the type of sequence that the digit of a given number represents.
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <returns>The information in the form of a string about the type of sequence that the digit of a given number represents.</returns>
        public static string GetTypeOfDigitsSequence(this long number)
        {
            if (number.GetTypeComparisonSigns() is null)
            {
                return "One digit number.";
            }

            int i = (int)number.GetTypeComparisonSigns();

            return i switch
            {
                1 => "Strictly Increasing.",
                2 => "Strictly Decreasing.",
                4 => "Monotonous.",
                5 => "Increasing.",
                6 => "Decreasing.",
                _ => "Unordered.",
            };
        }
    }
}
