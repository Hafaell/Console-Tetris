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

        public bool IsColisao(int x, int y)
        {
            foreach (var objLock in gameManager.Objects.Where(obj => obj.LockObject == true))
            {
                foreach (var objLockPos in objLock.Coordinates[objLock.IndexRotate])
                {
                    var possuiCordenada = gameManager.CurrentObject.Coordinates[objLock.IndexRotate].Any(cordenada => cordenada.X + x == objLockPos.X && cordenada.Y + y == objLockPos.Y);

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
