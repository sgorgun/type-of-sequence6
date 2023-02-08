using System;

namespace Numbers
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
            if (number == long.MinValue)
            {
                return ComparisonSigns.MoreThan | ComparisonSigns.Equals | ComparisonSigns.LessThan;
            }

            if (number < 10)
            {
                return null;
            }

            ComparisonSigns? comparisonSigns = 0;

            while (number >= 10)
            {
                long termA = number % 10;
                number /= 10;
                long termB = number % 10;

                if (termA > termB)
                {
                    comparisonSigns |= ComparisonSigns.LessThan;
                }
                else if (termA < termB)
                {
                    comparisonSigns |= ComparisonSigns.MoreThan;
                }
                else
                {
                    comparisonSigns |= ComparisonSigns.Equals;
                }
            }

            return comparisonSigns;
        }

        /// <summary>
        /// Gets information in the form of a string about the type of sequence that the digit of a given number represents.
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <returns>The information in the form of a string about the type of sequence that the digit of a given number represents.</returns>
        public static string GetTypeOfDigitsSequence(this long number)
        {
            ComparisonSigns? comparisonSigns = number.GetTypeComparisonSigns();

            return comparisonSigns switch
            {
                null => "One digit number.",
                ComparisonSigns.LessThan | ComparisonSigns.Equals => "Increasing.",
                ComparisonSigns.MoreThan | ComparisonSigns.Equals => "Decreasing.",
                ComparisonSigns.LessThan => "Strictly Increasing.",
                ComparisonSigns.MoreThan => "Strictly Decreasing.",
                ComparisonSigns.Equals => "Monotonous.",
                _ => "Unordered."
            };
        }
    }
}
