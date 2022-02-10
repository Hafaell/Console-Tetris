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

            gameManager.NextObject();
            gameManager.AddObjects(gameManager.nextObject);

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
                    grid.DrawGrid();
                    score.DrawScore();
                    Thread.Sleep(5);
                }

            }).Start();

            while (true)
            {
                gameManager.currentObject.Down();

                if (gameManager.currentObject.LockObject)
                {
                    gameManager.AddObjectsLock(gameManager.currentObject);
                    score.CompleteLine();
                    gameManager.AddObjects(gameManager.nextObject);
                }

                Thread.Sleep(500);
            }
        }

    }


}
