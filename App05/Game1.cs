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

        public static int ScreenHeight;
        public static int ScreenWidth;

        public static Random Random;

        private float _timer;

        private bool _hasStarted = false;

        private Player Player;

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
                new Player(YelloBird)
                {
                    Origin = new Vector2(YelloBird.Width / 2, YelloBird.Height / 2),
                    LinearVelocity = 4f,
                    Position = new Vector2(300, 100),
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

                new Player(RedBird)
                {
                    Origin = new Vector2(RedBird.Width / 2, RedBird.Height / 2),
                    LinearVelocity = 5f,
                    Position = new Vector2(50, 100),
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

            _hasStarted = false;
        }
                

        protected override void Update(GameTime gameTime)
        {
            

            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;


            foreach (var sprite in _sprites.ToArray())
                sprite.Update(gameTime, _sprites);

            // timer for the clouds
            if (_timer > 3f)
            {
                _timer = 0;
                _sprites.Add(new Cloud(Content.Load<Texture2D>("Cloud")));
            }
           
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
            if(sprite is Player)
                {
                    var player = sprite as Player;
                    if (player.HadDied)
                    {
                        player.Position = new Vector2(Random.Next(0,ScreenWidth), ScreenHeight);
                        player.HadDied = false;
                    }
                }

            }

        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin(SpriteSortMode.BackToFront);

            foreach (var sprite in _sprites)
             sprite.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
