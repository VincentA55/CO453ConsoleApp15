using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
            SetAnimations();

            Move();

            AnimationManager.Update(gameTime);
        }

        protected virtual void SetAnimations()
        {
            AnimationManager.Play(Animation);
        }
    }

}