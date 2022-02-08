using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class Objeto
    {
        public Objeto(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public char[,] Caracteres { get; set; }
    }

    public class NewObject : Objeto
    {
        public NewObject(char[,] matriz, int x, int y) : base (x,y)
        {
            Caracteres = matriz;
        }
    }
}
