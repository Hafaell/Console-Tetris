using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class Program
    {
        static Inputs inputClass;

        static void Main(string[] args)
        {
            Start();
            Update();
        }

        private static void Start()
        {
            Console.CursorVisible = false;
            Console.Title = "Console Tetris";

            inputClass = new Inputs();

            new Grid(10, 7);

            NovoObjeto(
                new char[4, 4] { { '@', '@', '_', '_' },
                                 { '@', '@', '@', '_' },
                                 { '@', '_', '_', '_' },
                                 { '@', '_', '_', '_' }},

                1, 2
                );

            Thread inputThread = new Thread(inputClass.Input);
            inputThread.Start();
        }

        private static void Update()
        {

            while (true)
            {
                inputClass.HandleInput();

                Thread.Sleep(20);
            }
        }

        public static void NovoObjeto(char[,] matriz, int x, int y)
        {
            var obj = new NewObject(matriz, x, y);

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    var caractere = (char)obj.Caracteres.GetValue(i, j);
                    Console.SetCursorPosition(obj.X + j, obj.Y + i);
                    Console.Write(caractere);
                }

                Console.Write("\n");
            }
        }
    }

}
