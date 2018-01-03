using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionAndFuncDelegates
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** Делегаты Action<> and Func<> *****");

            // Использовать делегат Action<> для указания на DisplayMessage.
            Action<string, ConsoleColor, int> actionTarget = new Action<string, ConsoleColor, int>(DisplayMessage);
            actionTarget("Сообщение о действии!", ConsoleColor.Yellow, 5);

            Func<int, int, int> funcTarget = Add;
            int result = funcTarget.Invoke(40, 40);
            Console.WriteLine($"40 + 40 = {result}");

            Func<int, int, string> funcTarget2 = SumToString;
            string sum = funcTarget2(90, 300);
            Console.WriteLine(sum);

            Console.ReadLine();
        }

        // Это цель для делегата Action<>.
        static void DisplayMessage(string msg, ConsoleColor txtColor, int printCount)
        {
            // Установить цвет текста консоли.
            ConsoleColor previous = Console.ForegroundColor;
            Console.ForegroundColor = txtColor;

            for (int i = 0; i < printCount; i++) Console.WriteLine(msg);

            // Восстановить цвет.
            Console.ForegroundColor = previous;
        }

        // Цель для делегата Func<>.
        static int Add(int x, int y)
        {
            return x + y;
        }

        static string SumToString(int x, int y)
        {
            return (x + y).ToString();
        }
    }
}
