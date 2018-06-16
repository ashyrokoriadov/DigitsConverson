using System;
using DigitsConversionLibrary.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DigitsConversionTest
{
    [TestClass]
    public class OctalDigitTest
    {
        //Will be initialized with a constructor with single integer argument.
        OctalDigit oct1;

        //Will be initialized with a constructor with single string argument.
        OctalDigit oct2;

        //Will be initialized with a constructor with string argument and char argument.
        OctalDigit oct3;

        //Will be initialized with a constructor with single string argument - fractional digit.
        OctalDigit oct4;

        //Will be initialized with a constructor with string argument and char argument  - fractional digit.
        OctalDigit oct5;

        //Will be intialized with null input;
        OctalDigit oct6;

        //Will be intialized with empty string input;
        OctalDigit oct7;

        //Will be intialized with whitespace string input;
        OctalDigit oct8;

        //Will be initialized with a constructor with string argument and char argument  - fractional digit, but with separator missmatch.
        OctalDigit oct9;

        [TestInitialize]
        public void TestInitialize()
        {
            oct1 = new OctalDigit(12);
            oct2 = new OctalDigit("12");
            oct3 = new OctalDigit("12", ',');

            oct4 = new OctalDigit("17,101422335136152376");
            oct5 = new OctalDigit("17,101422335136152376", ',');

            oct6 = new OctalDigit(null);
            oct7 = new OctalDigit(string.Empty);
            oct8 = new OctalDigit("  ");

            oct9 = new OctalDigit("17,101422335136152376", '.');
        }

        [TestMethod]
        public void IntegerInput_ShouldReturnCorrectValueForBinaryConversion()
        {
            Assert.AreEqual("1010", oct1.GetBinary());
            Assert.AreEqual("1010", oct2.GetBinary());
            Assert.AreEqual("1010", oct3.GetBinary());
        }

        [TestMethod]
        public void IntegerInput_ShouldReturnCorrectValueForDecimalConversion()
        {
            Assert.AreEqual("10", oct1.GetDecimal());
            Assert.AreEqual("10", oct2.GetDecimal());
            Assert.AreEqual("10", oct3.GetDecimal());
        }

        [TestMethod]
        public void IntegerInput_ShouldReturnCorrectValueForOctalConversion()
        {
            Assert.AreEqual("12", oct1.GetOctal());
            Assert.AreEqual("12", oct2.GetOctal());
            Assert.AreEqual("12", oct3.GetOctal());
        }

        [TestMethod]
        public void IntegerInput_ShouldReturnCorrectValueForHexadecimalConversion()
        {
            Assert.AreEqual("A", oct1.GetHexadecimal());
            Assert.AreEqual("A", oct2.GetHexadecimal());
            Assert.AreEqual("A", oct3.GetHexadecimal());
        }

        [TestMethod]
        public void FractionInput_ShouldReturnCorrectValueForBinaryConversion()
        {
            Assert.AreEqual("1111,00100000110001001001101110100101111000110101001111111", oct4.GetBinary());
            Assert.AreEqual("1111,00100000110001001001101110100101111000110101001111111", oct5.GetBinary());
        }

        [TestMethod]
        public void FractionInput_ShouldReturnCorrectValueForDecimalConversion()
        {
            Assert.AreEqual("15,128", oct4.GetDecimal());
            Assert.AreEqual("15,128", oct5.GetDecimal());
        }

        [TestMethod]
        public void FractionInput_ShouldReturnCorrectValueForOctalConversion()
        {
            Assert.AreEqual("17,101422335136152376", oct4.GetOctal());
            Assert.AreEqual("17,101422335136152376", oct5.GetOctal());
        }

        [TestMethod]
        public void FractionInput_ShouldReturnCorrectValueForHexadecimalConversion()
        {
            Assert.AreEqual("F,20C49BA5E353F8", oct4.GetHexadecimal());
            Assert.AreEqual("F,20C49BA5E353F8", oct5.GetHexadecimal());
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ShouldThrowAnExceptionForNullStringInGetDecimalMethod()
        {
            oct6.GetDecimal();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ShouldThrowAnExceptionForNullStringInGetBinaryMethod()
        {
            oct6.GetBinary();
        }

        [TestMethod]
        public void ShouldReturnNullForNullStringInGetOctalMethod()
        {
            Assert.IsNull(oct6.GetOctal());
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ShouldThrowAnExceptionForNullStringInGetHexadecimalMethod()
        {
            oct6.GetHexadecimal();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ShouldReturnEmptyStringForEmptyStringInGetBinaryMethod()
        {
            oct7.GetBinary();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ShouldThrowAnExceptionForEmptyStringInGetDecimalMethod()
        {
            oct7.GetDecimal();
        }

        [TestMethod]
        public void ShouldReturnEmptyStringForEmptyStringInGetOctalMethod()
        {
            Assert.AreEqual(string.Empty, oct7.GetOctal());
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ShouldThrowAnExceptionForEmptyStringInGetHexadecimalMethod()
        {
            oct7.GetHexadecimal();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ShouldThrowAnExceptionForWhitespaceStringInGetDecimalMethod()
        {
            oct8.GetDecimal();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ShouldThrowAnExceptionForWhitespaceStringInGetBinaryMethod()
        {
            oct8.GetBinary();
        }

        [TestMethod]        
        public void ShouldReturnEmptyStringForWhitespaceStringInGetOctalMethod()
        {
            Assert.AreEqual("  ", oct8.GetOctal());
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ShouldThrowAnExceptionForWhitespaceStringInGetHexadecimalMethod()
        {
            oct8.GetHexadecimal();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ShouldThrowExceptionForSeparatorMissmatchInputInGetDecimalMethod()
        {
           oct9.GetDecimal();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ShouldReturnBinaryValueForSeparatorMissmatchInputInGetBinaryMethod()
        {
            oct9.GetBinary();
        }

        [TestMethod]
        public void ShouldReturnInputValueForSeparatorMissmatchInputInGetOctalMethod()
        {
            Assert.AreEqual("17,101422335136152376", oct9.GetOctal());
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ShouldReturnEmptyStringForSeparatorMissmatchInputInGetHexadecimalMethod()
        {
            oct9.GetHexadecimal();
        }
    }
}
