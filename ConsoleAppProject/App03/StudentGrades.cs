using System;

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
        /// Main method for the StudentGrades class
        /// </summary>
        public void Main()
        {
            string[] choices = new string[]
            {
              "Input Marks", "Output Marks", "Output Stats", "Output Grade Profile", "Quit", "giveMarksTesting()"
            };

            bool finished = false;
            do
            {
                Console.WriteLine();
                switch (ConsoleHelper.SelectChoice(choices))
                {
                    case 1:
                        InputMarks();
                        break;

                    case 2:
                        OutputMarks();
                        break;

                    case 3:
                        OutputStats();
                        break;

                    case 4:
                        CalculateGradeProfile();
                        OutputGradeProfile();
                        break;

                    case 5:
                        Console.WriteLine(@"Now quitting Student Grades...
___________________________________________

");
                        finished = true;
                        break;

                    case 6:
                        giveMarksTesting();
                        break;
                }
            } while (!finished);
        }

        /// <summary>
        /// Input a mark between 0-100 for each
        /// student and stores it in the Marks array
        /// </summary>
        public void InputMarks()
        {
            int i = 0;

            foreach (string student in Students)
            {
                Console.WriteLine($"Enter the marks for {student} >");
                Marks[i] += ConsoleHelper.InputNumberWithin(LowestMark, HighestMark);
                i++;
            }
        }

        /// <summary>
        /// Lists all the students names and current mark
        /// </summary>
        public void OutputMarks()
        {
            Console.WriteLine("Output Marks :");
            Console.WriteLine();
            int i = 0;

            foreach (string student in Students)
            {
                Console.WriteLine($" Marks for {student} :| {Marks[i]} |");
                i++;
            }
        }

        /// <summary>
        /// Convert a students marks into a Grade(A-F)
        /// </summary>
        /// <param name="mark"></param>
        /// <returns>Grades</returns>
        public Grades ConvertToGrade(int mark)
        {
            if (ConsoleHelper.InRange(mark, LowestGradeA, HighestMark) || mark > 100)
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
        /// Calculate min, max, and mean mark for all students
        /// </summary>
        public void CalculateStats()
        {
            // calculates the mean
            double total = 0;

            foreach (int mark in Marks)
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
        /// prints out the stats for each student and the class
        /// </summary>
        public void OutputStats()
        {
            int i = 0;

            foreach (string student in Students)
            {
                CalculateGradeProfile();
                CalculateStats(); // NOT QUIT SURE WHAT IT SUPPOSED TO HAPPEN HERE !! NOT FINSHED COME BACK HERE<--
                string gradeClass = ConsoleHelper.GetDescription(ConvertToGrade(Marks[i]));
               
                Console.WriteLine($" |{student} :{gradeClass} ");
                Console.WriteLine(" |____________");
                Console.WriteLine($" |Grade : { ConvertToGrade(Marks[i])}  |");
                Console.WriteLine($" |Marks : {Marks[i]} |");
                Console.WriteLine($"");
                Console.WriteLine($"");
                i++;
            }
            Console.WriteLine("  ______________________");
            Console.WriteLine(" |Stats for all students|");
            Console.WriteLine(" |______________________|");

            Console.WriteLine($" |Maximum : {Maximum}  ");
            Console.WriteLine($" |Minimum : {Minimum}  ");
            Console.WriteLine($" |Average : {Mean}   ");
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

        /// <summary>
        /// Outputs the gradeprofile
        /// </summary>
        public void OutputGradeProfile()
        {
            Grades grade = Grades.F;
            Console.WriteLine();

            foreach (int count in GradeProfile)
            {
                int percentage = count * 100 / Marks.Length;
                Console.WriteLine($"Grade {grade} {percentage}% Count {count}");
                grade++;
            }

            Console.WriteLine();
        }

        /// <summary>
        ///gives each student marks for testing purposes
        /// </summary>
        public void giveMarksTesting()
        {
            int i = 0;
            Random r = new Random();
            foreach (string student in Students)
            {
                Marks[i] += r.Next(0, 100);
                Console.WriteLine($"{student} marks : {Marks[i]}");
                i++;
            }
        }
    }
}