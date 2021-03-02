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
    }
}
