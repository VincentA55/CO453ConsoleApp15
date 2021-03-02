using System;

namespace ConsoleAppProject.App02
{
    /// <summary>
    /// Calculates the BMI of the user
    /// </summary>
    /// <author>
    /// Vincent Assolutissimamente
    /// </author>
    public class BMICalculator
    {
        public string Units { get; set; }

        public double Weight { get; set; }
        public double Height { get; set; }

        public double Bmi;

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

            switch (InputChecker2.InputNumberWithin(1, 2))
            {
                case 1: // Does calculations for measurments in the Metric system
                    {
                        Console.WriteLine("Please enter your weight in Kg");

                        Weight = InputChecker2.InputNumber();

                        Console.WriteLine("");
                        Console.WriteLine("Please enter your height in cm");

                        Height = InputChecker2.InputNumber();

                        Console.WriteLine(" " + Weight + "Kg , " + Height + "cm");
                        Console.WriteLine("");

                        Bmi = Math.Round(Weight / Height / Height * 10000, 2);// Rounds up to 1 decimal places

                        Console.WriteLine("Your BMI is " + Bmi);

                        break;
                    }

                case 2: // Does calulations for Imperial system
                    {
                        Console.WriteLine("Please enter your weight in Stone");

                        Weight = InputChecker2.InputNumber();

                        Console.WriteLine("");
                        Console.WriteLine("Please enter your height in Feet");

                        Height = InputChecker2.InputNumber();

                        Console.WriteLine(" " + Weight + "lbs , " + Height + " feet");
                        Console.WriteLine("");

                        double wToPounds = Weight * 14; // converts the weight in stone to lbs
                        double hSquared = (Height * 12) * (Height * 12);// converts feet into inches and squares them

                        Bmi = Math.Round((wToPounds / hSquared) * 703, 2);

                        Console.WriteLine("Your BMI is " + Bmi);

                        break;
                    }
            }

            CheckBMI(Bmi);
        }
        public string CheckRange(double bmi)
        {
            if (InputChecker2.InRange(bmi, 0, 18.5))
            {
                return "Underweight";
            }
            if (InputChecker2.InRange(bmi, 18.6, 24.9))
            {
                return "Normal";
            }
            if (InputChecker2.InRange(bmi, 25, 29.9))
            {
                return "Overweight";
            }
            if (InputChecker2.InRange(bmi, 30, 34.9))
            {
                return "Obese Class I";
            }
            if (InputChecker2.InRange(bmi, 35, 39.9))
            {
                return "Obese Class II";
            }
            if (InputChecker2.InRange(bmi, 40, 9999999999))
            {
                return "Obese Class III";
            }
            else
            {
                return "No valid BMI";
            }
        }


        /**
         * returns bmi with metric input
         * */

        public double ReturnBMIMetric(double weight, double height)
        {
            Console.WriteLine(" " + weight + "Kg , " + height + "cm");
            Console.WriteLine("");
            this.Bmi = Math.Round(weight / height / height * 10000, 2);// Rounds up to 1 decimal places
            return Bmi;
        }


        /*
         * returns bmi with imperial input
         * */

        public double ReturnBMIImperial(double weight, double height)
        {
            Console.WriteLine(" " + weight + "lbs , " + height + " feet");
            Console.WriteLine("");

            double wToPounds = weight * 14; // converts the weight in stone to lbs
            double hSquared = (height * 12) * (height * 12);// converts feet into inches and squares them

            this.Bmi = Math.Round((wToPounds / hSquared) * 703, 2);
            return Bmi;
        }


        /**
         * checks for the range the users bmi is in
         */

        public void CheckBMI(double bmi)
        {
            string catagory = CheckRange(bmi);
            Console.WriteLine($"You are {catagory} !");
            Console.WriteLine("A normal BMI for an average person is 20");
        }
        /**
       * returns for the range the users bmi is in
       */

        public string ReturnBMI()
        {
            string catagory = CheckRange(Bmi);
            return @$"Your BMI is {Bmi}
                    You are {catagory} !
                    A normal BMI for an average person is 20";
        }

        /**
         * prints the text description for the bmi calculator
         */

        public string PrintDescription()
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
            return description;
        }
    }
}