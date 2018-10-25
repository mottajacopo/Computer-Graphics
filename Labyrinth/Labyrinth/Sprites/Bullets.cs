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
        public class Bullets  : Microsoft.Xna.Framework.DrawableGameComponent //non viene gestito da game, ma si gestisce automaticamente come se fosse un altro game
        {
            protected Texture2D texture;
            protected Rectangle spriteRectangle;
            protected Point position;
            protected int YSpeed;
            protected int XSpeed;
            protected Random random;
            protected SpriteBatch sBatch;
            


        public Bullets(Game game, ref Texture2D theTexture ,Cannon _cannon) : base(game)
            {
                this.texture = theTexture;
                this.position = new Point();

                V.isVisible = true;
                sBatch = (SpriteBatch)Game.Services.GetService(typeof(SpriteBatch));

                spriteRectangle = new Rectangle(0, 0, C.BULLETWIDTH, C.BULLETHEIGHT);

                random = new Random(this.GetHashCode());

                PutInStartPosition(_cannon);
            }

        public virtual Rectangle Rectangle
        {
            get
            {
                return new Rectangle(0, 0, C.BULLETWIDTH, C.BULLETHEIGHT);
            }
        }

        public void PutInStartPosition(Cannon _cannon)
            {
                position.X = (int)_cannon.Position.X + 16;
                position.Y = (int)_cannon.Position.Y + 10;

                XSpeed = _cannon.speedX * 2;
                YSpeed = _cannon.speedY * 2;
            }
            public override void Draw(GameTime gameTime)
            {
                sBatch.Draw(texture, new Rectangle(position, new Point(C.BULLETWIDTH, C.BULLETHEIGHT)), Color.White);
                base.Draw(gameTime);
            }

            public override void Update(GameTime gameTime)
            {
            
            foreach (var player in V.playerList)
            {
                
                if (player.Rectangle.Intersects(new Rectangle(position.X, position.Y, C.BULLETWIDTH, C.BULLETHEIGHT)))
                {
                    V.playerHealth = V.playerHealth - 1;

                    V.deathHeroPoisition = player.Position;
                    if (V.playerHealth < 0)
                    {
                        player.hasDied = true;
                    }
                    
                }
            }

            foreach (var map in V.mapList)
            {
                if (map.ID == '1')
                {
                    if (map.Rectangle.Intersects(new Rectangle(position.X, position.Y, C.BULLETWIDTH, C.BULLETHEIGHT)))
                    {
                        XSpeed = 0;
                        YSpeed = 0;
                        V.isVisible = false;
                        
                        
                    } 
                }
            }
            
                position.X += XSpeed;
                position.Y += YSpeed;
                base.Update(gameTime);

            }
    }
}

