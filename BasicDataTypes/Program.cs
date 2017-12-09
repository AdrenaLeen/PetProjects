using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicDataTypes
{
    class Program
    {
        static void Main()
        {
            LocalVarDeclarations();
            NewingDataTypes();
            ObjectFunctionality();
            DataTypeFunctionality();

            Console.WriteLine("bool.FalseString: {0}", bool.FalseString);
            Console.WriteLine("bool.TrueString: {0}", bool.TrueString);

            Console.ReadLine();
        }

        private static void LocalVarDeclarations()
        {
            Console.WriteLine("=> Объявление переменных:");
            // Локальные переменные объявляются и инициализируются так:
            // типДанных имяПеременной = начальноеЗначение;
            int myInt = 0;

            // Объявлять и присваивать можно также в двух отдельных строках.
            string myString;
            myString = "Это мои символьные данные";

            // Объявить три переменные типа bool в одной строке.
            bool b1 = true, b2 = false, b3 = b1;

            // Использовать тип данных System.Boolean для объявления булевской переменной.
            System.Boolean b4 = false;

            Console.WriteLine("Ваши данные: {0}, {1}, {2}, {3}, {4}, {5}", myInt, myString, b1, b2, b3, b4);
            Console.WriteLine();
        }

        private static void NewingDataTypes()
        {
            Console.WriteLine("=> Использование new для создания переменных:");
            // Устанавливается в false.
            bool b = new bool();

            // Устанавливается в 0.
            int i = new int();

            // Устанавливается в 0.
            double d = new double();

            // Устанавливается в 1/1/0001 12:00:00 AM.
            DateTime dt = new DateTime();

            Console.WriteLine("{0}, {1}, {2}, {3}", b, i, d, dt);
            Console.WriteLine();
        }

        private static void ObjectFunctionality()
        {
            Console.WriteLine("=> Функциональность System.Object:");
            // Ключевое слово int языка C# - это в действительности сокращение для типа System.Int32, который наследует от System.Object следующие члены:
            Console.WriteLine("12.GetHashCode() = {0}", 12.GetHashCode());
            Console.WriteLine("12.Equals(23) = {0}", 12.Equals(23));
            Console.WriteLine("12.ToString() = {0}", 12.ToString());
            Console.WriteLine("12.GetType() = {0}", 12.GetType());
            Console.WriteLine();
        }

        private static void DataTypeFunctionality()
        {
            Console.WriteLine("=> Функциональность числовых типов данных:");
            Console.WriteLine("Максимум int: {0}", int.MaxValue);
            Console.WriteLine("Минимум int: {0}", int.MinValue);
            Console.WriteLine("Максимум double: {0}", double.MaxValue);
            Console.WriteLine("Минимум double: {0}", double.MinValue);
            Console.WriteLine("double.Epsilon: {0}", double.Epsilon);
            Console.WriteLine("double.PositiveInfitity: {0}", double.PositiveInfinity);
            Console.WriteLine("double.NegativeInfitity: {0}", double.NegativeInfinity);
            Console.WriteLine();
        }
    }
}
