using System;
using System.Collections.Generic;
using Tetris.HUD;
using Tetris.Managers;

namespace Tetris.Pieces
{
    class Zpiece : TetrisObjects
    {
        private static int mid = UI.GetGrid().position.x + (UI.GetGrid().size.x - UI.GetGrid().position.x) / 2 - 1;
        private static int posY = UI.GetGrid().position.y;

        public Zpiece() : base(

            new List<List<Vector2>> {

                new List<Vector2>
                {
                    new Vector2(mid, posY),
                    new Vector2(mid + 1, posY),
                    new Vector2(mid, posY + 1),
                    new Vector2(mid - 1, posY + 1)
                },

                new List<Vector2>
                {
                    new Vector2(mid, posY),
                    new Vector2(mid, posY + 1),
                    new Vector2(mid + 1, posY + 1),
                    new Vector2(mid + 1, posY + 2)
                },
            }

            , "&", ConsoleColor.Green)
        { }
    }
}
