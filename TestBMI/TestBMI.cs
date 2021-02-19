using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleAppProject.App02;
namespace TestBMI
{
    [TestClass]
    public class TestBMI
    {
        [TestMethod]
        public void TestingBMIMetric()
        {
            BMI bmi = new BMI();
            bmi.weight = 73;
            bmi.height = 175;
            

            bmi.CheckBMI(bmi.CheckBMIMetric(bmi.weight,bmi.height));

            double expectedBMI = 23.84;
            Assert.AreEqual(bmi.bmi, expectedBMI);

        }

        [TestMethod]
        public void TestingBMIImperial()
        {
            BMI bmi = new BMI();
            bmi.weight = 100;
            bmi.height = 6;

            bmi.CheckBMI(bmi.CheckBMIImperial(bmi.weight, bmi.height));

            double expectedBMI = 189.85;
            Assert.AreEqual(bmi.bmi, expectedBMI);

        }
    }
}
