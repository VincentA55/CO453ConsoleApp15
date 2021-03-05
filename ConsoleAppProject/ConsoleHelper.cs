using System;

namespace ConsoleAppProject
{
    /// <summary>
    /// A utility class containing methods that help with various input validations and console functions
    /// </summary>
    public static class ConsoleHelper
    {
        public static void OutputHeading(string heading)
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine($"             {heading}");
            Console.WriteLine("    By Vincent Assoultissimamente");
            Console.WriteLine("-------------------------------------");
        }

        /// <summary>
        /// Takes an array of choices and returns the number of the users choice
        /// </summary>
        /// <param name="choices"></param>
        /// <returns>double</returns>
        public static int SelectChoice(string[] choices)
        {
            int choiceNo = 0;

            //Display all the choices

            foreach (string choice in choices)
            {
                choiceNo++;
                Console.WriteLine($"|{choiceNo}. {choice}");
            }

            choiceNo = InputNumberWithin(choiceNo-choiceNo+1, choices.Length);


            return choiceNo;
        }

        /// <summary>
        /// Aks for a number and ensures that only a number can be returned
        /// </summary>
        /// <returns>double</returns>
        public static double InputNumber()
        {
            double number = 0;
            bool Isvalid = false;

            do
            {
                Console.WriteLine(" ");
                Console.Write("Enter a number >");
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
        /// Only checks if a value is within a given range
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
        /// Returns and Ensures that only a number within a range can be returned
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns>double</returns>
        public static int InputNumberWithin(int from, int to)
        {
            int number;
            bool Isvalid;

            do
            {
                double value = InputNumber();

                number = Convert.ToInt32(value);
                Isvalid = true;
              
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