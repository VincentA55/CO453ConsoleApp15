using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace App05.Models
{
    public class AnimationManager
    {
        private Animation _animation;

        private float _timer;

        public Vector2 Position { get; set; }

        public AnimationManager(Animation animation)
        {
            _animation = animation;
        }

        public void Draw (SpriteBatch spriteBatch)
        {
            // the rectangle is the "destination", a box within the texture, that we see
            spriteBatch.Draw(_animation.Texture,
                              Position,
                              new Rectangle(_animation.CurrentFrame * _animation.FrameWidth,
                              0,
                              _animation.FrameWidth,
                              _animation.FrameHeight),
                              Color.White);
        }

        public void Play(Animation animation)
        {
            if (_animation != animation)
            {
                return;
            }

            _animation = animation;


            _animation.CurrentFrame = 0;
        }

        public void Stop()
        {
            _timer = 0f;

            _animation.CurrentFrame = 0;
        }


        public void Update(GameTime gameTime)
        {
            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (_timer > _animation.FrameSpeed)
            {
                _timer = 0f;

                _animation.CurrentFrame++;

                //this is a loop
                if(_animation.CurrentFrame >= _animation.FrameCount)
                {
                    _animation.CurrentFrame = 0;
                }
            }

        }
    }
}
