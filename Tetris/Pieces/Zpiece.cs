using System;
using System.Collections.Generic;
using Tetris.HUD;
using Tetris.Managers;

namespace Tetris.Pieces
{
    class Zpiece : TetrisObjects
    {
        private static int mid = UI.GetGrid().posX + (UI.GetGrid().borderX - UI.GetGrid().posX) / 2 - 1;
        private static int posY = UI.GetGrid().posY;

        public Zpiece() : base(

            new List<List<Cordenada>> {

                new List<Cordenada>
                {
                    new Cordenada(mid, posY),
                    new Cordenada(mid + 1, posY),
                    new Cordenada(mid, posY + 1),
                    new Cordenada(mid - 1, posY + 1)
                },

                new List<Cordenada>
                {
                    new Cordenada(mid, posY),
                    new Cordenada(mid, posY + 1),
                    new Cordenada(mid + 1, posY + 1),
                    new Cordenada(mid + 1, posY + 2)
                },
            }

            , "*", ConsoleColor.Green)
        { }
    }
}
