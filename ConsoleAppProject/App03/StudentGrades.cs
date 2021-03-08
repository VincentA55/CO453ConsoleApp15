﻿using System;

namespace ConsoleAppProject.App03
{
    public class StudentGrades
    {
        // Constants
        public const int LowestMark = 0;

        public const int LowestGradeD = 40;
        public const int LowestGradeC = 50;
        public const int LowestGradeB = 60;
        public const int LowestGradeA = 70;
        public const int HighestMark = 100;

        // Properties
        public string[] Students { get; set; }

        public int[] Marks { get; set; }

        public int[] GradeProfile { get; set; }

        public double Mean { get; set; }

        public int Minimum { get; set; }

        public int Maximum { get; set; }

        /// <summary>
        /// Class constructor sets up an array of students
        /// </summary>
        public StudentGrades()
        {
            Students = new string[]
            {
                "Daniel","Janiel", "Shmaniel",
                "Billy", "Georgia", "Roman",
                "Wills", "Fabio", "Oliver",
                "LisaLisa"
            };

            GradeProfile = new int[(int)Grades.A + 1];
            Marks = new int[Students.Length];
        }

        /// <summary>
        /// Input a mark between 0-100 for each
        /// student and stores it in the Marks array
        /// </summary>
        public void InputMarks()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Lists all the students names and current mark
        /// </summary>
        public void OutputMarks()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Convert a students marks into a Grade(A-F)
        /// </summary>
        /// <param name="mark"></param>
        /// <returns>Grades</returns>
        public Grades ConvertToGrade(int mark)
        {
            if (ConsoleHelper.InRange(mark, LowestGradeA, HighestMark)) 
            {
                return Grades.A;
            }
            else if (ConsoleHelper.InRange(mark, LowestGradeB, LowestGradeA - 1)) // -1 is required because InRange() checks <= not <
            {
                return Grades.B;
            }
            else if (ConsoleHelper.InRange(mark, LowestGradeC, LowestGradeB - 1))
            {
                return Grades.C;
            }
            else if (ConsoleHelper.InRange(mark, LowestGradeD, LowestGradeC - 1))
            {
                return Grades.D;
            }
            else 
            {
                return Grades.F;
            };
        }

        /// <summary>
        /// Calculate and displays
        /// min, max, and mean mark for all students
        /// </summary>
        public void CalculateStats()
        {
            // calculates the mean
            double total = 0;

            foreach(int mark in Marks)
            {
                total = total + mark;
            }

            Mean = total / Marks.Length;

            // calculates the maximum
            Maximum = 0; 
            foreach (int mark in Marks)
            {
                if (mark > Maximum)
                {
                    Maximum = mark;
                }
            }

            // calculates the minimum
            Minimum = 100;
            foreach (int mark in Marks)
            {
                if (mark < Minimum)
                {
                    Minimum = mark;
                }
            }
        }

        /// <summary>
        /// calculates the profile for a grade
        /// </summary>
        public void CalculateGradeProfile()
        {
            for (int i = 0; i < GradeProfile.Length; i++)
            {
                GradeProfile[i] = 0;
            }

            foreach (int mark in Marks)
            {
                Grades grade = ConvertToGrade(mark);
                GradeProfile[(int)grade]++;
            }
        }


    }
}