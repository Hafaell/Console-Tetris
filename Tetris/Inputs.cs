using System;
using System.Threading;

namespace Tetris
{
    class Inputs
    {
        GameManager gameManager;

        public Inputs()
        {
            gameManager = GameManager.instance;
        }

        public void HandleInput()
        {
            new Thread(() =>
            {
                while (true)
                {
                    var read = Console.ReadKey(true);

                    switch (read.Key)
                    {
                        case ConsoleKey.UpArrow:
                            gameManager.currentObject.Rotate();
                            break;

                        case ConsoleKey.DownArrow:
                            gameManager.currentObject.Down();
                            break;

                        case ConsoleKey.LeftArrow:
                            gameManager.currentObject.Left();
                            break;

                        case ConsoleKey.RightArrow:
                            gameManager.currentObject.Right();
                            break;
                    }

                    Thread.Sleep(5);
                }
            }).Start();
        }

    }
}
