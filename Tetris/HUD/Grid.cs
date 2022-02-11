using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Tetris.Managers;
using Tetris.Pieces;

namespace Tetris.HUD
{   
    class Grid
    {
        public int borderX { get; private set; }
        public int borderY { get; private set; }

        public int posX { get; }
        public int posY { get; } 

        private int sizeX;
        private int sizeY;

        private string branco = "-";

        public Grid(int sizeX, int sizeY, int posX, int posY)
        {
            this.sizeX = sizeX;
            this.sizeY = sizeY;

            this.posX = posX;
            this.posY = posY;

            borderX = sizeX + posX;
            borderY = sizeY + posY;
        }

        public void DrawGrid()
        {
            if (GameManager.instance.Objects.Count <= 0)
            {
                for (int i = posX; i < borderX; i++)
                {
                    for (int j = posY; j < borderY; j++)
                    {
                        Console.SetCursorPosition(i, j);
                        Console.Write(branco);
                    }
                }
            }
            else
            {
                for (int i = posX; i < borderX; i++)
                {
                    for (int j = posY; j < borderY; j++)
                    {
                        Console.SetCursorPosition(i, j);

                        var possuiCordenada = false;
                        TetrisObjects index = null;

                        foreach (var item in GameManager.instance.Objects)
                        {
                            possuiCordenada = item.Coordinates.Any(cordenada => cordenada.X == i && cordenada.Y == j);

                            if (possuiCordenada)
                            {
                                index = item;
                                break;
                            }
                        }

                        if (possuiCordenada)
                        {
                            Console.ForegroundColor = index.Color;
                            Console.Write(index.Caracter);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(branco);
                        }
                    }
                }
            }

        }
    }
}
