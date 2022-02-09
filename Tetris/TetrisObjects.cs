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
            if (lockObject || coordinates.Any(corden => corden.X == Grid.X - 1) )
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
            if(coordinates.Any(corden => corden.Y == Grid.Y - 1))
            {
                lockObject = true;
                return;
            }

            MovementY(1);
        }

        private void MovementX(int value)
        {
            foreach (var item in coordinates)
            {
                item.X += value;
            }
        }

        private void MovementY(int value)
        {
            foreach (var item in coordinates)
            {
                item.Y += value;
            }
        }
    }
}
