using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tetris
{
    public class Inputs
    {
        private ConsoleKeyInfo input;
        public Grid Grid;

        public Inputs(Grid grid)
        {
            Grid = grid;
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
                            Grid.currentObject.Rotate();
                            break;

                        case ConsoleKey.DownArrow:
                            Grid.currentObject.Down();
                            break;

                        case ConsoleKey.LeftArrow:
                            Grid.currentObject.Left();
                            break;

                        case ConsoleKey.RightArrow:
                            Grid.currentObject.Right();
                            break;
                    }
                    input = new ConsoleKeyInfo();

                    Task.Delay(5).Wait();
                }
            }).Start();
        }

        public void Input()
        {
            while (true)
            {
               
                input = Console.ReadKey(true);
            }
        }
    }
}
