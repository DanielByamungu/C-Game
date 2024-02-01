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
    public class Highscore : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private SpriteFont spriteFont;
        private string message;
        private Vector2 position;
        private Color textColor;
        int value;
        public int Value { get => value; set => this.value = value; }
        public string Message { get => message; set => message = value; }

        public Highscore(Game game, SpriteBatch spriteBatch, SpriteFont spriteFont, string message, Vector2 position, Color textColor) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.spriteFont = spriteFont;
            this.message = message;
            this.position = position;
            this.textColor = textColor;
        }


        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(spriteFont, message, position, textColor);
            spriteBatch.End();
            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public void AddScore()
        {
            value++;
            message = $"Score: {value}";
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

        public void ResetScore()
        {
            value = 0;
            message = "Score: 0";
        }

        public int GetValue(int scoreResult)
        {
            return scoreResult = value;
        }
    }
}