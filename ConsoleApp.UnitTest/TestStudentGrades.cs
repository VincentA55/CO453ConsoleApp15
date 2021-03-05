using ConsoleAppProject.App03;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleApp.UnitTest
{
    [TestClass]
    public class TestStudentGrades
    {
        private readonly StudentGrades converter = new StudentGrades();

        private int[] testMarks;

        public TestStudentGrades()
        {
            testMarks = new int[]
            {
                10,20,30,40,50,60,70,80,90,100
            };
        }

        [TestMethod]
        public void Convert0ToGradeF()
        {
            // Arrange
            Grades expectedGrade = Grades.F;

            // Act
            Grades actualGrade = converter.ConvertToGrade(0);

            // Assert
            Assert.AreEqual(expectedGrade, actualGrade);
        }

        [TestMethod]
        public void Convert39ToGradeF()
        {
            // Arrange
            Grades expectedGrade = Grades.F;

            // Act
            Grades actualGrade = converter.ConvertToGrade(39);

            // Assert
            Assert.AreEqual(expectedGrade, actualGrade);
        }

        [TestMethod]
        public void Convert40ToGradeD()
        {
            // Arrange
            Grades expectedGrade = Grades.D;

            // Act
            Grades actualGrade = converter.ConvertToGrade(40);

            // Assert
            Assert.AreEqual(expectedGrade, actualGrade);
        }

        [TestMethod]
        public void TestCalculateMean()
        {
            // Arrange
        
            converter.Marks = testMarks;

            double expectedMean = 55.0;

            // Act

            converter.CalculateStats();

            // Assert

            Assert.AreEqual(expectedMean, converter.Mean);
        }
    }
}