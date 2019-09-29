using System;

namespace GenericDelegate
{
    class Program
    {
        // Этот обобщённый делегат может вызывать любой метод, который возвращает void и принимает единственный параметр типа T.
        public delegate void MyGenericDelegate<T>(T arg);

        static void Main()
        {
            Console.WriteLine("***** Обобщённые делегаты *****");

            // Зарегистрировать цели.
            MyGenericDelegate<string> strTarget = new MyGenericDelegate<string>(StringTarget);
            strTarget("Некоторые строковые данные");

            MyGenericDelegate<int> intTarget = new MyGenericDelegate<int>(IntTarget);
            intTarget(9);
            Console.ReadLine();
        }

        static void StringTarget(string arg) => Console.WriteLine($"arg в верхнем регистре: {arg.ToUpper()}");

        static void IntTarget(int arg) => Console.WriteLine($"++arg: {++arg}");
    }
}
