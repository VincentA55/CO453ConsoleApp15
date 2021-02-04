
using System;
namespace ConsoleAppProject.App01
{
    /// <summary>
    /// Takes an input from the user and converts it into either feet, meters, or miles
    /// </summary>
    /// <author>
    /// Vincent Assolutissimamente 04/02/2021
    /// </author>
    public class DistanceConverter
    {
       public void PrintHeading(){

        Console.WriteLine("------------------------------------");
        Console.WriteLine("       Distance Converter");
        Console.WriteLine("    By Vincent Assoultissimamente");
        Console.WriteLine("------------------------------------");
        }
        public void Convert()
        {
            Console.WriteLine(" Options available :");
            Console.WriteLine();
            Console.WriteLine(" 1. Feet");
            Console.WriteLine(" 2. Meters");
            Console.WriteLine(" 3. Miles");
            Console.WriteLine();

            string[] input = Console.ReadLine().ToLower().Split();

            float distance = float.Parse(input[0]);
            string measurement = input[1];

            switch (measurement)
            {
                case "feet":
                    Console.WriteLine(" Convert " + distance + " Feet into...");
                    string newMeasurement = Console.ReadLine().ToLower();
                    switch (newMeasurement)
                    {
                        case "meters": Console.WriteLine(distance + " Feet = " + distance * 0.3048 + " Meters"); break;
                        default: Console.WriteLine("Enter a valid measurement!"); break;
                    }
                    break;




                default: Console.WriteLine("No input"); break;
            }

        }







    }


}
