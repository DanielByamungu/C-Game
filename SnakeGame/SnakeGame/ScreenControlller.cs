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
    public class ScreenControlller : GameComponent
    {
        SpriteBatch spriteBatch;
        ActionScene actionScene;
        StartScene startScene;
        HelpScene helpScene;
        HighScoreScene highScoreScene;
        AboutScene aboutScene;
        public ScreenControlller(Game game, SpriteBatch spriteBatch, ActionScene actionScene, StartScene startScene, HelpScene helpScene, HighScoreScene highScoreScene, AboutScene aboutScene) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.aboutScene = aboutScene;
            this.actionScene = actionScene;
            this.startScene = startScene;
            this.helpScene = helpScene;
            this.highScoreScene = highScoreScene;

        }


        public override void Update(GameTime gameTime)
        {
            int selectedIndex = 0;
            //int selectLevelSelectedIndex = 0;

            KeyboardState ks = Keyboard.GetState();

            if (startScene.Enabled)
            {

                selectedIndex = startScene.Menu.SelectedIndex;
                if (selectedIndex == 0 && ks.IsKeyDown(Keys.Enter))
                {
                    startScene.Hide();
                    actionScene.Show();
                    
                }
                if (selectedIndex == 1 && ks.IsKeyDown(Keys.Enter))
                {
                    startScene.Hide();
                    helpScene.Show();

                }
                if (selectedIndex == 2 && ks.IsKeyDown(Keys.Enter))
                {
                    startScene.Hide();
                    highScoreScene.Show();
                }
                if (selectedIndex == 3 && ks.IsKeyDown(Keys.Enter))
                {
                    startScene.Hide();
                    aboutScene.Show();
                }
                if (selectedIndex == 4 && ks.IsKeyDown(Keys.Enter))
                {
                    Game.Exit();
                }

            }
            if (helpScene.Enabled)
            {
                if (ks.IsKeyDown(Keys.Escape))
                {
                    helpScene.Hide();
                    startScene.Show();
                }

            }
            if (actionScene.Enabled)
            {
                if (ks.IsKeyDown(Keys.Escape))
                {

                    actionScene.Hide();
                    startScene.Show();
                }

            }

            if (highScoreScene.Enabled)
            {
                if (ks.IsKeyDown(Keys.Escape))
                {

                    highScoreScene.Hide();
                    startScene.Show();
                }

            }
            if (aboutScene.Enabled)
            {
                if (ks.IsKeyDown(Keys.Escape))
                {

                    aboutScene.Hide();
                    startScene.Show();
                }
            }

            //if (selectLevel.Enabled)
            //{
            //    selectLevelSelectedIndex = selectLevel.SelectLevelMenu.SelectedIndex;
            //    if (selectLevelSelectedIndex == 0 && ks.IsKeyDown(Keys.Enter) && oldState.IsKeyUp(Keys.Enter))
            //    {
            //        //selectLevel.Hide();
            //        //actionScene.Show();
            //    }

            //    if (selectLevelSelectedIndex == 1 && ks.IsKeyDown(Keys.Enter))
            //    {
            //        selectLevel.Hide();
            //        actionScene.Show();
            //    }


            //    oldState = ks;
            //}
            //switch (Shared.menuState)
            //{
            //    case Shared.MenuCoordinator.StartScene:
            //        startScene.Show();
            //        actionScene.Hide();
            //        helpScene.Hide();
            //        selectLevel.Hide();

            //        selectedIndex = startScene.Menu.SelectedIndex;
            //        if (selectedIndex == 0 && ks.IsKeyDown(Keys.Enter))
            //        {
            //            Shared.menuState = Shared.MenuCoordinator.SelectLevel;
            //        }
            //        if (selectedIndex == 1 && ks.IsKeyDown(Keys.Enter))
            //        {
            //            Shared.menuState = Shared.MenuCoordinator.HelpScene;
            //        }
            //        if (selectedIndex == 4 && ks.IsKeyDown(Keys.Enter))
            //        {
            //            Game.Exit();
            //        }
            //        break;
            //    case Shared.MenuCoordinator.ActionScene:
            //        startScene.Hide();
            //        actionScene.Show();
            //        helpScene.Hide();
            //        selectLevel.Hide();
            //        break;
            //    case Shared.MenuCoordinator.HelpScene:
            //        break;
            //    case Shared.MenuCoordinator.SelectLevel:
            //        startScene.Hide();
            //        actionScene.Hide();
            //        helpScene.Hide();
            //        selectLevel.Show();
            //        if (selectLevelSelectedIndex == 0 && ks.IsKeyDown(Keys.Enter))
            //        {
            //            Shared.menuState = Shared.MenuCoordinator.ActionScene;
            //        }

            //        if (selectLevelSelectedIndex == 1 && ks.IsKeyDown(Keys.Enter))
            //        {
            //            //selectLevel.Hide();
            //            //actionScene.Show();
            //        }
            //        break;
            //    default:
            //        break;
            //}

            base.Update(gameTime);
        }
    }
}
