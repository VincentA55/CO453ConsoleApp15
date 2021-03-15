using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppProject.App04
{
   public class NetworkApp
    {
        public void DisplayMenu()
        {
            ConsoleHelper.OutputHeading("   Vinnys News Feed  ");

            string[] choices = new string[]
            {
                "Post Message", "Post Image", "Display All Posts"
                ,"Quit"
            };

            bool finished = false;

            do
            {
                switch (ConsoleHelper.SelectChoice(choices))
                {
                    case 1:
                        PostMessage();
                        break;

                    case 2:
                        PostImage();
                        break;

                    case 3:
                        DisplayAll();
                        break;

                    case 4:
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
            throw new NotImplementedException();
        }

        /// <summary>
        /// post an  image to the feed
        /// </summary>
        private void PostImage()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// post a message to the feed
        /// </summary>
        private void PostMessage()
        {
            throw new NotImplementedException();
        }
    }
}
