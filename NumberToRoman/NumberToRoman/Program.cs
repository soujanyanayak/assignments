using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberToRoman
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            Console.WriteLine("Enter Number");
            n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Roman number = " + ToRoman(n));
            Console.ReadKey();
        }
        static string ToRoman(int n)
        {
            Stack roman_stk = new Stack();
            StringBuilder str = new StringBuilder();
            int i = 10;
            while (n > 0 )
            {
                string value;
                if (i == 10000)
                {
                    value = RomanValue(n, i / 10, i/2);
                    roman_stk.Push(value);
                    break;
                }
                int rem = n % 10;
                if (rem != 0)
                {
                    value = RomanValue(rem, i / 10, i / 2);
                    roman_stk.Push(value);
                }
                    
                i = i * 10;
                n = n / 10;                
            }

            foreach(object ob in roman_stk)
            {
                str.Append(ob);
            }
            return str.ToString();

        }

        static string RomanValue(int number, int unit, int m)
        {
            StringBuilder val = new StringBuilder();
            if (number == 0)
            {
                return "0";
            }
            else if (unit == 1000)
            {
                val.Append(Value(1000));
                for (int i = 1000; i <= number * unit - 1000; i = i + 1000)
                {
                    val.Append(Value(unit));
                }
                return val.ToString();
            }

            else
            {
                if (number*unit < m)
                {
                    if (m - number*unit == unit)
                    {
                        val.Append(Value(unit));
                        val.Append(Value(m));
                        //
                    }
                    else
                    {
                        
                        for (int i = 1; i <m-number; i=i*unit*10)
                        {
                            val.Append(Value(unit));
                        }
                    }
                }
                else
                {
                    if (m * 2 - number*unit == unit)
                    {
                        val.Append(Value(unit));
                        val.Append(Value(unit*10));
                    }
                    else
                    {
                        val.Append(Value(m));
                        if (m == 5)
                        {
                            for (int i = 1; i <= number - 5; i++)
                            {
                                val.Append(Value(unit));
                            }
                        }
                        else
                        {

                            for (int i = 1; i <= number*unit - m; i = i * unit)
                            {
                                val.Append(Value(unit));
                            }
                        }
                    }
                }

                return val.ToString();

            }
            
        }
        static string Value(int n)
        {
            switch (n)
            {
                case 1:return "I";
                case 5:return "V";
                case 10:return "X";
                case 50:return "L";
                case 100:return "C";
                case 500:return "D";
                case 1000:return "M";
            }
            return "0";
        }
    }
}
