using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace App05.Models
{
    public class AnimatedSprite : Sprite
    {
        private Animation Animation;

        public AnimationManager AnimationManager;

        private float _timer;
        int direction = 1; //Default travel direction


        public AnimatedSprite(Texture2D texture, int FrameCount)
           : base(texture)
        {
            Animation = new Animation(texture, FrameCount);

            AnimationManager = new AnimationManager(Animation);
        }

        public AnimatedSprite(Dictionary<string, Animation> animations)
            : base(animations)
        {
            Animation = animations["FlapWings"];

            AnimationManager = new AnimationManager(Animation);
        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            RandomMove(gameTime); 

           

            //Keep the sprite on the screen : takes in 1st the thing being clamped, 2nd the top left, 3rd bottom right
            _position.X = MathHelper.Clamp(_position.X, Animation.CurrentFrame / 2, Game1.ScreenWidth - Animation.Texture.Width / 4);
            _position.Y = MathHelper.Clamp(_position.Y, Animation.CurrentFrame / 2, Game1.ScreenHeight - Animation.Texture.Height);


            AnimationManager.Update(gameTime);
        }

        protected virtual void SetAnimations()
        {
            AnimationManager.Play(Animation);
        }

        public void RandomMove(GameTime gameTime) //DOENS WORK AT THE MOMENT!!!!
        {

            int MoveTimer = (int)_timer;
            
            if ((MoveTimer % 1) == 0) 
            {    
                direction = Game1.Random.Next(0,4); //Set the direction to a random value 

                
            }
          

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
            else if (direction == 3)
            {
                _position.Y -= LinearVelocity;
                Position += Direction * LinearVelocity;
                
            }
           else if (direction == 4)
            {
                _position.Y += LinearVelocity;
                Position += Direction * LinearVelocity;
                
            }

        }
        
        
    }

}