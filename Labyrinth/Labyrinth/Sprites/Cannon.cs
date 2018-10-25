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
        protected AnimationManager _animationManager;
        protected Dictionary<string, Animation> _animations;
        protected int offset = 20;
        public int speedX = 1;
        public int speedY = -1;

        private Random r = new Random();

        Texture2D[] values = new Texture2D[]{ C.cannonRightUp, C.cannonRight, C.cannonRightDown, C.cannonDown, C.cannonLeftDown,
                            C.cannonLeft, C.cannonLeftUp, C.cannonUp };

        //protected bool hasDead = false;

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

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, new Rectangle((int)Position.X, (int)Position.Y, 40, 40), Color.White);
        }

        public void Update(GameTime gameTime)
        {
            foreach (var map in V.mapList)
            {
                if (map.ID == '1')
                {
                    if (IsTouchingLeft(map))
                    {
                        _texture = C.cannonLeft; speedX = -1; speedY = 0; 
                    }
                    else if (IsTouchingRight(map))
                    {
                        _texture = C.cannonRight; speedX = 1; speedY = 0; 
                    }
                    else if (IsTouchingTop(map))
                    {
                        _texture = C.cannonUp; speedX = 0; speedY = -1; 
                    }
                    else if (IsTouchingBottom(map))
                    {
                        _texture = C.cannonDown; speedX = 0; speedY = 1; 
                    }     
                    
                }
            }

        }

        public Cannon(Texture2D texture)
                    : base(texture)
        {

        }
       

        public bool IsTouchingLeft(Map map)
        {
            return this.Rectangle.Right + offset > map.Rectangle.Left &&
              this.Rectangle.Left < map.Rectangle.Left &&
              this.Rectangle.Bottom > map.Rectangle.Top &&
              this.Rectangle.Top < map.Rectangle.Bottom;
        }

        public bool IsTouchingRight(Map map)
        {
            return this.Rectangle.Left - offset < map.Rectangle.Right &&
              this.Rectangle.Right > map.Rectangle.Right &&
              this.Rectangle.Bottom > map.Rectangle.Top &&
              this.Rectangle.Top < map.Rectangle.Bottom;
        }

        public bool IsTouchingTop(Map map)
        {
            return this.Rectangle.Bottom + offset > map.Rectangle.Top &&
              this.Rectangle.Top < map.Rectangle.Top &&
              this.Rectangle.Right > map.Rectangle.Left &&
              this.Rectangle.Left < map.Rectangle.Right;
        }

        public bool IsTouchingBottom(Map map)
        {
            return this.Rectangle.Top - offset < map.Rectangle.Bottom &&
              this.Rectangle.Bottom > map.Rectangle.Bottom &&
              this.Rectangle.Right > map.Rectangle.Left &&
              this.Rectangle.Left < map.Rectangle.Right;
        }
    }
}

