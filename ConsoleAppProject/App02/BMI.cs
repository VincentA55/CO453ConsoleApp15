using System;

namespace ConsoleAppProject.App02
{
    /// <summary>
    /// Calculates the BMI of the user
    /// </summary>
    /// <author>
    /// Vincent Assolutissimamente
    /// </author>
    public class BMI
    {
        private double weight;
        private double height;

        private double bmi;

        public void PrintHeading()
        {
            Console.WriteLine("------------------------------------");
            Console.WriteLine("      Body Mass Index calculator");
            Console.WriteLine("    By Vincent Assoultissimamente");
            Console.WriteLine("------------------------------------");
        }

        public void CalculateBMI()
        {
            Console.WriteLine("How would you like to enter your details?");
            Console.WriteLine("");
            Console.WriteLine("1. Metric (Kg + cm)");
            Console.WriteLine("2. Imperial (Pounds + Feet)");
            Console.WriteLine("");

            switch (Console.ReadLine())
            {
                case "1":
                    {
                        Console.WriteLine("Please enter your weight in Kg");
                        string input = Console.ReadLine();
                        weight = double.Parse(input);

                        Console.WriteLine("");
                        Console.WriteLine("Please enter your height in cm");
                        input = Console.ReadLine();
                        height = double.Parse(input);

                        Console.WriteLine( " " + weight + "Kg , " + height + "cm");


                        break;
                    }
            }
        }
    }
}