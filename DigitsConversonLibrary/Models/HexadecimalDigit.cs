using System;

namespace DigitsConversionLibrary.Models
{
    /// <summary>
    /// Represents a class with a hexadecimal digit and provides functionality to convert it to decimal, octal, binary digits.
    /// </summary>
    public sealed class HexadecimalDigit : Digit
    {
        /// <summary>
        /// One argument contructor of Hexadecimal class.
        /// </summary>
        /// <param name="digit">A hexadecimal digit to be stored in Hexadecimal class object.</param>
        public HexadecimalDigit(string digit) : this(digit, ',') { }

        /// <summary>
        /// Two arguments contructor of Hexadecimal class.
        /// </summary>
        /// <param name="digit">A hexadecimal digit as a string to be stored in Hexadecimal class object.</param>
        /// <param name="separator">A separator sign to be used for separation integer part of a digit from a fractional part.</param>
        public HexadecimalDigit(string digit, char separator)
        {
            Type = DigitType.Hexadecimal;
            Value = digit;
            Separator = separator;
        }

        /// <summary>
        /// Converts a hexadecimal digit into a decimal digit.
        /// </summary>
        /// <returns>A string representation of a decimal digit.</returns>
        public override string GetDecimal()
        {
            return GetValue(GetDecimal, GetDecimalFraction);
        }

        /// <summary>
        /// A method returns the hexadecimal value stored in Hexadecimal class
        /// </summary>
        /// <returns>A string representation of a hexadecimal digit.</returns>
        public override string GetHexadecimal()
        {
            return Value;
        }

        /// <summary>
        /// A method sets a new value for the digit stored in Hexadecimal class object.
        /// </summary>
        /// <param name="value">New value to be stored in Hexadecimal class object .</param>
        public override void SetValue(string value)
        {
            Value = value;
        }

        private string GetDecimal(string value)
        {
            double sum = 0;
            int partialDecimal;
            for (int i = 0; i < value.Length; i++)
            {
                bool conversionResult = false;

                if ("ABCDEF".Contains(value[i].ToString()))
                {
                    partialDecimal = GetNumberForLetter(value[i].ToString());
                    conversionResult = true;
                }
                else
                {
                    conversionResult = int.TryParse(value[i].ToString(), out partialDecimal);
                }

                if (conversionResult)
                {
                    sum += partialDecimal * Math.Pow(16, value.Length - i - 1);
                }
            }
            return sum.ToString();
        }

        private string GetDecimalFraction(string value)
        {
            double sum = 0;
            int partialDecimal;
            for (int i = 0; i < value.Length; i++)
            {
                bool conversionResult = false;

                if ("ABCDEF".Contains(value[i].ToString()))
                {
                    partialDecimal = GetNumberForLetter(value[i].ToString());
                    conversionResult = true;
                }
                else
                {
                    conversionResult = int.TryParse(value[i].ToString(), out partialDecimal);
                }

                if (conversionResult)
                {
                    sum += partialDecimal * Math.Pow(16, -(i + 1));
                }
            }

            string result = sum.ToString();
            return result.Substring(2, result.Length - 2);
        }
    }
}
