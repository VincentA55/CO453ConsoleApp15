using App05.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;

namespace App05.Models
{
    public class Player : Sprite
    {
        public bool HadDied = false;

        public Bullet Bullet;

        public bool HasBeenHit = false;

        public int Score { get; set; }

        public Player(GraphicsDevice graphicsDevice, Texture2D texture)
            : base(graphicsDevice, texture)
        {
            LayerDepth = 0.5f;

            CollisionEnabled = false;
           
        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            if (Input == null)
            {
                throw new Exception("Please assign a value to Input");
            }

            Move();

            Gravity();

            Shoot();

            //Keep the sprite on the screen : takes in 1st the thing being clamped, 2nd the top left, 3rd bottom right
            // the 100 locks them a little along the screen
            _position.X = MathHelper.Clamp(_position.X, 100 + _texture.Width / 2, Game1.ScreenWidth - _texture.Width / 2);
            _position.Y = MathHelper.Clamp(_position.Y, 0 + _texture.Height / 2, Game1.ScreenHeight - _texture.Height / 2);

            PlayerHitDetection(gameTime, sprites);
            ToggleShowRectangle();
        }

        /// <summary>
        /// Shoots an egg by Cloning the Bullet and adding it to the children array
        /// </summary>
        public void Shoot()
        {
            _previousKey = _currentKey;
            _currentKey = Keyboard.GetState();

            //Shooting
            if (_currentKey.IsKeyDown(Input.Shoot) && _previousKey.IsKeyUp(Input.Shoot))
            {
                AddBullet();
            }
        }

        /// <summary>
        /// Creates a Bullet.Clone and adds it to an array
        /// </summary>
        private void AddBullet()
        {
            var bullet = Bullet.Clone() as Bullet;
            bullet.Direction = this.Direction;
            bullet.LinearVelocity = 6;
            bullet._rotation = this._rotation;
            bullet.LifeSpan = 2f;
            bullet.Parent = this;
            bullet.Position = new Vector2(this.Position.X + 190, this.Position.Y);
            bullet.Input = null;
            bullet.LayerDepth = this.LayerDepth - 0.1f;

            Children.Add(bullet);
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

            if (Keyboard.GetState().IsKeyDown(Input.Up) && this.Position.Y < _texture.Height * 5)
            {
                _rotation -= MathHelper.ToRadians(RotationVelocity);

                Weight = -3;
                Velocity.Y -= 15; // jump speed
            }

            if (_rotation != 0 && Keyboard.GetState().IsKeyUp(Input.Up)) //TRYING TO HAVE BIRD AIM UP WHEN JUMPING
            {
                _rotation -= MathHelper.ToRadians(_rotation * 2);
            }

            Position = Direction + Velocity;
        }

        public void PlayerHitDetection(GameTime gameTime, List<Sprite> sprites)
        {
            foreach (var spriteB in sprites)
            {
                if (spriteB.CollisionEnabled && Intersects((Sprite)spriteB))
                {
                    spriteB.OnCollide(this, gameTime);
                }
            }
        }

        public override void OnCollide(Sprite sprite, GameTime gameTime)
        {
        }

        /// <summary>
        /// incriments the score by 1
        /// </summary>
        public override void ScoreUp()
        {
            Score++;
        }

        /// <summary>
        /// Decreases the score by 1
        /// </summary>
        public void ScoreDown()
        {
            Score--;
        }

        /// <summary>
        /// alternates the colour of the player red to white
        /// </summary>
        public void FlashRed()
        {
            if (!HasBeenHit)
            {
                this.Color = Color.Red;
                HasBeenHit = true;
            }
            else if (HasBeenHit)
            {
                this.Color = Color.White;
                HasBeenHit = false;
            }
        }

        /// <summary>
        /// Is called when the player gets hit 
        /// </summary>
        public override void PlayerGetHit(GameTime gameTime)
        {
            ScoreDown();
            FlashRed();
            _rotation = MathHelper.ToRadians(250);

            _position.X -= 50;
        }

        /// <summary>
        /// increased the score when collecting a coin
        /// </summary>
        public override void PlayerCollectCoin()
        {
            Score += 100;
        }
    }
}