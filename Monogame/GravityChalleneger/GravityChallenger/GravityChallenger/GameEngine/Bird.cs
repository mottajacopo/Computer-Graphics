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
using Android.Media;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

// my project import 
using GravityChallenger.GraphicsEngine;
using GravityChallenger.GameEngine;
using GravityChallenger.Global;


namespace GravityChallenger.GameEngine
{
    public class Bird : GameObject
    {
        // CONSTANT 
        public float FLAP = -12f * (float)(Settings.PIXEL_RATIO);
        public const float MAX_SPEED = 15f;
        private const float MAX_ROTATION_VELOCITY = 0.15f;
        private const float MAX_ROTATION = (float)Math.PI / 2f;

        // FIELDS
        private float speedY;
        private int currentFrame;
        private bool gravity;
        private int timer;
        private float rotationVelocity;
        private float rotation;

        

        // CONSTRUCTORS
        public Bird(int x, int y, AnimatedSprite sprite)
            : base(x, y, sprite)
        {
            this.gravity = false;
            this.speedY = 0f;
            this.currentFrame = 0;
        }

        // UPDATE & DRAW
        public override void Update(GameTime gameTime, Input input)
        {
            base.Update(gameTime, input);

            this.timer += gameTime.ElapsedGameTime.Milliseconds;

            if (this.timer >= 120)
            {
                this.timer = 0;
                if (this.currentFrame == 3)
                    this.currentFrame = 0;
                else
                    ++this.currentFrame;
                ((AnimatedSprite)this.sprite).SetIndex(this.currentFrame);
            }

            if (input != null)
            {
                if (input.IsPressed())
                {
                    this.gravity = true;
                    this.speedY = FLAP;
                    this.rotation = 0;
                    this.rotationVelocity = -0.0f;
                    Resources.Sounds["flap"].Play();
                    Resources.Sounds["flap2"].Play();

                    

                }
            }

            if (this.gravity)
            {
                if (this.speedY < MAX_SPEED)
                    this.speedY += 0.5f * (float)(Settings.PIXEL_RATIO);

                if (this.rotationVelocity < MAX_ROTATION_VELOCITY)
                    this.rotationVelocity += 0.000f;

                if (this.rotation < MAX_ROTATION)
                {
                    if (this.rotationVelocity > 0f)
                        this.rotation += this.rotationVelocity;
                }
                else
                {
                    this.rotation = MAX_ROTATION;
                }

                this.sprite.SetRotation(this.rotation);
                this.hitbox.Y += (int)this.speedY;
            }
         
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

        // METHODS
        public void ActiveGravity()
        {
            this.gravity = true;
        }

        public void SetMaxRotation()
        {
            this.rotation = MAX_ROTATION;
        }
    }
}