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
    public class StartScene : GameScene
    {
        private SpriteBatch spriteBatch;
        private MenuComponent menu;
        private StringWriter startMenu;
        public MenuComponent Menu { get => menu; set => menu = value; }
        private string[] menuItems = { "Start Game", "Help", "High Score", "About", "Quit" };

        public StartScene(Game game, SpriteBatch spriteBatch) : base(game)
        {
            this.spriteBatch = spriteBatch;
            SpriteFont regularFont = game.Content.Load<SpriteFont>("Fonts/RegularFont");
            SpriteFont highlightFont = game.Content.Load<SpriteFont>("Fonts/HighlightFont");
            SpriteFont gameOverFont = game.Content.Load<SpriteFont>("Fonts/gameOverFont");

            startMenu = new StringWriter(game, spriteBatch, gameOverFont, new string[] { "Main Menu" }, new Vector2(Shared.stage.X / 2 - 100, Shared.stage.Y / 2 - 100),Color.Black);
            this.Components.Add(startMenu);
            menu = new MenuComponent(game, spriteBatch, regularFont, highlightFont, menuItems, new Vector2(Shared.stage.X / 2 - 100, Shared.stage.Y / 2));
            this.Components.Add(menu);
        }

    }
}
