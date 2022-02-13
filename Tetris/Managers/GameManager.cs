using System;
using System.Collections.Generic;
using System.Linq;
using Tetris.Pieces;

namespace Tetris.Managers
{
    public enum PieceTypes
    {
        Zpiece, Lpiece, Rectange, Square
    }

    class GameManager
    {
        public bool Lose { get => lose; set => lose = value; }
        public bool IsRealTime { get => isRealTime; set => isRealTime = value; }

        public List<TetrisObjects> Objects { get => objects; }
        public TetrisObjects CurrentObject { get => currentObject; }
        public TetrisObjects NextObject { get => nextObject; }

        private PieceTypes piceTypes;
        private TetrisObjects currentObject;
        private TetrisObjects nextObject;

        private bool lose;
        private bool isRealTime;

        private List<TetrisObjects> objects = new List<TetrisObjects>();

        public static GameManager instance = null;
        public static Action RestartGame_ACT;

        private GameManager()
        {
            RestartGame_ACT += ResetGame;
        }

        public void AddObjects(TetrisObjects obj)
        {
            currentObject = obj;
            objects.Add(obj);
            SelectNextObject();
        }

        public void SelectNextObject()
        {
            Random rand = new Random();
            piceTypes = (PieceTypes)rand.Next(0, 4);

            switch (piceTypes)
            {
                case PieceTypes.Lpiece:
                    nextObject = new Lpiece();
                    break;

                case PieceTypes.Zpiece:
                    nextObject = new Zpiece();
                    break;

                case PieceTypes.Rectange:
                    nextObject = new Rectangle();
                    break;

                case PieceTypes.Square:
                    nextObject = new Square();
                    break;
            }
        }

        public void ResetGame()
        {
            Console.Clear();
            objects.Clear();

            SelectNextObject();
            AddObjects(NextObject);

            lose = false;
        }

        public IEnumerable<TetrisObjects> ObjectsLock()
        {
            var objects = Objects.Where(obj => obj.LockObject == true);

            return objects;
        }

        public static GameManager GetInstance()
        {
            if (instance == null)
            {
                instance = new GameManager();
            }

            return instance;
        }
    }
}
