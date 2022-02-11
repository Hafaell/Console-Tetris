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
        public List<Cordenada> Coordinates { get => coordinates; }

        public TetrisObjects(List<Cordenada> coordList, string caracterType, ConsoleColor consoleColor)
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
        private Collisions collision;
        private List<Cordenada> coordinates;

        public void Rotate()
        {
            
        }

        public void Right()
        {
            if (lockObject || coordinates.Any(corden => corden.X == UI.GetGrid().borderX - 1))
                return;

            MovementX(1);
        }

        public void Left()
        {
            if (lockObject || coordinates.Any(corden => corden.X == UI.GetGrid().posX))
                return;

            MovementX(-1);
        }

        public void Down()
        {
            if (coordinates.Any(corden => corden.Y == UI.GetGrid().borderY - 1))
            {
                lockObject = true;
                return;
            }

            MovementY(1);
        }

        private void MovementX(int value)
        {
            if (collision.IsColisao(value, 0))
                return;

            foreach (var item in coordinates)
            {
                item.X += value;
            }
        }

        public void MovementY(int value)
        {
            if (collision.IsColisao(0, value))
            {
                lockObject = true;
                return;
            }

            foreach (var item in coordinates)
            {
                item.Y += value;
            }
        }
    }
}
