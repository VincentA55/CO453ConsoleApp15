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
        public const int FEET_IN_MILES = 5280;
        public const double METERS_IN_MILES = 1609.34;
    
        public void PrintHeading()
        {
            Console.WriteLine("------------------------------------");
            Console.WriteLine("       Distance Converter");
            Console.WriteLine("    By Vincent Assoultissimamente");
            Console.WriteLine("------------------------------------");
        }

        /**
         * 
         * 
         * */
        public void Convert()
        {
            do
            {
                Console.WriteLine(" Options available :");
                Console.WriteLine();
                Console.WriteLine(" 1. Feet");
                Console.WriteLine(" 2. Meters");
                Console.WriteLine(" 3. Miles");
                Console.WriteLine();
                Console.WriteLine("Please type in the distance and mesurement you would like to convert");
                Console.WriteLine("Example : 10 meters");

                float distance = 0;
                string measurement = null;

                string[] input = Console.ReadLine().ToLower().Split();

                if (input.Length > 1) // checks if the input has more than 1 word
                {
                    distance = float.Parse(input[0]);
                    measurement = input[1];
                }
                else {
                    Console.WriteLine("Please type in the distance and measurement!");
                }

                switch (measurement)
                {
                    case "feet": // Converts from Feet into miles and meters
                        Console.WriteLine(" Convert " + distance + " Feet into...");
                        string newMeasurement = Console.ReadLine().ToLower();
                        switch (newMeasurement)
                        {
                            case "meters": Console.WriteLine(distance + " Feet = " + distance * 0.3048 + " Meters"); break;

                            case "miles": Console.WriteLine(distance + " Feet = " + distance / 5280 + " Miles"); break;

                            default: Console.WriteLine("Enter a valid measurement!"); break;
                        }
                        break;

                    case "meters": // Converts from Meters into feet and miles
                        Console.WriteLine(" Convert " + distance + " Meters into...");
                        string newMeasurement2 = Console.ReadLine().ToLower();
                        switch (newMeasurement2)
                        {
                            case "feet": Console.WriteLine(distance + " Meters = " + distance * 3.281 + " Feet"); break;

                            case "miles": Console.WriteLine(distance + " Meters = " + distance / 1609 + " Miles"); break;

                            default: Console.WriteLine("Enter a valid measurement!"); break;
                        }
                        break;

                    case "miles": // Converts from Miles into meters and feet
                        Console.WriteLine(" Convert " + distance + " Miles into...");
                        string newMeasurment3 = Console.ReadLine().ToLower();
                        switch (newMeasurment3)
                        {
                            case "meters": Console.WriteLine(distance + " Miles = " + distance * 1609 + " Meters"); break;

                            case "feet": Console.WriteLine(distance + " Miles = " + distance * 5280 + " Feet"); break;

                            default: Console.WriteLine("Enter a valid measurment!"); break;
                        }
                        break;

                    default: Console.WriteLine("No valid input!"); break;
                }
                Console.WriteLine("Would you like to convert again?");
            }
            while (Console.ReadLine().ToLower() != "no");

            Console.WriteLine("Thank you and good bye!");
        }
    }
}