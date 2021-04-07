using Microsoft.Xna.Framework;
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
            if (sprite == this.Parent)
            {
                return;
            }
            if (sprite is Bullet)
            {
                return;
            }

            IsRemoved = true;
        }
    }
}