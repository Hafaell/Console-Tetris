using System;
using System.Linq;
using Tetris.Pieces;
using Tetris.HUD;
using Tetris.Managers;

namespace Tetris
{
    class Score
    {
        private int posX = 15, posY = 7;
        private int score;
        private int initialScore = 0;
        private int rotateIndex;

        public Score()
        {
            score = initialScore;
            GameManager.RestartGame_ACT += RestartScore;
            rotateIndex = GameManager.instance.CurrentObject.IndexRotate;
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
            if (GameManager.instance.CurrentObject.Coordinates[rotateIndex].Any(coord => coord.Y == UI.GetGrid().posY))
            {
                var a = UI.GetGrid().borderY - UI.GetGrid().posY;
                GameManager.instance.Lose = true;
                return;
            }

            for (int gridY = UI.GetGrid().borderY - 1; gridY > UI.GetGrid().posY; gridY--)
            {
                int scoreIndex = 0;

                foreach (var item in GameManager.instance.Objects.Where(obj => obj.LockObject == true))
                {
                    foreach (var coords in item.Coordinates[rotateIndex].Where(coord => coord.Y == gridY))
                    {
                        for (int gridX = UI.GetGrid().posX; gridX < UI.GetGrid().borderX; gridX++)
                        {
                            if (coords.X == gridX && coords.Y == gridY)
                                scoreIndex++;
                        }
                    }
                }

                if (scoreIndex == UI.GetGrid().borderX - UI.GetGrid().posX)
                    ClearLine(gridY);
            }
        }

        private void ClearLine(int y)
        {
            bool needUpdate = false;
            int indexYupdate = 0;

            for (int xLinha = UI.GetGrid().posX; xLinha < UI.GetGrid().borderX; xLinha++)
            {
                foreach (var item in GameManager.instance.Objects.Where(obj => obj.LockObject == true))
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
                if (item.Coordinates[rotateIndex].Any(cord => cord.X == xLinha && cord.Y == y))
                {
                    for (int i = 0; i < item.Coordinates[rotateIndex].Count; i++)
                    {
                        if (item.Coordinates[rotateIndex][i].X == xLinha
                            && item.Coordinates[rotateIndex][i].Y == y)
                        {
                            item.Coordinates[rotateIndex].RemoveAt(i);
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
            foreach (var item in GameManager.instance.Objects.Where(obj => obj.LockObject == true))
            {
                foreach (var coord in item.Coordinates[rotateIndex])
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

