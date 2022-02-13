using System;
using System.Collections.Generic;
using Tetris.HUD;
using Tetris.Managers;

namespace Tetris.Pieces
{
    class Lpiece : TetrisObjects
    {
        public Lpiece(int mid, int posY) : base(

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
