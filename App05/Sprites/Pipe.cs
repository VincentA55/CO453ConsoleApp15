using App05.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace App05.Sprites
{
    public class Pipe : Sprite
    {
        public bool OnGround;

        public int SpawnHeight;

        public Pipe(Texture2D texture)
            : base(texture)
        {

            Size = Game1.Random.Next(1, 3);
            LayerDepth = 0.5f;

            CollisionEnabled = true;

            //Spawn location for the pipes
            _position.X = MathHelper.Clamp(_position.X, Game1.ScreenWidth + _texture.Width, Game1.ScreenWidth);

            GroundOrSky();

            _position.Y = MathHelper.Clamp(_position.Y,  Game1.ScreenHeight * SpawnHeight, _texture.Height / 2);
            Speed = 5;

        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            _position.X -= Speed;

            CheckIfOffScreen();
            ToggleShowRectangle();

        }

        /// <summary>
        /// determines if the pipe spawns on the "ground"
        /// </summary>
        /// <returns></returns>
        public void GroundOrSky()
        {
            int random = Game1.Random.Next(0, 10);

            if (random >= 5)
            {
                SpawnHeight = 0;
            }
            else if (random <= 4)
            {
                SpawnHeight = 1;
            }
        }

        /// <summary>
        /// Flips the spawn location 
        /// </summary>
        public void FlipSpawnHight()
        {
            if (SpawnHeight == 1)
            {
                _position.Y = 0;
            }
            if (SpawnHeight == 0)
            {
                _position.Y = Game1.ScreenHeight;
            }
        }

        /// <summary>
        /// increase the pipes speed
        /// </summary>
        /// <param name="speed"></param>
        public void IncreasePipeSpeed(int speed)
        {
            Speed += speed;

            _position.X += 40;
        }

        /// <summary>
        /// does something when a collision is detected
        /// </summary>
        /// <param name="sprite"></param>
        public override void OnCollide(Sprite sprite, GameTime gameTime)
        {
            if (sprite is Player)
            {
                sprite.PlayerGetHit(gameTime);
            }
        }

        /// <summary>
        /// checks if the pipe goes off the left of the screen
        /// </summary>
        public void CheckIfOffScreen()
        {
            if (_position.X < -10)
            {
                IsRemoved = true;
            }
        }
    }
}
