using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Labyrinth
{
    public static class H // Helpers
    {
        public static Point PointToPixel(Point point)  // quanto è largo e alto è il rettangolo che contiene il labirinto
        {
            return point * C.PIXELSXPOINT;
        }

        //devo creare i colori dei quadrati

        public static Texture2D CreateTexure(GraphicsDevice device, int width, int height, Func<int, Color> paint) // restituisce un file di texture
        {
            Texture2D texture = new Texture2D(device, width, height); // creo  la textture
            Color[] data = new Color[width * height];  // array di colori

            for (int pixel = 0; pixel < data.Count(); pixel++)
            {
                data[pixel] = paint(pixel);
            }

            texture.SetData(data);

            return texture;
        }


        public static Point HeroPosition()
        {
            return (V.currentHeroPosition * C.PIXELSXPOINT);
        }

        public static Point BrickPosition()
        {
            return (V.currentBrickPosition * C.PIXELSXPOINT);
        }

        public static Vector2 ToVector2(this Point point)
        {
            return new Vector2(point.X, point.Y);
        }

        public static int Random()
        {
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            int dice = rnd.Next(1, 40);
            return dice;
        }
    }
}
