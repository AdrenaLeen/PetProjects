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

            FormatNumericalData();

            Console.ReadLine();
        }

        // Демонстрация применения некоторых дескрипторов формата.
        private static void FormatNumericalData()
        {
            Console.WriteLine("Значение 99999 в различных форматах:");
            Console.WriteLine("Формат c: {0:c}", 99999);
            Console.WriteLine("Формат d9: {0:d9}", 99999);
            Console.WriteLine("Формат f3: {0:f3}", 99999);
            Console.WriteLine("Формат n: {0:n}", 99999);
            // Обратите внимание, что использование для символа шестнадцатеричного формата верхнего или нижнего регистра определяет регистр отображаемых символов.
            Console.WriteLine("Формат E: {0:E}", 99999);
            Console.WriteLine("Формат e: {0:e}", 99999);
            Console.WriteLine("Формат X: {0:X}", 99999);
            Console.WriteLine("Формат x: {0:x}", 99999);
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
