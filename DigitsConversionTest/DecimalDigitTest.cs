using System;
using DigitsConversionLibrary.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DigitsConversionTest
{
    [TestClass]
    public class DecimalDigitTest
    {
        //Will be initialized with a constructor with single integer argument.
        DecimalDigit dec1;

        //Will be initialized with a constructor with single string argument.
        DecimalDigit dec2;

        //Will be initialized with a constructor with string argument and char argument.
        DecimalDigit dec3;

        //Will be initialized with a constructor with single string argument - fractional digit.
        DecimalDigit dec4;

        //Will be initialized with a constructor with string argument and char argument  - fractional digit.
        DecimalDigit dec5;

        //Will be intialized with null input;
        DecimalDigit dec6;

        //Will be intialized with empty string input;
        DecimalDigit dec7;

        //Will be intialized with whitespace string input;
        DecimalDigit dec8;

        //Will be initialized with a constructor with string argument and char argument  - fractional digit, but with separator missmatch.
        DecimalDigit dec9;

        [TestInitialize]
        public void TestInitialize()
        {
            dec1 = new DecimalDigit(10);
            dec2 = new DecimalDigit("10");
            dec3 = new DecimalDigit("10", ',');

            dec4 = new DecimalDigit("15,128");
            dec5 = new DecimalDigit("15,128", ',');

            dec6 = new DecimalDigit(null);
            dec7 = new DecimalDigit(string.Empty);
            dec8 = new DecimalDigit("  ");

            dec9 = new DecimalDigit("15,128", '.');
        }

        [TestMethod]
        public void IntegerInput_ShouldReturnCorrectValueForBinaryConversion()
        {
            Assert.AreEqual("1010", dec1.GetBinary());
            Assert.AreEqual("1010", dec2.GetBinary());
            Assert.AreEqual("1010", dec3.GetBinary());
        }

        [TestMethod]
        public void IntegerInput_ShouldReturnCorrectValueForDecimalConversion()
        {
            Assert.AreEqual("10", dec1.GetDecimal());
            Assert.AreEqual("10", dec2.GetDecimal());
            Assert.AreEqual("10", dec3.GetDecimal());
        }

        [TestMethod]
        public void IntegerInput_ShouldReturnCorrectValueForOctalConversion()
        {
            Assert.AreEqual("12", dec1.GetOctal());
            Assert.AreEqual("12", dec2.GetOctal());
            Assert.AreEqual("12", dec3.GetOctal());
        }

        [TestMethod]
        public void IntegerInput_ShouldReturnCorrectValueForHexadecimalConversion()
        {
            Assert.AreEqual("A", dec1.GetHexadecimal());
            Assert.AreEqual("A", dec2.GetHexadecimal());
            Assert.AreEqual("A", dec3.GetHexadecimal());
        }

        [TestMethod]
        public void FractionInput_ShouldReturnCorrectValueForBinaryConversion()
        {
            Assert.AreEqual("1111,00100000110001001001101110100101111000110101001111111", dec4.GetBinary());
            Assert.AreEqual("1111,00100000110001001001101110100101111000110101001111111", dec5.GetBinary());
        }

        [TestMethod]
        public void FractionInput_ShouldReturnCorrectValueForDecimalConversion()
        {
            Assert.AreEqual("15,128", dec4.GetDecimal());
            Assert.AreEqual("15,128", dec5.GetDecimal());
        }

        [TestMethod]
        public void FractionInput_ShouldReturnCorrectValueForOctalConversion()
        {
            Assert.AreEqual("17,101422335136152376", dec4.GetOctal());
            Assert.AreEqual("17,101422335136152376", dec5.GetOctal());
        }

        [TestMethod]
        public void FractionInput_ShouldReturnCorrectValueForHexadecimalConversion()
        {
            Assert.AreEqual("F,20C49BA5E353F8", dec4.GetHexadecimal());
            Assert.AreEqual("F,20C49BA5E353F8", dec5.GetHexadecimal());
        }

        [TestMethod]
        public void ShouldReturnNullForNullStringInGetDecimalMethod()
        {
            Assert.IsNull(dec6.GetDecimal());
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ShouldThrowAnExceptionForNullStringInGetBinaryMethod()
        {
            dec6.GetBinary();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ShouldThrowAnExceptionForNullStringInGetOctalMethod()
        {
            dec6.GetOctal();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ShouldThrowAnExceptionForNullStringInGetHexadecimalMethod()
        {
            dec6.GetHexadecimal();
        }

        [TestMethod]
        public void ShouldReturnEmptyStringForEmptyStringInGetDecimalMethod()
        {
            Assert.AreEqual(string.Empty, dec7.GetDecimal());
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ShouldThrowAnExceptionForEmptyStringInGetBinaryMethod()
        {
            dec7.GetBinary();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ShouldThrowAnExceptionForEmptyStringInGetOctalMethod()
        {
            dec7.GetOctal();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ShouldThrowAnExceptionForEmptyStringInGetHexadecimalMethod()
        {
            dec7.GetHexadecimal();
        }

        [TestMethod]
        public void ShouldReturnWhitespaceStringForWhitespaceStringInGetDecimalMethod()
        {
            Assert.AreEqual("  ", dec8.GetDecimal());
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ShouldhrowAnExceptionForWhitespaceStringInGetBinaryMethod()
        {
            dec8.GetBinary();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ShouldThrowAnExceptionForWhitespaceStringInGetOctalMethod()
        {
            dec8.GetOctal();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ShouldhrowAnExceptionForWhitespaceStringInGetHexadecimalMethod()
        {
            dec8.GetHexadecimal();
        }

        [TestMethod]
        public void ShouldReturnDecimalValueForSeparatorMissmatchInputInGetDecimalMethod()
        {
            Assert.AreEqual("15,128", dec9.GetDecimal());
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ShouldThrowExceptionForSeparatorMissmatchInputInGetBinaryMethod()
        {
            dec9.GetBinary();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ShouldThrowExceptionForSeparatorMissmatchInputInGetOctalMethod()
        {
            dec9.GetOctal();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ShouldThrowExceptionForSeparatorMissmatchInputInGetHexadecimalMethod()
        {
            dec9.GetHexadecimal();
        }
    }
}
