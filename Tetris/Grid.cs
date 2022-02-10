using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Tetris.Pieces;

namespace Tetris
{
    
    class Grid
    {
        public static int X { get; private set; }
        public static int Y { get; private set; }

        private string[,] currentGrid;
        private string branco = "-";

        GameManager gameManager;

        public Grid(int x, int y)
        {
            gameManager = GameManager.instance;

            X = x;
            Y = y;
            
            DrawGrid();
            Thread.Sleep(200);
        }

        public void DrawGrid()
        {
            var grid = new string[X, Y];

            if (gameManager.Objects.Count <= 0)
            {
                for (int i = 0; i < X; i++)
                {
                    for (int j = 0; j < Y; j++)
                    {
                        grid[i, j] = branco;
                    }
                }
            }
            else
            {
                for (int i = 0; i < X; i++)
                {
                    for (int j = 0; j < Y; j++)
                    {
                        Console.SetCursorPosition(i, j);

                        var possuiCordenada = false;
                        TetrisObjects index = null;

                        foreach (var item in gameManager.Objects)
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

            currentGrid = grid;
        }
    }
}
