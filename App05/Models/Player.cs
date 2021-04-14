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
            : base( graphicsDevice ,texture)
        {
            LayerDepth = 0.5f;

        }

        public Player(GraphicsDevice graphicsDevice, Texture2D texture,Dictionary<string, Animation> animations)
            : base(graphicsDevice, texture)
        {
            LayerDepth = 0.5f;

        }


        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            if (Input == null)
            {
                throw new Exception("Please assign a value to Input");
            }

         
            Move();

            Shoot();
            
            //Keep the sprite on the screen : takes in 1st the thing being clamped, 2nd the top left, 3rd bottom right
            Position.X = MathHelper.Clamp(Position.X, 0 + _texture.Width / 2, Game1.ScreenWidth - _texture.Width / 2);
            Position.Y = MathHelper.Clamp(Position.Y, 0 + _texture.Height / 2, Game1.ScreenHeight - _texture.Height / 2);
        }

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