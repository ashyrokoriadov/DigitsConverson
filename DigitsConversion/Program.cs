using System;
using DigitsConversionLibrary.Models;

namespace DigitsConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryDigit bin = new BinaryDigit("101,11", ',');
            GetDecimal(bin); //5,75

            bin.SetValue("1110,0101");
            GetOctal(bin); //16,24

            bin.SetValue("1111010,0111111");
            GetHexadecimal(bin); //7A,7E

            DecimalDigit dec = new DecimalDigit(11);

            GetBinary(dec); //1011
            dec.SetValue("0");
            GetBinary(dec); //00
            dec.SetValue("0,378");
            GetBinary(dec); //110000,101
            dec.SetValue("48,378");
            GetBinary(dec);//110000.01100000110

            dec.SetValue("0,7");
            GetHexadecimal(dec); //B333

            dec.SetValue("0,6");
            GetOctal(dec); //0,463

            OctalDigit oct1 = new OctalDigit("57,24");
            OctalDigit oct2 = new OctalDigit("57,24", ',');

            GetOctal(oct1); // 57,24
            GetOctal(oct2); // 57,24

            GetDecimal(oct1); // 47,3125
            GetDecimal(oct2); // 47,3125

            oct1.SetValue("16,24");
            oct2.SetValue("16,24");
            GetBinary(oct1); // 1110,0101
            GetBinary(oct2); // 1110,0101

            oct1.SetValue("46,667");
            oct2.SetValue("45,123");
            GetHexadecimal(oct1); // 26,DB8
            GetHexadecimal(oct2); // 25,298

            HexadecimalDigit hex1 = new HexadecimalDigit("26,DB8");
            HexadecimalDigit hex2 = new HexadecimalDigit("25,298", ',');

            GetBinary(hex1); //100110.110110111
            GetBinary(hex2); //100101.001010011

            GetDecimal(hex1); //38.857421875
            GetDecimal(hex2); //37.162109375

            GetOctal(hex1); //46,667
            GetOctal(hex2); //45,123

            GetHexadecimal(hex1); //26,DB8
            GetHexadecimal(hex2); //25,298

            Console.ReadLine();            
        }        

        static void GetOctal(Digit digit)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Digit {0} of type {1} to octal: {2}", digit.Value, digit.Type, digit.GetOctal());
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void GetDecimal(Digit digit)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Digit {0} of type {1} to decimal: {2}", digit.Value, digit.Type, digit.GetDecimal());
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void GetHexadecimal(Digit digit)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Digit {0} of type {1} to hexadecimal: {2}", digit.Value, digit.Type, digit.GetHexadecimal());
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void GetBinary(Digit digit)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Digit {0} of type {1} to binary: {2}", digit.Value, digit.Type, digit.GetBinary());
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
