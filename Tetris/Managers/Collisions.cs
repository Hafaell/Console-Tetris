using System.Linq;

namespace Tetris.Managers
{
    class Collisions
    {
        GameManager gameManager;

        public Collisions()
        {
            gameManager = GameManager.GetInstance();
        }

        public bool IsColision(int x, int y, int? nextIndexRotate = null)
        {
            foreach (var objLock in gameManager.ObjectsLock())
            {
                foreach (var objLockPos in objLock.Coordinates[objLock.IndexRotate])
                {
                    var possuiCordenada = false;


                    if (!nextIndexRotate.HasValue)
                        possuiCordenada = gameManager.CurrentObject.Coordinates[gameManager.CurrentObject.IndexRotate].Any(cordenada => cordenada.x + x == objLockPos.x && cordenada.y + y == objLockPos.y);
                    else
                        possuiCordenada = gameManager.CurrentObject.Coordinates[nextIndexRotate.Value].Any(cordenada => cordenada.x == objLockPos.x && cordenada.y == objLockPos.y);


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
