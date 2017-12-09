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

            // Присваивать начальные значения локальным переменным, используемым как выходные параметры, не обязательно при условии, что в таком качестве они применяются впервые.
            int ans;
            Add(90, 90, out ans);
            Console.WriteLine($"90 + 90 = {ans}");

            int i;
            string str;
            bool b;
            FillTheseValues(out i, out str, out b);
            Console.WriteLine($"Int: {i}");
            Console.WriteLine($"String: {str}");
            Console.WriteLine($"Boolean: {b}");

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

        // Значения выходных параметров должны быть установлены внутри вызываемого метода.
        static void Add(int x, int y, out int ans)
        {
            ans = x + y;
        }

        // Возвращение множества выходных параметров
        static void FillTheseValues(out int a, out string b, out bool c)
        {
            a = 9;
            b = "Наслаждайтесь своей строкой.";
            c = true;
        }
    }
}
