using System;
using System.Collections.Generic;
using Tetris.HUD;
using Tetris.Managers;

namespace Tetris.Pieces
{
    class Lpiece : TetrisObjects
    {
        private static int mid = UI.GetGrid().position.x + (UI.GetGrid().size.x - UI.GetGrid().position.x) / 2 - 1;
        private static int posY = UI.GetGrid().position.y;

        public Lpiece() : base(

            new List<List<Vector2>> {

                new List<Vector2>
                {
                    new Vector2(mid, posY),
                    new Vector2(mid, posY + 1),
                    new Vector2(mid, posY + 2),
                    new Vector2(mid, posY + 3),
                    new Vector2(mid + 1, posY + 3)
                },

                new List<Vector2>
                {
                    new Vector2(mid + 2, posY + 3),
                    new Vector2(mid + 1, posY + 3),
                    new Vector2(mid, posY + 3),
                    new Vector2(mid - 1, posY + 3),
                    new Vector2(mid - 1, posY + 4)
                },

                new List<Vector2>
                {
                    new Vector2(mid, posY + 3),
                    new Vector2(mid, posY + 2),
                    new Vector2(mid, posY + 1),
                    new Vector2(mid, posY),
                    new Vector2(mid - 1, posY)
                },

                new List<Vector2>
                {
                    new Vector2(mid - 1, posY + 3),
                    new Vector2(mid, posY + 3),
                    new Vector2(mid + 1, posY + 3),
                    new Vector2(mid + 2, posY + 3),
                    new Vector2(mid + 2, posY + 2)
                }

            },

            "%", ConsoleColor.Magenta)
        { }
    }
}
