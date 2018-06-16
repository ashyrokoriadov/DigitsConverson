using System;
using System.Collections.Generic;
using System.Text;

namespace DigitsConversionLibrary.Models
{
    /// <summary>
    /// Represents a class with a binary digit and provides functionality to convert it to decimal, octal, hexadecimal digits.
    /// </summary>
    public sealed class BinaryDigit : Digit
    {
        /// <summary>
        /// One argument contructor of Binary class.
        /// </summary>
        /// <param name="digit">A binary digit to be stored in Binary class object.</param>
        public BinaryDigit(string digit) : this(digit, ',') { }

        /// <summary>
        /// Two arguments contructor of Binary class.
        /// </summary>
        /// <param name="digit">A binary digit to be stored in Binary class object.</param>
        /// <param name="separator">A separator sign to be used for separation integer part of a digit from a fractional part.</param>
        public BinaryDigit(string digit, char separator)
        {
            Type = DigitType.Binary;
            Value = digit;
            Separator = separator;
        }

        /// <summary>
        /// A method returns the binary value stored in Binary class
        /// </summary>
        /// <returns>A string representation of a binary digit.</returns>
        public override string GetBinary()
        {
            return Value;
        }

        /// <summary>
        /// Converts a binary digit into a decimal digit.
        /// </summary>
        /// <returns>A string representation of a decimal digit.</returns>
        public override string GetDecimal()
        {
            return GetValue(GetDecimal, GetDecimalFraction);
        }

        /// <summary>
        /// Converts a binary digit into a hexadecimal digit.
        /// </summary>
        /// <returns>A string representation of a hexadecimal digit.</returns>
        public override string GetHexadecimal()
        {
            return GetValue(GetHexadecimal, GetHexadecimalFraction);
        }

        /// <summary>
        /// Converts a binary digit into an octal digit.
        /// </summary>
        /// <returns>A string representation of an octal digit.</returns>
        public override string GetOctal()
        {
            return GetValue(GetOctal, GetOctalFraction);
        }

        /// <summary>
        /// A method sets a new value for the digit stored in Binary class object.
        /// </summary>
        /// <param name="value">New value to be stored in Binary class object.</param>
        public override void SetValue(string value)
        {
            Value = value;
        }

        private string GetOctalForTriad(string triad)
        {
            switch(triad)
            {
                case "000":
                    return "0";
                case "001":
                    return "1";
                case "010":
                    return "2";
                case "011":
                    return "3";
                case "100":
                    return "4";
                case "101":
                    return "5";
                case "110":
                    return "6";
                case "111":
                    return "7";
                default:
                    throw new Exception(INVALID_TRIAD);
            }
        }

        private string GetDecimalForTetrad(string tetrad)
        {
            switch (tetrad)
            {
                case "0000":
                    return "0";
                case "0001":
                    return "1";
                case "0010":
                    return "2";
                case "0011":
                    return "3";
                case "0100":
                    return "4";
                case "0101":
                    return "5";
                case "0110":
                    return "6";
                case "0111":
                    return "7";
                case "1000":
                    return "8";
                case "1001":
                    return "9";
                case "1010":
                    return "A";
                case "1011":
                    return "B";
                case "1100":
                    return "C";
                case "1101":
                    return "D";
                case "1110":
                    return "E";
                case "1111":
                    return "F";
                default:
                    throw new Exception(INVALID_TETRAD);
            }
        }

        private string GetDecimal(string value)
        {
            double sum = 0;
            int partialBinary;
            for (int i = 0; i < value.Length; i++)
            {
                bool conversionResult = int.TryParse(value[i].ToString(), out partialBinary);
                if (conversionResult)
                {
                    sum += partialBinary * Math.Pow(2, value.Length - i - 1);
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
                    sum += partialBinary * Math.Pow(2, -(i+1));
                }
            }

            string result = sum.ToString();
            return result.Substring(2, result.Length - 2); //removed '0,' from fractional result.
        }

        private string GetHexadecimal(string value)
        {
            List<string> result = new List<string>();
            for (int i = value.Length; i > 0; i -= 4)
            {
                string tetrad = string.Empty;
                if (i - 4 >= 0)
                {
                    tetrad = value.Substring(i - 4, 4);
                }
                else
                {
                    string additionalZeros = string.Empty;
                    switch (i)
                    {
                        case 3:
                            additionalZeros ="0";
                            break;
                        case 2:
                            additionalZeros ="00";
                            break;
                        case 1:
                            additionalZeros ="000";
                            break;
                    }
                    tetrad = string.Format("{0}{1}", additionalZeros, value.Substring(0, i));
                }
                result.Add(GetDecimalForTetrad(tetrad));
            }

            result.Reverse();

            StringBuilder sbResult = new StringBuilder();
            foreach (var item in result)
            {
                sbResult.Append(item);
            }

            return sbResult.ToString();
        }

        private string GetHexadecimalFraction(string value)
        {
            List<string> result = new List<string>();
            for (int i = 0; i < value.Length; i += 4)
            {
                string tetrad = string.Empty;
                if (i + 4 <= value.Length)
                {
                    tetrad = value.Substring(i, 4);
                }
                else
                {
                    string additionalZeros = string.Empty;
                    switch (value.Length - i)
                    {
                        case 3:
                            additionalZeros = "0";
                            break;
                        case 2:
                            additionalZeros = "00";
                            break;
                        case 1:
                            additionalZeros = "000";
                            break;
                    }
                    tetrad = string.Format("{0}{1}", value.Substring(i, value.Length - i), additionalZeros);
                }
                result.Add(GetDecimalForTetrad(tetrad));
            }

            StringBuilder sbResult = new StringBuilder();
            foreach (var item in result)
            {
                sbResult.Append(item);
            }

            return sbResult.ToString();
        }

        private string GetOctal(string value)
        {
            List<string> result = new List<string>();
            for (int i = value.Length; i > 0; i -= 3)
            {
                string triad = string.Empty;
                if (i - 3 >= 0)
                {
                    triad = value.Substring(i - 3, 3);
                }
                else
                {
                    string additionalZeros = string.Empty;
                    switch (i)
                    {
                        case 2:
                            additionalZeros = "0";
                            break;
                        case 1:
                            additionalZeros = "00";
                            break;
                    }
                    triad = string.Format("{0}{1}", additionalZeros, value.Substring(0, i));
                }
                result.Add(GetOctalForTriad(triad));
            }

            result.Reverse();

            StringBuilder sbResult = new StringBuilder();
            foreach (var item in result)
            {
                sbResult.Append(item);
            }

            return sbResult.ToString();
        }

        private string GetOctalFraction(string value)
        {
            List<string> result = new List<string>();
            for (int i = 0; i < value.Length; i += 3)
            {
                string triad = string.Empty;
                if (i + 3 <= value.Length)
                {
                    triad = value.Substring(i, 3);
                }
                else
                {
                    string additionalZeros = string.Empty;
                    switch (value.Length - i)
                    {
                        case 2:
                            additionalZeros = "0";
                            break;
                        case 1:
                            additionalZeros = "00";
                            break;
                    }
                    triad = string.Format("{0}{1}", value.Substring(i, value.Length - i), additionalZeros);
                }
                result.Add(GetOctalForTriad(triad));
            }

            StringBuilder sbResult = new StringBuilder();
            foreach (var item in result)
            {
                sbResult.Append(item);
            }

            return sbResult.ToString();
        }
                
    }
}
