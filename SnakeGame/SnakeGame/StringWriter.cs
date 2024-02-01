using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SnakeGame
{
    public class StringWriter:DrawableGameComponent
    {

        private SpriteBatch spriteBatch;
        private SpriteFont spriteFont;
        private string[] message;
        private Vector2 position;
        private Color textColor;


        public StringWriter(Game game, SpriteBatch spriteBatch, SpriteFont spriteFont, string[] message, Vector2 position, Color textColor) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.spriteFont = spriteFont;
            this.message = message;
            this.position = position;
            this.textColor = textColor;
        }

        public override void Draw(GameTime gameTime)
        {
            Vector2 temp = position;

            spriteBatch.Begin();

            for (int i = 0; i < message.Length; i++)
            {
                if (i == 0)
                {

                    spriteBatch.DrawString(spriteFont, message[i], temp, textColor);
                    temp.Y += spriteFont.LineSpacing;
                }
                else
                {
                    spriteBatch.DrawString(spriteFont, message[i], temp, textColor);
                    temp.Y += spriteFont.LineSpacing;

                }

            }
            spriteBatch.End();
            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public void Show()
        {
            this.Enabled = true;
            this.Visible = true;
        }

        public void Hide()
        {
            this.Enabled = false;
            this.Visible = false;
        }
    }
}
