using System;
using System.Collections.Generic;
using Tetris.Pieces;

namespace Tetris
{
    public enum PieceTypes
    {
        Zpiece, Lpiece, Rectange, Square
    }

    class GameManager
    {
        public List<TetrisObjects> Objects { get => objects; }
        public List<TetrisObjects> ObjectsLock { get => objectsLock; }

        public TetrisObjects currentObject;
        public TetrisObjects nextObject;

        private PieceTypes piceTypes;

        private List<TetrisObjects> objects = new List<TetrisObjects>();
        private List<TetrisObjects> objectsLock = new List<TetrisObjects>();

        public static GameManager instance = null;

        public void AddObjects(TetrisObjects obj)
        {
            
            currentObject = obj;
            objects.Add(obj);
            NextObject();
        }

        public void AddObjectsLock(TetrisObjects obj)
        {
            objectsLock.Add(obj);
        }

        public void NextObject()
        {
            Random rand = new Random();
            piceTypes = (PieceTypes)rand.Next(0, 4);

            switch (piceTypes)
            {
                case PieceTypes.Lpiece:
                    nextObject = new Lpiece();
                    break;

                case PieceTypes.Zpiece:
                    nextObject = new Square();
                    break;

                case PieceTypes.Rectange:
                    nextObject = new Rectangle();
                    break;

                case PieceTypes.Square:
                    nextObject = new Square();
                    break;
            }
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
