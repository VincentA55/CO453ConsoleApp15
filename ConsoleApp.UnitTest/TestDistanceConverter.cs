using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleAppProject.App01;

namespace ConsoleApp.UnitTest
{
    [TestClass]
    public class TestDistanceConverter
    {
        [TestMethod]
        public void TestMilesToFeet()
        {
            DistanceConverter converter = new DistanceConverter();
            converter.fromUnit = "miles";
            converter.toUnit = "feet";
            converter.fromDistance = 10;
            converter.Convert();

            double expectedDistance = 52800;
            Assert.AreEqual(converter.toDistance, expectedDistance);
        }
    }
}
