DeclareImplicitVars();
DeclarelmplicitNumerics();

// Также допустимо!
var myInt = 0;
var anotherInt = myInt;
string myString = "Вставай!";
var myData = myString;

GetAnInt();
ImplicitTypingIsStrongTyping();
LinqQueryOverInts();

Console.ReadLine();

static void DeclareImplicitVars()
{
    // Неявно типизированные локальные переменные объявляются следующим образом:
    // var имяПеременной = начальноеЗначение;
    var myInt = 0;
    var myBool = true;
    var myString = "Time, marches on...";

    // Вывести имена лежащих в основе типов.
    Console.WriteLine("myInt является: {0}", myInt.GetType().Name);
    Console.WriteLine("myBool является: {0}", myBool.GetType().Name);
    Console.WriteLine("myString является: {0}", myString.GetType().Name);
    Console.WriteLine();
}

static int GetAnInt()
{
    var retVal = 9;
    return retVal;
}

static void ImplicitTypingIsStrongTyping()
{
    // Компилятор знает, что s имеет тип System.String.
    var s = "Эта переменная может содержать только строковые данные!";
    s = "Это нормально...";

    // Можно обращаться к любому члену лежащего в основе типа.
    string upper = s.ToUpper();
}

static void LinqQueryOverInts()
{
    int[] numbers = { 10, 20, 30, 40, 1, 2, 3, 8 };
    var subset = from i in numbers where i < 10 select i;

    Console.Write("Значения в subset: ");
    foreach (var i in subset) Console.Write($"{i} ");
    Console.WriteLine();

    // И к какому же типу относится subset?
    Console.WriteLine("subset является: {0}", subset.GetType().Name);
    Console.WriteLine("subset определён в: {0}", subset.GetType().Namespace);
}

static void DeclarelmplicitNumerics()
{
    // Неявно типизированные числовые переменные.
    var myUInt = 0u;
    var myInt = 0;
    var myLong = 0L;
    var myDouble = 0.5;
    var myFloat = 0.5F;
    var myDecimal = 0.5M;

    // Вывод лежащего в основе типа.
    Console.WriteLine($"myUInt: {myUInt.GetType().Name}");
    Console.WriteLine($"myInt: {myInt.GetType().Name}");
    Console.WriteLine($"myLong: {myLong.GetType().Name}");
    Console.WriteLine($"myDouble: {myDouble.GetType().Name}");
    Console.WriteLine($"myFloat: {myFloat.GetType().Name}");
    Console.WriteLine($"myDecimal: {myDecimal.GetType().Name}");
    Console.WriteLine();
}