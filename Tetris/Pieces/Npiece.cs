using System;
using System.Collections.Generic;
using Tetris.Managers;

namespace Tetris.Pieces
{
    class Npiece : TetrisObjects
    {
        public Npiece(int mid, int posY) : base(

            new List<List<Vector2>> {

                new List<Vector2>
                {
                    new Vector2(mid, posY),
                    new Vector2(mid, posY + 1),
                    new Vector2(mid + 1, posY),
                    new Vector2(mid + 1, posY - 1)
                },

                new List<Vector2>
                {
                    new Vector2(mid, posY),
                    new Vector2(mid, posY + 1),
                    new Vector2(mid - 1, posY),
                    new Vector2(mid + 1, posY + 1)
                },
            },

            "&", ConsoleColor.Red)
        { }
    }
}
