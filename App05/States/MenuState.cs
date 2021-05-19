using App05.Menus;
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
