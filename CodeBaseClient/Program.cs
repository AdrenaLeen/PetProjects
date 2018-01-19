using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarLibrary;

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
