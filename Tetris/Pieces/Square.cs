using System;
using System.Collections.Generic;

namespace Tetris.Pieces
{
    public class Square : TetrisObjects
    {
        public Square() : base(new List<Cordenada>() {
            new Cordenada(3, 0),
            new Cordenada(4, 0),
            new Cordenada(3, 1),
            new Cordenada(4, 1)
        }, "@", ConsoleColor.Yellow){ }
    }
}
