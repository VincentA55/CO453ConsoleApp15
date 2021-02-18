using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleAppProject.App02;
namespace TestBMI
{
    [TestClass]
    public class TestBMI
    {
        [TestMethod]
        public void TestingBMI()
        {
            BMI bmi = new BMI();
            bmi.weight = 73;
            bmi.height = 175;
            bmi.CalculateBMI();

            bmi.CheckBMI(bmi.bmi);

            double expectedBMI = 23.84;
            Assert.AreEqual(bmi.bmi, expectedBMI);

        }
    }
}
