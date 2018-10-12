﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Example_lab
{
    public static class H // Helpers
    {
        public static Point PointToPixel(Point point)  // quanto è largo e alto è il rettangolo che contiene il labirinto
        {
            return point * C.PIXELSXPOINT + C.WINDOWSOFFSET;
        }

        //devo creare i colori dei quadrati

        public static Texture2D CreateTexure(GraphicsDevice device , int width, int height, Func<int , Color> paint) // restituisce un file di texture
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


        public static Point heroPosition()
        {
            return (C.WINDOWSOFFSET + V.currentHeroPosition * C.PIXELSXPOINT);
        }
        
    }

}
