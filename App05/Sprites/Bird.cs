using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace App05.Sprites
{
    public class Bird : Sprite
    {
        public Bullet Bullet;

            public Bird(Texture2D texture)
             : base(texture)
        {

        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            
        }
    }
}
