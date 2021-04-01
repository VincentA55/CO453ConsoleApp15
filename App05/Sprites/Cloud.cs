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
            Position = new Vector2(Game1.Random.Next(0, Game1.ScreenWidth - _texture.Width),-_texture.Height);
            Speed = Game1.Random.Next(1, 5);
        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            Position.X += Speed;

            //if it hits the left of the window
            if(Rectangle.Left >= Game1.ScreenWidth)
            {
                IsRemoved = true;
            }
        }
    }
}
