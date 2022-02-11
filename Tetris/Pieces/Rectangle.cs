using System;
using System.Collections.Generic;
using Tetris.HUD;
using Tetris.Managers;

namespace Tetris.Pieces
{
    class Rectangle : TetrisObjects
    {
        public Rectangle() : base(new List<Cordenada>() {
            new Cordenada(4 + UI.GetGrid().posX, 0 + UI.GetGrid().posY),
            new Cordenada(4 + UI.GetGrid().posX, 1 + UI.GetGrid().posY),
            new Cordenada(4 + UI.GetGrid().posX, 2 + UI.GetGrid().posY),
            new Cordenada(4 + UI.GetGrid().posX, 3 + UI.GetGrid().posY)
        }, "#", ConsoleColor.Blue)
        { }
    }
}
