using System;
using System.Collections.Generic;
using Tetris.HUD;
using Tetris.Managers;

namespace Tetris.Pieces
{
    public class Square : TetrisObjects
    {
        private static int mid = UI.GetGrid().position.x + (UI.GetGrid().size.x - UI.GetGrid().position.x) / 2 - 1;
        private static int posY = UI.GetGrid().position.y;

        public Square() : base(

            new List<List<Vector2>> {

                new List<Vector2>
                {
                    new Vector2(mid, 0 + posY),
                    new Vector2(mid, 1 + posY),
                    new Vector2(mid + 1, 0 + posY),
                    new Vector2(mid + 1, 1 + posY)
                }

            }

            , "@", ConsoleColor.Yellow)
        { }
    }
}
