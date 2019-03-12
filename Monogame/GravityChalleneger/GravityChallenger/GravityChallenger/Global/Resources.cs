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
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace GravityChallenger.Global
{

    public class Resources
    {
        public static Dictionary<string, Texture2D> Images ;
        public static Dictionary<string, SoundEffect> Sounds;

        public static void LoadImages(ContentManager content, GraphicsDevice graphicsDevice)
        {
            Images = new Dictionary<string, Texture2D>();

            List<string> graphics = new List<string>()
            {
                "alien",
                "background_jungle",
                "background_sea",
                "background_sky",
                "background_space",  
                "bestscore",
                "bird",
                "bug",
                "game_buttons",
                "gameover",
                "getready",
                "ground_jungle",
                "ground_sea",
                "ground_sky",
                "ground_space",
                "logo",
                "logo_original",
                "medals",
                "menu_buttons",
                "new",
                "numbers_large",
                "numbers_small",
                "pipe_bot_jungle",
                "pipe_bot_sea",
                "pipe_bot_sky",
                "pipe_top_jungle",
                "pipe_top_sea",
                "pipe_top_sky",
                "score_box",
                "submarine"
            };

            /*foreach (string img in graphics)
            {
                using (var stream = TitleContainer.OpenStream("Content/Graphics/" + img))
                {
                    Images.Add(img, Texture2D.FromStream(graphicsDevice, stream));
                }
            }*/

            foreach (string img in graphics)
                Images.Add(img, content.Load<Texture2D>("Graphics/" + img));
        }

        public static void LoadSounds(ContentManager content, GraphicsDevice graphicsDevice)
        {
            Sounds = new Dictionary<string, SoundEffect>();

            List<string> sounds = new List<string>()
            {
                "button_click",
                "button_hover",
                "flap",
                "flap2",
                "pipe_hit",
                "pipe_hit2",
                "pipe_pass"
            };

             foreach (string s in sounds)
                 Sounds.Add(s, content.Load<SoundEffect>("Sounds/" + s));
        }
    }
}