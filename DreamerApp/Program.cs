using System;
using DreamerAppTest;

namespace DreamerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Dreamer.Name = "Дрим";
            Console.WriteLine(Dreamer.Name);
            Console.ReadLine();
        }
    }
}
