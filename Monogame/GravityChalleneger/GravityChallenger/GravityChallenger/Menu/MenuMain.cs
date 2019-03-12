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
using Microsoft.Xna.Framework;


// my project import 
using GravityChallenger.GraphicsEngine;
using GravityChallenger.GameEngine;
using GravityChallenger.Global;

namespace GravityChallenger.Menu
{

    public class MenuMain : MenuBase
    {
        // FIELDS
        private Sprite logo;
        private MyButton startButton;
        private MyButton quitButton;
        private MyButton scoreButton;
        private MyButton settingsButton;


        // CONSTRUCTOR
        public MenuMain() 
            : base()
        {            
            this.logo = new Sprite("logo", 60, 50);
            this.startButton = new MyButton(38 , 970, 
                new AnimatedSprite("menu_buttons", 312, 110, 4, SheetOrientation.VERTICAL, 0, 0));
            this.scoreButton = new MyButton(370, 970, 
                new AnimatedSprite("menu_buttons", 312, 110, 1, SheetOrientation.VERTICAL, 0, 0));
            this.settingsButton = new MyButton(38, 1100, 
                new AnimatedSprite("menu_buttons", 312, 110, 10, SheetOrientation.VERTICAL, 0, 0));
            this.quitButton = new MyButton(370, 1100,
                new AnimatedSprite("menu_buttons", 312, 110, 2, SheetOrientation.VERTICAL, 0, 0));
        }

        // METHODS

        // UPDATE and DRAW
        public override void Update(GameTime gameTime, Input input, Game1 game)
        {
            this.startButton.Update(gameTime, input);
            this.scoreButton.Update(gameTime, input);
            this.settingsButton.Update(gameTime, input);
            this.quitButton.Update(gameTime, input);

            if (this.startButton.IsPressed())
                game.ChangeMenu(MenuState.GAME);
            if (this.settingsButton.IsPressed())
                game.ChangeMenu(MenuState.SETTINGS);
            if (this.scoreButton.IsPressed())
                game.ChangeMenu(MenuState.SCORE);
            if (this.quitButton.IsPressed())
                game.Exit();

            base.Update(gameTime, input, game);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            this.logo.Draw(spriteBatch);
            this.startButton.Draw(spriteBatch);
            this.scoreButton.Draw(spriteBatch);
            this.settingsButton.Draw(spriteBatch);
            this.quitButton.Draw(spriteBatch);
        }
    }
}