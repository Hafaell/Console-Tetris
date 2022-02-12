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
        public List<List<Cordenada>> Coordinates { get => coordinates; }

        public TetrisObjects(List<List<Cordenada>> coordList, string caracterType, ConsoleColor consoleColor)
        {
            gameManager = GameManager.GetInstance();
            coordinates = coordList;
            caracter = caracterType;
            color = consoleColor;
            collision = new Collisions();
        }

        GameManager gameManager;

        private ConsoleColor color;
        private string caracter;
        private bool lockObject;
        private int indexRotate;

        private Collisions collision;
        private List<List<Cordenada>> coordinates;

        public void Rotate(int value)
        {
            if (lockObject)
                return;

            int aux = indexRotate + value;

            if (aux == coordinates.Count)
            {
                aux = 0;
            }

            if (aux == - 1)
            {
                aux = coordinates.Count - 1;
            }

            if (coordinates[aux].Any(corden => corden.X == UI.GetGrid().borderX))
                return;
            else if (coordinates[aux].Any(corden => corden.X == UI.GetGrid().posX - 1))
                return;
            else if (collision.IsColision(value, 0, true, aux))
                return;

            indexRotate = aux;
        }


        public void Right()
        {
            if (lockObject || coordinates[indexRotate].Any(corden => corden.X == UI.GetGrid().borderX - 1))
                return;

            MovementX(1);
        }

        public void Left()
        {
            if (lockObject || coordinates[indexRotate].Any(corden => corden.X == UI.GetGrid().posX))
                return;

            MovementX(-1);
        }

        public void Down()
        {
            if (coordinates[indexRotate].Any(corden => corden.Y == UI.GetGrid().borderY - 1))
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
                    coord.X += value;
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
                    coord.Y += value;
                }
            }
        }
    }
}
