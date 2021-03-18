using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppProject.App04
{
   public class NetworkApp
    {
        private NewsFeed news = new NewsFeed();

        /// <summary>
        /// Displays the menu for the NewsFeed
        /// </summary>
        public void DisplayMenu()
        {
            ConsoleHelper.OutputHeading(" Vinnys News Feed  ");

            string[] choices = new string[]
            {
                "Post Message", "Post Image", "Display All Posts"
                ,"Comment", "Quit"
            };

            bool finished = false;

            do
            {
                int amountOfPosts = news.posts.Count;

                switch (ConsoleHelper.SelectChoice(choices))
                {
                    case 1:
                        PostMessage(ConsoleHelper.InputString("Author:"), ConsoleHelper.InputString("Message:")) ;
                        break;

                    case 2:
                        PostImage(ConsoleHelper.InputString("Author:"),ConsoleHelper.InputString("File:"), ConsoleHelper.InputString("Caption:"));
                        break;

                    case 3:
                        DisplayAll();
                        break;

                    case 4:
                        Comment(ConsoleHelper.InputNumberWithin(1, amountOfPosts), ConsoleHelper.InputString("Comment:"));
                        break;

                    case 5:
                        finished = true;
                        break;
                }
            }
            while (!finished);
        }


        /// <summary>
        /// Displays all the posts from the feed
        /// </summary>
        private void DisplayAll()
        {
            news.Display();
        }

        /// <summary>
        /// post an  image to the feed
        /// </summary>
        private void PostImage(string author, string filename, string caption)
        {
            PhotoPost photoPost = new PhotoPost(author, filename, caption);

            news.AddPhotoPost(photoPost);
        }

        /// <summary>
        /// post a message to the feed
        /// </summary>
        private void PostMessage(string author, string message)
        {
            MessagePost newPost = new MessagePost(author, message);

            news.AddMessagePost(newPost);
        }

        private void Comment(int postNo, string comment)
        {
            news.CommentOnPost(postNo, comment);
        }
    }
}
