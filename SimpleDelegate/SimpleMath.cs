using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDelegate
{
    // Этот класс содержит методы, на которые будет указывать BinaryOp.
    class SimpleMath
    {
        public int Add(int x, int y)
        {
            return x + y;
        }

        public static int Subtract(int x, int y)
        {
            return x - y;
        }

        public static int SquareNumber(int a)
        {
            return a * a;
        }
    }
}
