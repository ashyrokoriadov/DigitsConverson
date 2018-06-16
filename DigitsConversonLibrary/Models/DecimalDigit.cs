using System;
using System.Collections.Generic;
using System.Text;

namespace DigitsConversionLibrary.Models
{
    /// <summary>
    /// Represents a class with a decimal digit and provides functionality to convert it to binary, octal, hexadecimal digits.
    /// </summary>
    public sealed class DecimalDigit : Digit
    {
        /// <summary>
        /// One argument contructor of Decimal class.
        /// </summary>
        /// <param name="digit">A decimal digit to be stored in Decimal class object.</param>
        public DecimalDigit(int digit) : this(digit.ToString(), ',') { }

        /// <summary>
        /// One argument contructor of Decimal class.
        /// </summary>
        /// <param name="digit">A decimal digit as a string to be stored in Decimal class object.</param>
        public DecimalDigit(string digit) : this(digit, ',') { }

        /// <summary>
        /// Two arguments contructor of Decimal class.
        /// </summary>
        /// <param name="digit">A decimal digit as a string to be stored in Decimal class object.</param>
        /// <param name="separator">A separator sign to be used for separation integer part of a digit from a fractional part.</param>
        public DecimalDigit(string digit, char separator)
        {
            Type = DigitType.Decimal;
            Value = digit;
            Separator = separator;
        }

        /// <summary>
        /// Converts a decimal digit into a binary digit.
        /// </summary>
        /// <returns>A string representation of a binary digit.</returns>
        public override string GetBinary()
        {
            return GetValue(GetBinary, GetBinaryFraction);
        }

        /// <summary>
        /// A method returns the decimal value stored in Decimal class
        /// </summary>
        /// <returns>A string representation of a decimal digit.</returns>
        public override string GetDecimal()
        {
            return Value;
        }

        /// <summary>
        /// Converts a decimal digit into a hexadecimal digit.
        /// </summary>
        /// <returns>A string representation of a hexadecimal digit.</returns>
        public override string GetHexadecimal()
        {
            return GetValue(GetHexadecimal, GetHexadecimalFraction);
        }

        /// <summary>
        /// Converts a decimal digit into an octal digit.
        /// </summary>
        /// <returns>A string representation of an octal digit.</returns>
        public override string GetOctal()
        {
            return GetValue(GetOctal, GetOctalFraction);
        }

        /// <summary>
        /// A method sets a new value for the digit stored in Decimal class object.
        /// </summary>
        /// <param name="value">New value to be stored in Decimal class object.</param>
        public override void SetValue(string value)
        {
            Value = value;
        }

        private string GetBinary (string value)
        {
            List<string> result = new List<string>();
            int iValue = 0;

            bool conversioResult = int.TryParse(value, out iValue);
            if (conversioResult)
            {
                int mod = 0;
                int devidend = iValue;
                do
                {
                    mod = devidend % 2;
                    result.Add(mod.ToString());
                    devidend = devidend / 2;
                }
                while (devidend > 1);

                if(devidend != 0)
                    result.Add(devidend.ToString());
            }

            result.Reverse();
            StringBuilder sb = new StringBuilder();
            foreach (var item in result)
                sb.Append(item);

            return sb.ToString();
        }

        private string GetBinaryFraction(string value)
        {
            value = string.Format("0,{0}", value);
            List<string> result = new List<string>();
            double dValue = 0;

            bool conversioResult = double.TryParse(value, out dValue);
            if (conversioResult)
            {
                do
                {
                    double intermediaryResult = dValue * 2;

                    double integerPart = Math.Truncate(intermediaryResult);
                    double fractionalPart = intermediaryResult - integerPart;

                    result.Add(integerPart.ToString());
                    dValue = fractionalPart;
                }
                while (Math.Round(dValue, 3) !=0);                
            }

            StringBuilder sb = new StringBuilder();
            foreach (var item in result)
                sb.Append(item);

            return sb.ToString();
        }

        private string GetHexadecimal(string value)
        {
            List<string> result = new List<string>();
            int iValue = 0;

            bool conversioResult = int.TryParse(value, out iValue);
            if (conversioResult)
            {
                int mod = 0;
                int devidend = iValue;
                do
                {
                    mod = devidend % 16;
                    result.Add(mod.ToString());
                    devidend = devidend / 16;
                }
                while (devidend > 15);

                if (devidend != 0)
                    result.Add(devidend.ToString());
            }

            List<string> hexadecimalResult = new List<string>();

            foreach (var item in result)
            {
                int tempValue = Convert.ToInt32(item);
                if (tempValue > 9)
                {
                    hexadecimalResult.Add(GetLetterForNumber(tempValue));
                }
                else
                {
                    hexadecimalResult.Add(item);
                }
            }

            hexadecimalResult.Reverse();

            StringBuilder sb = new StringBuilder();
            foreach (var item in hexadecimalResult)
                sb.Append(item);

            return sb.ToString();
        }

        private string GetHexadecimalFraction(string value)
        {
            value = string.Format("0,{0}", value);
            List<string> result = new List<string>();
            double dValue = 0;

            bool conversioResult = double.TryParse(value, out dValue);
            if (conversioResult)
            {
                do
                {
                    double intermediaryResult = dValue * 16;

                    double integerPart = Math.Truncate(intermediaryResult);
                    double fractionalPart = intermediaryResult - integerPart;

                    result.Add(integerPart.ToString());
                    dValue = fractionalPart;
                }
                while (Math.Round(dValue, 3) != 0);
            }

            List<string> hexadecimalResult = new List<string>();

            foreach (var item in result)
            {
                int tempValue = Convert.ToInt32(item);
                if (tempValue > 9)
                {
                    hexadecimalResult.Add(GetLetterForNumber(tempValue));
                }
                else
                {
                    hexadecimalResult.Add(item);
                }
            }

            StringBuilder sb = new StringBuilder();
            foreach (var item in hexadecimalResult)
                sb.Append(item);

            return sb.ToString();
        }

        private string GetOctal (string value)
        {
            List<string> result = new List<string>();
            int iValue = 0;

            bool conversioResult = int.TryParse(value, out iValue);
            if (conversioResult)
            {
                int mod = 0;
                int devidend = iValue;
                do
                {
                    mod = devidend % 8;
                    result.Add(mod.ToString());
                    devidend = devidend / 8;
                }
                while (devidend > 7);

                if(devidend !=0)
                    result.Add(devidend.ToString());
            }

            result.Reverse();
            StringBuilder sb = new StringBuilder();
            foreach (var item in result)
                sb.Append(item);

            return sb.ToString();
        }

        private string GetOctalFraction(string value)
        {
            value = string.Format("0,{0}", value);
            List<string> result = new List<string>();
            double dValue = 0;

            bool conversioResult = double.TryParse(value, out dValue);
            if (conversioResult)
            {
                do
                {
                    double intermediaryResult = dValue * 8;

                    double integerPart = Math.Truncate(intermediaryResult);
                    double fractionalPart = intermediaryResult - integerPart;

                    result.Add(integerPart.ToString());
                    dValue = fractionalPart;
                }
                while (Math.Round(dValue, 3) != 0);
            }

            StringBuilder sb = new StringBuilder();
            foreach (var item in result)
                sb.Append(item);

            return sb.ToString();
        }
    }
}
