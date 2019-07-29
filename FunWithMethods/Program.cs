using System;

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

            // Присваивать начальные значения локальным переменным, используемым как выходные параметры, не обязательно при условии, что в таком качестве они применяются впервые. Версия C# 7 позволяет объявлять параметры out в вызове метода.
            Add(90, 90, out int ans);
            Console.WriteLine($"90 + 90 = {ans}");

            FillTheseValues(out int i, out string str, out bool b);
            Console.WriteLine($"Int: {i}");
            Console.WriteLine($"String: {str}");
            Console.WriteLine($"Boolean: {b}");

            string s1 = "Флип";
            string s2 = "Флоп";
            Console.WriteLine($"До: {s1}, {s2}");
            SwapStrings(ref s1, ref s2);
            Console.WriteLine($"После: {s1}, {s2}");

            // Передать список значений double, разделённых запятыми...
            double average;
            average = CalculateAverage(4.0, 3.2, 5.7, 64.22, 87.2);
            Console.WriteLine($"Среднее равно: {average}");
            // ...или передать массив значений double.
            double[] data = { 4.0, 3.2, 5.7 };
            average = CalculateAverage(data);
            Console.WriteLine($"Среднее равно: {average}");
            // Среднее из 0 равно 0!
            Console.WriteLine("Среднее равно: {0}", CalculateAverage());

            EnterLogData("О нет! Сетка не может найти данные");
            EnterLogData("О нет! Я не могу найти данные о заработной плате", "CFO");

            DisplayFancyMessage(message: "Вау! Очень фантастично!", textColor: ConsoleColor.DarkRed, backgroundColor: ConsoleColor.White);
            DisplayFancyMessage(backgroundColor: ConsoleColor.Green, message: "Тестирование...", textColor: ConsoleColor.DarkBlue);

            // Здесь всё в порядке, т.к. позиционные аргументы находятся перед именованными.
            DisplayFancyMessage(ConsoleColor.Blue, message: "Тестирование...", backgroundColor: ConsoleColor.White);

            DisplayFancyMessage(message: "Привет!");

            DisplayFancyMessage(backgroundColor: ConsoleColor.Green);

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

        // Возвращение множества выходных параметров.
        static void FillTheseValues(out int a, out string b, out bool c)
        {
            a = 9;
            b = "Наслаждайтесь своей строкой.";
            c = true;
        }

        // Ссылочные параметры.
        public static void SwapStrings(ref string s1, ref string s2)
        {
            string tempStr = s1;
            s1 = s2;
            s2 = tempStr;
        }

        // Возвращение среднего из некоторого количества значений double.
        static double CalculateAverage(params double[] values)
        {
            Console.WriteLine("Вы прислали мне {0} параметров double.", values.Length);
            double sum = 0;
            if (values.Length == 0) return sum;
            for (int i = 0; i < values.Length; i++) sum += values[i];
            return sum / values.Length;
        }

        static void EnterLogData(string message, string owner = "Программист")
        {
            Console.Beep();
            Console.WriteLine($"Ошибка: {message}");
            Console.WriteLine($"Владелец ошибки: {owner}");
        }

        static void DisplayFancyMessage(ConsoleColor textColor = ConsoleColor.Blue, ConsoleColor backgroundColor = ConsoleColor.White, string message = "Тестовое сообщение")
        {
            // Сохранить старые цвета для их восстановления после вывода сообщения.
            ConsoleColor oldTextColor = Console.ForegroundColor;
            ConsoleColor oldBackgroundColor = Console.BackgroundColor;

            // Установить новые цвета и вывести сообщение.
            Console.ForegroundColor = textColor;
            Console.BackgroundColor = backgroundColor;
            Console.WriteLine(message);

            // Восстановить предыдущие цвета.
            Console.ForegroundColor = oldTextColor;
            Console.BackgroundColor = oldBackgroundColor;
        }
    }
}
