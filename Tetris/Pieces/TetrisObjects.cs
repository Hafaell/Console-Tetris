using System;
using System.Collections.Generic;
using System.Linq;
using Tetris.HUD;
using Tetris.Managers;

namespace Tetris.Pieces
{
    public class TetrisObjects
    {
        public string Caracter { get => caracter; }
        public bool LockObject { get => lockObject; }
        public ConsoleColor Color { get => color; }
        public int IndexRotate { get => indexRotate; }
        public List<List<Vector2>> Coordinates { get => coordinates; }

        public TetrisObjects(List<List<Vector2>> coordList, string caracterType, ConsoleColor consoleColor)
        {
            gameManager = GameManager.GetInstance();

            this.coordinates = coordList;
            this.caracter = caracterType;
            this.color = consoleColor;

            collision = new Collisions();
        }

        GameManager gameManager;

        private ConsoleColor color;
        private string caracter;
        private bool lockObject;
        private int indexRotate;

        private Collisions collision;
        private List<List<Vector2>> coordinates;

        public void Rotate(int value)
        {
            if (lockObject)
                return;

            int nextIndexRotate = indexRotate + value;

            if (nextIndexRotate == coordinates.Count)
            {
                nextIndexRotate = 0;
            }

            if (nextIndexRotate == - 1)
            {
                nextIndexRotate = coordinates.Count - 1;
            }

            if (coordinates[nextIndexRotate].Any(corden => corden.x == UI.GetGrid().size.x))
                return;
            else if (coordinates[nextIndexRotate].Any(corden => corden.x == UI.GetGrid().position.x - 1))
                return;
            else if (collision.IsColision(value, 0, nextIndexRotate))
                return;

            indexRotate = nextIndexRotate;
        }


        public void Right()
        {
            if (lockObject || coordinates[indexRotate].Any(corden => corden.x == UI.GetGrid().size.x - 1))
                return;

            MovementX(1);
        }

        public void Left()
        {
            if (lockObject || coordinates[indexRotate].Any(corden => corden.x == UI.GetGrid().position.x))
                return;

            MovementX(-1);
        }

        public void Down()
        {
            if (coordinates[indexRotate].Any(corden => corden.y == UI.GetGrid().size.y - 1))
            {
                lockObject = true;
                return;
            }

            MovementY(1);
        }

        private void MovementX(int value)
        {
            if (collision.IsColision(value, 0))
                return;

            foreach (var item in coordinates)
            {
                foreach (var coord in item)
                {
                    coord.x += value;
                }
            }
        }

        public void MovementY(int value)
        {
            if (collision.IsColision(0, value))
            {
                lockObject = true;
                return;
            }

            foreach (var item in coordinates)
            {
                foreach (var coord in item)
                {
                    coord.y += value;
                }
            }
        }
    }
}
