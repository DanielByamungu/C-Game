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
    public class Snake : DrawableGameComponent
    {

        private Game game;
        private SpriteBatch spriteBatch;
        private Texture2D tex;
        private Vector2 position;
        Texture2D snakeBodyTex;
        private Vector2 stage;
        int UPDATE_INTERVAL = 90;
        private List<Snake> tailList;
        double secondsSinceLastUpdate = 0;
        private SpriteFont regularFont,highlightFont;
        private int verticalSpeed, horizontalSpeed;
        private Vector2 initialPosition;

        public Vector2 Position { get => position; set => position = value; }
        public List<Snake> TailList { get => tailList; set => tailList = value; }

        public Snake(Game game, SpriteBatch spriteBatch, Texture2D tex, Vector2 stage, Vector2 position) : base(game)
        {
            this.game = game;
            this.spriteBatch = spriteBatch;
            this.tex = tex;
            this.stage = stage;
            this.position = position;
            this.initialPosition = position;
            tailList = new List<Snake>();
            tailList.Add(this);
            snakeBodyTex = game.Content.Load<Texture2D>("Images/snakeBody");
            regularFont = game.Content.Load<SpriteFont>("Fonts/RegularFont");
            highlightFont = game.Content.Load<SpriteFont>("Fonts/highlightFont");
            verticalSpeed = tex.Height;
            horizontalSpeed = tex.Width;
            //highScore = new Highscore(game, spriteBatch, regularFont, "Score: ", new Vector2(30, 30), Color.Black);
            //game.Components.Add(highScore);
        }

        public override void Draw(GameTime gameTime)
        {


            for (int i = 0; i < tailList.Count; i++)
            {
                if (i == 0)
                {
                    spriteBatch.Begin();
                    spriteBatch.Draw(tex, tailList[0].position, Color.White);
                    spriteBatch.End();
                }
                else
                {
                    spriteBatch.Begin();
                    spriteBatch.Draw(snakeBodyTex, tailList[i].position, Color.Gray);
                    spriteBatch.End();
                }
            }




            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {


            secondsSinceLastUpdate += gameTime.ElapsedGameTime.TotalMilliseconds;
            if (secondsSinceLastUpdate >= UPDATE_INTERVAL && Shared.gameState != Shared.GameState.Pause)
            {

                CheckForOutOfBounds();
                secondsSinceLastUpdate = 0;
                

                for (int i = tailList.Count - 1; i >= 0; i--)
                {
                    
                    if (i == 0)
                    {
                        switch (Shared.direction)
                        {
                            case Shared.Direction.Up:

                                position.X += 0;
                                position.Y -= verticalSpeed;
                                
                                break;
                            case Shared.Direction.Down:

                                position.X += 0;
                                position.Y += verticalSpeed;
                                
                                break;
                            case Shared.Direction.Left:

                                position.X -= horizontalSpeed;
                                position.Y += 0;
                               
                                break;
                            case Shared.Direction.Right:

                                position.X += horizontalSpeed;
                                position.Y += 0;                               
                                break;
                            case Shared.Direction.None:
                                break;
                            default:
                                break;
                        }


                    }

                    else
                    {
                        tailList[i].position = tailList[i - 1].position;
                    }


                }

                


            }
            KeyboardState ks = Keyboard.GetState();



            if (ks.IsKeyDown(Keys.Left) && Shared.direction != Shared.Direction.Right)
            {

                Shared.direction = Shared.Direction.Left;

            }

            else if (ks.IsKeyDown(Keys.Right) && Shared.direction != Shared.Direction.Left)
            {

                Shared.direction = Shared.Direction.Right;

            }

            else if (ks.IsKeyDown(Keys.Up) && Shared.direction != Shared.Direction.Down)
            {

                Shared.direction = Shared.Direction.Up;


            }

            else if (ks.IsKeyDown(Keys.Down) && Shared.direction != Shared.Direction.Up)
            {

                Shared.direction = Shared.Direction.Down;

            }



            base.Update(gameTime);
        }


        public Rectangle getBound()
        {
            return new Rectangle((int)position.X, (int)position.Y, tex.Width, tex.Height);
        }

        public void AddTail()
        {
            Snake snakeTail;
            switch (Shared.direction)
            {
                //up
                case Shared.Direction.Up:
                    snakeTail = new Snake(game, spriteBatch, snakeBodyTex, stage, new Vector2((int)tailList[tailList.Count - 1].position.X, (int)tailList[tailList.Count - 1].position.Y + tex.Height));
                    tailList.Add(snakeTail);
                    break;
                //down
                case Shared.Direction.Down:
                    snakeTail = new Snake(game, spriteBatch, snakeBodyTex, stage, new Vector2((int)tailList[tailList.Count - 1].position.X, (int)tailList[tailList.Count - 1].position.Y - tex.Height));
                    tailList.Add(snakeTail);
                    break;
                //left
                case Shared.Direction.Left:
                    snakeTail = new Snake(game, spriteBatch, snakeBodyTex, stage, new Vector2((int)tailList[tailList.Count - 1].position.X + tex.Width, (int)tailList[tailList.Count - 1].position.Y));
                    tailList.Add(snakeTail);
                    break;
                //right
                case Shared.Direction.Right:
                    snakeTail = new Snake(game, spriteBatch, snakeBodyTex, stage, new Vector2((int)tailList[tailList.Count - 1].position.X - tex.Width, (int)tailList[tailList.Count - 1].position.Y));
                    tailList.Add(snakeTail);
                    break;
                default:
                    break;
            }


        }



        public void CheckForOutOfBounds()
        {
            if (tailList[0].position.X > stage.X - tex.Width)
            {
                tailList[0].position.X = 0;
            }
            if (tailList[0].position.X < 0)
            {
                tailList[0].position.X = stage.X - tex.Width;
            }
            if (tailList[0].position.Y < 0)
            {
                tailList[0].position.Y = stage.Y - tex.Height;
            }
            if (tailList[0].position.Y > stage.Y)
            {
                tailList[0].position.Y = 0;
            }
        }

        public void RestartSnake()
        {
            
            tailList.Clear();
            tailList.Add(this);
            this.position = initialPosition;
            Shared.gameState = Shared.GameState.Pause;

        }
        
        public void Hide()
        {

        }

    }
}
