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
    public class Map
    {
        protected Texture2D _texture;
        public char _id;

        protected Vector2 _position;
        public Color Colour = Color.White;



        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, 40, 40);
            }
        }

        public Map(Texture2D texture )
        {
            _texture = texture;
            
        }

        public Vector2 Position
        {
            get { return _position; }
            set
            {
                _position = value;

            }
        }

        public char ID
        {
            get { return _id; }
            set
            {
                _id = value;

            }
        }

        public virtual void Update(GameTime gameTime, List<Sprite> sprites)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, new Rectangle((int)Position.X, (int)Position.Y, 40, 40), Colour);
            
        }
    }
}
