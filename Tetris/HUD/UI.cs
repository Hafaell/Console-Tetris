
using System;
using System.IO;
using Tetris.Managers;

namespace Tetris.HUD
{
    class UI
    {
        //Movement all UI objects
        private Vector2 uiPosition = new Vector2(50, 1);

        //movement just single object in UI
        private Grid grid;
        public Vector2 gridPos = new Vector2(0, 0);
        public Vector2 gridSize = new Vector2(10, 20);

        private NextPiece nextPiece;
        public Vector2 nextPiecePos = new Vector2(-14, 0);
        public Vector2 nextPieceSize = new Vector2(9, 7);

        private Score score;
        public Vector2 scorePos = new Vector2(-14, 8);

        private Lose lose;
        public Vector2 losePos = new Vector2(14, 10);

        private Comands comands;
        public Vector2 comandsPos = new Vector2(14, 0);

        public static UI instance;

        private UI()
        {
            grid = new Grid(
                new Vector2(uiPosition.x + gridPos.x, uiPosition.y + gridPos.y), 
                new Vector2(gridSize.x, gridSize.y)
                );

            nextPiece = new NextPiece(
                new Vector2(uiPosition.x + nextPiecePos.x, uiPosition.y + nextPiecePos.y),
                new Vector2(nextPieceSize.x, nextPieceSize.y)
                );

            score = new Score(
                new Vector2(uiPosition.x + scorePos.x, uiPosition.y + scorePos.y)
                );

            lose = new Lose(
                new Vector2(uiPosition.x + losePos.x, uiPosition.y + losePos.y)
                );

            comands = new Comands(
                new Vector2(uiPosition.x + comandsPos.x, uiPosition.y + comandsPos.y)
                );
        }

        public void DrawUI()
        {
            grid.DrawGrid();
            score.DrawScore();
            nextPiece.DrawNextPiece();
            comands.DrawComands();

            if(GameManager.instance.Lose)
                lose.DrawLose();
        }

        public static Grid GetGrid()
        {
            return instance.grid;
        }

        public static Score GetScore()
        {
            return instance.score;
        }

        public static NextPiece GetNextPiece()
        {
            return instance.nextPiece;
        }

        public static UI GetInstance()
        {
            if (instance == null)
            {
                instance = new UI();
            }

            return instance;
        }
    }
}
