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


// my project import 
using GravityChallenger.GraphicsEngine;
using GravityChallenger.GameEngine;
using GravityChallenger.Global;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GravityChallenger.Menu
{
    class MenuScore : MenuBase
    {

        // FIELDS
        private MyButton menuButton;
        private Sprite logo;
        private int highscore;

        // CONSTRUCTOR
        public MenuScore()
            : base()
        {
            this.highscore = HighScore.GetHighScore();
            this.logo = new Sprite("bestscore", 10, 50);
            this.menuButton = new MyButton(300, 600,
                           new AnimatedSprite("game_buttons", 120, 120, 2, SheetOrientation.HORIZONTAL, 0, 0));
        }

        // METHODS

        // UPDATE and DRAW
        public override void Update(GameTime gameTime, Input input, Game1 game)
        {

            this.menuButton.Update(gameTime, input);

            if (this.menuButton.IsPressed())
                game.ChangeMenu(MenuState.MAIN);

            Console.WriteLine("{0}", Settings.gameMode);

            base.Update(gameTime, input, game);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            this.logo.Draw(spriteBatch);
            this.menuButton.Draw(spriteBatch);

            Number.Draw(spriteBatch, NumberSize.LARGE, (int)(300 * (int)Settings.PIXEL_RATIO), 400, highscore);

        }
    }
}
