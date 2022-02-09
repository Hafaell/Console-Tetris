using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Tetris
{
    public class StartGame
    {
        private Inputs inputClass;
        private Grid grid;

        public void Start()
        {
            Console.CursorVisible = false;
            Console.Title = "Console Tetris";

            grid = new Grid(10, 20);
            inputClass = new Inputs(grid);

            grid.AddObjects(new Square());
        }

        public void Update()
        {
            new Thread(inputClass.HandleInput).Start();

            new Thread(() =>
            {
                while (true)
                {
                    grid.DrawGrid();
                    Thread.Sleep(1);
                }

            }).Start();

            while (true)
            {
                grid.currentObject.Down();

                if (grid.currentObject.LockObject)
                    grid.AddObjects(grid.nextObject);

                Thread.Sleep(500);
            }
        }

    }


}
