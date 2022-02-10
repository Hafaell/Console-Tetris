using System;
using System.Collections.Generic;

namespace Tetris.Pieces
{
    class Rectangle : TetrisObjects
    {
        public Rectangle() : base(new List<Cordenada>() {
            new Cordenada(4, 0),
            new Cordenada(4, 1),
            new Cordenada(4, 2),
            new Cordenada(4, 3)
        }, "#", ConsoleColor.Blue)
        { }
    }
}
