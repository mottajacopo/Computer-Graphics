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
using Microsoft.Xna.Framework.Graphics;
using GravityChallenger.Global;

namespace GravityChallenger.GameEngine
{
    class Button : GameObject
    {
        // FIELDS
        private bool hover;
        private bool isPressed;

        // GETTER
        public bool IsPressed()
        {
            bool result = this.isPressed;

            if (this.isPressed)
                this.isPressed = false;

            return result;
        }

        // CONSTRUCTOR
        public Button(int x, int y, int index)
            : base(x, y, new AnimatedSprite("menu_buttons", 40, 14, index))
        {
            this.hover = false;
            this.isPressed = false;
        }

        // METHODS

        // UPDATE & DRAW
        public override void Update(Input input)
        {
            base.Update(input);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}