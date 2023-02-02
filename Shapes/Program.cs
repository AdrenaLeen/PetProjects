using Shapes;

Console.WriteLine("***** Полиморфизм *****");

// Создать массив совместимых с Shape объектов.
Shape[] myShapes = { new Hexagon(), new Circle(), new Hexagon("Мик"), new Circle("Бэт"), new Hexagon("Линда") };

// Пройти в цикле по всем элементам и взаимодействовать с полиморфным интерфейсом.
foreach (Shape s in myShapes) s.Draw();

// Здесь вызывается метод Draw(), определённый в классе ThreeDCircle.
var o = new ThreeDCircle();
ThreeDCircle.Draw();

// Здесь вызывается метод Draw(), определённый в родительском классе!
((Circle)o).Draw();

Console.ReadLine();