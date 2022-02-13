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
        public Vector2 position { get; }
        public Vector2 size { get; }

        private string branco = "-";

        public Grid(Vector2 position, Vector2 size)
        {
            int borderX = size.x + position.x;
            int borderY = size.y + position.y;

            this.position = position;
            this.size = new Vector2(borderX, borderY);
        }

        public void DrawGrid()
        {
            if (GameManager.instance.Objects.Count <= 0)
            {
                for (int i = position.x; i < size.x; i++)
                {
                    for (int j = position.y; j < size.y; j++)
                    {
                        Console.SetCursorPosition(i, j);
                        Console.Write(branco);
                    }
                }
            }
            else
            {
                for (int i = position.x; i < size.x; i++)
                {
                    for (int j = position.y; j < size.y; j++)
                    {
                        lock (GameManager.instance.Objects)
                        {
                            Console.SetCursorPosition(i, j);

                            var possuiCordenada = false;
                            TetrisObjects index = null;

                            foreach (var item in GameManager.instance.Objects.ToList())
                            {
                                possuiCordenada = item.Coordinates[item.IndexRotate].Any(cordenada => cordenada.x == i && cordenada.y == j);

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
}
