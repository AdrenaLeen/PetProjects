using GenericPoint;

Console.WriteLine("***** Обобщенные структуры *****");

// Точка с координатами типа int.
var p = new Point<int>(10, 10);
Console.WriteLine($"p.ToString()={p}");
p.ResetPoint();
Console.WriteLine($"p.ToString()={p}");
Console.WriteLine();

// Точка с координатами типа double.
var p2 = new Point<double>(5.4, 3.3);
Console.WriteLine($"p2.ToString()={p2}");
p2.ResetPoint();
Console.WriteLine($"p2.ToString()={p2}");

// Точка с координатами типа string.
var p3 = new Point<string>("i", "3i");
Console.WriteLine($"p3.ToString()={p3}");
p3.ResetPoint();
Console.WriteLine($"p3.ToString()={p3}");
Console.WriteLine();

Point<string> p4 = default;
Console.WriteLine($"p4.ToString()={p4}");
Console.WriteLine();
Point<int> p5 = default;
Console.WriteLine($"p5.ToString()={p5}");
Console.WriteLine();
PatternMatching(p4);
PatternMatching(p5);
Console.ReadLine();

static void PatternMatching<T>(Point<T> p)
{
    switch (p)
    {
        case Point<string>:
            Console.WriteLine("Структура Point основана на типе string");
            return;
        case Point<int>:
            Console.WriteLine("Структура Point основана на типе int");
            return;
    }
}