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
            

            RandomMove(gameTime); //POTENTIALLY HAVE UNIQUE MOVE METHOD!!

           

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
            float elapsedTime = 0; //Time elapsed since the last check
            int direction = 1; //Default travel direction

            elapsedTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (elapsedTime > 1)
            { //Get a new random direction every 1 second
                elapsedTime -= 1; //Subtract the 1 second we've already checked
                direction = Game1.Random.Next(0, 3); //Set the direction to a random value (0 or 1)
            }

            Direction = new Vector2((float)Math.Cos(direction), (float)Math.Sin(direction));

            if (direction == 0)
            {
                
                Position += Direction * LinearVelocity;
            }
            else if (direction > 1)
            {
                
                Position -= Direction * LinearVelocity;
            }
        }
        
    }

}