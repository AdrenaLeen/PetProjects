using InterfaceHierarchy;

Console.WriteLine("***** Простая иерархия интерфейсов *****");

// Вызвать на уровне объекта.
var myBitmap = new BitmapImage();
myBitmap.Draw();
myBitmap.DrawInBoundingBox(10, 10, 100, 150);
myBitmap.DrawUpsideDown();

// Получить IAdvancedDraw явным образом.
if (myBitmap is IAdvancedDraw iAdvDraw)
{
    iAdvDraw.DrawUpsideDown();
    Console.WriteLine($"Время на отрисовку: {iAdvDraw.TimeToDraw()}");
}

// Всегда вызывается метод на экземпляре:
Console.WriteLine("***** Вызов реализованного TimeToDraw *****");
Console.WriteLine($"Время на отрисовку: {myBitmap.TimeToDraw()}");
Console.WriteLine($"Время на отрисовку: {((IDrawable)myBitmap).TimeToDraw()}");
Console.WriteLine($"Время на отрисовку: {((IAdvancedDraw)myBitmap).TimeToDraw()}");

Console.ReadLine();