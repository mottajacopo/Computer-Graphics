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
    public class Sprite
    {
        protected Vector2 _position;
        protected Texture2D _texture;

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, 30, 30);
            }
        }

        public virtual Vector2 Position
        {
            get { return _position; }
            set
            {
                _position = value;
            }
        }

       
        public Sprite(Texture2D texture)
        {
            _texture = texture;
        }

        public Sprite(Dictionary<string, Animation> animations)
        {
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, new Rectangle((int)Position.X, (int)Position.Y, 40, 40), Color.White);
        }
    }
}

