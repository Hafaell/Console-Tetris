using System;
using Tetris.Managers;

namespace Tetris.HUD
{
    class Score
    {
        private Vector2 position;
        
        public Score(Vector2 position)
        {
            this.position = position;
        }

        public void DrawScore()
        {
            Console.SetCursorPosition(position.x, position.y);
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write($"Pontuação: {GameManager.instance.Points}");
        }
    }
}

