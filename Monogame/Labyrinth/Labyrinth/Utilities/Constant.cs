using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace Labyrinth
{
    public static class C // Constants
    {
        public static Point MAINWINDOW = new Point(960, 720);
        //public static Point WINDOWSOFFSET = new Point(50, 40);
        public static Point PIXELSXPOINT = new Point(40, 40); // quanti pixel voglio per ogni punto del labirinto

        public static string LabyrinthPathName = @"C:\Git\Computer-Graphics\Monogame\Labyrinth\Labyrinth\Content\Labirinto.txt";

        public static Texture2D brickWall, brickGrass, brickStart, brickEnd, brickLava, brickDiamond, brickEnd2;
        public static Texture2D Grave;
        public static Texture2D cannonRightUp, cannonRight, cannonRightDown , cannonDown , cannonLeftDown, cannonLeft, cannonLeftUp, cannonUp;
        public static Texture2D bulletTexture , bulletTrasp;
        public static Texture2D win;
        public static Texture2D cover;

        public static SoundEffect explosion;            // prof
        public static SoundEffect newBullet;            // prof
        public static Song backMusic;                   // prof
        public static int BULLETWIDTH = 6;               // prof
        public static int BULLETHEIGHT = 6;              // prof
    }
}
