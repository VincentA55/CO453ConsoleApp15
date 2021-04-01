using App05.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace App05
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private List<Sprite> _sprites;

        public static int ScreenHeight;
        public static int ScreenWidth;

        public static Random Random;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            var YelloBird = Content.Load<Texture2D>("YelloBird");
            var RedBird = Content.Load<Texture2D>("RedBird");

            _sprites = new List<Sprite>()
            {
                new Bird(YelloBird)
                {
                    Origin = new Vector2(YelloBird.Width / 2, YelloBird.Height / 2 ),
                    LinearVelocity = 4f,
                    Position = new Vector2(100,100), 
                    Bullet = new Bullet(Content.Load<Texture2D>("BirdBullet")),
                    Input = new Input()
                    {
                        Up = Keys.W, 
                        Down = Keys.S, 
                        Left = Keys.A, 
                        Right = Keys.D
                    } 
                },

                new Bird(RedBird)
                {
                    Origin = new Vector2(RedBird.Width - 45, RedBird.Height / 2 ),
                    LinearVelocity = 5f,
                    Position = new Vector2(50,100),
                    Bullet = new Bullet(Content.Load<Texture2D>("BirdBullet")),
                    Input = new Input()
                    {
                        Up = Keys.Up,
                        Down = Keys.Down,
                        Left = Keys.Left,
                        Right = Keys.Right
                    }
                }
            };
        }

        protected override void Update(GameTime gameTime)
        {
            foreach (var sprite in _sprites.ToArray())
                sprite.Update(gameTime, _sprites);

            PostUpdate();

            base.Update(gameTime);
        }

        private void PostUpdate()
        {
            //where we reomve stuff from the collection
            for (int i = 0; i < _sprites.Count; i++)
            {
                if (_sprites[i].IsRemoved)
                {
                    _sprites.RemoveAt(i);
                    i--;
                }
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();

            foreach (var sprite in _sprites)
             sprite.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
