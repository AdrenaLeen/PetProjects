using ObjectsInitializers;

Console.WriteLine("***** Синтаксис инициализации объектов *****");

// Создать объект Point, устанавливая каждое свойство вручную.
var firstPoint = new Point();
firstPoint.X = 10;
firstPoint.Y = 10;
firstPoint.DisplayStats();
Console.WriteLine();

// Создать объект Point посредством специального конструктора.
var anotherPoint = new Point(20, 20);
anotherPoint.DisplayStats();
Console.WriteLine();

// Создать объект Point, используя синтаксис инициализации объектов.
// Здесь стандартный конструктор вызывается неявно.
var finalPoint = new Point { X = 30, Y = 30 };
finalPoint.DisplayStats();
Console.WriteLine();

// Создать объект точки, который допускает только чтение после конструирования.
var firstReadonlyPoint = new PointReadOnlyAfterCreation(20, 20);
firstReadonlyPoint.DisplayStats();
Console.WriteLine();

// Или создать объект точки с использованием синтаксиса только для инициализации.
var secondReadonlyPoint = new PointReadOnlyAfterCreation { X = 30, Y = 30 };
secondReadonlyPoint.DisplayStats();
Console.WriteLine();

// Вызов более интересного специального конструктора с помощью синтаксиса инициализации.
var goldPoint = new Point(PointColorEnum.Gold) { X = 90, Y = 20 };
goldPoint.DisplayStats();
Console.WriteLine();

// Создать и инициализировать объект Rectangle.
var myRect = new Rectangle
{
    TopLeft = new Point { X = 10, Y = 10 },
    BottomRight = new Point { X = 200, Y = 200 }
};
myRect.DisplayStats();

Console.ReadLine();