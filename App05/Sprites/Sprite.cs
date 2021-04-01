using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace App05
{
   public class Sprite : ICloneable
    {
        /// <summary>
        /// the actual 
        /// </summary>
        protected Texture2D _texture;

        /// <summary>
        /// the angle of roation
        /// </summary>
        public float _rotation;
        /// <summary>
        /// the point from which it rotates
        /// </summary>
        public Vector2 Origin;


        public float RotationVelocity = 4f;
        public float LinearVelocity = 4f;
        public float Speed;
        

        public SpriteEffects SpriteEffect;

        public Vector2 Position;
        public Vector2 Direction;

        public Input Input;

        protected KeyboardState _currentKey;
        protected KeyboardState _previousKey;


        public Sprite Parent;

        public float LifeSpan = 0f;
        public bool IsRemoved = false;


        /// <summary>
        /// returns a "hitbox" of the sprite
        /// </summary>
        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, _texture.Width, _texture.Height);
            }
        }

        public Sprite(Texture2D texture)
        {
            _texture = texture;
            Origin = new Vector2(_texture.Width / 2, _texture.Height / 2);
        }

        public virtual void Update(GameTime gameTime, List<Sprite> sprites)
        {

        }

        public void Update()
        {
            Move();
        }

        public void Move()
        {
            if (Input == null)
                return;

            
            if (Keyboard.GetState().IsKeyDown(Input.Left))
            {
                _rotation -= MathHelper.ToRadians(RotationVelocity);
                
            }

            if (Keyboard.GetState().IsKeyDown(Input.Right))
            {
                _rotation += MathHelper.ToRadians(RotationVelocity);

            }
           
          Direction = new Vector2((float)Math.Cos(_rotation), (float)Math.Sin(_rotation));

            if (Keyboard.GetState().IsKeyDown(Input.Up))
            {

                Position += Direction * LinearVelocity;
            }

            if (Keyboard.GetState().IsKeyDown(Input.Down))
            {
                Position -=  Direction * LinearVelocity;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Position, null , Color.White, _rotation, Origin, 1, SpriteEffect, 0f);
        }


        public object Clone()
        {
            return this.MemberwiseClone();
        }

     
    }
}
