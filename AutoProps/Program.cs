using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoProps
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** Автоматические свойства *****");
            Car c = new Car();
            c.PetName = "Франк";
            c.Speed = 55;
            c.Color = "Красный";
            Console.WriteLine($"Вашу машину зовут {c.PetName}? Это странно...");
            c.DisplayStats();

            Console.ReadLine();
        }
    }
}
