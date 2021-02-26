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
            converter.FromUnit = "miles";
            converter.ToUnit = "feet";
            converter.FromDistance = 10;
            converter.Convert();

            double expectedDistance = 52800;
            Assert.AreEqual(converter.ToDistance, expectedDistance);
        }
    }
}
