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
        public class Bullet : Sprite
        {
            protected Texture2D texture;
            protected Rectangle spriteRectangle;
            protected Point position;
            protected int YSpeed;
            protected int XSpeed;
            protected SpriteBatch sBatch;
            public bool isVisible;

        public Bullet(Texture2D texture ,Cannon cannon)
            :base(texture)
        {
                this.texture = texture;
                this.position = new Point();

                spriteRectangle = new Rectangle(0, 0, C.BULLETWIDTH, C.BULLETHEIGHT);

                isVisible = true;

                PutInStartPosition(cannon);
            }

       

        public void PutInStartPosition(Cannon cannon)
            {
                position.X = (int)cannon.Position.X + 16;
                position.Y = (int)cannon.Position.Y + 10;

                XSpeed = cannon.speedX * 2;
                YSpeed = cannon.speedY * 2;
            }
            public override void Draw(SpriteBatch spriteBatch)
            {
                spriteBatch.Draw(texture, new Rectangle(position, new Point(C.BULLETWIDTH, C.BULLETHEIGHT)), Color.White);
                
            }

      

            public void Update(GameTime gameTime)
            {
            
            foreach (var player in V.playerList)
            {
                
                if (player.Rectangle.Intersects(new Rectangle(position.X, position.Y, C.BULLETWIDTH, C.BULLETHEIGHT)))
                {
                    if (player.Health > 0)
                    {
                        V.playerHealth--;
                        player.Health = V.playerHealth / 20;
                       
                    }
                    V.playerHealth--;

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

                        isVisible = false;

                    } 
                }
            }
            
                position.X += XSpeed;
                position.Y += YSpeed;
                

            }
    }
}

