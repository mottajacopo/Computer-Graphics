using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Example_lab
{
    public static class V // Variables
    {
        //variabile che prendo da un file di testo

        public static int labyrinthMatrixColumns;
        public static int labyrinthMatrixRows;
        public static int[,] labyrinthMatrix;

        public static Rectangle labyrinthRect;

        public static Texture2D hero;
        public static Texture2D heroDamaged;

        public static Point currentHeroPosition;

        public static List<Point> labEnter = new List<Point>();
        public static List<Point> labExit = new List<Point>();


    }
}
