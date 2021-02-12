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
            Console.WriteLine("2. Imperial (lbs + Feet)");
            Console.WriteLine("");

            switch (Console.ReadLine())
            {
                case "1": // Does calculations for measurments in the Metric system
                    {
                        Console.WriteLine("Please enter your weight in Kg");

                        weight = double.Parse(Console.ReadLine());

                        Console.WriteLine("");
                        Console.WriteLine("Please enter your height in cm");

                        height = double.Parse(Console.ReadLine());

                        Console.WriteLine(" " + weight + "Kg , " + height + "cm");
                        Console.WriteLine("");

                        bmi = weight / height / height * 10000;
                        Math.Round(bmi, 2); // Rounds up to 1 decimal places
                        Console.WriteLine("Your BMI is " + bmi);

                        break;
                    }

                case "2": // Does calulations for Imperial system
                    {
                        Console.WriteLine("Please enter your weight in Stone");

                        weight = double.Parse(Console.ReadLine());

                        Console.WriteLine("");
                        Console.WriteLine("Please enter your height in Feet");

                        height = double.Parse(Console.ReadLine());

                        Console.WriteLine(" " + weight + "lbs , " + height + " feet");
                        Console.WriteLine("");

                        double wToPounds = weight * 14;
                        double hSquared = (height * 12) * (height * 12);

                        // BMI calculation isnt 100% atm somthing to do with feet to inches
                        bmi = Math.Round((wToPounds / hSquared) * 703 ,2);
                       
                        Console.WriteLine("Your BMI is " + bmi);

                        break;
                    }
            }
        }
    }
}