using System;

namespace ConsoleAppProject.App02
{
    internal class InputChecker
    {
        /*
         * uses the InRange method to check what WHO catagory each BMI falls into
         */

        public string CheckRange(double bmi)
        {
            if (InRange(bmi, 0, 18.5))
            {
                return "Underweight";
            }
            if (InRange(bmi, 18.6, 24.9))
            {
                return "Normal";
            }
            if (InRange(bmi, 25, 29.9))
            {
                return "Overweight";
            }
            if (InRange(bmi, 30, 34.9))
            {
                return "Obese Class I";
            }
            if (InRange(bmi, 35, 39.9))
            {
                return "Obese Class II";
            }
            if (InRange(bmi, 40, 9999999999))
            {
                return "Obese Class III";
            }
            else
            {
                return "No valid BMI";
            }
        }

        /**
         * Checks if a value is within a given range
         */

        public bool InRange(double value, double from, double to)
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

        public double InputNumber()
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

        public double InputNumberWithin(int from, int to)
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