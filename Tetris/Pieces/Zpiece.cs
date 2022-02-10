using System;
using System.Collections.Generic;

namespace Tetris.Pieces
{
    class Zpiece : TetrisObjects
    {
        public Zpiece() : base(new List<Cordenada>() {
            new Cordenada(4, 0),
            new Cordenada(5, 0),
            new Cordenada(4, 1),
            new Cordenada(3, 1)
        }, "*", ConsoleColor.Green)
        { }
    }
}
