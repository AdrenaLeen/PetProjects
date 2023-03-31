using SimpleFinalize;

Console.WriteLine("***** Финализаторы *****");
Console.WriteLine("Нажмите клавишу <Enter>, чтобы завершить приложение");
Console.WriteLine("и заставить сборщик мусора вызвать метод Finalize()");
Console.WriteLine("для всех финализируемых объектов, которые были созданы в домене этого приложения.");
Console.ReadLine();
var _ = new MyResourceWrapper();