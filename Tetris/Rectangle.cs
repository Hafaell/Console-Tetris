using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class Rectangle : TetrisObjects
    {
        public Rectangle() : base(new List<Cordenada>() {
            new Cordenada(0, 0),
            new Cordenada(0, 1),
            new Cordenada(0, 2),
            new Cordenada(0, 3)
        }, "#")
        { }
    }
}
