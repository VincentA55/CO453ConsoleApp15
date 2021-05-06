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
           
            LinearVelocity = 2;


            //Keep the sprite on the screen : takes in 1st the thing being clamped, 2nd the top left, 3rd bottom right
            _position.X = MathHelper.Clamp(_position.X, Game1.ScreenWidth,Game1.ScreenWidth + Animation.FrameWidth);
            Position = new Vector2(Game1.ScreenWidth + 20,Game1.Random.Next(Game1.ScreenHeight));
            Speed = 2;
        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            Position -= new Vector2(2, 0);
            AnimationManager.Update(gameTime);
        }

        public override void OnCollide(Sprite sprite)
        {
        }
    }
}