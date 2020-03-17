using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        
        static void Main(string[] args)
        {
            string roman_number;
            int number;
            Console.WriteLine("Enter the Roman Number");
            roman_number = Console.ReadLine();
            number = fromRoman(roman_number);
            Console.WriteLine("Numeric form of Roman Number" + roman_number + " = " +number);
            Console.ReadKey();
        }
        static int fromRoman(string roman)
        {
            int number = 0;
            for (int i = 0; i < roman.Length; i++)
            {
                int a = getRomanValue(roman[i]);
                int b;
                if (i + 1 < roman.Length)
                    b = getRomanValue(roman[i + 1]);
                else b = 0;
                if (b > a)//if the second digit is greater than first digit, then it has to be subtracted
                {
                    number = number + (b - a);
                    i++;
                }
                else //else the first digit is added to next number
                    number = number + a;

            }
            return number;
        }
        //return the numeric value for each roman digit
        static int getRomanValue(char roman_digit)
        {
            switch (roman_digit)
            {
                case 'I': return 1;
                case 'V': return 5;
                case 'X': return 10;
                case 'L': return 50;
                case 'C': return 100;
                case 'D': return 500;
                case 'M': return 1000;
            }
            return 0;
        }
    }
}
