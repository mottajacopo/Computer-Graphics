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
using GravityChallenger.Global;


namespace GravityChallenger.GameEngine
{
    public enum PipeType
    {
        TOP,
        BOT
    }

    class Pipe : GameObject
    {

        // FIELDS
        private PipeType pipeType;
        private int timer;
        private bool toDelete;
        private bool isPassed;
        

        // GETTER
        public PipeType GetPipeType()
        {
            return this.pipeType;
        }

        public bool ToDelete()
        {
            return this.toDelete;
        }

        public bool IsPassed()
        {
            return this.isPassed;
        }

        public void SetPassed()
        {
            this.isPassed = true;
        }

        /**public void SetSprite()
        {
            if (pipeType == PipeType.TOP)
                choosenSprite = new Sprite("pipe_top");
            else
                choosenSprite = new Sprite("pipe_bot");
        }**/

        // CONSTRUCTOR
        public Pipe(int x, int y, PipeType type)
            : base(x, y, GetSprite(type))               
        {
            this.pipeType = type;
            this.timer = 0;
            this.toDelete = false;
            this.isPassed = false;

            /**if (type == PipeType.BOT)
                this.sprite.SetOrientation(SpriteEffects.FlipVertically);**/
        }

        // METHODS
        public static Sprite GetSprite(PipeType type)
        {
            switch(Settings.gameMode)
            {
                case GameMODE.SEA:
                    return (type == PipeType.TOP ? new Sprite("pipe_top_sea") : new Sprite("pipe_bot_sea"));
                case GameMODE.JUNGLE:
                    return (type == PipeType.TOP ? new Sprite("pipe_top_jungle") : new Sprite("pipe_bot_jungle"));
                case GameMODE.SPACE:
                    return (type == PipeType.TOP ? new Sprite("pipe_top_sky") : new Sprite("pipe_bot_sky"));
                case GameMODE.ICE:
                    return (type == PipeType.TOP ? new Sprite("pipe_top_sky") : new Sprite("pipe_bot_sky"));
                default:
                    return (type == PipeType.TOP ? new Sprite("pipe_top_sky") : new Sprite("pipe_bot_sky"));
            }            
        }

        // UPDATE & DRAW
        public override void Update(GameTime gameTime, Input input)
        {
            base.Update(gameTime, input);

            this.timer += gameTime.ElapsedGameTime.Milliseconds;

            while (this.timer >= (int)(5 * Settings.PIXEL_RATIO))
            {
                this.timer -= (int)(5 * Settings.PIXEL_RATIO);
                this.hitbox.X -= (int)Math.Ceiling(Settings.PIXEL_RATIO);

                if (this.hitbox.X <= -155 * (int)Settings.PIXEL_RATIO)
                    this.toDelete = true;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
