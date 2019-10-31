using System;

namespace ObjectContextApp
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** Объект контекста *****");

            // Объекты при создании будут отображать контекстную информацию.
            SportsCar sport = new SportsCar();
            Console.WriteLine();

            SportsCar sport2 = new SportsCar();
            Console.WriteLine();

            SportsCarTS synchroSport = new SportsCarTS();

            Console.ReadLine();
        }
    }
}
