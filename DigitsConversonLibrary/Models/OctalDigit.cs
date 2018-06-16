using System;

namespace DigitsConversionLibrary.Models
{
    /// <summary>
    /// Represents a class with an octal digit and provides functionality to convert it to binary, decimal, hexadecimal digits.
    /// </summary>
    public sealed class OctalDigit : Digit
    {
        /// <summary>
        /// One argument contructor of Octal class.
        /// </summary>
        /// <param name="digit">A octal digit to be stored in Octal class object.</param>
        public OctalDigit(int digit) : this(digit.ToString(), ',') { }

        /// <summary>
        /// One argument contructor of Octal class.
        /// </summary>
        /// <param name="digit">An octal digit as a string to be stored in Octal class object.</param>
        public OctalDigit(string digit) : this(digit, ',') { }

        /// <summary>
        /// Two argumenst contructor of Octal class.
        /// </summary>
        /// <param name="digit">An octal digit as a string to be stored in Octal class object.</param>
        /// <param name="separator">A separator sign to be used for separation integer part of a digit from a fractional part.</param>
        public OctalDigit(string digit, char separator)
        {
            Type = DigitType.Octal;
            Value = digit;
            Separator = separator;
        }

        /// <summary>
        /// Converts an octal digit into a decimal digit.
        /// </summary>
        /// <returns>A string representation of a decimal digit.</returns>
        public override string GetDecimal()
        {
            return GetValue(GetDecimal, GetDecimalFraction);
        }

        /// <summary>
        /// A method returns the octal value stored in Octal class
        /// </summary>
        /// <returns>A string representation of a octal digit.</returns>
        public override string GetOctal()
        {
            return Value;
        }

        /// <summary>
        /// A method sets a new value for the digit stored in Octal class object.
        /// </summary>
        /// <param name="value">New value to be stored in Octal class object.</param>
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
                bool conversionResult = int.TryParse(value[i].ToString(), out partialDecimal);
                if (conversionResult)
                {
                    sum += partialDecimal * Math.Pow(8, value.Length - i - 1);
                }
            }
            return sum.ToString();
        }

        private string GetDecimalFraction(string value)
        {
            double sum = 0;
            int partialBinary;
            for (int i = 0; i < value.Length; i++)
            {
                bool conversionResult = int.TryParse(value[i].ToString(), out partialBinary);
                if (conversionResult)
                {
                    sum += partialBinary * Math.Pow(8, -(i + 1));
                }
            }

            string result = sum.ToString();
            return result.Substring(2, result.Length - 2);
        }               
    }
}
