using System;
using System.Threading;
using Tetris.Pieces;

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
            grid.NextObject();
            grid.AddObjects(grid.nextObject);

            inputClass = new Inputs(grid);
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
                {
                    grid.AddObjectsLock(grid.currentObject);
                    grid.CompleteLine();
                    grid.AddObjects(grid.nextObject);
                }

                Thread.Sleep(500);
            }
        }

    }


}
