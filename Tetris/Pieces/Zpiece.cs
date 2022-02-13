using System;
using System.Collections.Generic;
using Tetris.HUD;
using Tetris.Managers;

namespace Tetris.Pieces
{
    class Zpiece : TetrisObjects
    {
        public Zpiece(int mid, int posY) : base(

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
            },

            "&", ConsoleColor.Green)
        { }
    }
}
