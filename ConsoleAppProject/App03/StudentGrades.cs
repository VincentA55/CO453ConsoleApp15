using System;
namespace ConsoleAppProject.App03
{
    public class StudentGrades
    {
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
            throw new NotImplementedException();
        }

        /// <summary>
        /// Calculate and displays 
        /// min, max, and mean mark for all students
        /// </summary>
        public void CalculateStats()
        {
            throw new NotImplementedException();
        }
    }
}