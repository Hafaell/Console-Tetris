using System;
using System.Threading;
using Tetris.Pieces;

namespace Tetris
{
    public class StartGame
    {
        private GameManager gameManager;
        private Inputs inputClass;
        private Score score;
        private Grid grid;

        public void Start()
        {
            Console.CursorVisible = false;
            Console.Title = "Console Tetris";

            gameManager = GameManager.GetInstance();

            gameManager.SelectNextObject();
            gameManager.AddObjects(gameManager.NextObject);

            score = new Score();
            grid = new Grid(10, 20);

            inputClass = new Inputs();
        }

        public void Update()
        {
            new Thread(inputClass.HandleInput).Start();

            new Thread(() =>
            {
                while (true)
                {
                    if (!gameManager.Lose)
                    {
                        grid.DrawGrid();
                        score.DrawScore();
                    }
                    else
                    {
                        Console.SetCursorPosition(20, 0);
                        Console.Write("Lose");
                    }

                    Thread.Sleep(5);
                }

            }).Start();

            new Thread(() =>
            {
                while (true)
                {
                    gameManager.CurrentObject.Down();

                    if (gameManager.CurrentObject.LockObject)
                    {
                        score.CompleteLine();
                        gameManager.AddObjects(gameManager.NextObject);
                    }

                    Thread.Sleep(500);
                }
            }).Start();
        }
    }


}
