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
    public class Bullets : Sprite
    {

        #region Fields

        #endregion

        #region Properties

        #endregion

        #region Methods

        public override void Draw(SpriteBatch spriteBatch)
        {

        }

        public virtual void Move()
        {
          
        }

        protected virtual void SetAnimations()
        {
            
        }

        public Bullets(Texture2D texture)
            : base(texture)
        {
        }
        
        public void Update(GameTime gameTime, List<Player> player, List<Map> _map)
        {
            
        }

        public bool IsTouchingLeft(Player player)
        {
            return this.Rectangle.Right  > player.Rectangle.Left  &&
              this.Rectangle.Left < player.Rectangle.Left &&
              this.Rectangle.Bottom > player.Rectangle.Top &&
              this.Rectangle.Top < player.Rectangle.Bottom;
        }

        public bool IsTouchingRight(Sprite player)
        {
            return this.Rectangle.Left < player.Rectangle.Right &&
              this.Rectangle.Right > player.Rectangle.Right &&
              this.Rectangle.Bottom > player.Rectangle.Top &&
              this.Rectangle.Top < player.Rectangle.Bottom;
        }

        public bool IsTouchingTop(Sprite player)
        {
            return this.Rectangle.Bottom > player.Rectangle.Top &&
              this.Rectangle.Top < player.Rectangle.Top &&
              this.Rectangle.Right > player.Rectangle.Left &&
              this.Rectangle.Left < player.Rectangle.Right;
        }

        public bool IsTouchingBottom(Sprite player)
        {
            return this.Rectangle.Top < player.Rectangle.Bottom &&
              this.Rectangle.Bottom > player.Rectangle.Bottom &&
              this.Rectangle.Right > player.Rectangle.Left &&
              this.Rectangle.Left < player.Rectangle.Right;
        }

        #endregion
    }
}

