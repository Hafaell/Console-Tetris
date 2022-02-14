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
                    case ConsoleKey.X:
                        gameManager.CurrentObject.Rotate(1);
                        break;

                    case ConsoleKey.Z:
                        gameManager.CurrentObject.Rotate(-1);
                        break;

                    case ConsoleKey.R:

                        if (gameManager.Lose)
                            gameManager.ResetGame();
                        break;

                    case ConsoleKey.DownArrow:

                        if (gameManager.IsRealTime)
                            gameManager.CurrentObject.Down();
                        break;

                    case ConsoleKey.LeftArrow:
                        gameManager.CurrentObject.Left();
                        break;

                    case ConsoleKey.RightArrow:
                        gameManager.CurrentObject.Right();
                        break;

                    case ConsoleKey.Tab:
                        gameManager.IsRealTime = !gameManager.IsRealTime;
                        Console.Clear();
                        break;
                }

                if (!gameManager.IsRealTime)
                    gameManager.CurrentObject.Down();

                Thread.Sleep(5);
            }
        }

    }
}
