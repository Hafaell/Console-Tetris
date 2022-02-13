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
        private ClearLines clearLines;
        private UI ui;

        public void Start()
        {
            Console.CursorVisible = false;
            Console.Title = "Console Tetris";

            gameManager = GameManager.GetInstance();
            ui = UI.GetInstance();

            gameManager.SelectNextObject();
            gameManager.AddObjects(gameManager.NextObject);

            clearLines = new ClearLines(UI.GetScore());
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
                        ui.DrawUI();                        
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
                    if (!gameManager.Lose)
                    {
                        if (gameManager.IsRealTime)
                            gameManager.CurrentObject.Down();

                        clearLines.ClearLinesCompleted();

                        if (gameManager.CurrentObject.LockObject)
                        {
                            gameManager.AddObjects(gameManager.NextObject);
                        }

                    }

                    Thread.Sleep(500);
                }
            }).Start();
        }
    }


}
