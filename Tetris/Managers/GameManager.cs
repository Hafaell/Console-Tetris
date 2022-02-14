using System;
using System.Collections.Generic;
using System.Linq;
using Tetris.HUD;
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

        public int Points { get => points; }
        public int Score { get => score; }
        public List<TetrisObjects> Objects { get => objects; }
        public TetrisObjects CurrentObject { get => currentObject; }
        public TetrisObjects NextObject { get => nextObject; }

        private PieceTypes piceTypes;
        private TetrisObjects currentObject;
        private TetrisObjects nextObject;

        private bool lose;
        private bool isRealTime;

        private int score;
        private int points;
        private int initialPoints = 0;

        private List<TetrisObjects> objects = new List<TetrisObjects>();

        public static GameManager instance = null;

        public void AddObjects()
        {
            ResetPositionObjsToGrid();

            objects.Add(currentObject);
            SelectNextObject();
        }

        public void SelectNextObject()
        {
            int midX = UI.GetNextPiece().position.x + (UI.GetNextPiece().size.x - UI.GetNextPiece().position.x) / 2;
            int posY = UI.GetNextPiece().position.y + (UI.GetNextPiece().size.y - UI.GetNextPiece().position.y) / 2;

            Random rand = new Random();
            piceTypes = (PieceTypes)rand.Next(0, 4);

            switch (piceTypes)
            {
                case PieceTypes.Lpiece:
                    nextObject = new Lpiece(midX, posY);
                    break;

                case PieceTypes.Zpiece:
                    nextObject = new Zpiece(midX, posY);
                    break;

                case PieceTypes.Rectange:
                    nextObject = new Rectangle(midX, posY);
                    break;

                case PieceTypes.Square:
                    nextObject = new Square(midX, posY);
                    break;
            }
        }

        private void ResetPositionObjsToGrid()
        {
            int midX = UI.GetGrid().position.x + (UI.GetGrid().size.x - UI.GetGrid().position.x) / 2 - 1;
            int posY = UI.GetGrid().position.y;

            currentObject = nextObject;

            int diferenceX = midX - currentObject.Coordinates[0][0].x;
            int diferenceY = posY - currentObject.Coordinates[0][0].y;

            foreach (var item in currentObject.Coordinates)
            {
                foreach (var coords in item)
                {
                    coords.x += diferenceX;
                    coords.y += diferenceY;
                }
            }
        }

        public void ResetGame()
        {
            objects.Clear();

            SelectNextObject();
            AddObjects();

            points = initialPoints;

            lose = false;
            Console.Clear();
        }

        public void Scored()
        {
            points++;

            if (points > score)
            {
                score = points;
            }
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
