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
    public class SnakeFood : DrawableGameComponent
    {
        SpriteBatch spriteBatch;
        Texture2D tex;
        Vector2 position;

        public Vector2 Position { get => position; set => position = value; }
        public Texture2D Tex { get => tex; set => tex = value; }

        public SnakeFood(Game game, SpriteBatch spriteBatch, Texture2D tex, Vector2 stage) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.tex = tex;
            position = new Vector2(Shared.stage.X / 3, Shared.stage.Y / 3);
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

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(tex, position, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public Rectangle getBound()
        {
            return new Rectangle((int)position.X, (int)position.Y, tex.Width, tex.Height);
        }

        public void ResetFoodPosition()
        {
            this.position = new Vector2(Shared.stage.X / 3, Shared.stage.Y / 3);
        }
    }
}
