using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace App05.Models
{
    public class AnimatedSprite : Sprite
    {
        public Animation Animation;

        public AnimationManager AnimationManager;

        private float _timer;
        private double direction = 1; //Default travel direction

        public AnimatedSprite(Texture2D texture, int FrameCount, float frameSpeed)
           : base(texture)
        {
            Animation = new Animation(texture, FrameCount, frameSpeed);

            AnimationManager = new AnimationManager(Animation);

            _texture = Animation.Texture;
        }

        public AnimatedSprite(Dictionary<string, Animation> animations)
            : base(animations)
        {
            Animation = animations["Animation1"];

            AnimationManager = new AnimationManager(Animation);

            _texture = Animation.Texture;
        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            Gravity();

            Move();
         

            //Keep the sprite on the screen : takes in 1st the thing being clamped, 2nd the top left, 3rd bottom right
            _position.X = MathHelper.Clamp(_position.X, Animation.CurrentFrame / 2, Game1.ScreenWidth);
            _position.Y = MathHelper.Clamp(_position.Y, 0 + Animation.CurrentFrame / 2, Game1.ScreenHeight - Animation.Texture.Height);

            AnimationManager.Update(gameTime);
        }

        /// <summary>
        /// Plays the animation for an AnimatedSprite
        /// </summary>
        protected virtual void SetAnimations()
        {
            AnimationManager.Play(Animation);
        }

        public void RandomMove() //DOENS WORK AT THE MOMENT!!!!
        {
            int MoveTimer = (int)_timer;

            if ((MoveTimer % 1) == 0)
            {
                direction = Game1.Random.Next(1, 4);//Set the direction

                if (direction == 1)
                {
                    _position.X -= LinearVelocity;
                    Position += Direction * LinearVelocity;
                }
                else if (direction == 2)
                {
                    _position.X += LinearVelocity;
                    Position -= Direction * LinearVelocity;
                }
                else if (direction == 2)
                {
                    _position.Y -= LinearVelocity;
                    Position += Direction * LinearVelocity;
                }
                else if (direction == 3)
                {
                    _position.Y += LinearVelocity;
                    Position += Direction * LinearVelocity;
                }
            }
            else if (direction > 4)
            {
                direction = 1;
            }
        }
    }
}