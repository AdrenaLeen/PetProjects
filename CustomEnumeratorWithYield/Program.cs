using System;

namespace CustomEnumeratorWithYield
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** Ключевое слово yield *****");
            Garage carLot = new Garage();

            // Получить элементы, используя GetEnumerator().
            foreach (Car c in carLot) Console.WriteLine($"{c.PetName} едет со скоростью {c.CurrentSpeed} км/ч");
            Console.WriteLine();

            // Получить элементы (в обратном порядке!), используя именованный итератор.
            foreach (Car c in carLot.GetTheCars(true)) Console.WriteLine($"{c.PetName} едет со скоростью {c.CurrentSpeed} км/ч");

            Console.ReadLine();
        }
    }
}
