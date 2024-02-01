using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;

namespace SnakeGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private int score;
        private ScoreManager scoreManager;
        public static Random random;

        //Scene declarations
        private StartScene startScene;
        private ActionScene actionScene;
        private HelpScene helpScene;
        private HighScoreScene highScoreScene;
        private AboutScene aboutScene;

        //Sound declarations
        SoundEffect themeSound;
        SoundEffect explosionSound;
        SoundEffect biteSound;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 700;
            graphics.PreferredBackBufferHeight = 650;
            IsMouseVisible = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Shared.stage = new Vector2(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            //Sounds

            //themeSound = Content.Load<SoundEffect>("Sounds/gameMusic"); //hitting wall
            explosionSound = Content.Load<SoundEffect>("Sounds/Explosion+1"); //hitting bat
            biteSound = Content.Load<SoundEffect>("Sounds/snakeBite");

            scoreManager = ScoreManager.Load();
            helpScene = new HelpScene(this, spriteBatch);
            this.Components.Add(helpScene);
            startScene = new StartScene(this, spriteBatch);
            this.Components.Add(startScene);
            actionScene = new ActionScene(this, spriteBatch, startScene, actionScene, helpScene,scoreManager,biteSound,explosionSound);
            this.Components.Add(actionScene);
            highScoreScene = new HighScoreScene(this, spriteBatch,scoreManager);
            this.Components.Add(highScoreScene);
            aboutScene = new AboutScene(this, spriteBatch);
            this.Components.Add(aboutScene);
            ScreenControlller screenControlller = new ScreenControlller(this, spriteBatch, actionScene, startScene, helpScene,highScoreScene,aboutScene);
            this.Components.Add(screenControlller);
            startScene.Show();

            Song song = Content.Load<Song>("Sounds/gameMusic");
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(song);





        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            //    Exit();


            // TODO: Add your update logic here
            KeyboardState ks = Keyboard.GetState();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CadetBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
