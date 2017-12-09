using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCSharpApp
{
    class Program
    {
        // Обратите внимание, что теперь возвращается int, а не void.
        static int Main()
        {
            // Вывести пользователю простое сообщение
            Console.WriteLine("***** Моё первое C#-приложение *****");
            Console.WriteLine("Hello World!");
            Console.WriteLine();
            // Ожидать нажатия клавиши <Enter>, прежде чем завершить работу.
            Console.ReadLine();
            // Возвратить произвольный код ошибки
            return -1;
        }
    }
}
