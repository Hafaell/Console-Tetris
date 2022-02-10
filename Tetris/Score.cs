using System;
using System.Collections.Generic;
using System.Linq;
using Tetris.Pieces;

namespace Tetris
{
    class Score
    {
        private int score;
        GameManager gameManager;

        public Score()
        {
            score = 0;
            gameManager = GameManager.instance;
            DrawScore();
        }

        public void DrawScore()
        {
            Console.SetCursorPosition(15, 7);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"Score: {score}");
        }

        public void CompleteLine()
        {
            for (int y = Grid.Y - 1; y > 0; y--)
            {
                int erros = 0;

                for (int x = 0; x < Grid.X; x++)
                {
                    if (erros != 0)
                        continue;

                    erros = VerifyLine(erros, x, y);

                    if (erros != 0)
                        continue;

                    if (x == Grid.X - 1)
                    {
                        ClearLine(Grid.X, y);
                    }
                }
            }
        }

        private int VerifyLine(int erros, int x, int y)
        {
            foreach (var item in gameManager.ObjectsLock)
            {
                if (item.Coordinates.Any(cord => cord.X == x && cord.Y == y))
                    return erros;
            }

            erros++;
            return erros;
        }

        private void ClearLine(int x, int y)
        {
            bool needUpdate = false;
            int indexYupdate = 0;

            for (int xLinha = 0; xLinha < x; xLinha++)
            {
                foreach (var item in gameManager.ObjectsLock)
                {
                    Clear(item, xLinha);
                }
            }

            if (!needUpdate)
                return;

            UpdateLockObj(indexYupdate);
            CompleteLine();

            void Clear(TetrisObjects item, int xLinha)
            {
                if (item.Coordinates.Count > 0)
                {
                    if (item.Coordinates.Any(cord => cord.X == xLinha && cord.Y == y))
                    {
                        for (int i = 0; i < item.Coordinates.Count; i++)
                        {
                            if (item.Coordinates[i].X == xLinha
                                && item.Coordinates[i].Y == y)
                            {
                                item.Coordinates.RemoveAt(i);
                                needUpdate = true;
                                indexYupdate = y;
                                score++;
                            }
                        }
                    }
                }
            }
        }

        void UpdateLockObj(int indexYupdate)
        {
            foreach (var item in gameManager.ObjectsLock)
            {
                foreach (var coord in item.Coordinates)
                {
                    if (coord.Y < indexYupdate)
                    {
                        coord.Y++;
                    }
                }
            }
        }
    }
}
