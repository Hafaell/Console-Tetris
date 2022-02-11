using System;
using System.Collections.Generic;
using System.Linq;
using Tetris.Pieces;

namespace Tetris
{
    class Score
    {
        private int posX = 15, posY = 7;
        private int score;
        private int initialScore = 0;
        GameManager gameManager;

        public Score()
        {
            score = initialScore;
            gameManager = GameManager.GetInstance();
            GameManager.RestartGame_ACT += RestartScore;
            DrawScore();
        }

        private void RestartScore()
        {
            Console.Clear();
            score = initialScore;
        }

        public void DrawScore()
        {
            Console.SetCursorPosition(posX, posY);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"Score: {score}");
        }

        public void CompleteLine()
        {
            if (gameManager.CurrentObject.Coordinates.Any(coord => coord.Y == 0))
            {
                gameManager.Lose = true;
                return;
            }

            for (int gridY = Grid.Y - 1; gridY > 0; gridY--)
            {
                int scoreIndex = 0;

                foreach (var item in gameManager.Objects.Where(obj => obj.LockObject == true))
                {
                    foreach (var coords in item.Coordinates.Where(coord => coord.Y == gridY))
                    {
                        for (int gridX = 0; gridX < Grid.X; gridX++)
                        {
                            if (coords.X == gridX && coords.Y == gridY)
                                scoreIndex++;
                        }
                    }
                }

                if (scoreIndex == Grid.X)
                    ClearLine(gridY);
            }
        }

        private void ClearLine(int y)
        {
            bool needUpdate = false;
            int indexYupdate = 0;

            for (int xLinha = 0; xLinha < Grid.X; xLinha++)
            {
                foreach (var item in gameManager.Objects.Where(obj => obj.LockObject == true))
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

        void UpdateLockObj(int indexYupdate)
        {
            foreach (var item in gameManager.Objects.Where(obj => obj.LockObject == true))
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

