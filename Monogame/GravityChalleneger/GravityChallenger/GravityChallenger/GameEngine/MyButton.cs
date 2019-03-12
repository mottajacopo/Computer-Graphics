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
using Microsoft.Xna.Framework;

namespace GravityChallenger.GameEngine
{
    class MyButton : GameObject
    {
        // FIELDS
        private bool isPressed;
        private bool hover;

        // PROPERTIES

        // CONSTRUCTORS
        public MyButton(int x, int y, AnimatedSprite animatedSprite)
            : base(x, y, animatedSprite)
        {
            this.isPressed = false;
        }

        // UPDATE & DRAW
        public override void Update(GameTime game, Input input)
        {
            if (this.hitbox.Contains(input.GetPosition()))
            {
                this.isPressed = true;
                Console.WriteLine("\nButton is pressed\n");
                Resources.Sounds["button_click"].Play();                

                if (input.IsPressed())
                    this.sprite.SetColor(Color.Gray);
                else
                {
                    this.sprite.SetColor(Color.LightGray);
                    if (this.hover == false)
                        Resources.Sounds["button_hover"].Play();
                }

                this.hover = true;
            }
            else
            {
                this.sprite.SetColor(Color.White);
                this.hover = false;
            }


            base.Update(game, input);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

        // METHODS

        public bool IsPressed()
        {
            bool result = this.isPressed;

            if (this.isPressed)
                this.isPressed = false;

            return result;
        }
    }
}