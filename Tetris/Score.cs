using System;
using System.Collections.Generic;
using System.Linq;

namespace Tetris
{
    class Score
    {
        public void CompleteLine()
        {
            for (int y = Grid.Y - 1; y > 0; y--)
            {
                int lineComplete = 0;

                for (int x = 0; x < Grid.X; x++)
                {
                    if (lineComplete != 0)
                        continue;

                    lineComplete = VerifyLine(lineComplete, x, y);

                    if (lineComplete != 0)
                        continue;

                    if (x == Grid.X - 1)
                    {
                        ClearLine(Grid.X, y);
                    }
                }
            }
        }

        private int VerifyLine(int lineComplete, int x, int y)
        {
            foreach (var item in Grid.ObjectsLock)
            {
                if (item.Coordinates.Any(cord => cord.X == x && cord.Y == y))
                    return lineComplete;
            }

            lineComplete++;
            return lineComplete;
        }

        private void ClearLine(int x, int y)
        {
            bool needUpdate = false;
            int indexYupdate = 0;

            for (int xLinha = 0; xLinha < x; xLinha++)
            {
                foreach (var item in Grid.ObjectsLock)
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
                            }
                        }
                    }
                }
            }

            if (!needUpdate)
                return;

            UpdateLockObj(indexYupdate);
            CompleteLine();
        }

        void UpdateLockObj(int indexYupdate)
        {
            foreach (var item in Grid.ObjectsLock)
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
