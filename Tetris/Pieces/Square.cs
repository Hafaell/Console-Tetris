using System;
using System.Collections.Generic;
using Tetris.HUD;
using Tetris.Managers;

namespace Tetris.Pieces
{
    public class Square : TetrisObjects
    {
        public Square() : base(new List<Cordenada>() {
            new Cordenada(3 + UI.GetGrid().posX, 0 + UI.GetGrid().posY),
            new Cordenada(4 + UI.GetGrid().posX, 0 + UI.GetGrid().posY),
            new Cordenada(3 + UI.GetGrid().posX, 1 + UI.GetGrid().posY),
            new Cordenada(4 + UI.GetGrid().posX, 1 + UI.GetGrid().posY)
        }, "@", ConsoleColor.Yellow){ }
    }
}
