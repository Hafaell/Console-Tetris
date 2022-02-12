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
            foreach (var objLock in gameManager.Objects.Where(obj => obj.LockObject == true))
            {
                foreach (var objLockPos in objLock.Coordinates[objLock.IndexRotate])
                {
                    var possuiCordenada = false;


                    if (!nextIndexRotate.HasValue)
                        possuiCordenada = gameManager.CurrentObject.Coordinates[gameManager.CurrentObject.IndexRotate].Any(cordenada => cordenada.X + x == objLockPos.X && cordenada.Y + y == objLockPos.Y);
                    else
                        possuiCordenada = gameManager.CurrentObject.Coordinates[nextIndexRotate.Value].Any(cordenada => cordenada.X == objLockPos.X && cordenada.Y == objLockPos.Y);


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
