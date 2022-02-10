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
        public static List<TetrisObjects> ObjectsLock { get => objectsLock; }

        private string[,] currentGrid;
        private string branco = "-";
        private List<TetrisObjects> objects = new List<TetrisObjects>();
        private static List<TetrisObjects> objectsLock = new List<TetrisObjects>();
        public TetrisObjects currentObject;
        public TetrisObjects nextObject;

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
                        TetrisObjects index = null;

                        foreach (var item in objects)
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

        public void AddObjects(TetrisObjects obj)
        {
            currentObject = obj;
            objects.Add(obj);
            NextObject();
        }

        public void AddObjectsLock(TetrisObjects obj)
        {
            objectsLock.Add(obj);
        }

        public void NextObject()
        {
            Random rand = new Random();
            int randomNumber = rand.Next(0, 10);

            if (randomNumber < 5)
            {
                nextObject = new Rectangle();
            }
            else
            {
                nextObject = new Square();
            }
        }
    }
}
