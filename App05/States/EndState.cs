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
   public class EndState : State
    {
        private List<Component> _components;

        private List<Player> _players;

        private Vector2 WinPosition = new Vector2(350, 100);
        private Vector2 LosePosition = new Vector2(350, 300);

        private Vector2 WinText = new Vector2(300, 90);
        private Vector2 LoseText = new Vector2(300, 290);

        public SpriteFont buttonFont;

        public EndState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content, List<Player> players)
             : base(game, graphicsDevice, content)
        {
            _players = players;

            var buttonTexture = _content.Load<Texture2D>("BasicButton");
            buttonFont = _content.Load<SpriteFont>("Font");

            var newGameButton = new Button(buttonTexture, buttonFont)
            {
                Postition = new Vector2(300, 400),
                Text = "New Game",
            };

            newGameButton.Click += NewGameButton_Click;

            _components = new List<Component>()
            {
                newGameButton,
            };

         
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            var i = 0;
            var fontY = 10;
            spriteBatch.Begin();

            foreach (var component in _components)
            {
                component.Draw(gameTime, spriteBatch);
            }

            foreach(var player in _players)
            {
                player.Draw(spriteBatch);
                spriteBatch.DrawString(buttonFont, (player.Name + string.Format(" : {0}", player.Score)), new Vector2(player.Position.X, player.Position.Y + 80), Color.Black);
            }

            WinnerLoser(spriteBatch);
            spriteBatch.End();
        }

        public override void PostUpdate(GameTime gameTime)
        {
            
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var component in _components)
            {
                component.Update(gameTime);
            }
          
        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            //load new state
            _game.ChangeState(new GameState(_game, _graphicsDevice, _content));

            _game.Restart();
        }

        /// <summary>
        /// postitions the birds depending on which has the heigher score
        /// </summary>
        /// <param name="spriteBatch"></param>
        private void WinnerLoser(SpriteBatch spriteBatch)
        {
            foreach(Player playerA in _players)
            {
                foreach(Player playerB in _players)
                {
                    if(playerA == playerB)
                    {
                        break;
                    }

                    if(playerA.GetScore() > playerB.GetScore())
                    {
                        playerA.Position = WinPosition;
                        spriteBatch.DrawString(buttonFont, ("WINNER: "), new Vector2(playerA.Position.X - 150, playerA.Position.Y + 40), Color.Black);

                        playerB.Position = LosePosition;
                        spriteBatch.DrawString(buttonFont, ("LOSER: "), new Vector2(playerB.Position.X - 150, playerB.Position.Y + 40), Color.Black);
                    }
                    else if(playerA.GetScore() < playerB.GetScore())
                    {
                        playerB.Position = WinPosition;
                        spriteBatch.DrawString(buttonFont, ("WINNER: "), new Vector2(playerB.Position.X - 150, playerB.Position.Y + 40), Color.Black);

                        playerA.Position = LosePosition;
                        spriteBatch.DrawString(buttonFont, ("LOSER: "), new Vector2(playerA.Position.X - 150, playerA.Position.Y + 40), Color.Black);
                    }

                    else if (playerA.GetScore() == playerB.GetScore())
                    {
                        playerA.Position = WinPosition;
                        playerB.Position = new Vector2(400, 100);

                        spriteBatch.DrawString(buttonFont, ("DRAW"), new Vector2(375, 300), Color.Black);

                    }
                }
            }

        }
    }
}
