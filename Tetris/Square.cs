using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class Square : TetrisObjects
    {
        public Square() : base(new List<Cordenada>() {
            new Cordenada(0, 0),
            new Cordenada(1, 0),
            new Cordenada(0, 1),
            new Cordenada(1, 1)
        }, "$"){ }
    }
}
