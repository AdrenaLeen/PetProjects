using FunWithStructures;

Console.WriteLine("***** Структуры *****");
// Создать начальную переменную типа Point.
Point myPoint;
myPoint.X = 349;
myPoint.Y = 76;
myPoint.Display();

// Скорректировать значения X и Y.
myPoint.Increment();
myPoint.Display();

// Все в порядке! Перед использованием значения присвоены обоим полям.
Point p2;
p2.X = 10;
p2.Y = 10;
p2.Display();

// Установить для всех полей стандартные значения, используя стандартный конструктор.
var p1 = new Point();
// Выводит X=0, Y=0.
p1.Display();

// Вызвать специальный конструктор
var p3 = new Point(50, 60);
// Выводит X=50, Y=60.
p3.Display();

var p4 = new PointWithReadOnly(50, 60, "Point w/RO");
p4.Display();

var s = new DisposableRefStruct(50, 60);
s.Display();
s.Dispose();

Console.ReadLine();