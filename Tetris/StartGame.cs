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
        Inputs inputClass;
        Grid grid;

        public void Start()
        {
            Console.CursorVisible = false;
            Console.Title = "Console Tetris";
            grid = new Grid(10, 20);

            inputClass = new Inputs(grid);

            grid.AddObjects(new Objeto(new List<Cordenada>() { new Cordenada (0, 0), (new Cordenada (1, 0)) },  "@"));

            Thread inputThread = new Thread(inputClass.HandleInput);
            inputThread.Start();

            new Thread(() =>
            {
                while (true)
                {
                    grid.DrawGrid();
                    Thread.Sleep(1);
                }
            }
                
            ).Start();
        }

        public void Update()
        {
            while (true)
            {
                //inputClass.HandleInput();
                grid.currentObject.Down();
                Thread.Sleep(500);
            }
        }

    }


}
