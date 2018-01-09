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

            PrintValueAndAddress();

            Console.ReadLine();
        }

        unsafe static void SquareIntPointer(int* myIntPointer)
        {
            // Возвести значение в квадрат просто для тестирования.
            *myIntPointer *= *myIntPointer;
        }

        unsafe static void PrintValueAndAddress()
        {
            int myInt;

            // Определить указатель на int и присвоить ему адрес myInt.
            int* ptrToMyInt = &myInt;

            // Присвоить значение myInt, используя обращение через указатель.
            *ptrToMyInt = 123;

            // Вывести некоторые значения.
            Console.WriteLine($"Значение myInt: {myInt}");
            Console.WriteLine($"Адрес myInt: {(int)&ptrToMyInt:X}");
        }
    }
}
