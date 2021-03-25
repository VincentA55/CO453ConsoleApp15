using ConsoleAppProject.App04;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ConsoleApp.UnitTest
{
    [TestClass]
    public class TestNewsFeed
    {
        public readonly NetworkApp networkAppTester = new NetworkApp();

        public readonly NewsFeed newsFeedTester = new NewsFeed();


        [TestMethod]
        public void FirstPostAuthor()
        {
            //Arrange
            string expectedAuthor = ("Vinny");


            //Act

           List<Post> testList = newsFeedTester.SearchByAuthor("Vinny");


            //Assert

            Assert.AreEqual(testList[0].Username, expectedAuthor);

        }
    } 
}

