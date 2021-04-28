using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace App05.Sprites
{
    public class Pipe : Sprite
    {
        public Pipe(Texture2D texture)
            : base(texture)
        {

            LayerDepth = Game1.Random.Next(0, 2);

            CollisionEnabled = false;

            //Spawn location for the clouds
            _position.X = MathHelper.Clamp(_position.X, Game1.ScreenWidth + _texture.Width, Game1.ScreenWidth);
            _position.Y = MathHelper.Clamp(_position.Y, _texture.Height / 2, Game1.ScreenHeight - _texture.Height / 2);
            Speed = 3;

        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            _position.X -= Speed;

            //if it hits the left of the window

        }
    }
}
