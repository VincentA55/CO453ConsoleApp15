using ConsoleAppProject.App02;
using System;

namespace ConsoleAppProject.App01
{
    /// <summary>
    /// The main method in this class is called first
    /// when the application is started.  It will be used
    /// to start Apps 01 to 05 for CO453 CW1
    ///
    /// This Project has been modified by:
    /// Vincent Assoultissimamente 01/02/2021
    /// </summary>
    public static class Program
    {
        public static void Main()
        {
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("BNU CO453 Applications Programming 2020-2021!");
            Console.WriteLine();
            Console.Beep();
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("");
            Console.WriteLine("|1. Distance converter");
            Console.WriteLine("|2. BMI calculator");

            string[] choices = {"|1. Distance Converter", "|2. BMI Calculator", "|3. Student Grades"};
            

            switch (ConsoleHelper.SelectChoice(choices))
            {
                case 1:
                    {
                        DistanceConverter converter = new DistanceConverter();
                        ConsoleHelper.OutputHeading("Distance Converter");
                        converter.Convert();
                        break;
                    }
                case 2:
                    {
                        BMICalculator bmi = new BMICalculator();
                        ConsoleHelper.OutputHeading("BMI Calculator");
                        bmi.CalculateBMI();
                        break;
                    }
            }
            Main();
        }
    }
}