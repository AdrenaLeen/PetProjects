using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceExtensions
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** Расширение типов, реализующих интерфейсы *****");

            // System.Array реализует IEnumerable!
            string[] data = { "Wow", "this", "is", "sort", "of", "annoying", "but", "in", "a", "weird", "way", "fun!"};

            data.PrintDataAndBeep();
            Console.WriteLine();

            // List<T> реализует IEnumerable!
            List<int> myInts = new List<int>() { 10, 15, 20 };
            myInts.PrintDataAndBeep();

            Console.ReadLine();
        }
    }
}
