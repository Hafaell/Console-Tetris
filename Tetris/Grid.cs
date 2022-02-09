using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class Grid
    {
        public int x = 10;
        public int y = 5;

        public Grid(char caractere)
        {
            int[,] grid = new int[x, y];

            for (int yy = 0; yy < y; yy++)
            {
                for (int xx = 0; xx < x; xx++)
                {
                    Console.Write(caractere);
                }
                Console.Write("\n");
            }
        }

        public static string[,] DrawObject(List<Cordenada> posicao)
        {
            int x = 10;
            int y = 7;

            var grid = new string[x, y];

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    foreach (var item in posicao)
                    {
                        if (item.X == j && item.Y == j)
                            grid[i, j] = "@";
                        else
                            grid[i, j] = "-";
                    }
                }
            }

            return grid;
        }

        public class Cordenada
        {
            public int X;
            public int Y;

            public Cordenada(int x, int y)
            {
                X = x;
                Y = y;
            }
        }
    }
}
