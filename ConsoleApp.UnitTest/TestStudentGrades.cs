using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleAppProject.App03;

namespace ConsoleApp.UnitTest
{
    [TestClass]
    public class TestStudentGrades
    {
       private readonly StudentGrades studentGrades = new StudentGrades();

        [TestMethod]
        public void Convert0ToGradeF()
        {
            // Arrange
            Grades expectedGrade = Grades.F;

            // Act
            Grades actualGrade = studentGrades.ConvertToGrade(0);

            // Assert
            Assert.AreEqual(expectedGrade, actualGrade);
        }
    }
}
