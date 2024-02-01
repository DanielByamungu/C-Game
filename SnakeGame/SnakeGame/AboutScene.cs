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
    public class AboutScene : GameScene
    {
        private SpriteBatch spriteBatch;
        private SpriteFont txtFont;
        private StringWriter message;

        public AboutScene(Game game, SpriteBatch spriteBatch) : base(game)
        {
            this.spriteBatch = spriteBatch;
            txtFont = game.Content.Load<SpriteFont>("Fonts/TextFont");
            message = new StringWriter(game, spriteBatch, txtFont, new[]{"                                            ABOUT\n\n This game involves controlling a single block or snakehead by turning\nonly left or right by ninety" +
               "degrees until you manage to eat an apple.\nWhen you get the apple, the Snake grows an extra block or body segment.If,or \nrather when, the snake accidentally eats himself the game is over.\nThe more apples the snake eats the higher the score." +
               "\n\n        Done by Daniel Byamungu & Stefan Kovacevic \n\n\n" +
               "                                   Press ESCAPE KEY to go back" },
                new Vector2(0, 0), Color.Black);

            this.Components.Add(message);

        }
    }
}