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
        public const double METERS_IN_MILES = 1609;

        public string FromUnit { get; set; }
        public string ToUnit { get; set; }
        public double FromDistance { get; set; }
        public double ToDistance { get; set; }

        public void PrintHeading()
        {
            Console.WriteLine("------------------------------------");
            Console.WriteLine("       Distance Converter");
            Console.WriteLine("    By Vincent Assoultissimamente");
            Console.WriteLine("------------------------------------");
        }

        /**
         *  Recives measurments from the user in the measurement of their choice and converts it into a different measurement of their choice
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
                Console.WriteLine();

                string[] input = Console.ReadLine().ToLower().Split(" ");

                if (input.Length > 1) // checks if the input has more than 1 word
                {
                    FromDistance = float.Parse(input[0]);
                    FromUnit = input[1];
                }
                else
                {
                    Console.WriteLine("Please type in the distance and measurement!");
                }

                Console.WriteLine(" Convert " + FromDistance + " " + FromUnit + " into...");
                ToUnit = Console.ReadLine().ToLower();

                if (FromUnit == "feet" && ToUnit == "meters") // feet into meters
                {
                    ToDistance = FromDistance * 0.3048;
                }
                if (FromUnit == "feet" && ToUnit == "miles") // feet into miles
                {
                    ToDistance = FromDistance / FEET_IN_MILES;
                }

                if (FromUnit == "meters" && ToUnit == "feet")// meters into feet
                {
                    ToDistance = FromDistance * 3.281;
                }
                if (FromUnit == "meters" && ToUnit == "miles") // meters into miles
                {
                    ToDistance = FromDistance / METERS_IN_MILES;
                }

                if (FromUnit == "miles" && ToUnit == "feet")// miles into feet
                {
                    ToDistance = FromDistance * FEET_IN_MILES;
                }
                if (FromUnit == "miles" && ToUnit == "meters")// miles into meters
                {
                    ToDistance = FromDistance * METERS_IN_MILES;
                }

                Console.WriteLine(FromDistance + " " + FromUnit + " = " + Math.Round(ToDistance, 4) + " " + ToUnit);
                Console.WriteLine("");
                Console.WriteLine("Would you like to convert again?");
            }

            while (Console.ReadLine().ToLower() != "no");

            Console.WriteLine("Thank you and good bye!");
        }

        public void ConvertDistance()
        {
            if (FromUnit == "feet" && ToUnit == "meters") // feet into meters
            {
                ToDistance = FromDistance * 0.3048;
            }
           else if (FromUnit == "feet" && ToUnit == "miles") // feet into miles
            {
                ToDistance = FromDistance / FEET_IN_MILES;
            }

           else if (FromUnit == "meters" && ToUnit == "feet")// meters into feet
            {
               ToDistance = FromDistance * 3.281;
            }
           else if (FromUnit == "meters" && ToUnit == "miles") // meters into miles
            {
                ToDistance = FromDistance / METERS_IN_MILES;
            }

           else if (FromUnit == "miles" && ToUnit == "feet")// miles into feet
            {
               ToDistance = FromDistance * FEET_IN_MILES;
            }
            else if (FromUnit == "miles" && ToUnit == "meters")// miles into meters
            {
               ToDistance = FromDistance * METERS_IN_MILES;
            }
            else
            {
                 ToDistance = 80085;
            }
        }
    }
}