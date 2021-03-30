using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace App05
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private List<Sprite> _sprites;

        private Sprite _sprite1;
        private Sprite _sprite2;

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

            var texture = Content.Load<Texture2D>("YelloBird");

            _sprites = new List<Sprite>()
            {
                new Sprite(texture)
                {
                    Postition = new Vector2(100,100), 
                    Input = new Input()
                    {
                        Up = Keys.W, 
                        Down = Keys.S, 
                        Left = Keys.A, 
                        Right = Keys.D
                    } 
                },

                new Sprite(texture)
                {
                    Speed = 5f,
                    Postition = new Vector2(0,100),
                    Input = new Input()
                    {
                        Up = Keys.Up,
                        Down = Keys.Down,
                        Left = Keys.Left,
                        Right = Keys.Right
                    }
                }
            };

            _sprite1 = new Sprite(texture);
            _sprite1.Postition = new Vector2(100, 100);

            _sprite2 = new Sprite(texture)
            {
                Postition = new Vector2(200, 100),
                Speed = 3f,
             };
        }

        protected override void Update(GameTime gameTime)
        {
            foreach (var sprite in _sprites)
                sprite.Update();
            

            base.Update(gameTime);
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
