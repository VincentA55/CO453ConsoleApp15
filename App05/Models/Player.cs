using App05.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace App05.Models
{
    public class Player : Sprite
    {
        public bool HadDied = false;

        public Bird Bird;

        public Bullet Bullet;

        public Player(Texture2D texture) 
            : base(texture)
        {
        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            if(Input == null)
            {
                throw new Exception("Please assign a value to Input");
            }

            Move();

            foreach (var sprite in sprites)
            {
                if (sprite == this)
                {
                    continue;
                }

                if (sprite.Rectangle.Intersects(this.Rectangle))
                {
                 this.HadDied = true;
                }
            }

            Position += LinearVelocity * Direction;

            //Keep the sprite on the screen
            Position.X = MathHelper.Clamp(Position.X, 0 + _texture.Width / 2, Game1.ScreenWidth - _texture.Width / 2);
            Position.Y = MathHelper.Clamp(Position.Y, 0 + _texture.Height / 2, Game1.ScreenHeight - _texture.Height / 2);



        }

    }
}
