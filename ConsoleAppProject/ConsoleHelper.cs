using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppProject
{
    public static class ConsoleHelper
    {
        public static void OutputHeading(string heading)
        {
                Console.WriteLine("------------------------------------");
                Console.WriteLine($"             {heading}");
                Console.WriteLine("    By Vincent Assoultissimamente");
                Console.WriteLine("------------------------------------");
            
        }

        public static int SelectChoice(string[] choices)
        {
            int choiceNo = 0;
            
            //Display all the choices

            foreach(string choice in choices)
            {
                choiceNo++;
                Console.WriteLine($" {choiceNo}. {choice}"):
            }

            //Input the users choice as a number

            Console.WriteLine("\n Please enter your choice number >");

            string value = Console.ReadLine();
            choiceNo = Convert.ToInt16(value);

            return choiceNo;
        }
    }
}
