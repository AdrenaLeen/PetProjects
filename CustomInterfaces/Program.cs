using CustomInterfaces;

Console.WriteLine("***** Интерфейсы *****");

CloneableExample();

// Обратиться к свойству Points, определенному в интерфейсе IPointy.
var hex = new Hexagon();
Console.WriteLine($"Количество вершин: {hex.Points}");

// Перехватить возможное исключение InvalidCastException.
var c = new Circle("Лиза");
try
{
    var itfPt = (IPointy)c;
    Console.WriteLine(itfPt.Points);
}
catch (InvalidCastException e)
{
    Console.WriteLine(e.Message);
}

// Можно ли hex2 трактовать как IPointy?
var hex2 = new Hexagon("Питэр");
IPointy itfPt2 = hex2;
if (itfPt2 != null) Console.WriteLine($"Количество вершин: {itfPt2.Points}");
else Console.WriteLine("Упс! Нет вершин...");
if (hex2 is IPointy itfPt3) Console.WriteLine($"Количество вершин: {itfPt3.Points}");
else Console.WriteLine("Упс! Нет вершин...");

var sq = new Square("Бокси") { NumberOfSides = 4, SideLength = 4 };
sq.Draw();
Console.WriteLine($"{sq.PetName} имеет {sq.NumberOfSides} стороны длиной {sq.SideLength} и периметром {((IRegularPointy)sq).Perimeter}");

Console.WriteLine($"Пример свойства: {IRegularPointy.ExampleProperty}");
IRegularPointy.ExampleProperty = "Обновлено";
Console.WriteLine($"Пример свойства: {IRegularPointy.ExampleProperty}");
var _ = new Square("Второй") { NumberOfSides = 4, SideLength = 3 };
Console.WriteLine($"Пример свойства: {IRegularPointy.ExampleProperty}");

// Создать массив элементов Shape.
Shape[] myShapes = { new Hexagon(), new Circle(), new Triangle("Джои"), new Circle("ЙоЙо") };
for (int i = 0; i < myShapes.Length; i++)
{
    // Можно ли нарисовать эту фигуру в трехмерном виде?
    if (myShapes[i] is IDraw3D s) DrawIn3D(s);
}

// Получить первый элемент, который имеет вершины.
IPointy? firstPointyItem = FindFirstPointyShape(myShapes);
// В целях безопасности использовать null-условную операцию.
Console.WriteLine($"У элемента {firstPointyItem?.Points} вершин");

// Этот массив может содержать только типы, которые реализуют интерфейс IPointy.
IPointy[] myPointyObjects = { new Hexagon(), new Knife(), new Triangle(), new Fork(), new PitchFork() };
foreach (IPointy i in myPointyObjects) Console.WriteLine($"У объекта {i.Points} вершин.");

Console.ReadLine();

static void CloneableExample()
{
    // Все эти классы поддерживают интерфейс ICloneable.
    string myStr = "Привет";
    var unixOS = new OperatingSystem(PlatformID.Unix, new Version());

    // Следовательно, все они могут быть переданы методу, принимающему параметр типа ICloneable.
    CloneMe(myStr);
    CloneMe(unixOS);
    static void CloneMe(ICloneable c)
    {
        // Клонировать то, что получено, и вывести имя.
        object theClone = c.Clone();
        Console.WriteLine($"Ваша копия: {theClone.GetType().Name}");
    }
}

// Будет рисовать любую фигуру, поддерживающую IDraw3D.
static void DrawIn3D(IDraw3D itf3d)
{
    Console.WriteLine("-> Отрисовка совместимых с IDraw3D типов");
    itf3d.Draw3D();
}

// Этот метод возвращает первый объект в массиве, который реализует интерфейс IPointy.
static IPointy? FindFirstPointyShape(Shape[] shapes)
{
    foreach (Shape s in shapes)
    {
        if (s is IPointy ip) return ip;
    }
    return null;
}