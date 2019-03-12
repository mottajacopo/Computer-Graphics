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
using GravityChallenger.Global;

// my project import 
using GravityChallenger.GraphicsEngine;
using Microsoft.Xna.Framework;

namespace GravityChallenger.GameEngine
{
    public class Ground : GameObject
    {
        // FIELDS
        private int baseX;
        private int currentOffset;
        private int timer;

        // PROPERTIES 

        // CONSTRUCTORS 
        public Ground(int x, int y, Sprite sprite)
            : base(x, y, sprite)
        {
            this.baseX = x;
            this.currentOffset = 0;
            this.timer = 0;
        }

        // UPDATE & DRAW
        public override void Update(GameTime gameTime, Input input)
        {
            base.Update(gameTime, input);

            this.timer += gameTime.ElapsedGameTime.Milliseconds;

            while (this.timer >= 5)
            {
                this.timer -= 5;
                this.currentOffset += 1;

                if (this.currentOffset >= 30)
                    this.currentOffset = 0;

                this.hitbox.X = this.baseX - (int)((this.currentOffset * Settings.PIXEL_RATIO));
            }
        }

        // METHODS
    }
}