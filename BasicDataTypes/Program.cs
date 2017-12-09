using System;
using System.Numerics;

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
            Console.WriteLine();

            CharFunctionality();
            ParseFromStrings();
            UseDatesAndTimes();
            UseBigInteger();

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

        private static void CharFunctionality()
        {
            Console.WriteLine("=> Функциональность типа char:");
            char myChar = 'а';
            Console.WriteLine("char.IsDigit('а'): {0}", char.IsDigit(myChar));
            Console.WriteLine("char.IsLetter('а'): {0}", char.IsLetter(myChar));
            Console.WriteLine("char.IsWhiteSpace('Hello There', 5): {0}", char.IsWhiteSpace("Hello There", 5));
            Console.WriteLine("char.IsWhiteSpace('Hello There', 6): {0}", char.IsWhiteSpace("Hello There", 6));
            Console.WriteLine("char.IsPunctuation('?'): {0}", char.IsPunctuation('?'));
            Console.WriteLine();
        }

        private static void ParseFromStrings()
        {
            Console.WriteLine("=> Разбор значений из строковых данных:");
            bool b = bool.Parse("True");
            Console.WriteLine("Значение b: {0}", b);
            double d = double.Parse("99,884");
            Console.WriteLine("Значение d: {0}", d);
            int i = int.Parse("8");
            Console.WriteLine("Значение i: {0}", i);
            char c = Char.Parse("w");
            Console.WriteLine("Значение c: {0}", c);
            Console.WriteLine();
        }

        private static void UseDatesAndTimes()
        {
            Console.WriteLine("=> Дата и время:");
            // Этот конструктор принимает год, месяц и день.
            DateTime dt = new DateTime(2015, 10, 17);

            // Какой это день месяца?
            Console.WriteLine("День {0} - это {1}", dt.Date, dt.DayOfWeek);

            // Сейчас месяц декабрь.
            dt = dt.AddMonths(2);
            Console.WriteLine("Летнее время: {0}", dt.IsDaylightSavingTime());

            // Этот конструктор принимает часы, минуты и секунды.
            TimeSpan ts = new TimeSpan(4, 30, 0);
            Console.WriteLine(ts);

            // Вычесть 15 минут из текущего значения TimeSpan и вывести результат.
            Console.WriteLine(ts.Subtract(new TimeSpan(0, 15, 0)));
            Console.WriteLine();
        }

        private static void UseBigInteger()
        {
            Console.WriteLine("=> Использование BigInteger:");
            BigInteger biggy = BigInteger.Parse("9999999999999999999999999999999999999999999999");

            // Значение biggy
            Console.WriteLine("Значение biggy равно {0}", biggy);

            // biggy - чётное?
            Console.WriteLine("biggy - чётное число?: {0}", biggy.IsEven);

            // biggy - степень 2?
            Console.WriteLine("biggy - степень двойки?: {0}", biggy.IsPowerOfTwo);
            BigInteger reallyBig = BigInteger.Multiply(biggy, BigInteger.Parse("8888888888888888888888888888888888888888888"));

            // Значение reallyBig
            Console.WriteLine("Значение reallyBig равно {0}", reallyBig);
        }
    }
}
