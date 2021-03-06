﻿using Microsoft.Xna.Framework;
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
            
            Size = Game1.Random.Next(1, 3);
            LayerDepth = Game1.Random.Next(0, 2);

            CollisionEnabled = false;

            //Spawn location for the clouds
            _position.X = MathHelper.Clamp(_position.X,Game1.ScreenWidth +_texture.Width, Game1.ScreenWidth);
            _position.Y = Game1.Random.Next(Game1.ScreenHeight);
            Speed = Game1.Random.Next(1, 5);

            if (LayerDepth < 0.5)
            {
                Color = Color.LightBlue;
            };

        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            _position.X -= Speed;
            ToggleShowRectangle();

        }

        public override void OnCollide(Sprite sprite, GameTime gameTime)
        {
            
        }

        public void IncreaseSpeed(int speed)
        {
            Speed += speed;
        }
      
    }
}
