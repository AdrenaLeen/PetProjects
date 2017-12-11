using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicInheritance
{
    // MiniVan "является" Car.
    // Класс MiniVan является производным от Car.
    class MiniVan : Car
    {
        public void TestMethod()
        {
            // Нормально! Доступ к открытым членам родительского типа в производном типе возможен.
            Speed = 10;
        }
    }
}
