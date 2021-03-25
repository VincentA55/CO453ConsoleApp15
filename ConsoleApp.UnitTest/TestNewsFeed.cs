﻿using ConsoleAppProject.App04;
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
        public void SearchAuthorVinny()
        {
            //Arrange
            string expectedAuthor = ("Vinny");


            //Act
           List<Post> testList = newsFeedTester.SearchByAuthor("Vinny");


            //Assert
            Assert.AreEqual(testList[0].Username, expectedAuthor);

        }

        [TestMethod]
        public void SearchAuthorErrorAuthorNotFound()
        {
            //Arrange
            newsFeedTester.SearchByAuthor("asdfghj");

            //Act

            //Assert
            Assert.IsFalse(newsFeedTester.ErrorDetected);
        }


        [TestMethod]
        public void LikePost()
        {
            //Arrange
            newsFeedTester.LikePost(1);

            //Assert
            Assert.IsFalse(newsFeedTester.ErrorDetected);
        }

        [TestMethod]
        public void LikePostErrorNumberTooHigh()
        {
            //Arrange
            newsFeedTester.LikePost(8);

            //Assert
            Assert.IsTrue(newsFeedTester.ErrorDetected);
        }

        [TestMethod]
        public void LikePostErrorNegativeNumber()
        {
            //Arrange
            newsFeedTester.LikePost(-8);

            //Assert
            Assert.IsTrue(newsFeedTester.ErrorDetected);
        }

    } 
}

