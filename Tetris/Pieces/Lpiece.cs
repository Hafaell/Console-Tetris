using System;
using System.Collections.Generic;
using Tetris.HUD;
using Tetris.Managers;

namespace Tetris.Pieces
{
    class Lpiece : TetrisObjects
    {
        static int a = UI.GetGrid().borderX;

        public Lpiece() : base(new List<Cordenada>() {
            new Cordenada((UI.GetGrid().borderX / 2) + UI.GetGrid().posX, 0 + UI.GetGrid().posY),
            new Cordenada(4 + UI.GetGrid().posX, 1 + UI.GetGrid().posY),
            new Cordenada(4 + UI.GetGrid().posX, 2 + UI.GetGrid().posY),
            new Cordenada(4 + UI.GetGrid().posX, 3 + UI.GetGrid().posY),
            new Cordenada(5 + UI.GetGrid().posX, 3 + UI.GetGrid().posY)
        }, "%", ConsoleColor.Magenta)
        { }
    }
}
