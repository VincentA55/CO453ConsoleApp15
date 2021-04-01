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
            Position = new Vector2(Game1.Random)
        }
    }
}
