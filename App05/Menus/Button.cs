using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace App05.Menus
{
   public class Button : Component
    {
        #region Fields

        private MouseState _currentMouse;

        private SpriteFont _font;

        private bool _isHovering;

        private MouseState _previousMouse;

        private Texture2D _texture;
        #endregion

        #region Properties

        public event EventHandler Click;

        public Color PenColour { get; set; }

        public Vector2 Postition { get; set; }

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Postition.X, (int)Postition.Y, _texture.Width, _texture.Height);
            }
        }

        public string Text { get; set; }
        #endregion



        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }

        public override void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
