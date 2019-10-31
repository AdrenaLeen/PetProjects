using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections.Generic;

namespace DynamicKeyword
{
    class Program
    {
        static void Main()
        {
            PrintThreeStrings();
            ChangeDynamicDataType();
            InvokeMembersOnDynamicData();
            Console.ReadLine();
        }

        static void ImplicitlyTypedVariable()
        {
            // Переменная a имеет тип List<int>.
            var a = new List<int>();
            a.Add(90);
        }

        static void UseObjectVarible()
        {
            // Пусть имеется класс по имени Person.
            object o = new Person() { FirstName = "Майк", LastName = "Ларсон" };

            // Для получения доступа к свойствам Person переменную o потребуется привести к Person.
            Console.WriteLine("Person's first name is {0}", ((Person)o).FirstName);
        }

        static void PrintThreeStrings()
        {
            var s1 = "Привет";
            object s2 = "из";
            dynamic s3 = "Миннеаполиса";
            Console.WriteLine($"Тип s1: {s1.GetType()}");
            Console.WriteLine($"Тип s2: {s2.GetType()}");
            Console.WriteLine($"Тип s3: {s3.GetType()}");
            Console.WriteLine();
        }

        static void ChangeDynamicDataType()
        {
            // Объявить одиночный динамический элемент данных по имени t.
            dynamic t = "Привет!";
            Console.WriteLine($"Тип t: {t.GetType()}");

            t = false;
            Console.WriteLine($"Тип t: {t.GetType()}");

            t = new List<int>();
            Console.WriteLine($"Тип t: {t.GetType()}");

            Console.WriteLine();
        }

        static void InvokeMembersOnDynamicData()
        {
            dynamic textData1 = "Привет";

            try
            {
                Console.WriteLine(textData1.ToUpper());
                Console.WriteLine(textData1.toupper());
                Console.WriteLine(textData1.Foo(10, "ee", DateTime.Now));
            }
            catch (RuntimeBinderException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine();
        }
    }
}
