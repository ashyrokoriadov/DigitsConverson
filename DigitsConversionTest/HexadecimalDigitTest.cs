using System;
using DigitsConversionLibrary.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DigitsConversionTest
{
    [TestClass]
    public class HexadecimalDigitTest
    {
        //Will be initialized with a constructor with single string argument.
        HexadecimalDigit hex2;

        //Will be initialized with a constructor with string argument and char argument.
        HexadecimalDigit hex3;

        //Will be initialized with a constructor with single string argument - fractional digit.
        HexadecimalDigit hex4;

        //Will be initialized with a constructor with string argument and char argument  - fractional digit.
        HexadecimalDigit hex5;

        //Will be intialized with null input;
        HexadecimalDigit hex6;

        //Will be intialized with empty string input;
        HexadecimalDigit hex7;

        //Will be intialized with whitespace string input;
        HexadecimalDigit hex8;

        //Will be initialized with a constructor with string argument and char argument  - fractional digit, but with separator missmatch.
        HexadecimalDigit hex9;

        [TestInitialize]
        public void TestInitialize()
        {
            hex2 = new HexadecimalDigit("A");
            hex3 = new HexadecimalDigit("A", ',');

            hex4 = new HexadecimalDigit("F,20C49BA5E353F8");
            hex5 = new HexadecimalDigit("F,20C49BA5E353F8", ',');

            hex6 = new HexadecimalDigit(null);
            hex7 = new HexadecimalDigit(string.Empty);
            hex8 = new HexadecimalDigit("  ");

            hex9 = new HexadecimalDigit("F,20C49BA5E353F8", '.');
        }

        [TestMethod]
        public void IntegerInput_ShouldReturnCorrectValueForBinaryConversion()
        {
            Assert.AreEqual("1010", hex2.GetBinary());
            Assert.AreEqual("1010", hex3.GetBinary());
        }

        [TestMethod]
        public void IntegerInput_ShouldReturnCorrectValueForDecimalConversion()
        {
            Assert.AreEqual("10", hex2.GetDecimal());
            Assert.AreEqual("10", hex3.GetDecimal());
        }

        [TestMethod]
        public void IntegerInput_ShouldReturnCorrectValueForOctalConversion()
        {
            Assert.AreEqual("12", hex2.GetOctal());
            Assert.AreEqual("12", hex3.GetOctal());
        }

        [TestMethod]
        public void IntegerInput_ShouldReturnCorrectValueForHexadecimalConversion()
        {
            Assert.AreEqual("A", hex2.GetHexadecimal());
            Assert.AreEqual("A", hex3.GetHexadecimal());
        }

        [TestMethod]
        public void FractionInput_ShouldReturnCorrectValueForBinaryConversion()
        {
            Assert.AreEqual("1111,00100000110001001001101110100101111000110101001111111", hex4.GetBinary());
            Assert.AreEqual("1111,00100000110001001001101110100101111000110101001111111", hex5.GetBinary());
        }

        [TestMethod]
        public void FractionInput_ShouldReturnCorrectValueForDecimalConversion()
        {
            Assert.AreEqual("15,128", hex4.GetDecimal());
            Assert.AreEqual("15,128", hex5.GetDecimal());
        }

        [TestMethod]
        public void FractionInput_ShouldReturnCorrectValueForOctalConversion()
        {
            Assert.AreEqual("17,101422335136152376", hex4.GetOctal());
            Assert.AreEqual("17,101422335136152376", hex5.GetOctal());
        }

        [TestMethod]
        public void FractionInput_ShouldReturnCorrectValueForHexadecimalConversion()
        {
            Assert.AreEqual("F,20C49BA5E353F8", hex4.GetHexadecimal());
            Assert.AreEqual("F,20C49BA5E353F8", hex5.GetHexadecimal());
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ShouldThrowAnExceptionForNullStringInGetDecimalMethod()
        {
            hex6.GetDecimal();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ShouldThrowAnExceptionForNullStringInGetBinaryMethod()
        {
            hex6.GetBinary();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ShouldThrowAnExceptionForNullStringInGetOctalMethod()
        {
            hex6.GetOctal();
        }

        [TestMethod]
        
        public void ShouldReturnNullForNullStringInGetHexadecimalMethod()
        {
            Assert.IsNull(hex6.GetHexadecimal());
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ShouldReturnEmptyStringForEmptyStringInGetBinaryMethod()
        {
            hex7.GetBinary();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ShouldThrowAnExceptionForEmptyStringInGetDecimalMethod()
        {
            hex7.GetDecimal();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ShouldThrowAnExceptionForEmptyStringInGetOctalMethod()
        {
            hex7.GetOctal();
        }

        [TestMethod]        
        public void ShouldReturnEmptyStringForEmptyStringInGetHexadecimalMethod()
        {
            Assert.AreEqual(string.Empty, hex7.GetHexadecimal());
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ShouldThrowAnExceptionForWhitespaceStringInGetDecimalMethod()
        {
            hex8.GetDecimal();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ShouldThrowAnExceptionForWhitespaceStringInGetBinaryMethod()
        {
            hex8.GetBinary();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ShouldThrowAnExceptionForWhitespaceStringInGetOctalMethod()
        {
            hex8.GetOctal();
        }

        [TestMethod]       
        public void ShouldReturnEmptyStringWhitespaceStringInGetHexadecimalMethod()
        {
            Assert.AreEqual("  ", hex8.GetHexadecimal());
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ShouldThrowExceptionForSeparatorMissmatchInputInGetDecimalMethod()
        {
           hex9.GetDecimal();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ShouldReturnBinaryValueForSeparatorMissmatchInputInGetBinaryMethod()
        {
            hex9.GetBinary();
        }

        [TestMethod]
        public void ShouldReturnInputValueForSeparatorMissmatchInputInGetOctalMethod()
        {
            Assert.AreEqual("F,20C49BA5E353F8", hex9.GetHexadecimal());
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ShouldReturnEmptyStringForSeparatorMissmatchInputInGetHexadecimalMethod()
        {
            hex9.GetOctal();
        }
    }
}
