using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Microsoft.Xna.Framework.Graphics;

namespace GravityChallenger.Global
{
    public enum GameMODE
    {
        SKY,
        SEA,
        JUNGLE,
        SPACE,
        ICE
    }

    public class Settings
    {

        public static double PIXEL_RATIO = (Double)GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / 1280;
        //public static double  PIXEL_RATIO = 1;


        public static int SCREEN_HEIGHT = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
        public static int SCREEN_WIDTH = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;

        public static bool IS_FULLSCREEN = false;

        public static Color BACKGROUND_COLOR = Color.CornflowerBlue;

        public static GameMODE gameMode = GameMODE.SKY;

    }
}