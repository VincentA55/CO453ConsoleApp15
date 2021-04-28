using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace App05.Sprites
{
    public class Pipe : Sprite
    {

        int Length = 1;

        private RenderTarget2D TempTexture;

        public Pipe(Texture2D texture)
            : base(texture)
        {
            Size = Game1.Random.Next(1, 3);
            LayerDepth = Game1.Random.Next(0, 2);

            CollisionEnabled = false;

            //Spawn location for the pipes
            _position.X = MathHelper.Clamp(_position.X, Game1.ScreenWidth + _texture.Width, Game1.ScreenWidth);
            _position.Y = MathHelper.Clamp(_position.Y,  Game1.ScreenHeight - _texture.Height / 2, _texture.Height / 2);
            Speed = 5;

        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            _position.X -= Speed;

            //if it hits the left of the window

        }

        public void SetLenght()
        {
    
        }
    }
}
