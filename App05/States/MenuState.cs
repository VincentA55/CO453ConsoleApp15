using App05.Menus;
using App05.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace App05.States
{
    public class MenuState : State
    {
        private List<Component> _components;

        private List<AnimatedSprite> _animatedSprites;

        public MenuState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content)
            :base(game, graphicsDevice, content)
        {
            var buttonTexture = _content.Load<Texture2D>("BasicButton");
            var buttonFont = _content.Load<SpriteFont>("Font");

            var newGameButton = new Button(buttonTexture, buttonFont)
            {
                Postition = new Vector2(300, 200),
                Text = "New Game",
            };

            newGameButton.Click += NewGameButton_Click;

            var quitButton = new Button(buttonTexture, buttonFont)
            {
                Postition = new Vector2(300, 300),
                Text = "Quit",
            };

            quitButton.Click += QuitButton_Click;


            var birdPoweredUp = new Dictionary<string, Animation>()
            {
                {"Animation1", new Animation(_content.Load<Texture2D>("BigBirdPowerAnimationStrip"), 8, 0.1f) },
            };

           var PowerBird = new AnimatedSprite(birdPoweredUp, _graphicsDevice)
            {
                Position = new Vector2(550, 200),
            };

            var redBirdFlapping = new Dictionary<string, Animation>()
            {
                {"Animation1", new Animation(_content.Load<Texture2D>("RedBirdAnimationStrip"), 4, 0.1f) },
            };

            var RedBird = new AnimatedSprite(redBirdFlapping, _graphicsDevice)
            {
                Position = new Vector2(350, 180),
            };


            var birdFlapping  = new Dictionary<string, Animation>()
            {
                {"Animation1", new Animation(_content.Load<Texture2D>("BigBirdAnimationStripFixed"), 4, 0.3f) },
            };

            var YelloBird = new AnimatedSprite(birdFlapping, _graphicsDevice)
            {
                Position = new Vector2(100, 200),
            };

            _animatedSprites = new List<AnimatedSprite>()
            {
                PowerBird,
                YelloBird,
                RedBird,
            };

            _components = new List<Component>()
            {
                newGameButton,
                quitButton,
                
            };
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            foreach(var component in _components)
            {
                component.Draw(gameTime, spriteBatch);
            }

            foreach(var sprite in _animatedSprites)
            {
                sprite.Draw(spriteBatch);
                sprite.AnimationManager.Update(gameTime);
            }

            spriteBatch.End();
        }

        public override void PostUpdate(GameTime gameTime)
        {
           //remove sprites if they are not needed
        }

        public override void Update(GameTime gameTime)
        {
            foreach(var component in _components)
            {
                component.Update(gameTime);
            }
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            _game.Exit();
        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            //load new state

            _game.ChangeState(new GameState(_game, _graphicsDevice, _content));
        }

    }
}
