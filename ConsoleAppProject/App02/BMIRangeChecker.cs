using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppProject.App02
{
    class BMIRangeChecker
    {
        public double bmiToCheck;

        public string CheckRange(double bmi)
        {

            if (InRange(bmi,0,18.5))
            {
                return "Underweight";
            }
            if (InRange(bmi,18.6,24.9))
            {
                return "Normal";
            }
            if (InRange(bmi,25,29.9))
            {
                return "Overweight";
            }
            if (InRange(bmi,30,34.9))
            {
                return "Obese Class I";
            }
            if (InRange(bmi,35,39.9))
            {
                return "Obese Class II";
            }
            if (InRange(bmi,40,9999999999))
            {
                return "Obese Class III";
            }
            else
            {
                return "No valid BMI";
            }

        }

        /**
         * Checks if a value is within a given range
         */
        public bool InRange(double value, double from, double to)
        {
            if (value >= from && value <= to)
                return true;
            else
            {
                return false;
            }
        }
    }
}
