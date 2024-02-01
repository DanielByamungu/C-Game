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
    public class CollisionManager : GameComponent
    {
        private Snake snake, snakeHead;

        private SpriteBatch spriteBatch;
        private SnakeFood snakefood;
        private Highscore highscore;
        private SpriteFont regularFont, highlightFont;
        private MenuComponent menu;
        private Explosion explosion;
        private ActionScene actionScene;
        private StringWriter g;
        private ScoreManager scoreManager;
        private SoundEffect biteSound, explosionSound;
        private AddHighscore addHighscore;
        private StringWriter sw;
        private Texture2D blackLine;
        int value;
        bool foodCollidesWithSnake = true;
        string text = " ";

            Keys[] keysToCheck = new Keys[] {
        Keys.A, Keys.B, Keys.C, Keys.D, Keys.E,
        Keys.F, Keys.G, Keys.H, Keys.I, Keys.J,
        Keys.K, Keys.L, Keys.M, Keys.N, Keys.O,
        Keys.P, Keys.Q, Keys.R, Keys.S, Keys.T,
        Keys.U, Keys.V, Keys.W, Keys.X, Keys.Y,
        Keys.Z, Keys.Back, Keys.Space};

        KeyboardState currentKeyboardState;
        KeyboardState lastKeyboardState;


        public CollisionManager(Game game, SpriteBatch spriteBatch, Snake snake, SnakeFood snakefood, MenuComponent menu, ActionScene actionScene, StringWriter g, Highscore h, Explosion e,ScoreManager scoreManager, SoundEffect biteSound, SoundEffect explosionSound) : base(game)
        {
            this.explosionSound = explosionSound;
            this.biteSound = biteSound;
            this.scoreManager = scoreManager;
            this.snake = snake;
            this.spriteBatch = spriteBatch;
            this.snakefood = snakefood;
            this.highscore = h;
            this.g = g;
            regularFont = game.Content.Load<SpriteFont>("Fonts/RegularFont");
            highlightFont = game.Content.Load<SpriteFont>("Fonts/highlightFont");
            snakeHead = snake.TailList[0];
            this.actionScene = actionScene;
            this.menu = menu;
            this.actionScene = actionScene;
            this.explosion = e;
            addHighscore = new AddHighscore(game, spriteBatch, regularFont, text, new Vector2(Shared.stage.X / 2 - 175, Shared.stage.Y / 2 + 150), Color.Black);
            addHighscore.Hide();
            game.Components.Add(addHighscore);
            sw = new StringWriter(game, spriteBatch, regularFont, new[] { "Please Enter your name down here" }, new Vector2(Shared.stage.X / 2 - 175, Shared.stage.Y / 2 + 80), Color.Black);
            game.Components.Add(sw);
            sw.Hide();
        }

        public override void Update(GameTime gameTime)
        {

            currentKeyboardState = Keyboard.GetState();

            foreach (Keys key in keysToCheck)
            {
                if (CheckKey(key))
                {
                    AddKeyToText(key);
                    break;
                }
            }

            KeyboardState ks = Keyboard.GetState();

            Rectangle snakeRect = snake.getBound();
            Rectangle snakeFoodRect = snakefood.getBound();

            if (snakeRect.Intersects(snakeFoodRect))
            {
                Random r = new Random();
                int xPosition, yPosition;
             
                xPosition = r.Next(0 + snakefood.Tex.Width, (int)Shared.stage.X - snakefood.Tex.Width);
                yPosition = r.Next(0+snakefood.Tex.Height, (int)Shared.stage.Y - snakefood.Tex.Height);

                while (foodCollidesWithSnake == true)
                {
                    for (int i = 1; i < snake.TailList.Count-2; i++)
                    {
                        if (snake.TailList[i].Position.X == xPosition || snake.TailList[i].Position.Y == yPosition)
                        {
                            xPosition = r.Next(0 + snakefood.Tex.Width, (int)Shared.stage.X - snakefood.Tex.Width);
                            yPosition = r.Next(0 + snakefood.Tex.Height, (int)Shared.stage.Y - snakefood.Tex.Height);
                            foodCollidesWithSnake = true;
                        }
                    }
                    foodCollidesWithSnake = false;

                }

                snakefood.Hide();
                snakefood.Position = new Vector2(xPosition, yPosition);
                snakefood.Show();
                snake.AddTail();
                highscore.AddScore();
                foodCollidesWithSnake = true;
                biteSound.Play();
            }
            if (g.Enabled)
            {
                if (ks.IsKeyDown(Keys.Enter))
                {
                    scoreManager.Add(new Score()
                    {
                        PlayerName = addHighscore.Message,
                        Value = highscore.GetValue(value),


                    });
                    ScoreManager.Save(scoreManager);
                    addHighscore.Message = " ";
                    sw.Hide();
                    addHighscore.Hide();
                    actionScene.ResetActionScene();

                }

                if (ks.IsKeyDown(Keys.R))
                {
                    sw.Hide();
                    addHighscore.Hide();
                    actionScene.ResetActionScene();

                    addHighscore.Message = " ";


                }
                if (ks.IsKeyDown(Keys.Escape))
                {
                    sw.Hide();
                    addHighscore.Hide();

                    Shared.menuState = Shared.MenuCoordinator.StartScene;
                    actionScene.ResetActionScene();

                    addHighscore.Message = " ";
                }
            }

            if (ks.IsKeyDown(Keys.Escape))
            {
                sw.Hide();
                addHighscore.Hide();
                Shared.menuState = Shared.MenuCoordinator.StartScene;
                actionScene.ResetActionScene();

                addHighscore.Message = " ";


            }

            CheckIfDead();


            base.Update(gameTime);
            lastKeyboardState = currentKeyboardState;
        }

        public void CheckIfDead()
        {
            if (Shared.gameState == Shared.GameState.Play)
            {


                Rectangle snakeRect = snake.TailList[0].getBound();
                for (int i = 1; i < snake.TailList.Count; i++)
                {
                    Rectangle snakeTailRect = snake.TailList[i].getBound();
                    if (snakeRect.Intersects(snakeTailRect))
                    {
                        explosionSound.Play();
                        Shared.gameState = Shared.GameState.Pause;
                        g.Show();
                        explosion.Position = new Vector2(snakeHead.Position.X, snakeHead.Position.Y);
                        explosion.Start();
                        sw.Show();
                        addHighscore.Show();
                        
                        break;

                    }
                }
            }
        }

        private void AddKeyToText(Keys key)
        {
            string newChar = "";

            if (text.Length >= 20 && key != Keys.Back)
                return;

            switch (key)
            {
                case Keys.A:
                    newChar += "a";
                    break;
                case Keys.B:
                    newChar += "b";
                    break;
                case Keys.C:
                    newChar += "c";
                    break;
                case Keys.D:
                    newChar += "d";
                    break;
                case Keys.E:
                    newChar += "e";
                    break;
                case Keys.F:
                    newChar += "f";
                    break;
                case Keys.G:
                    newChar += "g";
                    break;
                case Keys.H:
                    newChar += "h";
                    break;
                case Keys.I:
                    newChar += "i";
                    break;
                case Keys.J:
                    newChar += "j";
                    break;
                case Keys.K:
                    newChar += "k";
                    break;
                case Keys.L:
                    newChar += "l";
                    break;
                case Keys.M:
                    newChar += "m";
                    break;
                case Keys.N:
                    newChar += "n";
                    break;
                case Keys.O:
                    newChar += "o";
                    break;
                case Keys.P:
                    newChar += "p";
                    break;
                case Keys.Q:
                    newChar += "q";
                    break;
                case Keys.R:
                    newChar += "r";
                    break;
                case Keys.S:
                    newChar += "s";
                    break;
                case Keys.T:
                    newChar += "t";
                    break;
                case Keys.U:
                    newChar += "u";
                    break;
                case Keys.V:
                    newChar += "v";
                    break;
                case Keys.W:
                    newChar += "w";
                    break;
                case Keys.X:
                    newChar += "x";
                    break;
                case Keys.Y:
                    newChar += "y";
                    break;
                case Keys.Z:
                    newChar += "z";
                    break;
                case Keys.Space:
                    newChar += " ";
                    break;
                case Keys.Back:
                    if (addHighscore.Message.Length != 0)
                        addHighscore.Message = addHighscore.Message.Remove(addHighscore.Message.Length - 1);
                    return;
            }
            if (currentKeyboardState.IsKeyDown(Keys.RightShift) ||
                currentKeyboardState.IsKeyDown(Keys.LeftShift))
            {
                newChar = newChar.ToUpper();
            }
            addHighscore.Message += newChar;
        }

        private bool CheckKey(Keys theKey)
        {
            return lastKeyboardState.IsKeyDown(theKey) && currentKeyboardState.IsKeyUp(theKey);
        }
    }
}
