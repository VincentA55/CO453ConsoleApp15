using System;

namespace ConsoleAppProject
{
    /// <summary>
    /// A class that has various methods that help with input validation 
    /// </summary>
    /// <author>Vincent Assolutissimamente</author>
    public static class InputChecker2
    {
        /// <summary>
        /// Checks if a value is within a given range
        /// </summary>
        /// <param name="value"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns>boolean</returns>
        public static bool InRange(double value, double from, double to)
        {
            if (value >= from && value <= to)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Ensures that only a number can be returned
        /// </summary>
        /// <returns>double</returns>
        public static double InputNumber()
        {
            double number = 0;
            bool Isvalid = false;

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

        /// <summary>
        /// Ensures that only a number within a range can be returned
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns>double</returns>
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