using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace App05.Sprites
{
   public class Cloud : Sprite
    {
        public Cloud(Texture2D texture)
            :base(texture)
        {
           
            //Spawn location for the clouds
            Position.X = MathHelper.Clamp(Position.X,Game1.ScreenWidth, Game1.ScreenWidth);
            Position.Y = Game1.Random.Next(Game1.ScreenHeight);
            Speed = Game1.Random.Next(1, 5);
        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            Position.X -= Speed;

            //if it hits the left of the window
            if(Rectangle.Right <= 0)
            {
                IsRemoved = true;
            }
        }
    }
}
