using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaExpressionsMultipleParams
{
    class Program
    {
        static void Main()
        {
            // Зарегистрировать делегат как лямбда-выражение.
            SimpleMath m = new SimpleMath();
            m.SetMathHandler((msg, result) =>
            {
                Console.WriteLine($"Сообщение: {msg}, Результат: {result}");
            });

            // Это приведёт к выполнению лямбда-выражения.
            m.Add(10, 10);

            Console.ReadLine();
        }
    }
}
