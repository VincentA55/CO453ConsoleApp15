using App05.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;

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


        public float Weight = 5;
        public Vector2 Velocity;

        public Color Color = Color.White;
        public String Name { get; set; }

        public float RotationVelocity = 2f;
        public float LinearVelocity = 4f;
        public float Speed;

        public float LayerDepth;
        public float Size = 1;
        public SpriteEffects SpriteEffect;

        public Vector2 Direction;

        //Circular movement things
        public float radius = 5;
        public float angle = 50;

        public float originX = 100;
        public float originY = 100;

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
        public bool CollisionEnabled = false;

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

        //Animation stuff
        protected AnimationManager _animationManager;

        protected Dictionary<string, Animation> _animations;
        protected Vector2 _position;

        public Vector2 Position 
        {
            get { return _position; }
            set
            {
                _position = value; // this is just incase we have a manager but no texture
                if (_animationManager != null)
                {
                    _animationManager.Position = _position;
                }
            }
        }

        // extra constuctor
        public Sprite(Dictionary<string, Animation> animations)
        {
            _animations = animations;
            _animationManager = new AnimationManager(_animations.First().Value); //this bit returns an animation

            Children = new List<Sprite>();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="texture"></param>
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
            : this(texture)
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
                        y == texture.Height - 1)// bottom side
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

        public void Draw(SpriteBatch spriteBatch)
        {
            if (_animationManager != null)
            {
                _animationManager.Draw(spriteBatch);
            }
            else if (_texture != null)
            {
                spriteBatch.Draw(_texture, Position, null, Color, _rotation, Origin, Size, SpriteEffect, LayerDepth);
            }

            if (ShowRectangle)
            {
                if (_rectangleTexture != null)
                {
                    spriteBatch.Draw(_rectangleTexture, Position, Color);
                }
            }
        }

        /// <summary>
        /// This movement is similar to tank controls
        /// </summary>
        public void Move()
        {
            if (Input == null)
                return;

            if (Keyboard.GetState().IsKeyDown(Input.Left))
            {
                _position.X -= LinearVelocity;
                Position += Direction * LinearVelocity;
            }

            if (Keyboard.GetState().IsKeyDown(Input.Right))
            {
                _position.X += LinearVelocity;
                Position -= Direction * LinearVelocity;
            }


           // Direction = new Vector2((float)Math.Cos(_rotation), (float)Math.Sin(_rotation));

            if (Keyboard.GetState().IsKeyDown(Input.Up))
            {
                _rotation -= MathHelper.ToRadians(RotationVelocity);

                Weight = -3;
                Velocity.Y -= 15; // jump speed

            }

            if (_rotation != 0 && Keyboard.GetState().IsKeyUp(Input.Up)) //TRYING TO HAVE BIRD AIM UP WHEN JUMPING
            {
                _rotation -= MathHelper.ToRadians(_rotation * 2);
            }

            if (Keyboard.GetState().IsKeyDown(Input.Down))
            {
                CircleMove();
            }



        }

        /// <summary>
        /// testing out cirular movement
        /// </summary>
        public void CircleMove()
        {
            _rotation += MathHelper.ToRadians(1000);

            Direction = new Vector2((float)Math.Cos(_rotation), (float)Math.Sin(_rotation));


            Position -= Direction * LinearVelocity;

            Direction = new Vector2(0, 0);
        }

        /// <summary>
        /// adds gravity for a sprite
        /// </summary>
        public void Gravity()
        {
            if (Position.Y < Game1.ScreenHeight)
            {
                Velocity.Y += Weight;
                Weight += (float)0.5;
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

        public virtual void ScoreUp()
        {
        }

    }
}