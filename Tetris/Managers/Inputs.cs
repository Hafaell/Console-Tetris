using System;
using System.Threading;

namespace Tetris.Managers
{
    class Inputs
    {
        GameManager gameManager;

        public Inputs()
        {
            gameManager = GameManager.GetInstance();
        }

        public void HandleInput()
        {
            while (true)
            {
                var read = Console.ReadKey(true);

                switch (read.Key)
                {
                    case ConsoleKey.UpArrow:
                        gameManager.CurrentObject.Rotate();
                        break;

                    case ConsoleKey.R:
                        if (gameManager.Lose)
                            GameManager.RestartGame_ACT?.Invoke();
                        break;

                    case ConsoleKey.DownArrow:
                        gameManager.CurrentObject.Down();
                        break;

                    case ConsoleKey.LeftArrow:
                        gameManager.CurrentObject.Left();
                        break;

                    case ConsoleKey.RightArrow:
                        gameManager.CurrentObject.Right();
                        break;
                }

                Thread.Sleep(5);
            }
        }

    }
}
