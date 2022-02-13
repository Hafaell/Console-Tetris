using System;
using Tetris.Managers;

namespace Tetris.HUD
{
    class Score
    {
        private Vector2 position;
        private int score;
        private int initialScore = 0;

        public Score(Vector2 position)
        {
            score = initialScore;

            this.position = position;

            GameManager.RestartGame_ACT += RestartScore;
        }

        private void RestartScore()
        {
            Console.Clear();
            score = initialScore;
        }

        public void DrawScore()
        {
            Console.SetCursorPosition(position.x, position.y);
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write($"Score: {score}");
        }

        public void Scored()
        {
            score++;
        }

    }
}

