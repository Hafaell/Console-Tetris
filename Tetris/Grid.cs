using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class Grid
    {

        public Grid(int x, int y)
        {
            int[,] grid = new int[x, y];

            for (int yy = 0; yy < y; yy++)
            {
                for (int xx = 0; xx < x; xx++)
                {
                    Console.Write("_");
                }
                Console.Write("\n");
            }
        }
    }
}
