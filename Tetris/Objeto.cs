using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class Objeto
    {
        public Objeto(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public char[,] Caracteres { get; set; }

        Grid grid = new Grid('-');

        public void Left()
        {
            if (X > 0)
                X--;
        }

        public void Right()
        {
            if (X < grid.x - LarguraObjeto())
                X++;
        }

        public int LarguraObjeto()
        {
            int largura = 0;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    var caractere = (char)Program.actualObject.Caracteres.GetValue(i, j);

                    if (caractere == '-')
                        continue;
                    else if (largura < j)
                    {
                        largura = j;
                    }
                }
            }

            return largura + 1;
        }

        public int AlturaObjeto()
        {
            int altura = 0;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    var caractere = (char)Program.actualObject.Caracteres.GetValue(i, j);

                    if (caractere == '-')
                        continue;
                    else if (altura < i)
                    {
                        altura = i;
                    }
                }
            }

            return altura + 1;
        }
    }

    public class NewObject : Objeto
    {
        static char _ = '-';

        public static char[,] quadrado = new char[4, 4] { { '@', '@', _, _},
                                                          { '@', '@', _, _},
                                                          { _, _, _, _},
                                                          { _, _, _, _ }};

        public static char[,] retangulo = new char[4, 4] { { '$', '$', _, _ },
                                                           { '$', '$', _, _ },
                                                           { '$', '$', _, _ },
                                                           { _, _, _, _ }};


        public NewObject(char[,] matriz, int x, int y) : base(x, y)
        {
            Caracteres = matriz;
        }
    }
}
