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
            bmi.Weight = 73;
            bmi.Height = 175;
            

            bmi.CheckBMI(bmi.ReturnBMIMetric(bmi.Weight,bmi.Height));

            double expectedBMI = 23.84;
            Assert.AreEqual(bmi.Bmi, expectedBMI);

        }

        [TestMethod]
        public void TestingBMIImperial()
        {
            BMI bmi = new BMI();
            bmi.Weight = 100;
            bmi.Height = 6;

            bmi.CheckBMI(bmi.ReturnBMIImperial(bmi.Weight, bmi.Height));

            double expectedBMI = 189.85;
            Assert.AreEqual(bmi.Bmi, expectedBMI);

        }
    }
}
