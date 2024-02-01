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
    public class HelpScene : GameScene
    {
        private SpriteBatch spriteBatch;
        private Texture2D tex;
        private SpriteFont txtFont;
        private StringWriter message;
        public HelpScene(Game game, SpriteBatch spriteBatch) : base(game)
        {
            this.spriteBatch = spriteBatch;
            txtFont = game.Content.Load<SpriteFont>("Fonts/TextFont");
            //tex = game.Content.Load<Texture2D>("Images/helpImage");
            message = new StringWriter(game, spriteBatch, txtFont, new[]{"                                       HOW TO PLAY THE GAME\n\n -Please select START in the main menu to start the game \n -Use any arrow key to trigger the movement of the snake " +
               "\n -Continue using the appropriate arrow key to switch directions until the snake\neats the food\n -Keep track of the snake length as it grows to avoid collision of the snake\n head with the rest of the body\n\n\n" +
               "                                 Press ESCAPE KEY to go back" },
               new Vector2(0, 0), Color.AntiqueWhite);
            this.Components.Add(message);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            //spriteBatch.Draw(tex, Vector2.Zero, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
