﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Example_lab
{
    public static class C // Constants
    {
        public static Point MAINWINDOW = new Point(1200, 700);
        public static Point WINDOWSOFFSET = new Point(100, 50);
        public static Point PIXELSXPOINT = new Point(40, 40); // quanti pixel voglio per ogni punto del labirinto

        public static string LabyrinthPathName = @"C:\Git\Computer-Graphics\Example_lab\Example_lab\Content\Labirinto.txt";

        public static Texture2D brickBlack, brickGold, brickBlue, brickGreen, brickLava , brickDiamante;
    }
}
