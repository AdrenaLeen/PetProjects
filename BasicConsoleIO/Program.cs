using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicConsoleIO
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** Базовый ввод-вывод с помощью класса Console *****");
            GetUserData();

            // Джон говорит...
            Console.WriteLine("{0}, Number {0}, Number {0}", 9);

            // Выводит: 20, 10, 30
            Console.WriteLine("{1}, {0}, {2}", 10, 20, 30);

            Console.ReadLine();
        }

        private static void GetUserData()
        {
            // Получить информацию об имени и возрасте.

            // Предложить ввести имя.
            Console.Write("Пожалуйста, введите своё имя: ");
            string userName = Console.ReadLine();

            // Предложить ввести возраст.
            Console.Write("Пожалуйста, введите свой возраст: ");
            string userAge = Console.ReadLine();

            // Просто ради забавы изменить цвет переднего плана.
            ConsoleColor prevColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;

            // Вывести полученную информацию на консоль.
            Console.WriteLine("Здравствуйте, {0}! Вам {1} лет.", userName, userAge);

            // Восстановить предыдущий цвет переднего плана.
            Console.ForegroundColor = prevColor;
        }
    }
}
