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
    public class Shared
    {

        public static Vector2 stage;

        public enum Direction
        {
            Up,
            Down,
            Left,
            Right,
            None
        };

        public enum GameState
        {
            Pause,
            Play
        }

        public enum MenuCoordinator
        {
            StartScene,
            ActionScene,
            HelpScene,
            SelectLevel
            
        }
        public static Direction direction { get; set; }
        public static GameState gameState { get; set; }
        public static MenuCoordinator menuState { get; set; }
        

    }
}
