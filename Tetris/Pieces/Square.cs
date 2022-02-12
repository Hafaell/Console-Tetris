using System;
using System.Collections.Generic;
using Tetris.HUD;
using Tetris.Managers;

namespace Tetris.Pieces
{
    public class Square : TetrisObjects
    {
        private static int mid = UI.GetGrid().posX + (UI.GetGrid().borderX - UI.GetGrid().posX) / 2 - 1;
        private static int posY = UI.GetGrid().posY;

        public Square() : base(new List<Cordenada>() {
            new Cordenada(mid, 0 + posY),
            new Cordenada(mid, 1 + posY),
            new Cordenada(mid + 1, 0 + posY),
            new Cordenada(mid + 1, 1 + posY)
        }, "@", ConsoleColor.Yellow){ }
    }
}
