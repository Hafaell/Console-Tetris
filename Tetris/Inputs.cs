using System;
using System.Threading;

namespace Tetris
{
    public class Inputs
    {
        public Grid grid;

        public Inputs(Grid currentGrid)
        {
            grid = currentGrid;
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
                            grid.currentObject.Rotate();
                            break;

                        case ConsoleKey.DownArrow:
                            grid.currentObject.Down();
                            break;

                        case ConsoleKey.LeftArrow:
                            grid.currentObject.Left();
                            break;

                        case ConsoleKey.RightArrow:
                            grid.currentObject.Right();
                            break;
                    }

                    Thread.Sleep(5);
                }
            }).Start();
        }

    }
}
