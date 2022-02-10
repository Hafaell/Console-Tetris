using System;
using System.Collections.Generic;
using System.Linq;

namespace Tetris
{
    public class TetrisObjects
    {
        public string Caracter { get => caracter; }
        public bool LockObject { get => lockObject; }
        public List<Cordenada> Coordinates { get => coordinates; }

        public TetrisObjects(List<Cordenada> coordList, string caracterType)
        {
            coordinates = coordList;
            caracter = caracterType;
        }

        private string caracter;
        private List<Cordenada> coordinates;
        private bool lockObject;

        public void Rotate()
        {

        }

        public void Right()
        {
            if (lockObject || coordinates.Any(corden => corden.X == Grid.X - 1))
                return;

            MovementX(1);
        }

        public void Left()
        {
            if (lockObject || coordinates.Any(corden => corden.X == 0))
                return;

            MovementX(-1);
        }

        public void Down()
        {
            if (coordinates.Any(corden => corden.Y == Grid.Y - 1))
            {
                lockObject = true;
                return;
            }

            MovementY(1);
        }

        private void MovementX(int value)
        {
            if (IsColisao(value, 0))
                return;

            foreach (var item in coordinates)
            {
                item.X += value;
            }
        }

        public void MovementY(int value)
        {
            if (IsColisao(0, value))
            {
                lockObject = true;
                return;
            }

            foreach (var item in coordinates)
            {
                item.Y += value;
            }
        }

        public bool IsColisao(int x, int y)
        {
            foreach (var objLock in Grid.ObjectsLock)
            {
                foreach (var objLockPos in objLock.Coordinates)
                {
                    var possuiCordenada = coordinates.Any(cordenada => cordenada.X + x == objLockPos.X && cordenada.Y + y == objLockPos.Y);

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
