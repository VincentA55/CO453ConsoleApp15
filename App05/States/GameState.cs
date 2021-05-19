using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace App05.States
{
    public class GameState : State
    {
        public GameState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content)
             : base(game, graphicsDevice, content)
        {
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {

            spriteBatch.Begin(SpriteSortMode.FrontToBack);

            foreach (var sprite in _game.spriteBatch)
            {
                sprite.Draw(spriteBatch);
            }

            _game.DisplayScore();

            spriteBatch.End();

        }

        public override void PostUpdate(GameTime gameTime)
        {
            int count = _game.spriteBatch.Count;
            for (int i = 0; i < count; i++)
            {
                foreach (var child in _game.spriteBatch[i].Children)
                    _game.spriteBatch.Add(child);

                _game.spriteBatch[i].Children.Clear();
            }

            for (int i = 0; i < _game.spriteBatch.Count; i++)
            {
                if (_game.spriteBatch[i].IsRemoved)
                {
                    _game.spriteBatch.RemoveAt(i);
                    i--;
                }
            }
        }

        public override void Update(GameTime gameTime)
        {
            
           _game._timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

           _game.SpawnPipe(); //Cant have spawning on the same intervals

            foreach (var sprite in _game.spriteBatch.ToArray())
            {
                sprite.Update(gameTime, _game.spriteBatch);
            }

           _game.SpawnCloud();
            _game.SpawnCoin();

           _game.DifficultyLevel();

          _game.PostUpdate();
        }
    }
}
