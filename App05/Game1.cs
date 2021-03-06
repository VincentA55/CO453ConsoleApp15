﻿using App05.Models;
using App05.Sprites;
using App05.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace App05
{
    public class Game1 : Game
    {
        private State _currentState;

        private State _nextState;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Color _backGroundColour = Color.CornflowerBlue;

        public List<Sprite> spriteBatch;

        public List<Player> _players;

        private SpriteFont _font;

        public static int ScreenHeight;
        public static int ScreenWidth;

        public static Random Random;

        public double Difficulty = 1;

        public float _timer;
        public float coinTimer;

        private bool HasSpawned = false;
        private double WhenSpawned = 0;

        private bool PipeHasSpawned = false;
        private double WhenPipeSpawned = 0;

        private bool DevStats = false;

        public bool GameOver = false;

        public Pipe pipe;

        public Coin coin;

        public void ChangeState(State state)
        {
            _nextState = state;
        }

        public Game1()
        {
            GameOver = false;
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            Random = new Random();

            ScreenWidth = _graphics.PreferredBackBufferWidth;
            ScreenHeight = _graphics.PreferredBackBufferHeight;
        }

        protected override void Initialize()
        {
            IsMouseVisible = true;

            base.Initialize();
        }

        protected override void LoadContent()
        {
           
            Restart();
        }

        public void Menu()
        {
        }
        /// <summary>
        /// Loads the players and their sprites
        /// </summary>
        public void Restart()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _nextState = new MenuState(this, _graphics.GraphicsDevice, Content);

            _timer = 0;

            GameOver = false;

            Difficulty = 0;


            LoadBirds();

            //LoadAnimations();

            _font = Content.Load<SpriteFont>("Font");
        }

        protected override void Update(GameTime gameTime)
        {
            if (_nextState != null)
            {
                _currentState = _nextState;

                _nextState = null;
            }

            _currentState.Update(gameTime);

            _currentState.PostUpdate(gameTime);

            base.Update(gameTime);
        }

        public void PostUpdate()
        {
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(_backGroundColour);

            //front to back is layer 0 at the bottom

            _currentState.Draw(gameTime, _spriteBatch);

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
                if (Difficulty <= 5)
                {
                    Cloud cloud = new Cloud(Content.Load<Texture2D>("Cloud"));

                    cloud.IncreaseSpeed(0);

                    spriteBatch.Add(cloud);
                }
                else if (Difficulty >= 10 && Difficulty < 15)
                {
                    Cloud cloud = new Cloud(Content.Load<Texture2D>("Cloud"));

                    cloud.IncreaseSpeed(2);

                    spriteBatch.Add(cloud);
                }
                else if (Difficulty >= 15 && Difficulty < 20)
                {
                    Cloud cloud = new Cloud(Content.Load<Texture2D>("Cloud"));

                    cloud.IncreaseSpeed(4);

                    spriteBatch.Add(cloud);
                }
                else if (Difficulty > 20)
                {
                    Cloud cloud = new Cloud(Content.Load<Texture2D>("Cloud"));

                    cloud.IncreaseSpeed(6);

                    spriteBatch.Add(cloud);
                }
            }
        }

        /// <summary>
        /// Spawns pipes
        /// </summary>
        public void SpawnPipe()
        {
            pipe = new Pipe(Content.Load<Texture2D>("LongPipeFixed"));
            // timer for the pipes
            if (PipeSpawnTimer(1))
            {
                if (Difficulty < 5)
                {
                    spriteBatch.Add((Sprite)pipe.Clone());
                }
                else if (Difficulty == 5)
                {
                    pipe.IncreasePipeSpeed(1);

                    spriteBatch.Add((Sprite)pipe.Clone());
                }
                else if (Difficulty >= 5 && Difficulty < 10)
                {
                    pipe.IncreasePipeSpeed(1);

                    spriteBatch.Add((Sprite)pipe.Clone());
                }
                else if (Difficulty >= 10 && Difficulty < 15)
                {
                    pipe.IncreasePipeSpeed(1);

                    spriteBatch.Add((Sprite)pipe.Clone());
                }
                else if (Difficulty >= 15)
                {
                    int speed = (int)Difficulty / 5;

                    pipe.IncreasePipeSpeed(speed);

                    spriteBatch.Add((Sprite)pipe.Clone());

                    pipe.FlipSpawnHight();

                    pipe.IncreasePipeSpeed(speed);

                    spriteBatch.Add((Sprite)pipe.Clone());
                }
            }
        }

        /// <summary>
        /// Spawns Coins
        /// </summary>
        public void SpawnCoin()
        {
            // timer for the coins
            if (SpawnTimer(2))
            {
                var Coin = new Dictionary<string, Animation>()
                    {
                {"Animation1", new Animation(Content.Load<Texture2D>("Coin"), 9, 0.1f) },
                    };

                coin = new Coin(Coin, _graphics.GraphicsDevice);
                //coin.IncreaseSpeed((int)Difficulty / 5);
                spriteBatch.Add((Sprite)coin.Clone());
            }
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
        /// takes in a timer and returns true if modulo = 0
        /// </summary>
        /// <param name="gameTime"></param>
        /// <param name="timer"></param>
        /// <returns></returns>
        public bool PipeSpawnTimer(int timer)
        {
            int Stimer = (int)_timer;

            if ((Stimer % timer) == 0 && !PipeHasSpawned)
            {
                PipeHasSpawned = true;
                WhenPipeSpawned = Stimer;
                return true;
            }
            else
            {
                if (Stimer >= (WhenPipeSpawned + timer))
                {
                    PipeHasSpawned = false;
                }

                return false;
            }
        }

        /// <summary>
        /// loads the player birds
        /// </summary>
        public void LoadBirds()
        {
            var YelloBird = Content.Load<Texture2D>("YelloBird");
            var RedBird = Content.Load<Texture2D>("RedBird");

            var Bullet = new Bullet(Content.Load<Texture2D>("BirdBullet"));

            Player YelloPlayer = new Player(_graphics.GraphicsDevice, YelloBird)
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
                },
            };

            Player RedPlayer = new Player(_graphics.GraphicsDevice, RedBird)
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
            };

            spriteBatch = new List<Sprite>()
            {
                 YelloPlayer ,
                 RedPlayer
            };

            _players = new List<Player>()
            {
                YelloPlayer,
                RedPlayer
            };

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

                    new AnimatedSprite(yelloAnimations, _graphics.GraphicsDevice)
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

            spriteBatch.Add(new AnimatedSprite(PowerUp, _graphics.GraphicsDevice)
            {
                Position = new Vector2(400, 300),
            });

            spriteBatch.Add(new AnimatedSprite(birdPoweredUp, _graphics.GraphicsDevice)
            {
                Position = new Vector2(400, 100),
            });
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
                    DevStats = sprite.ShowRectangle;

                    _spriteBatch.DrawString(_font, (Name + string.Format(" : {1}", ++i, ((Player)sprite).Score)), new Vector2(10, fontY += 20), Color.Black);
                }
            }
            if (DevStats)
            {
                _spriteBatch.DrawString(_font, ("Game Timer" + string.Format(" : {1}", ++i, _timer)), new Vector2(10, fontY += 20), Color.Black); // game timer

                _spriteBatch.DrawString(_font, ("Difficulty" + string.Format(" : {1}", ++i, Difficulty)), new Vector2(10, fontY += 20), Color.Black); //DifficultyTimer

                _spriteBatch.DrawString(_font, ("WhenSpawned" + string.Format(" : {1}", ++i, WhenSpawned)), new Vector2(10, fontY += 20), Color.Black);
                _spriteBatch.DrawString(_font, ("HasSpawned" + string.Format(" : {1}", ++i, HasSpawned)), new Vector2(10, fontY += 20), Color.Black);
            }
        }

        /// <summary>
        /// increases the difficulty every 5 seconds 
        /// </summary>
        public void DifficultyLevel()
        {
            int Stimer = (int)_timer;

            int level = 10;

            if ((Stimer % 5) == 0)
            {
                level = Stimer - 5;

                Difficulty = level;
            }

            if (Difficulty == 15)
            {
                GameOver = true;
            }
        }

        /// <summary>
        /// goes through the batch to determine a collision
        /// </summary>
        public void PostUpdateHitDetection(Sprite spriteA, Sprite spriteB)
        {
            if (spriteA.CollisionEnabled)
            {
                if (spriteA.Intersects(spriteB))
                {
                    //spriteA.OnCollide(spriteB);
                }
            }
        }
    }
}