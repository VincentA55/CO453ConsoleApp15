using App05.Models;
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

        public List<Player> _players;

        private SpriteFont _font;

        public static int ScreenHeight;
        public static int ScreenWidth;

        public static Random Random;

        private float _timer;

        private bool _hasStarted = false;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            Random = new Random();

            ScreenWidth = _graphics.PreferredBackBufferWidth;
            ScreenHeight = _graphics.PreferredBackBufferHeight;
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
            var Cloud = Content.Load<Texture2D>("Cloud");

            Restart();
            
        }

        /// <summary>
        /// Loads the players and their sprites
        /// </summary>
        public void Restart()
        {

            var YelloBird = Content.Load<Texture2D>("YelloBird");
            var RedBird = Content.Load<Texture2D>("RedBird");

            _sprites = new List<Sprite>()
            {
                new Player(_graphics.GraphicsDevice,YelloBird)
                {
                    ShowRectangle = true,
                    Origin = new Vector2(YelloBird.Width / 2, YelloBird.Height / 2),
                    LinearVelocity = 4f,
                    Color = Color.White,
                    Position = new Vector2(ScreenWidth - YelloBird.Width, 100),
                    Bullet = new Bullet(Content.Load<Texture2D>("BirdBullet")),
                    Input = new Input()
                    {
                        Up = Keys.W,
                        Down = Keys.S,
                        Left = Keys.A,
                        Right = Keys.D,
                        Shoot = Keys.Space
                    }

                },

                new Player(_graphics.GraphicsDevice, RedBird)
                {
                    Origin = new Vector2(RedBird.Width / 2, RedBird.Height / 2),
                    LinearVelocity = 5f,
                    Color = Color.White,
                    Position = new Vector2(RedBird.Width, 100),
                    Bullet = new Bullet(Content.Load<Texture2D>("BirdBullet")),
                    Input = new Input()
                    {
                        Up = Keys.Up,
                        Down = Keys.Down,
                        Left = Keys.Left,
                        Right = Keys.Right,
                        Shoot = Keys.NumPad0
                    }
                }

            };

            _font = Content.Load<SpriteFont>("Font");

            _hasStarted = false;
        }
                

        protected override void Update(GameTime gameTime)
        {
            

            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;


            foreach (var sprite in _sprites.ToArray())
                sprite.Update(gameTime, _sprites);

            SpawnCloud();

            PostUpdate();

            base.Update(gameTime);
        }

        private void PostUpdate()
        {
            //where we reomve stuff from the collection
            for (int i = 0; i < _sprites.Count; i++)
            {
                var sprite = _sprites[i];

                if (_sprites[i].IsRemoved)
                {
                    _sprites.RemoveAt(i);
                    i--;
                }

                // checks if the player has died
                if (sprite is Player)
                {
                    var player = sprite as Player;
                    if (player.HadDied)
                    {

                        player.Position = new Vector2(Random.Next(0, ScreenWidth), ScreenHeight);
                        player.HadDied = false;
                    }
                }

            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);


             //front to back is layer 0 at thoe bottom

            _spriteBatch.Begin(SpriteSortMode.FrontToBack);

            foreach (var sprite in _sprites)
            {
                sprite.ShowRectangle = true;
                sprite.Draw(_spriteBatch);
            }

            var fontY = 10;
            var i = 0;
            foreach(var sprite in _sprites)
            {
                if (sprite is Player)
                {
                    _spriteBatch.DrawString(_font, string.Format("Player {0}: {1}", ++i,((Player)sprite).Score), new Vector2(10, fontY += 20), Color.Black);
                }
            }




            _spriteBatch.End();

            base.Draw(gameTime);
        }

        /// <summary>
        /// Spawns clouds
        /// </summary>
        public void SpawnCloud()
        {
            // timer for the clouds
            if (_timer > 3f)
            {
                _timer = 0;
                _sprites.Add(new Cloud(Content.Load<Texture2D>("Cloud")));
            }
        }
    }
}
