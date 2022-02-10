using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class Collisions
    {
        GameManager gameManager;

        public Collisions()
        {
            gameManager = GameManager.instance;
        }

        public bool IsColisao(int x, int y)
        {
            foreach (var objLock in gameManager.ObjectsLock)
            {
                foreach (var objLockPos in objLock.Coordinates)
                {
                    var possuiCordenada = gameManager.currentObject.Coordinates.Any(cordenada => cordenada.X + x == objLockPos.X && cordenada.Y + y == objLockPos.Y);

                    if (possuiCordenada)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
