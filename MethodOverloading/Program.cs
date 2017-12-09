using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodOverloading
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** Перегрузка методов *****");

            // Вызов int-версии Add().
            Console.WriteLine(Add(10, 10));

            // Вызов long-версии Add().
            Console.WriteLine(Add(900000000000, 900000000000));

            // Вызов double-версии Add().
            Console.WriteLine(Add(4.3, 4.4));

            Console.ReadLine();
        }

        // Перегруженный метод Add().
        static int Add(int x, int y)
        {
            return x + y;
        }

        static double Add(double x, double y)
        {
            return x + y;
        }

        static long Add(long x, long y)
        {
            return x + y;
        }
    }
}
