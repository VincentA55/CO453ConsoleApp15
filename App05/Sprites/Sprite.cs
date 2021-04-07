﻿using Microsoft.Xna.Framework;
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
        /// the actual sprites texture
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

        public Color Color = Color.White;

        public float RotationVelocity = 4f;
        public float LinearVelocity = 4f;
        public float Speed;

        public float LayerDepth;
        public float Size = 1;
        public SpriteEffects SpriteEffect;

        public Vector2 Position;
        public Vector2 Direction;

        public Input Input;

        protected KeyboardState _currentKey;
        protected KeyboardState _previousKey;

        public List<Sprite> Children { get; set; }
        public Sprite Parent;

        public float LifeSpan = 0f;
        public bool IsRemoved = false;

        protected Texture2D _rectangleTexture;
        /// <summary>
        /// returns a "hitbox" of the sprite
        /// </summary>
        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X - (int)Origin.X, (int)Position.Y - (int)Origin.Y, _texture.Width, _texture.Height);
            }
            
        }

        public bool ShowRectangle { get; set; }


        //Hit detection stuff
        public readonly Color[] TextureData;
        public Matrix Transform
        {
            get
            {
                return Matrix.CreateTranslation(new Vector3(-Origin, 0)) *
                       Matrix.CreateRotationZ(_rotation) *
                       Matrix.CreateTranslation(new Vector3(Position, 0));
            }
        }


        public Sprite(Texture2D texture)
        {
            _texture = texture;
            Origin = new Vector2(_texture.Width / 2, _texture.Height / 2);

            ShowRectangle = false;

            Children = new List<Sprite>();

            TextureData = new Color[_texture.Width * _texture.Height];
            _texture.GetData(TextureData); //assigns the array to the data
        }

        //rectangle related
        public Sprite(GraphicsDevice graphics, Texture2D texture)
            :this(texture)
        {
            SetRectangleTexture(graphics, texture);
        }

        //rectangle related
        public void SetRectangleTexture(GraphicsDevice graphics, Texture2D texture)
        {
            var colours = new List<Color>();

            for (int y = 0; y < texture.Height; y++)
            {
                for (int x = 0; x < texture.Width; x++)
                {
                    if (x == 0 || // left side
                        y == 0 || //top side
                        x == texture.Width - 1 || // right side
                        y == texture.Height -1)// bottom side
                    {
                        colours.Add(new Color(255, 255, 255, 255));
                    }
                    else
                    {
                        colours.Add(new Color(0, 0, 0, 0));
                    }

                }
            }

            _rectangleTexture = new Texture2D(graphics, texture.Width, texture.Height);
            _rectangleTexture.SetData<Color>(colours.ToArray());

        }

        public virtual void Update(GameTime gameTime, List<Sprite> sprites)
        {
          
        }

        public void Move()
        {
            if (Input == null)
                return;

            // the reason for no elseifs is so they can go diagonal

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
            spriteBatch.Draw(_texture, Position, null , Color , _rotation, Origin, Size, SpriteEffect, LayerDepth);

            if (ShowRectangle)
            {
                if (_rectangleTexture != null)
                {
                    spriteBatch.Draw(_rectangleTexture, Position, Color);
                }
            }
        }

        public virtual void OnCollide(Sprite sprite)
        {

        }

        public bool Intersects(Sprite sprite)
        {
            // Calculate a matrix which transforms from A's local space into
            // world space and then into B's local space
            var transformAToB = this.Transform * Matrix.Invert(sprite.Transform);

            // When a point moves in A's local space, it moves in B's local space with a
            // fixed direction and distance proportional to the movement in A.
            // This algorithm steps through A one pixel at a time along A's X and Y axes
            // Calculate the analogous steps in B:
            var stepX = Vector2.TransformNormal(Vector2.UnitX, transformAToB);
            var stepY = Vector2.TransformNormal(Vector2.UnitY, transformAToB);

            // Calculate the top left corner of A in B's local space
            // This variable will be reused to keep track of the start of each row
            var yPosInB = Vector2.Transform(Vector2.Zero, transformAToB);

            for (int yA = 0; yA < this.Rectangle.Height; yA++)
            {
                // Start at the beginning of the row
                var posInB = yPosInB;

                for (int xA = 0; xA < this.Rectangle.Width; xA++)
                {
                    // Round to the nearest pixel
                    var xB = (int)Math.Round(posInB.X);
                    var yB = (int)Math.Round(posInB.Y);

                    if (0 <= xB && xB < sprite.Rectangle.Width &&
                        0 <= yB && yB < sprite.Rectangle.Height)
                    {
                        // Get the colors of the overlapping pixels
                        var colourA = this.TextureData[xA + yA * this.Rectangle.Width];
                        var colourB = sprite.TextureData[xB + yB * sprite.Rectangle.Width];

                        // If both pixel are not completely transparent
                        if (colourA.A != 0 && colourB.A != 0)
                        {
                            return true;
                        }
                    }

                    // Move to the next pixel in the row
                    posInB += stepX;
                }

                // Move to the next row
                yPosInB += stepY;
            }

            // No intersection found
            return false;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
