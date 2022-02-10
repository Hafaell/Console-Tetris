using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Tetris.Pieces;

namespace Tetris
{
    public enum PieceTypes
    {
        Zpiece, Lpiece, Rectange, Square
    }

    public class Grid
    {
        public static int X { get; private set; }
        public static int Y { get; private set; }
        public static List<TetrisObjects> ObjectsLock { get => objectsLock; }

        public TetrisObjects currentObject;
        public TetrisObjects nextObject;

        private string[,] currentGrid;
        private string branco = "-";
        private List<TetrisObjects> objects = new List<TetrisObjects>();
        private static List<TetrisObjects> objectsLock = new List<TetrisObjects>();

        private PieceTypes piceTypes;

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
            piceTypes = (PieceTypes)rand.Next(0, 4);

            switch (piceTypes)
            {
                case PieceTypes.Lpiece:
                    nextObject = new Lpiece();
                    break;

                case PieceTypes.Zpiece:
                    nextObject = new Zpiece();
                    break;

                case PieceTypes.Rectange:
                    nextObject = new Rectangle();
                    break;

                case PieceTypes.Square:
                    nextObject = new Square();
                    break;
            }

        }

        
    }
}
