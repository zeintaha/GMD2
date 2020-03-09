using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMD2_Snake
{
    class OneBlockSnake
    {
        public int X { get; set; }
        public int Y { get; set; }

        public OneBlockSnake(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void Set(OneBlockSnake p)
        {
            X = p.X;
            Y = p.Y;
        }

        public Boolean Equals(OneBlockSnake p)
        {
            return p.X == X && p.Y == Y;
        }

        public override string ToString()
        {
            return String.Format("OneBlockSnake (X: {0}, Y: {1})", X, Y);
        }
    }
}
