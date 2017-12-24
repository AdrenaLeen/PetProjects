using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomEnumerator
{
    // Код выглядит корректным...
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** IEnumerable / IEnumerator *****");
            Garage carLot = new Garage();

            // Проход по всем объектам Car в коллекции?
            foreach (Car c in carLot) Console.WriteLine($"{c.PetName} едет со скоростью {c.CurrentSpeed} км/ч");

            Console.ReadLine();
        }
    }
}
