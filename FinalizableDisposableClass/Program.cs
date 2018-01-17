using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalizableDisposableClass
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** Dispose() / Destructor Combo Platter *****");

            // Вызвать метод Dispose() вручную. Это не приведёт к вызову финализатора.
            MyResourceWrapper rw = new MyResourceWrapper();
            rw.Dispose();

            // Не вызывать метод Dispose(). Это приведёт к вызову финализатора и выдаче звукового сигнала.
            MyResourceWrapper rw2 = new MyResourceWrapper();

            Console.ReadLine();
        }
    }
}
