using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Labyrinth.Models;
using Labyrinth.Sprites;

namespace Labyrinth
{
    public static class V // Variables
    {
        public static int labyrinthMatrixColumns;
        public static int labyrinthMatrixRows;
        public static int[,] labyrinthMatrix;

        public static Rectangle labyrinthRect;
        
        public static Point currentHeroPosition;
        public static Point currentBrickPosition;
        public static Vector2 deathHeroPoisition;

        public static int deathCount;
        public static int playerHealth;

        public static List<Point> labEnter = new List<Point>();
        public static List<Point> labExit = new List<Point>();

        public static string animationUp;
        public static string animationDown;
        public static string animationLeft;
        public static string animationRight;
        public static string animationDied;

        public static Texture2D cannonTexture;

        public static int score;

        public static bool win;

        public static Rectangle labyrinthPixels;         //prof
        public static Random random = new Random();

        public static List<Sprite> spriteList = new List<Sprite>(); // list for sprite (es . grave)
        public static List<Cannon> cannonList = new List<Cannon>();
        public static List<Bullet> bulletsList = new List<Bullet>();
        public static List<Player> playerList;
        public static List<Map> mapList = new List<Map>();

    }
}
