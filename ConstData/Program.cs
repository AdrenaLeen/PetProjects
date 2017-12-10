using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstData
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** Константы *****");
            Console.WriteLine($"Значение PI равно: {MyMathClass.PI}");
            LocalConstStringVariable();

            Console.ReadLine();
        }

        static void LocalConstStringVariable()
        {
            // Доступ к локальным константным данным можно получать напрямую.
            const string fixedStr = "Фиксированные строковые данные";
            Console.WriteLine(fixedStr);
        }
    }
}
