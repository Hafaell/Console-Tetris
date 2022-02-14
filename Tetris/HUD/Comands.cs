using System;
using Tetris.Managers;

namespace Tetris.HUD
{
    class Comands
    {
        private Vector2 position;

        public Comands(Vector2 position)
        {
            this.position = position;
        }

        public void DrawComands()
        {
            Console.SetCursorPosition(position.x, position.y);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Rotacionar no sentido horário: X");

            Console.SetCursorPosition(position.x, position.y + 1);
            Console.Write("Rotacionar no sentido anti horário: Z");

            Console.SetCursorPosition(position.x, position.y + 3);
            Console.Write("Movimentar peça: <- ->");

            Console.SetCursorPosition(position.x, position.y + 4);
            string piceMoveDown = GameManager.instance.IsRealTime ? "Descer peça: ↓" : "Proximo turno: ↓";
            Console.Write(piceMoveDown);

            Console.SetCursorPosition(position.x, position.y + 5);
            Console.Write("Aperte R quando perder para reiciniar");

            Console.SetCursorPosition(position.x, position.y + 7);
            string gameMode = GameManager.instance.IsRealTime ? "Modo de jogo: tempo real" : "Modo de jogo: por turno";
            Console.Write(gameMode);

            Console.SetCursorPosition(position.x, position.y + 8);
            Console.Write("Aperte TAB para trocar entre modos de jogo");
        }
    }
}
