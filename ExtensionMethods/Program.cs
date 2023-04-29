using ExtensionMethods;
using System.Data;

Console.WriteLine("***** Расширяющие методы *****");

// В int появилась новая отличительная черта!
int myInt = 12345678;
myInt.DisplayDefiningAssembly();

// То же и в DataSet!
var d = new DataSet();
d.DisplayDefiningAssembly();

// Использовать новую функциональность int.
Console.WriteLine($"Значение myInt: {myInt}");
Console.WriteLine($"Обратный порядок следования цифр myInt: {myInt.ReverseDigits()}");

Console.ReadLine();