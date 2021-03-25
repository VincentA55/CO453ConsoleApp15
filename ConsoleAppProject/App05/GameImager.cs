using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppProject.App05
{
    class GameImager
    {
        public GameImages Imager = new GameImages();


        public void Menu()
        {
            ConsoleHelper.OutputHeading(" Vinnys Game images ");

            string[] choices = new string[]
            {
                "Draw Scissors", "Draw Rock", "Draw Paper", "Draw Smile", "Thumb up", "Thumb down", "Quit"
            };

            bool finished = false;

            do
            {
                switch (ConsoleHelper.SelectChoice(choices))
                    {
                    case 1: Imager.DrawScissors(ConsoleHelper.InputInt(), ConsoleHelper.InputInt()) ;
                           break;

                    case 2:
                        Imager.DrawRock(ConsoleHelper.InputInt(), ConsoleHelper.InputInt());
                        break;

                    case 7:
                        finished = true;
                        break;

                     }

            } while (!finished);
        

        }
    }
}


