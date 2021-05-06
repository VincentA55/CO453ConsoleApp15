﻿using App05.Models;
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

        private List<Sprite> spriteBatch;

        public List<Player> _players;

        private SpriteFont _font;

        public static int ScreenHeight;
        public static int ScreenWidth;

        public static Random Random;

        public float _timer;
        public float coinTimer;

        bool HasSpawned = false;
        double WhenSpawned = 0;

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

          
            

            Restart();
        }

        /// <summary>
        /// Loads the players and their sprites
        /// </summary>
        public void Restart()
        {
            LoadBirds();
            LoadAnimations();



            _font = Content.Load<SpriteFont>("Font");

            _hasStarted = false;
        }

        protected override void Update(GameTime gameTime)
        {
            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            foreach (var sprite in spriteBatch.ToArray())
                sprite.Update(gameTime, spriteBatch);

            SpawnPipe(); //Cant have spawning on the same intervals
            SpawnCloud();
            SpawnCoin();


            PostUpdate();

            base.Update(gameTime);
        }

        private void PostUpdate()
        {
         
            int count = spriteBatch.Count;
            for (int i = 0; i < count; i++)
            {
                foreach (var child in spriteBatch[i].Children)
                    spriteBatch.Add(child);

                spriteBatch[i].Children.Clear();
            }

            for (int i = 0; i < spriteBatch.Count; i++)
            {
                if (spriteBatch[i].IsRemoved)
                {
                    spriteBatch.RemoveAt(i);
                    i--;
                }
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            //front to back is layer 0 at thoe bottom

            _spriteBatch.Begin(SpriteSortMode.FrontToBack);

            foreach (var sprite in spriteBatch)
            {
                sprite.Draw(_spriteBatch);
            }

            DisplayScore();

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        /// <summary>
        /// Spawns clouds every 3 seconds
        /// </summary>
        public void SpawnCloud()
        {
          
            // timer for the clouds
            if (SpawnTimer(3))
            {
                // RESETING THE TIMER IS WHAT MAKES IT WORK AND NOT WORK!!!
               spriteBatch.Add(new Cloud(Content.Load<Texture2D>("Cloud")));
            }
        }

        /// <summary>
        /// Spawns pipes 
        /// </summary>
        public void SpawnPipe()
        {
            // timer for the pipes
            if (SpawnTimer(1))
            {
                spriteBatch.Add(new Pipe(Content.Load<Texture2D>("LongPipeFixed")));
            }
        }

        /// <summary>
        /// Spawns Coins
        /// </summary>
        public void SpawnCoin()
        {
           

            // timer for the coins
            if (SpawnTimer(2))

            {var Coin = new Dictionary<string, Animation>()
            {
                {"Animation1", new Animation(Content.Load<Texture2D>("Coin"), 9, 0.1f) },
            };

                spriteBatch.Add(new Coin(Coin));
            }
        }

        public void LoadBirds()
        {
            var YelloBird = Content.Load<Texture2D>("YelloBird");
            var RedBird = Content.Load<Texture2D>("RedBird");

            var Bullet = new Bullet(Content.Load<Texture2D>("BirdBullet"));

            spriteBatch = new List<Sprite>()
            {

               new Player(_graphics.GraphicsDevice,YelloBird)
                {
                    Origin = new Vector2(YelloBird.Width / 2, YelloBird.Height / 2),
                    Name = "YelloBird",
                    LinearVelocity = 4f,
                    Color = Color.White,
                    Position = new Vector2(YelloBird.Width, 100),
                    Bullet = Bullet,
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
                    Name = "RedBird",
                    LinearVelocity = 5f,
                    Color = Color.White,
                    Position = new Vector2(ScreenWidth - RedBird.Width, 100),
                    Bullet = Bullet,
                    Input = new Input()
                    {
                        Up = Keys.Up,
                        Down = Keys.Down,
                        Left = Keys.Left,
                        Right = Keys.Right,
                        Shoot = Keys.NumPad0
                    }
                } };
        }

        /// <summary>
        /// loads the animations
        /// </summary>
        public void LoadAnimations()
        {
            var yelloAnimations = new Dictionary<string, Animation>()
            {
                {"Animation1", new Animation(Content.Load<Texture2D>("BigBirdAnimationStripFixed"), 4, 0.3f) },
            };

            var birdPoweredUp = new Dictionary<string, Animation>()
            {
                {"Animation1", new Animation(Content.Load<Texture2D>("BigBirdPowerAnimationStrip"), 8, 0.1f) },
            };

            var PowerUp = new Dictionary<string, Animation>()
            {
                {"Animation1", new Animation(Content.Load<Texture2D>("BigPowerUpAnimated3"),9, 0.05f) }
            };

                spriteBatch.Add(

                        new AnimatedSprite(yelloAnimations)
                        {
                            Position = new Vector2(300, 300),
                            Input = new Input()
                            {
                                Up = Keys.NumPad8,
                                Down = Keys.NumPad5,
                                Left = Keys.NumPad4,
                                Right = Keys.NumPad6
                            }
                        });

            spriteBatch.Add(new AnimatedSprite(PowerUp)
            {

                Position = new Vector2(400, 300),

            });

            spriteBatch.Add(new AnimatedSprite(birdPoweredUp)
            {
                Position = new Vector2(400, 100),
            });

               
        }


        /// <summary>
        /// takes in a timer and returns true if modulo = 0
        /// </summary>
        /// <param name="gameTime"></param>
        /// <param name="timer"></param>
        /// <returns></returns>
        public bool SpawnTimer(int timer)
        {
            int Stimer = (int)_timer;

            if ((Stimer % timer) == 0 && !HasSpawned)
            {
                HasSpawned = true;
                WhenSpawned = Stimer;
                return true;

            }
            else
            {
                if (Stimer >= (WhenSpawned + timer))
                {
                    HasSpawned = false;
                }

                return false;
            }
        }

        /// <summary>
        /// Displays the score for each player
        /// </summary>
        public void DisplayScore()
        {
            var fontY = 10;
            var i = 0;
            foreach (var sprite in this.spriteBatch) // displays the players score
            {
                if (sprite is Player)
                {
                    string Name = sprite.Name;

                    _spriteBatch.DrawString(_font, (Name + string.Format(" : {1}", ++i, ((Player)sprite).Score)), new Vector2(10, fontY += 20), Color.Black);

                }
            }
                    _spriteBatch.DrawString(_font, (string.Format(" : {1}", ++i, _timer)), new Vector2(10, fontY += 20), Color.Black); // game timer

                    _spriteBatch.DrawString(_font, (string.Format(" : {1}", ++i, WhenSpawned)), new Vector2(10, fontY += 20), Color.Black);
                    _spriteBatch.DrawString(_font, (string.Format(" : {1}", ++i, HasSpawned)), new Vector2(10, fontY += 20), Color.Black);

        }
    }
}