using System;
using System.Collections.Generic;
using Tetris.HUD;
using Tetris.Managers;

namespace Tetris.Pieces
{
    class Lpiece : TetrisObjects
    {
        private static int mid = UI.GetGrid().posX + (UI.GetGrid().borderX - UI.GetGrid().posX) / 2 - 1;
        private static int posY = UI.GetGrid().posY;

        public Lpiece() : base(

            new List<List<Cordenada>> {

                new List<Cordenada>
                {
                    new Cordenada(mid, posY),
                    new Cordenada(mid, posY + 1),
                    new Cordenada(mid, posY + 2),
                    new Cordenada(mid, posY + 3),
                    new Cordenada(mid + 1, posY + 3)
                },

                new List<Cordenada>
                {
                    new Cordenada(mid + 2, posY + 3),
                    new Cordenada(mid + 1, posY + 3),
                    new Cordenada(mid, posY + 3),
                    new Cordenada(mid - 1, posY + 3),
                    new Cordenada(mid - 1, posY + 4)
                },

                new List<Cordenada>
                {
                    new Cordenada(mid, posY + 3),
                    new Cordenada(mid, posY + 2),
                    new Cordenada(mid, posY + 1),
                    new Cordenada(mid, posY),
                    new Cordenada(mid - 1, posY)
                },

                new List<Cordenada>
                {
                    new Cordenada(mid - 1, posY + 3),
                    new Cordenada(mid, posY + 3),
                    new Cordenada(mid + 1, posY + 3),
                    new Cordenada(mid + 2, posY + 3),
                    new Cordenada(mid + 2, posY + 2)
                }

            },

            "%", ConsoleColor.Magenta)
        { }
    }
}
