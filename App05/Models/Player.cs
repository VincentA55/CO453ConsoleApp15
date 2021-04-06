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

        public int Score;

        public List<Player> players;

        public Player(Texture2D texture)
            : base(texture)
        {
            LayerDepth = 0.5f;

            players = new List<Player>();
        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            if (Input == null)
            {
                throw new Exception("Please assign a value to Input");
            }

            Move();

            Shoot(sprites);

            foreach (var sprite in sprites) // hit detection
            {
                if (sprite is Player)
                {
                    players.Add((Player)sprite);
                    continue;
                }
                //for bullets
                if (sprite.Rectangle.Intersects(this.Rectangle) && sprite.Parent != this && sprite is Bullet)
                {
                    Score++;
                    this.Color = Color.Red;
                    this.HadDied = true;
                }
            }

            foreach (Player player in players)
            {
                //for other players
                if (this.IsTouchingLeft(player) || this.IsTouchingRight(player))
                {
                    Color = Color.Red;
                    this.Direction += this.Direction * this.LinearVelocity;
                }
                if ( this.IsTouchingTop(player) || this.IsTouchingBottom(player))
                {
                    Color = Color.Blue;
                    
                }
            }

            //Keep the sprite on the screen : takes in 1st the thing being clamped, 2nd the top left, 3rd bottom right
            Position.X = MathHelper.Clamp(Position.X, 0 + _texture.Width / 2, Game1.ScreenWidth - _texture.Width / 2);
            Position.Y = MathHelper.Clamp(Position.Y, 0 + _texture.Height / 2, Game1.ScreenHeight - _texture.Height / 2);
        }

        public void Shoot(List<Sprite> sprites)
        {
            _previousKey = _currentKey;
            _currentKey = Keyboard.GetState();

            //Shooting
            if (_currentKey.IsKeyDown(Input.Shoot) && _previousKey.IsKeyUp(Input.Shoot))
            {
                AddBullet(sprites);
            }
        }

        private void AddBullet(List<Sprite> sprites)
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

            sprites.Add(bullet);
        }
    }
}