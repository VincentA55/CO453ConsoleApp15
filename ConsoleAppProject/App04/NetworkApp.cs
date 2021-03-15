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
                "Post Message", "Post Image", "DisplayMenu All Posts"
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
    }
}
