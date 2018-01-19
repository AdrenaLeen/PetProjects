using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarLibrary;

namespace SharedCarLibClient
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** Клиент для разделяемой сборки *****");
            SportsCar c = new SportsCar();
            c.TurboBoost();
            Console.ReadLine();
        }
    }
}
