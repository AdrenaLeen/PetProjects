using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDispose
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** Fun with Dispose *****\n");

            // Создать освобождаемый объект и вызвать метод Dispose() для освобождения любых внутренних ресурсов.
            MyResourceWrapper rw = new MyResourceWrapper();
            if (rw is IDisposable) rw.Dispose();

            Console.ReadLine();
        }
    }
}
