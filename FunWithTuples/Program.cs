using System;

namespace FunWithTuples
{
    class Program
    {
        static void Main()
        {
            (string, int, string) values = ("a", 5, "c");
            Console.WriteLine($"Первый элемент: {values.Item1}");
            Console.WriteLine($"Второй элемент: {values.Item2}");
            Console.WriteLine($"Третий элемент: {values.Item3}");
            Console.WriteLine();

            (string FirstLetter, int TheNumber, string SecondLetter) valuesWithNames = ("a", 5, "c");
            (string, int, string) valuesWithNames2 = (FirstLetter: "a", TheNumber: 5, SecondLetter: "c");
            Console.WriteLine($"Первый элемент: {valuesWithNames.FirstLetter}");
            Console.WriteLine($"Второй элемент: {valuesWithNames.TheNumber}");
            Console.WriteLine($"Третий элемент: {valuesWithNames.SecondLetter}");
            Console.WriteLine();

            // Система обозначений ItemX по-прежнему работает!
            Console.WriteLine($"Первый элемент: {valuesWithNames.Item1}");
            Console.WriteLine($"Второй элемент: {valuesWithNames.Item2}");
            Console.WriteLine($"Третий элемент: {valuesWithNames.Item3}");
            Console.WriteLine();

            (int Field1, int Field2) example = (Custom1: 5, Custom2: 7);

            Console.WriteLine("=> Выведение имён свойств кортежей");
            var foo = new { Prop1 = "первый", Prop2 = "второй" };
            (string Prop1, string Prop2) bar = (foo.Prop1, foo.Prop2);
            Console.WriteLine($"{bar.Prop1};{bar.Prop2}");
            Console.WriteLine();

            (int a, string b, bool c) samples = FillTheseValues();
            Console.WriteLine($"Int: {samples.a}");
            Console.WriteLine($"String: {samples.b}");
            Console.WriteLine($"Boolean: {samples.c}");
            Console.WriteLine();

            Console.ReadLine();
        }

        static (int a, string b, bool c) FillTheseValues() => (9, "Насладитесь этой строкой.", true);

        // Действия, необходимые для расщепления полного имени.
        static (string first, string middle, string last) SplitNames(string fullName) => ("Ксения", "Сергеевна", "Кузнецова");
    }
}
