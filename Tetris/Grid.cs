using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class Grid
    {
        public static int X { get; private set; }
        public static int Y { get; private set; }
        private List<Objeto> objects = new List<Objeto>();
        public Objeto currentObject;
        private string[,] currentGrid;
        private string branco = "-";

        public Grid(int x, int y)
        {
            X = x; 
            Y = y;
            DrawGrid();
            Thread.Sleep(200);
        }

        public void DrawGrid()
        {
            var grid = new string[X, Y];

            if (objects.Count <= 0)
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
                        Objeto index = null;

                        foreach (var item in objects)
                        {
                            possuiCordenada = item.Cordenadas.Any(cordenada => cordenada.X == i && cordenada.Y == j);

                            if (possuiCordenada)
                            {
                                index = item;
                                break;
                            }
                        }

                        if (possuiCordenada)
                        {
                            Console.Write(index.Caracter);
                        }
                        else
                        {
                            Console.Write(branco);
                        }
                    }
                }
            }
                currentGrid = grid;
        }

        public void AddObjects(Objeto obj)
        {
            currentObject = obj;
            objects.Add(obj);
        }
    }
}
