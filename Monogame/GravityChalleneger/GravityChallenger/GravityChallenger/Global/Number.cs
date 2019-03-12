using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GravityChallenger.Global
{
    public enum NumberSize
    {
        LARGE,
        SMALL
    }

    public class Number
    {
        // STATIC FIELDS
        public static int SMALL_NUMBER_WIDTH = 40;
        public static int SMALL_NUMBER_HEIGHT = 50;

        public static int LARGE_NUMBER_WIDTH = 70;
        public static int LARGE_NUMBER_HEIGHT = 80;

        // STATIC METHODS
        public static void Draw(SpriteBatch spriteBatch, NumberSize size, int x, int y, int num)
        {
            string strNum = num.ToString();

            foreach (char c in strNum)
            {
                int n = c - '0';
                if (size == NumberSize.SMALL)
                {
                    spriteBatch.Draw(Resources.Images["numbers_small"],
                        new Rectangle((int)(x * Settings.PIXEL_RATIO),(int)(y * Settings.PIXEL_RATIO),
                                      (int)(SMALL_NUMBER_WIDTH * Settings.PIXEL_RATIO), (int)(SMALL_NUMBER_HEIGHT * Settings.PIXEL_RATIO)),
                        new Rectangle(n * SMALL_NUMBER_WIDTH, 0, SMALL_NUMBER_WIDTH, SMALL_NUMBER_HEIGHT), Color.White);

                    x += SMALL_NUMBER_WIDTH;
                }
                else
                {
                    spriteBatch.Draw(Resources.Images["numbers_large"],
                        new Rectangle((int)(x * Settings.PIXEL_RATIO),(int)(y * Settings.PIXEL_RATIO), 
                                        (int)(LARGE_NUMBER_WIDTH * Settings.PIXEL_RATIO),(int)(LARGE_NUMBER_HEIGHT * Settings.PIXEL_RATIO)),
                        new Rectangle(n * LARGE_NUMBER_WIDTH, 0, LARGE_NUMBER_WIDTH, LARGE_NUMBER_HEIGHT), Color.White);
                    x += LARGE_NUMBER_WIDTH;
                }
            }
        }
    }
}