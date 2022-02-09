using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class Objeto
    {
        public Objeto(List<Cordenada> cordenadas, string caracter)
        {
            Cordenadas = cordenadas;
            Caracter = caracter;
        }

        public string Caracter;
        public List<Cordenada> Cordenadas;
        private bool Lock;

        public void Rotate()
        {

        }

        public void Right()
        {
            if (!Cordenadas.Any(corden => corden.X == Grid.X - 1) && !Lock)
            {
                foreach (var item in Cordenadas)
                {
                    item.X++;
                }
            }
        }

        public void Left()
        {
            if (!Cordenadas.Any(corden => corden.X == 0) && !Lock)
            {
                foreach (var item in Cordenadas)
                {
                    item.X --;
                }
            }
        }

        public void Down()
        {
            if (!Cordenadas.Any(corden => corden.Y == Grid.Y - 1))
            {
                foreach (var item in Cordenadas)
                {
                    item.Y++;
                }
            }
            else
            {
                Lock = true;
            }
        }
    }
}
