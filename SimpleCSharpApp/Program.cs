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
        // Обратите внимание, что в случае применения foreach отпадает необходимость в проверке размера массива.
        static int Main(string[] args)
        {
            // Вывести пользователю простое сообщение.
            Console.WriteLine("***** Моё первое C#-приложение *****");
            Console.WriteLine("Hello World!");
            Console.WriteLine();

            // Обработать любые входные аргументы.
            for (int i = 0; i < args.Length; i++) Console.WriteLine("Arg: {0}", args[i]);

            // Обработать любые входные аргументы, используя foreach.
            foreach (string arg in args) Console.WriteLine("Arg: {0}", arg);

            // Получить аргументы с использованием System.Environment.
            string[] theArgs = Environment.GetCommandLineArgs();
            foreach (string arg in theArgs) Console.WriteLine("Arg: {0}", arg);

            // Ожидать нажатия клавиши <Enter>, прежде чем завершить работу.
            Console.ReadLine();
            // Возвратить произвольный код ошибки.
            return -1;
        }
    }
}
