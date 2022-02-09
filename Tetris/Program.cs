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

        public static NewObject actualObject;

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

            var random = new Random();
            var sortearObjeto = random.Next(0, 2);

            if (sortearObjeto == 0)
            {
                NovoObjeto(NewObject.quadrado, 1, 0);
            }
            else if (sortearObjeto == 1)
            {
                NovoObjeto(NewObject.retangulo, 1, 0);
            }

            new Grid('-');

            Console.SetCursorPosition(0, 0);

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
            actualObject = new NewObject(matriz, x, y);

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    var caractere = (char)actualObject.Caracteres.GetValue(i, j);
                    if (caractere == '-')
                        continue; 

                    Console.SetCursorPosition(actualObject.X + j, actualObject.Y + i);
                    Console.Write(caractere);
                    
                }

                Console.Write("\n");
            }
        }
    }

}
