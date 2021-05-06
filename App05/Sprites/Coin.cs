using App05.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace App05.Sprites
{
    public class Coin : AnimatedSprite
    {
        public Coin(Dictionary<string, Animation> animations)
              : base(animations)
        {


            //Keep the sprite on the screen : takes in 1st the thing being clamped, 2nd the top left, 3rd bottom right
            _position.X = MathHelper.Clamp(_position.X, Game1.ScreenWidth,Game1.ScreenWidth + Animation.FrameWidth);
            _position.Y = Game1.Random.Next(Game1.ScreenHeight);
            Speed = 2;
        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            _position.X -= Speed;

            AnimationManager.Update(gameTime);
        }

        public override void OnCollide(Sprite sprite)
        {
        }
    }
}