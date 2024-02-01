using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace SnakeGame
{
    public class ActionScene : GameScene
    {
        private SpriteBatch spriteBatch;
        private Snake s;
        private SnakeFood sf;
        private CollisionManager cm;
        private SpriteFont regularFont, highlightFont, gameOverFont;
        private Highscore h;
        private ActionScene actionScene;
        private MenuComponent menu;
        private StringWriter g;
        private Explosion explosion;
        private ScoreManager scoreManager;
        private SoundEffect explosionSound, biteSound;
        private string[] menuItems = new string[] { "Game Over", "Press R to Restart", "Press Escape to End" };


        public ActionScene(Game game, SpriteBatch spriteBatch, StartScene startScene, ActionScene actionScene, HelpScene helpScene, ScoreManager scoreManager, SoundEffect biteSound, SoundEffect explosionSound) : base(game)
        {
            this.explosionSound = explosionSound;
            this.biteSound = biteSound;
            this.scoreManager = scoreManager;
            this.spriteBatch = spriteBatch;
            Shared.direction = Shared.Direction.None;
            this.spriteBatch = spriteBatch;
            Shared.gameState = Shared.GameState.Play;
            Texture2D snakeTex = game.Content.Load<Texture2D>("Images/snakeHead");
            s = new Snake(game, spriteBatch, snakeTex, Shared.stage, new Vector2(Shared.stage.X / 2, Shared.stage.Y / 2));
            this.Components.Add(s);
            Texture2D snakeFoodTex = game.Content.Load<Texture2D>("Images/snakeFood");
            sf = new SnakeFood(game, spriteBatch, snakeFoodTex, Shared.stage);
            this.Components.Add(sf);
            regularFont = game.Content.Load<SpriteFont>("Fonts/RegularFont");
            highlightFont = game.Content.Load<SpriteFont>("Fonts/highlightFont");
            gameOverFont = game.Content.Load<SpriteFont>("Fonts/gameOverFont");
            menu = new MenuComponent(game, spriteBatch, regularFont, highlightFont, menuItems, new Vector2(Shared.stage.X / 2 - 100, Shared.stage.Y / 2 - 70));
            this.Components.Add(menu);
            menu.Hide();
            h = new Highscore(game, spriteBatch, regularFont, "Score: ", new Vector2(10, 10), Color.Black);
            h.Show();
            this.Components.Add(h);
            StringWriter g = new StringWriter(game, spriteBatch, gameOverFont, menuItems, new Vector2(Shared.stage.X / 2 - 170, Shared.stage.Y / 2 - 70), Color.BlanchedAlmond);
            this.Components.Add(g);
            g.Hide();
            this.g = g;
            Texture2D explosionTex = game.Content.Load<Texture2D>("Images/explosion");
            explosion = new Explosion(game, spriteBatch, explosionTex, Vector2.Zero, 3);
            this.Components.Add(explosion);
            cm = new CollisionManager(game, spriteBatch, s, sf, menu, this, g, h, explosion,scoreManager,biteSound,explosionSound);
            this.Components.Add(cm);
            this.actionScene = actionScene;

        }

        public void ResetActionScene()
        {
            s.RestartSnake();
            g.Hide();
            h.ResetScore();
            sf.ResetFoodPosition();
            Shared.gameState = Shared.GameState.Play;
            Shared.direction = Shared.Direction.None;

        }

    }


}
