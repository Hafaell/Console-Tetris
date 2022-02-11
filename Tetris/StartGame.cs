using System;
using System.Threading;
using Tetris.HUD;
using Tetris.Managers;

namespace Tetris
{
    public class StartGame
    {
        private GameManager gameManager;
        private Inputs inputClass;
        private Score score;
        private UI ui;

        public void Start()
        {
            Console.CursorVisible = false;
            Console.Title = "Console Tetris";

            gameManager = GameManager.GetInstance();
            ui = UI.GetInstance();

            gameManager.SelectNextObject();
            gameManager.AddObjects(gameManager.NextObject);

            score = new Score();

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
                        ui.grid.DrawGrid();
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
