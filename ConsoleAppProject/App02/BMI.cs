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
            Console.WriteLine("1. Metric (Kg + cm)");
            Console.WriteLine("2. Imperial (Pounds + Feet)");
        }
    }
}