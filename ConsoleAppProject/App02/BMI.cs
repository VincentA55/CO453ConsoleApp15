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

        private InputChecker checker = new InputChecker();

        /**
         * Prints the heading for the bmi calculatior
         */

        public void PrintHeading()
        {
            Console.WriteLine("------------------------------------");
            Console.WriteLine("      Body Mass Index calculator");
            Console.WriteLine("    By Vincent Assoultissimamente");
            Console.WriteLine("------------------------------------");
        }

        /**
         *  Asks the user to choose which system they would like to use to input their measurments
         *  then does a different calculation based on their choice
         */

        public void CalculateBMI()
        {
            PrintDescription();

            Console.WriteLine("How would you like to enter your details?");
            Console.WriteLine("");
            Console.WriteLine("1. Metric (Kg + cm)");
            Console.WriteLine("2. Imperial (lbs + Feet)");
            Console.WriteLine("");

            switch (checker.InputNumber())
            {
                case 1: // Does calculations for measurments in the Metric system
                    {
                        Console.WriteLine("Please enter your weight in Kg");

                        weight = checker.InputNumber();

                        Console.WriteLine("");
                        Console.WriteLine("Please enter your height in cm");

                        height = checker.InputNumber();

                        Console.WriteLine(" " + weight + "Kg , " + height + "cm");
                        Console.WriteLine("");

                        bmi = Math.Round(weight / height / height * 10000, 2);// Rounds up to 1 decimal places

                        Console.WriteLine("Your BMI is " + bmi);

                        break;
                    }

                case 2: // Does calulations for Imperial system
                    {
                        Console.WriteLine("Please enter your weight in Stone");

                        weight = checker.InputNumber();

                        Console.WriteLine("");
                        Console.WriteLine("Please enter your height in Feet");

                        height = checker.InputNumber();

                        Console.WriteLine(" " + weight + "lbs , " + height + " feet");
                        Console.WriteLine("");

                        double wToPounds = weight * 14; // converts the weight in stone to lbs
                        double hSquared = (height * 12) * (height * 12);// converts feet into inches and squares them

                        bmi = Math.Round((wToPounds / hSquared) * 703, 2);

                        Console.WriteLine("Your BMI is " + bmi);

                        break;
                    }
            }

            CheckBMI(bmi);
        }

        /**
         * checks for the range the users bmi is in
         */

        public void CheckBMI(double bmi)
        {
            string catagory = checker.CheckRange(bmi);
            Console.WriteLine($"You are {catagory} !");
            Console.WriteLine("A normal BMI for an average person is 20");
        }

        /**
         * prints the text description for the bmi calculator
         */

        public void PrintDescription()
        {
            string description = @"
_______________________________________________________________________________________________________________________
Your BMI, or Body Mass Index, is a measure of your weight compared to your height.
Accurate assessments of obesity are important,as being overweight or obese significantly increases
your risk of a variety of medical conditionsincluding type 2 diabetes, heart disease and cancer.

For most adults, BMI gives a good estimate of your weight-related health risks.
If your BMI is over 35, your weight is definitely putting your health at risk, regardless of the factors below.
However, there are some situations where BMI may underestimate or overestimate these risks in the 25-35 BMI range.
The main ones are:
-Children
-Pregnant women
-Muscle Builders
-BAME: Black, Asian and other minority ethnic groups.
_______________________________________________________________________________________________________________________

                ";

            Console.WriteLine(description);
        }


    }
}