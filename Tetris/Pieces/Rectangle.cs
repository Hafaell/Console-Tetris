using System;
using System.Collections.Generic;
using Tetris.HUD;
using Tetris.Managers;

namespace Tetris.Pieces
{
    class Rectangle : TetrisObjects
    {
        private static int mid = UI.GetGrid().posX + (UI.GetGrid().borderX - UI.GetGrid().posX) / 2 - 1;
        private static int posY = UI.GetGrid().posY;

        public Rectangle() : base(

            new List<List<Cordenada>> {

            new List<Cordenada>
            {
                new Cordenada(mid, 0 + posY),
                new Cordenada(mid, 1 + posY),
                new Cordenada(mid, 2 + posY),
                new Cordenada(mid, 3 + posY)
            },

            new List<Cordenada>
            {
                new Cordenada(mid - 1, posY + 4),
                new Cordenada(mid, posY + 4),
                new Cordenada(mid + 1, posY + 4),
                new Cordenada(mid + 2, posY + 4)
            },
        } 
            , "#", ConsoleColor.Blue, 0)
        {}
    }
}
