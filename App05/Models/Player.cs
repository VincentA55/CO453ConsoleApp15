using App05.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace App05.Models
{
    public class Player : Sprite
    {
        public bool HadDied = false;

        public Bird Bird;

        public Bullet Bullet;

        public int Score { get; set; }

       
        public Player(GraphicsDevice graphicsDevice, Texture2D texture)
            : base(graphicsDevice, texture)
        {
            LayerDepth = 0.5f;

        }

        public Player(Texture2D texture, Dictionary<string, Animation> animations)
            : base(animations)
        {
            LayerDepth = 0.5f;

            _texture = texture;

        }


        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            if (Input == null)
            {
                throw new Exception("Please assign a value to Input");
            }

            if(_animationManager != null)
            {
                SetAnimations();
            }
         
            Move();

            Shoot();
            
            //Keep the sprite on the screen : takes in 1st the thing being clamped, 2nd the top left, 3rd bottom right
            _position.X = MathHelper.Clamp(_position.X, 0 + _texture.Width / 2, Game1.ScreenWidth - _texture.Width / 2);
            _position.Y = MathHelper.Clamp(_position.Y, 0 + _texture.Height / 2, Game1.ScreenHeight - _texture.Height / 2);
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
            bullet.Position = Position;
            bullet.LinearVelocity = 6;
            bullet._rotation = this._rotation;
            bullet.LifeSpan = 2f;
            bullet.Parent = this;
            bullet.Input = null;
            bullet.LayerDepth = this.LayerDepth - 0.1f;

            Children.Add(bullet);    
        }

        public override void OnCollide(Sprite sprite)
        {
           
        }

        /// <summary>
        /// incriments the score by +1
        /// </summary>
        public override void ScoreUp()
        {
            Score++;
        }
    }
}