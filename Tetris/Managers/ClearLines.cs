using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.HUD;

namespace Tetris.Managers
{
    class ClearLines
    {
        Score score;

        public ClearLines(Score score)
        {
            this.score = score;
        }

        public void ClearLinesCompleted()
        {
            var indexRotate = GameManager.instance.CurrentObject.IndexRotate;

            foreach (var item in GameManager.instance.ObjectsLock())
            {
                if (item.Coordinates[item.IndexRotate].Any(coord => coord.y == UI.GetGrid().position.y))
                {
                    GameManager.instance.Lose = true;
                    return;
                }
            }

            for (int gridY = UI.GetGrid().size.y - 1; gridY > UI.GetGrid().position.y; gridY--)
            {
                var isLineCompleted = true;

                for (int xLinha = UI.GetGrid().position.x; xLinha < UI.GetGrid().size.x; xLinha++)
                {
                    var possuiCoordenada = false;

                    foreach (var lockObject in GameManager.instance.ObjectsLock())
                    {
                        possuiCoordenada = lockObject.Coordinates[lockObject.IndexRotate].Any(coord => coord.x == xLinha && coord.y == gridY);

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
                    for (int xLinha = UI.GetGrid().position.x; xLinha < UI.GetGrid().size.x; xLinha++)
                    {
                        foreach (var lockObject in GameManager.instance.ObjectsLock())
                        {
                            var coordenada = lockObject.Coordinates[lockObject.IndexRotate].FirstOrDefault(coord => coord.x == xLinha && coord.y == gridY);
                            var possuiCoordenada = coordenada != null;

                            if (possuiCoordenada)
                            {
                                lockObject.Coordinates[lockObject.IndexRotate].Remove(coordenada);
                                score.Scored();
                            }
                        }
                    }

                    UpdateLockObj(gridY);
                    ClearLinesCompleted();
                }
            }

            foreach (var obj in GameManager.instance.ObjectsLock().ToList())
            {
                if (obj.Coordinates[obj.IndexRotate].Count == 0)
                {
                    GameManager.instance.Objects.Remove(obj);
                }
            }
        }

        void UpdateLockObj(int indexYupdate)
        {
            foreach (var item in GameManager.instance.ObjectsLock())
            {
                foreach (var coord in item.Coordinates[item.IndexRotate])
                {
                    if (coord.y < indexYupdate)
                    {
                        coord.y++;
                    }
                }
            }
        }
    }
}
