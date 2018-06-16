using System;
using DigitsConversionLibrary.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DigitsConversionTest
{
    [TestClass]
    public class BinaryDigitTest
    {
        //Will be initialized with a constructor with single string argument.
        BinaryDigit bin2;

        //Will be initialized with a constructor with string argument and char argument.
        BinaryDigit bin3;

        //Will be initialized with a constructor with single string argument - fractional digit.
        BinaryDigit bin4;

        //Will be initialized with a constructor with string argument and char argument  - fractional digit.
        BinaryDigit bin5;

        //Will be intialized with null input;
        BinaryDigit bin6;

        //Will be intialized with empty string input;
        BinaryDigit bin7;

        //Will be intialized with whitespace string input;
        BinaryDigit bin8;

        //Will be initialized with a constructor with string argument and char argument  - fractional digit, but with separator missmatch.
        BinaryDigit bin9;

        [TestInitialize]
        public void TestInitialize()
        {
            bin2 = new BinaryDigit("1010");
            bin3 = new BinaryDigit("1010", ',');

            bin4 = new BinaryDigit("1111,00100000110001001001101110100101111000110101001111111");
            bin5 = new BinaryDigit("1111,00100000110001001001101110100101111000110101001111111", ',');

            bin6 = new BinaryDigit(null);
            bin7 = new BinaryDigit(string.Empty);
            bin8 = new BinaryDigit("  ");

            bin9 = new BinaryDigit("1111,00100000110001001001101110100101111000110101001111111", '.');
        }

        [TestMethod]
        public void IntegerInput_ShouldReturnCorrectValueForBinaryConversion()
        {
            Assert.AreEqual("1010", bin2.GetBinary());
            Assert.AreEqual("1010", bin3.GetBinary());
        }

        [TestMethod]
        public void IntegerInput_ShouldReturnCorrectValueForDecimalConversion()
        {
            Assert.AreEqual("10", bin2.GetDecimal());
            Assert.AreEqual("10", bin3.GetDecimal());
        }

        [TestMethod]
        public void IntegerInput_ShouldReturnCorrectValueForOctalConversion()
        {
            Assert.AreEqual("12", bin2.GetOctal());
            Assert.AreEqual("12", bin3.GetOctal());
        }

        [TestMethod]
        public void IntegerInput_ShouldReturnCorrectValueForHexadecimalConversion()
        {
            Assert.AreEqual("A", bin2.GetHexadecimal());
            Assert.AreEqual("A", bin3.GetHexadecimal());
        }

        [TestMethod]
        public void FractionInput_ShouldReturnCorrectValueForBinaryConversion()
        {
            Assert.AreEqual("1111,00100000110001001001101110100101111000110101001111111", bin4.GetBinary());
            Assert.AreEqual("1111,00100000110001001001101110100101111000110101001111111", bin5.GetBinary());
        }

        [TestMethod]
        public void FractionInput_ShouldReturnCorrectValueForDecimalConversion()
        {
            Assert.AreEqual("15,128", bin4.GetDecimal());
            Assert.AreEqual("15,128", bin5.GetDecimal());
        }

        [TestMethod]
        public void FractionInput_ShouldReturnCorrectValueForOctalConversion()
        {
            Assert.AreEqual("17,101422335136152376", bin4.GetOctal());
            Assert.AreEqual("17,101422335136152376", bin5.GetOctal());
        }

        [TestMethod]
        public void FractionInput_ShouldReturnCorrectValueForHexadecimalConversion()
        {
            Assert.AreEqual("F,20C49BA5E353F8", bin4.GetHexadecimal());
            Assert.AreEqual("F,20C49BA5E353F8", bin5.GetHexadecimal());
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ShouldThrowAnExceptionForNullStringInGetDecimalMethod()
        {
            bin6.GetDecimal();
        }

        [TestMethod]
        public void ShouldReturnNullForNullStringInGetBinaryMethod()
        {
            Assert.IsNull(bin6.GetBinary());
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ShouldThrowAnExceptionForNullStringInGetOctalMethod()
        {
            bin6.GetOctal();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ShouldThrowAnExceptionForNullStringInGetHexadecimalMethod()
        {
            bin6.GetHexadecimal();
        }

        [TestMethod]
        public void ShouldReturnEmptyStringForEmptyStringInGetBinaryMethod()
        {
            Assert.AreEqual(string.Empty, bin7.GetBinary());
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ShouldThrowAnExceptionForEmptyStringInGetDecimalMethod()
        {
            bin7.GetDecimal();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ShouldThrowAnExceptionForEmptyStringInGetOctalMethod()
        {
            bin7.GetOctal();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ShouldThrowAnExceptionForEmptyStringInGetHexadecimalMethod()
        {
            bin7.GetHexadecimal();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ShouldThrowAnExceptionStringForWhitespaceStringInGetDecimalMethod()
        {
            bin8.GetDecimal();
        }

        [TestMethod]
        public void ShouldReturnEmptyStringForWhitespaceStringInGetBinaryMethod()
        {
            Assert.AreEqual("  ", bin8.GetBinary());
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ShouldThrowEceptionForWhitespaceStringInGetOctalMethod()
        {
            bin8.GetOctal();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ShouldThrowEceptionForWhitespaceStringInGetHexadecimalMethod()
        {
            bin8.GetHexadecimal();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ShouldThrowExceptionForSeparatorMissmatchInputInGetDecimalMethod()
        {
           bin9.GetDecimal();
        }

        [TestMethod]
        public void ShouldReturnBinaryValueForSeparatorMissmatchInputInGetBinaryMethod()
        {
            Assert.AreEqual("1111,00100000110001001001101110100101111000110101001111111", bin9.GetBinary());
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ShouldReturnEmptyStringForSeparatorMissmatchInputInGetOctalMethod()
        {
            bin9.GetOctal();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ShouldReturnEmptyStringForSeparatorMissmatchInputInGetHexadecimalMethod()
        {
            bin9.GetHexadecimal();
        }
    }
}
