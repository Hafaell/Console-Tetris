using System;
using System.Collections.Generic;
using Tetris.HUD;
using Tetris.Managers;

namespace Tetris.Pieces
{
    public class Square : TetrisObjects
    {
        public Square(int mid, int posY) : base(

            new List<List<Vector2>> {

                new List<Vector2>
                {
                    new Vector2(mid, 0 + posY),
                    new Vector2(mid, 1 + posY),
                    new Vector2(mid + 1, 0 + posY),
                    new Vector2(mid + 1, 1 + posY)
                }

            },

           "@", ConsoleColor.Yellow)
        { }
    }
}
