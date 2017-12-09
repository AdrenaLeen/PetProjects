using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithMethods
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** Методы и модификаторы параметров *****");
            
            // Передать две переменные по значению.
            int x = 9, y = 10;
            Console.WriteLine($"До вызова: X: {x}, Y: {y}");
            Console.WriteLine("Ответ: {0}", Add(x, y));
            Console.WriteLine($"После вызова: X: {x}, Y: {y}");

            Console.ReadLine();
        }

        // По умолчанию аргументы передаются по значению.
        static int Add(int x, int y)
        {
            int ans = x + y;
            // Вызывающий код не увидит эти изменения, т.к. модифицируется копия исходных данных.
            x = 10000;
            y = 88888;
            return ans;
        }
    }
}
