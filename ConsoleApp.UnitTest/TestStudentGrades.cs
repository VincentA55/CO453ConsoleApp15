using ConsoleAppProject.App03;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleApp.UnitTest
{
    [TestClass]
    public class TestStudentGrades
    {
        private readonly StudentGrades studentGradeTester = new StudentGrades();

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
            Grades actualGrade = studentGradeTester.ConvertToGrade(0);

            // Assert
            Assert.AreEqual(expectedGrade, actualGrade);
        }

        [TestMethod]
        public void Convert39ToGradeF()
        {
            // Arrange
            Grades expectedGrade = Grades.F;

            // Act
            Grades actualGrade = studentGradeTester.ConvertToGrade(39);

            // Assert
            Assert.AreEqual(expectedGrade, actualGrade);
        }

        [TestMethod]
        public void Convert40ToGradeD()
        {
            // Arrange
            Grades expectedGrade = Grades.D;

            // Act
            Grades actualGrade = studentGradeTester.ConvertToGrade(40);

            // Assert
            Assert.AreEqual(expectedGrade, actualGrade);
        }

        [TestMethod]
        public void TestCalculateMean()
        {
            // Arrange
        
            studentGradeTester.Marks = testMarks;

            double expectedMean = 55.0;

            // Act

            studentGradeTester.CalculateStats();

            // Assert

            Assert.AreEqual(expectedMean, studentGradeTester.Mean);
        }


        [TestMethod]
        public void TestCalculateMax()
        {
            // Arrange

            studentGradeTester.Marks = testMarks;

            double expectedMax = 100;

            // Act

            studentGradeTester.CalculateStats();

            // Assert

            Assert.AreEqual(expectedMax, studentGradeTester.Maximum);
        }


        [TestMethod]
        public void TestCalculateMin()
        {
            // Arrange

            studentGradeTester.Marks = testMarks;

            double expectedMin = 10;

            // Act

            studentGradeTester.CalculateStats();

            // Assert

            Assert.AreEqual(expectedMin, studentGradeTester.Minimum);
        }

        [TestMethod]
        public void TestGradeProfile()
        {
            // Arrange
            studentGradeTester.Marks = testMarks;

            // Act
            studentGradeTester.CalculateGradeProfile();

            bool expectedProfile;
            expectedProfile = ((studentGradeTester.GradeProfile[0] == 3) &&
                               (studentGradeTester.GradeProfile[1] == 1) &&
                               (studentGradeTester.GradeProfile[2] == 1) &&
                               (studentGradeTester.GradeProfile[3] == 1) &&
                               (studentGradeTester.GradeProfile[4] == 4));

            // Assert
            Assert.IsTrue(expectedProfile);
        }

        [TestMethod]
        public void TestGiveMarksToJaniel()
        {
            //Arrange
            studentGradeTester.giveMarksTo("Janiel", 88);

            //Act

            //Assert
            int expectedMark = 88;
            Assert.IsTrue(studentGradeTester.Marks[1] == expectedMark);
        }

        [TestMethod]
        public void TestGiveNegativeMarksToJaniel()
        {
            //Arrange
            
            //Act

            //Assert
            int expectedMark = -1;
            Assert.IsTrue(studentGradeTester.giveMarksTo("Janiel", -88) == expectedMark);
        }
    }
}