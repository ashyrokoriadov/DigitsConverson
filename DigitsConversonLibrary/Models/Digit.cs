using System;
using DigitsConversionLibrary.Interfaces;

namespace DigitsConversionLibrary.Models
{
    /// <summary>
    /// An abstract class for representation of any digit to be converted  to binary, octal, decimal, hexadecimal digits.
    /// </summary>
    public abstract class Digit : IDigit
    {
        public char Separator { get; protected set; }
        
        /// <summary>
        /// Digit type, possible values are binary, octal, decimal, hexadecimal.
        /// </summary>
        public DigitType Type { get; protected set; }

        /// <summary>
        /// A value of digit stored in class object.
        /// </summary>
        public string Value { get; protected set; }

        /// <summary>
        /// Converts a digit into an octal digit.
        /// </summary>
        /// <returns>A string representation of an octal digit. If digit conversion fails, it returns an empty string.</returns>
        public virtual string GetOctal()
        {
            bool conversionResult = false;
            Digit digit = GetDecimalDigit(out conversionResult);
            return conversionResult ? digit.GetOctal() : string.Empty;
        }

        /// <summary>
        /// Converts a digit into a hexadecimal digit.
        /// </summary>
        /// <returns>A string representation of a hexadecimal digit.If digit conversion fails, it returns an empty string.</returns>
        public virtual string GetHexadecimal()
        {
            bool conversionResult = false;
            Digit digit = GetDecimalDigit(out conversionResult);
            return conversionResult ? digit.GetHexadecimal() : string.Empty;
        }

        /// <summary>
        /// Converts a digit into a decimal digit.
        /// </summary>
        /// <returns>A string representation of a decimal digit.</returns>
        public abstract string GetDecimal();

        /// <summary>
        /// Converts a digit into a binary digit.
        /// </summary>
        /// <returns>A string representation of a binary digit. If digit conversion fails, it returns an empty string.</returns>
        public virtual string GetBinary()
        {
            bool conversionResult = false;
            Digit digit = GetDecimalDigit(out conversionResult);
            return conversionResult ? digit.GetBinary() : string.Empty;
        }

        /// <summary>
        /// A method sets a new value for the digit stored in a class object.
        /// </summary>
        /// <param name="value">New value to be stored in a class object.</param>
        public abstract void SetValue(string value);

        protected int GetNumberForLetter(string letter)
        {
            switch(letter)
            {
                case "A":
                return 10;
                case "B":
                return 11;
                case "C":
                return 12;
                case "D":
                return 13;
                case "E":
                return 14;
                case "F":
                return 15;
                default:
                    throw new Exception("Incorrect letter");
            }
        }

        protected string GetLetterForNumber(int number)
        {
            switch (number.ToString())
            {
                case "10":
                    return "A";
                case "11":
                    return "B";
                case "12":
                    return "C";
                case "13":
                    return "D";
                case "14":
                    return "E";
                case "15":
                    return "F";
                default:
                    throw new Exception("Incorrect letter");
            }
        }

        protected string GetValue(Func<string, string> GetIntegerPart, Func<string, string> GetFractionPart)
        {
            if(string.IsNullOrEmpty(Value) || string.IsNullOrWhiteSpace(Value))
                throw new Exception(INVALID_INPUT_STRING);

            string[] separatedDigit = Value.Split(Separator);
            int length = separatedDigit.Length;

            if(length == 1)
            {
                if (separatedDigit[0].Contains(",") 
                    || separatedDigit[0].Contains("."))
                    throw new Exception(SEPARATOR_MISSMATCH);
            }

            switch (length)
            {
                case 0:
                    return string.Empty;
                case 1:
                    return GetIntegerPart(Value);
                case 2:
                    string integerPart = GetIntegerPart(separatedDigit[0]);
                    string fractionalPart = GetFractionPart(separatedDigit[1]);
                    return string.Format("{0}{1}{2}", integerPart, Separator, fractionalPart);
                default:
                    throw new Exception(INVALID_INPUT_STRING);
            }
        }

        protected Digit GetDecimalDigit(out bool conversionResult)
        {
            double decimalValue;
            conversionResult = double.TryParse(GetDecimal(), out decimalValue);
            if (conversionResult)
            {
                DecimalDigit decimalDigit = new DecimalDigit(decimalValue.ToString(), Separator);
                return decimalDigit;
            }
            return null;
        }

        protected const string INVALID_TRIAD = "Invalid triad.";
        protected const string INVALID_TETRAD = "Invalid tetrad.";
        protected const string INVALID_INPUT_STRING = "Invalid input string: 1. input string is null or empty; 2. invalid separator.";
        protected const string SEPARATOR_MISSMATCH = "Input string and separator missmatch.";
    }

    public enum DigitType
    {
        Binary,
        Octal,
        Decimal,
        Hexadecimal
    }
}
