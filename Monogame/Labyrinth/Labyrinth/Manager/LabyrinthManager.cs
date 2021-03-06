﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Labyrinth.Models;
using Labyrinth.Sprites;
using Labyrinth.Manager;

namespace Labyrinth
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
            var lines = data.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

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
                    int dice = H.Random();
                    switch (ca[j])
                    {
                        case '0':
                            if (dice == 5)   // soluzione temporanea cannoni (poi usiamo la classe )
                            {
                                V.labyrinthMatrix[i, j] = 'C';
                            }
                            else
                            {
                                V.labyrinthMatrix[i, j] = '0';
                            }
                            break;
                        case '1':
                            V.labyrinthMatrix[i, j] = '1';
                            break;
                        case 'L':
                            V.labyrinthMatrix[i, j] = 'L';
                            break;
                        case 'D':
                            V.labyrinthMatrix[i, j] = 'D';
                            break;
                        case 'F':
                            V.labyrinthMatrix[i, j] = 'F';
                            break;
                        case 'I':
                            V.labyrinthMatrix[i, j] = 'I';
                            V.labEnter.Add(new Point(j, i));
                            break;
                        case 'E':
                            V.labyrinthMatrix[i, j] = 'E';
                            V.labExit.Add(new Point(j, i));
                            break;
                    }
                }
            }
        }

        public void FillLabyrinth(SpriteBatch sp)
        {
            Texture2D brick = C.brickGrass; // lo uso come brick defauld

            int[,] k = V.labyrinthMatrix;
            for (int i = 0; i < V.labyrinthMatrixRows; i++)
            {

                for (int j = 0; j < V.labyrinthMatrixColumns; j++)
                {
                    int dice = H.Random();
                    V.currentBrickPosition = new Point(j, i);
                    switch (V.labyrinthMatrix[i, j])
                    {
                        case '0':
                            
                            brick = C.brickGrass;
                            V.mapList.Add(new Map(brick)
                            {
                                Position = H.ToVector2(H.BrickPosition()),
                                ID = '0',
                            });

                            break;
                        case '1':
                            brick = C.brickWall;


                            V.mapList.Add(new Map(brick)
                            {
                                Position = H.ToVector2(H.BrickPosition()),
                                ID = '1',
                            });

                            break;
                        case 'I':
                            brick = C.brickStart;

                            V.mapList.Add(new Map(brick)
                            {
                                Position = H.ToVector2(H.BrickPosition()),
                                ID = 'I',
                            });
                            break;
                        case 'L':
                            brick = C.brickLava;

                            V.mapList.Add(new Map(brick)
                            {
                                Position = H.ToVector2(H.BrickPosition()),
                                ID = 'L',
                            });
                            break;
                        case 'F':
                            brick = C.brickEnd2;

                            V.mapList.Add(new Map(brick)
                            {
                                Position = H.ToVector2(H.BrickPosition()),
                                ID = 'F',
                            });
                            break;
                        case 'D':
                            brick = C.brickDiamond;

                            V.mapList.Add(new Map(brick)
                            {
                                Position = H.ToVector2(H.BrickPosition()),
                                ID = 'D',
                            });
                            break;
                        case 'E':
                            brick = C.brickEnd;

                            V.mapList.Add(new Map(brick)
                            {
                                Position = H.ToVector2(H.BrickPosition()),
                                ID = 'E',
                            });
                            break;

                        case 'C':

                            brick = C.brickGrass;
                            V.mapList.Add(new Map(brick)
                            {
                                Position = H.ToVector2(H.BrickPosition()),
                                ID = 'C',
                            });

                            V.cannonList.Add(new Cannon(V.cannonTexture)
                            {
                                Position = H.ToVector2(H.BrickPosition()),
                            });
                            break;
                    }
                }
            }
        }
    }
}
