using InterfaceExtensions;

Console.WriteLine("***** Расширение типов, которые реализуют специфичные интерфейсы *****");

// System.Array реализует IEnumerable!
string[] data = { "Wow", "this", "is", "sort", "of", "annoying", "but", "in", "a", "weird", "way", "fun!" };

data.PrintDataAndBeep();
Console.WriteLine();

// List<T> реализует IEnumerable!
var myInts = new List<int>() { 10, 15, 20 };
myInts.PrintDataAndBeep();

Console.ReadLine();