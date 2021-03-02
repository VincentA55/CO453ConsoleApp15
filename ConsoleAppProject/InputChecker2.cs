using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppProject
{
    public static class InputChecker2
    {
            /**
             * Checks if a value is within a given range
             */

            public static bool InRange(double value, double from, double to)
            {
                if (value >= from && value <= to)
                    return true;
                else
                {
                    return false;
                }
            }

            /**
             * Ensures that only a number can be returned
             */

            public static double InputNumber()
            {
                double number = 0;
                bool Isvalid;
               
                do
                {
                    Console.Write(">");
                    string value = Console.ReadLine();
                    
                    try
                    {
                        number = Convert.ToDouble(value);
                        Isvalid = true;
                    }
                    catch (Exception)
                    {
                        Isvalid = false;
                        Console.WriteLine("Number is INVALID!!");
                    }
                }
                while (!Isvalid);
                return number;
            }

            /**
             * Ensures that only a number can be returned
             */

            public static double InputNumberWithin(int from, int to)
            {
                double number = 0;
                bool Isvalid;

                do
                {
                    Console.Write(">");
                    string value = Console.ReadLine();

                    try
                    {
                        number = Convert.ToDouble(value);
                        Isvalid = true;
                    }
                    catch (Exception)
                    {
                        Isvalid = false;
                        Console.WriteLine("Number is INVALID!!");
                    }

                    if (number < from || number > to)
                    {
                        Console.WriteLine($"Number must be between {from} and {to} !");
                        Isvalid = false;
                    }
                }
                while (!Isvalid);

                return number;
            }
        }
    }
