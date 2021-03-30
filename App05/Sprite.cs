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
        private Texture2D _texture;
        public Vector2 Postition;

        public Input Input;

        public float Speed = 2f;


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

            if (Keyboard.GetState().IsKeyDown(Input.Up))
            {
                Postition.Y -= Speed;
            }

            if (Keyboard.GetState().IsKeyDown(Input.Down))
            {
                Postition.Y += Speed;
            }

            if (Keyboard.GetState().IsKeyDown(Input.Left))
            {
                Postition.X -= Speed;
            }

            if (Keyboard.GetState().IsKeyDown(Input.Right))
            {
                Postition.X += Speed;
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Postition, Color.White);
        }

    }
}
