﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace App05.Sprites
{
    public class Bullet : Sprite
    {
        private float _timer;

        public bool IsBullet = true;

        public Bullet(Texture2D texture)
            : base(texture)
        {
        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (_timer > LifeSpan)
            {
                IsRemoved = true;
            }

            Position += Direction * LinearVelocity;
        }

        public override void OnCollide(Sprite sprite)
        {
            if (sprite is Bullet)
            {
                return;
            }

            if (HitPlayer(sprite))
            {
                sprite.Color = Color.Red;
            }

            IsRemoved = true;
        }

        /// <summary>
        /// returns a bool if it hits a player
        /// </summary>
        /// <param name="sprite"></param>
        /// <returns></returns>
        public bool HitPlayer(Sprite sprite)
        {
            if (Intersects(sprite) && sprite is Models.Player && sprite != this.Parent)
            {
                return true;
            }

            return false;
        }
    }
}