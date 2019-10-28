using System;

namespace SimpleFinalize
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** Финализаторы *****");
            Console.WriteLine("Нажмите клавишу <Enter>, чтобы завершить приложение");
            Console.WriteLine("и заставить сборщик мусора вызвать метод Finalize()");
            Console.WriteLine("для всех финализируемых объектов, которые были созданы в домене этого приложения.");
            Console.ReadLine();
            MyResourceWrapper rw = new MyResourceWrapper();
        }
    }
}
