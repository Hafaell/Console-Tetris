using System;
using System.Collections.Generic;
using Tetris.HUD;
using Tetris.Managers;

namespace Tetris.Pieces
{
    class Rectangle : TetrisObjects
    {
        public Rectangle(int mid, int posY) : base(

            new List<List<Vector2>> {

                new List<Vector2>
                {
                    new Vector2(mid, 0 + posY),
                    new Vector2(mid, 1 + posY),
                    new Vector2(mid, 2 + posY),
                    new Vector2(mid, 3 + posY)
                },

                new List<Vector2>
                {
                    new Vector2(mid - 1, posY + 4),
                    new Vector2(mid, posY + 4),
                    new Vector2(mid + 1, posY + 4),
                    new Vector2(mid + 2, posY + 4)
                },
            },

          "#", ConsoleColor.Blue)
        {}
    }
}
