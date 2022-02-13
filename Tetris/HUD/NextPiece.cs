using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Managers;
using Tetris.Pieces;

namespace Tetris.HUD
{
    class NextPiece
    {
        public Vector2 position;
        public Vector2 size;

        private string branco = "I";

        private int midX;
        private int midy;

        public NextPiece(Vector2 position, Vector2 size)
        {
            int borderX = size.x + position.x;
            int borderY = size.y + position.y;

            this.position = position;
            this.size = new Vector2(borderX, borderY);

            midX = position.x + (this.size.x - position.x) / 2;
            midy = position.y + (this.size.y - position.y) / 2;
        }

        public void DrawNextPiece()
        {
            DrawNextPieces();
        }

        private void ClearGrid()
        {
            for (int i = position.x; i < size.x; i++)
            {
                for (int j = position.y; j < size.y; j++)
                {
                    Console.SetCursorPosition(i, j);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("");
                }
            }
        }

        private void DrawNextPieces()
        {
            for (int i = position.x; i < size.x; i++)
            {
                for (int j = position.y; j < size.y; j++)
                {
                    Console.SetCursorPosition(i, j);

                    if (i == size.x - 1 || i == position.x
                        || j == size.y - 1 || j == position.y)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(branco);
                        continue;
                    }

                    if (!GameManager.instance.NextObject.Coordinates[0].Any(coords => coords.x == i && coords.y - 1 == j))
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(" ");
                        continue;
                    }

                    Console.ForegroundColor = GameManager.instance.NextObject.Color;
                    Console.Write(GameManager.instance.NextObject.Caracter);
                }
            }
        }
    }
}
