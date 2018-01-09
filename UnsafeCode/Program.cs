using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnsafeCode
{
    class Program
    {
        unsafe static void Main()
        {
            int myInt2 = 5;
            SquareIntPointer(&myInt2);
            Console.WriteLine($"myInt: {myInt2}");

            Console.ReadLine();
        }

        unsafe static void SquareIntPointer(int* myIntPointer)
        {
            // Возвести значение в квадрат просто для тестирования.
            *myIntPointer *= *myIntPointer;
        }
    }
}
