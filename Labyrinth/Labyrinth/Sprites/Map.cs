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
    public class Map : Sprite
    {
        public char _id;
        public Color Colour = Color.White;

        public Map(Texture2D texture)
            : base(texture)
        {
          
        }

        public char ID
        {
            get { return _id; }
            set
            {
                _id = value;

            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, new Rectangle((int)Position.X, (int)Position.Y, 40, 40), Colour);
            
        }
    }
}
