using System;
using Tetris.Managers;

namespace Tetris.HUD
{
    class Lose
    {
        private Vector2 position;

        public Lose(Vector2 position)
        {
            this.position = position;
        }

        public void DrawLose()
        {
            Console.SetCursorPosition(position.x, position.y);
            Console.ForegroundColor = ConsoleColor.Red;

            Console.Write($"Você perdeu");
            Console.SetCursorPosition(position.x, position.y + 1);
            Console.Write($"Melhor Pontuação: {GameManager.instance.Score}");
        }
    }
}
