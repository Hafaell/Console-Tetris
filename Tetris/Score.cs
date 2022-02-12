using System;
using System.Linq;
using Tetris.Pieces;
using Tetris.HUD;
using Tetris.Managers;
using System.Collections.Generic;

namespace Tetris
{
    class Score
    {
        private int posX = 15, posY = 7;
        private int score;
        private int initialScore = 0;
        //private int rotateIndex;

        public Score()
        {
            score = initialScore;
            GameManager.RestartGame_ACT += RestartScore;
            //rotateIndex = GameManager.instance.CurrentObject.IndexRotate;
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

        public void ClearLinesComplete()
        {
            var indexRotate = GameManager.instance.CurrentObject.IndexRotate;

            if (GameManager.instance.CurrentObject.Coordinates[indexRotate].Any(coord => coord.Y == UI.GetGrid().posY))
            {
                GameManager.instance.Lose = true;
                return;
            }

            var lockObjects = GameManager.instance.Objects.Where(obj => obj.LockObject == true);

            for (int gridY = UI.GetGrid().borderY - 1; gridY > UI.GetGrid().posY; gridY--)
            {
                var isLineCompleted = true;

                for(int xLinha = UI.GetGrid().posX; xLinha < UI.GetGrid().borderX; xLinha++)
                {
                    var possuiCoordenada = false;

                    foreach (var lockObject in lockObjects)
                    {
                        possuiCoordenada = lockObject.Coordinates[lockObject.IndexRotate].Any(coord => coord.X == xLinha && coord.Y == gridY);

                        if (possuiCoordenada)
                            break;
                    }

                    if (!possuiCoordenada)
                    {
                        isLineCompleted = false;
                        break;
                    }
                }

                if (isLineCompleted)
                {
                    for (int xLinha = UI.GetGrid().posX; xLinha < UI.GetGrid().borderX; xLinha++)
                    {
                        foreach (var lockObject in lockObjects)
                        {
                            var coordenada = lockObject.Coordinates[lockObject.IndexRotate].FirstOrDefault(coord => coord.X == xLinha && coord.Y == gridY);
                            var possuiCoordenada = coordenada != null;

                            if (possuiCoordenada)
                            {
                                lockObject.Coordinates[lockObject.IndexRotate].Remove(coordenada);
                                score++;
                            }
                        }
                    }

                    UpdateLockObj(gridY);
                }
            }

            foreach (var obj in lockObjects.ToList())
            {
                if (obj.Coordinates[obj.IndexRotate].Count == 0)
                {
                    GameManager.instance.Objects.Remove(obj);
                }
            }
        }

        void UpdateLockObj(int indexYupdate)
        {
            foreach (var item in GameManager.instance.Objects.Where(obj => obj.LockObject == true))
            {
                foreach (var coord in item.Coordinates[item.IndexRotate])
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

