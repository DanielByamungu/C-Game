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
    public class HighScoreScene:GameScene
    {
        private SpriteBatch spriteBatch;
        private Texture2D tex;
        ScoreManager scoreManager;
        private SpriteFont regularFont;
        public HighScoreScene(Game game, SpriteBatch spriteBatch,ScoreManager scoreManager) : base(game)
        {
            this.spriteBatch = spriteBatch;
            //tex = game.Content.Load<Texture2D>("Images/helpImage");
            this.scoreManager = scoreManager;
            regularFont = game.Content.Load<SpriteFont>("Fonts/RegularFont");
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(regularFont, "Highscores \n\n" + string.Join("\n", scoreManager.HighScores.Select(c => c.PlayerName + ":" + c.Value).ToArray()), new Vector2(Shared.stage.X/2 - 80, Shared.stage.Y /2 - 200), Color.Black);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
