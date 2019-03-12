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

// my project import 
using GravityChallenger.GraphicsEngine;
using GravityChallenger.Global;


namespace GravityChallenger.GameEngine
{
    public abstract class GameObject
    {
        // FIELDS
        protected Rectangle hitbox;
        protected Sprite sprite;

        // PROPERTIES
        public int X
        {
            get { return this.hitbox.X; }
        }

        public int Right
        {
            get { return this.hitbox.Right; }
        }

        // CONSTRUCTORS
        protected GameObject(int x, int y, Sprite sprite)
        {
            Point textureSize = sprite.GetTextureSize();
            this.hitbox = new Rectangle((int)(x * Settings.PIXEL_RATIO), (int)(y * Settings.PIXEL_RATIO), textureSize.X, 
                textureSize.Y - (int)(15 * Settings.PIXEL_RATIO));
            this.sprite = sprite;
            this.sprite.Update(x, y);
        }

        // UPDATE & DRAW
        public virtual void Update(GameTime gameTime, Input input)
        {
            this.sprite.Update((int)(this.hitbox.X / Settings.PIXEL_RATIO), (int)(this.hitbox.Y / Settings.PIXEL_RATIO));
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            this.sprite.Draw(spriteBatch);
            // Debug the game 
            // spriteBatch.Draw(Resources.Images["ground_sky"], this.hitbox, Color.Red);
        }

        // METHODS
        public bool CollisionWith(GameObject obj)
        {
            return this.hitbox.Intersects(obj.hitbox);
        }
    }
}