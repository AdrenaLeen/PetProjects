using CarLibrary;
using System;

namespace CodeBaseClient
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** CodeBase *****");
            SportsCar c = new SportsCar();
            Console.WriteLine("Был выделен спортивный автомобиль.");
            Console.ReadLine();
        }
    }
}
