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
            _previousKey = _currentKey;
            _currentKey = Keyboard.GetState();

            if (_currentKey.IsKeyDown(Input.Left))
            {
                _rotation -= MathHelper.ToRadians(RotationVelocity);
            }

           else if (_currentKey.IsKeyDown(Input.Right))
            {
                _rotation += MathHelper.ToRadians(RotationVelocity);
            }

            Direction = new Vector2((float)Math.Cos(_rotation), (float)Math.Sin(_rotation));

            if (_currentKey.IsKeyDown(Input.Up))
            {

                Position += Direction * LinearVelocity;
            }

            else if (_currentKey.IsKeyDown(Input.Down))
            {
                Position -= Direction * LinearVelocity;
            }
            
        }
    }
}
