using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Labyrinth.Models;
using Labyrinth.Sprites;
using Labyrinth.Manager;

namespace Labyrinth.Sprites
{
    public class Cannon : Sprite
    {

        #region Fields

        protected AnimationManager _animationManager;
        protected Dictionary<string, Animation> _animations;
        protected Bullets _bullet;
        protected Vector2 Orientation;
        //protected bool hasDead = false;

        #endregion

        #region Properties

        public override Vector2 Position
        {
            get { return _position; }
            set
            {
                _position = value;

                if (_animationManager != null)
                    _animationManager.Position = _position;
            }
        }
        #endregion

        #region Methods

        protected virtual void SetAnimations()
        {
            if (Orientation.X > 0)
                _animationManager.Play(_animations[""]);
            else if (Orientation.X < 0)
                _animationManager.Play(_animations[""]);
            else if (Orientation.Y > 0)
                _animationManager.Play(_animations[""]);
            else if (Orientation.Y < 0)
                _animationManager.Play(_animations[""]);
            else _animationManager.Stop();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if(_texture != null)
                spriteBatch.Draw(_texture, new Rectangle((int)Position.X, (int)Position.Y, 40, 40), Color.White);
            else if (_animationManager != null)
                _animationManager.Draw(spriteBatch);
            else throw new Exception("This ain't right..!");
        }

        public virtual void Positioning()
        {

        }


        public Cannon(Texture2D texture, Bullets[] bullets)
            : base(texture)
        {
            foreach(var bullet in bullets)
                _bullet = bullet;
        }
        #endregion
    }
}

