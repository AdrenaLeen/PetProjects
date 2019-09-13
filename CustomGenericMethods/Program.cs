using System;

namespace CustomGenericMethods
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** Специальные обобщённые методы *****");

            // Обмен двух целочисленных значений.
            int a = 10, b = 90;
            Console.WriteLine($"До обмена: {a}, {b}");
            MyGenericMethods.Swap<int>(ref a, ref b);
            Console.WriteLine($"После обмена: {a}, {b}");
            Console.WriteLine();

            // Обмен двух строковых значений.
            string s1 = "Привет", s2 = "Всем";
            Console.WriteLine($"До обмена: {s1} {s2}");
            MyGenericMethods.Swap<string>(ref s1, ref s2);
            Console.WriteLine($"После обмена: {s1} {s2}");
            Console.WriteLine();

            // Компилятор выведет тип System.Boolean.
            bool b1 = true, b2 = false;
            Console.WriteLine($"До обмена: {b1}, {b2}");
            MyGenericMethods.Swap(ref b1, ref b2);
            Console.WriteLine($"После обмена: {b1}, {b2}");
            Console.WriteLine();

            // Если метод не принимает параметров, то должно быть указан параметр типа.
            MyGenericMethods.DisplayBaseClass<int>();
            MyGenericMethods.DisplayBaseClass<string>();

            Console.ReadLine();
        }

        static void Swap(ref int a, ref int b)
        {
            int temp;
            temp = a;
            a = b;
            b = temp;
        }

        // Обмен двух объектов Person.
        static void Swap(ref Person a, ref Person b)
        {
            Person temp;
            temp = a;
            a = b;
            b = temp;
        }
    }
}
