using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Swap<int>(ref a, ref b);
            Console.WriteLine($"После обмена: {a}, {b}");
            Console.WriteLine();

            // Обмен двух строковых значений.
            string s1 = "Привет", s2 = "Всем";
            Console.WriteLine($"До обмена: {s1} {s2}");
            Swap<string>(ref s1, ref s2);
            Console.WriteLine($"После обмена: {s1} {s2}");
            Console.WriteLine();

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

        // Этот метод будет менять местами два элемента типа, указанного в параметре <T>.
        public static void Swap<T>(ref T a, ref T b)
        {
            Console.WriteLine($"Вы послали методу Swap() {typeof(T)}");
            T temp;
            temp = a;
            a = b;
            b = temp;
        }
    }
}
