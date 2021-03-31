using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace App05
{
   public class Sprite
    {
        /// <summary>
        /// the actual 
        /// </summary>
        private Texture2D _texture;

        /// <summary>
        /// the angle of roation
        /// </summary>
        private float _rotation;
        /// <summary>
        /// the point from which it rotates
        /// </summary>
        public Vector2 Origin;


        public float RotationVelocity = 3f;
        public float LinearVelocity = 2f;

        public Vector2 Postition;

        public Input Input;

        


        public Sprite(Texture2D texture)
        {
            _texture = texture;
        }

        public void Update()
        {
            Move();
        }

        private void Move()
        {
            if (Input == null)
                return;

            
            if (Keyboard.GetState().IsKeyDown(Input.Left))
            {
                _rotation -= MathHelper.ToRadians(RotationVelocity);
                Postition.X -= LinearVelocity;
            }

            if (Keyboard.GetState().IsKeyDown(Input.Right))
            {
                _rotation += MathHelper.ToRadians(RotationVelocity);
                Postition.X += LinearVelocity;
            }
           
          var direction = new Vector2((float)Math.Cos(_rotation), (float)Math.Sin(_rotation));

            if (Keyboard.GetState().IsKeyDown(Input.Up))
            {

                Postition += direction * LinearVelocity;
            }

            if (Keyboard.GetState().IsKeyDown(Input.Down))
            {
                Postition -=  direction * LinearVelocity;
            }

           

       
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Postition, null , Color.White, _rotation, Origin, 1, SpriteEffects.None, 0f);
        }

    
    }
}
