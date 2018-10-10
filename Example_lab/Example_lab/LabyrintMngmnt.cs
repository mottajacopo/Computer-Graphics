using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Example_lab
{
    public partial class Game1 // prima era class LabyrinthMngmnt
    {
        public void ReadLabyrinthSpec(int[,] Labyrinth, string labyrinthPathName)
        {
            // leggo il file di testo
            var data = System.IO.File.ReadAllText(labyrinthPathName);
            //leggo il file tutto di seguito
            //divido in righe 
            //trasformo ogni stringa in vettori di carattere 
            //in data ho tutti i caratteri

            //creo la matrice di stringe
            var lines = data.Split(new[] {'\r', '\n'}, StringSplitOptions.RemoveEmptyEntries);

            V.labyrinthMatrixColumns = lines[0].Length;
            V.labyrinthMatrixRows = lines.Length;

            //creo il rettangolo del labirinto (qui si mette colonne*righe )
            V.labyrinthRect = new Rectangle(0, 0, V.labyrinthMatrixColumns, V.labyrinthMatrixRows); // 0,0 origine

            //creo la matrice
            V.labyrinthMatrix = new int[V.labyrinthMatrixRows, V.labyrinthMatrixColumns];

            //ricopiamo il file di testo dentro la matrice 
            for (int i = 0; i < V.labyrinthMatrixRows; i++)
            {
                char[] ca = lines[i].ToCharArray();
                for (int j = 0; j < V.labyrinthMatrixColumns; j++)
                {
                    switch (ca[j])
                    {
                        case '0' :
                            V.labyrinthMatrix[i, j] = '0';
                            break;
                        case '1' :
                            V.labyrinthMatrix[i, j] = '1';
                            break;
                        case 'I' :
                            V.labyrinthMatrix[i, j] = 'I';
                            break;
                        case 'E' :
                            V.labyrinthMatrix[i, j] = 'E';
                            break;
                    }
                }
            }
        }

        public void FillLabyrinth(SpriteBatch sp)
        {
            Texture2D brick = C.brickGold; // lo uso come brick defauld

            for (int i = 0; i < V.labyrinthMatrixRows; i++)
            {

                for (int j = 0; j < V.labyrinthMatrixColumns; j++)
                {
                    switch (V.labyrinthMatrix[i, j])
                    {
                        case '0':
                            brick = C.brickGold;
                            break;
                        case '1':
                            brick = C.brickBlack;
                            break;
                        case 'I':
                            brick = C.brickBlue;
                            break;
                        case 'E':
                            brick = C.brickGreen;
                            break;
                    }
                    //disegno il labirinto
                    sp.Draw(brick , new Rectangle(H.PointToPixel(new Point(j,i)) , C.PIXELSXPOINT) , Color.White);
                }
            }
        }
    }
}
