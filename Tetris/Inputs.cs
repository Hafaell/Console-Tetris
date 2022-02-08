using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class Inputs
    {
        private ConsoleKeyInfo input;

        public void HandleInput()
        {
            switch (input.Key)
            {
                case ConsoleKey.UpArrow:
                    Console.WriteLine($"clicou em {ConsoleKey.UpArrow}");
                    break;

                case ConsoleKey.DownArrow:
                    Console.WriteLine($"clicou em {ConsoleKey.DownArrow}");
                    break;

                case ConsoleKey.LeftArrow:
                    Console.WriteLine($"clicou em {ConsoleKey.LeftArrow}");
                    break;

                case ConsoleKey.RightArrow:
                    Console.WriteLine($"clicou em {ConsoleKey.RightArrow}");
                    break;
            }

            input = new ConsoleKeyInfo();
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
