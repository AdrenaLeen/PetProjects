using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstData
{
    class MyMathClass
    {
        // Поля только для чтения могут присваиваться в конструкторах, но больше нигде.
        public readonly double PI;

        public MyMathClass()
        {
            PI = 3.14;
        }
    }
}
