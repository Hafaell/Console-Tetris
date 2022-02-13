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
            gameManager.AddObjects();

            clearLines = new ClearLines();
            inputClass = new Inputs();
        }

        public void Update()
        {
            new Thread(inputClass.HandleInput).Start();

            new Thread(() =>
            {
                while (true)
                {
                    ui.DrawUI();

                    Thread.Sleep(1);
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

                        if (gameManager.CurrentObject.LockObject)
                        {
                            clearLines.ClearLinesCompleted();
                            gameManager.AddObjects();
                        }

                    }

                    Thread.Sleep(500);
                }
            }).Start();
        }
    }


}
