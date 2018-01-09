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

            Console.WriteLine("***** Вызов методов с небезопасным кодом *****");

            // Значения, которые подлежат обмену.
            int i = 10, j = 20;

            // "Безопасный" обмен значений.
            Console.WriteLine("***** Безопасный обмен *****");
            Console.WriteLine($"Значения до безопасного обмена: i = {i}, j = {j}");
            SafeSwap(ref i, ref j);
            Console.WriteLine($"Значения после безопасного обмена: i = {i}, j = {j}");

            // "Небезопасный" обмен значений
            Console.WriteLine("***** Небезопасный обмен *****");
            Console.WriteLine($"Значения до небезопасного обмена: i = {i}, j = {j}");
            UnsafeSwap(&i, &j);
            Console.WriteLine($"Значения после небезопасного обмена: i = {i}, j = {j}");

            UsePointerToPoint();
            UnsafeStackAlloc();
            UseAndPinPoint();

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

        unsafe public static void UnsafeSwap(int* i, int* j)
        {
            int temp = *i;
            *i = *j;
            *j = temp;
        }

        public static void SafeSwap(ref int i, ref int j)
        {
            int temp = i;
            i = j;
            j = temp;
        }

        unsafe static void UsePointerToPoint()
        {
            // Доступ к членам через указатель.
            Point point;
            Point* p = &point;
            p->x = 100;
            p->y = 200;
            Console.WriteLine(p->ToString());

            // Доступ к членам через разыменованный указатель.
            Point point2;
            Point* p2 = &point2;
            (*p2).x = 100;
            (*p2).y = 200;
            Console.WriteLine((*p2).ToString());
        }

        unsafe static void UnsafeStackAlloc()
        {
            char* p = stackalloc char[256];
            for (int k = 0; k < 256; k++) p[k] = (char)k;
        }

        unsafe public static void UseAndPinPoint()
        {
            PointRef pt = new PointRef();
            pt.x = 5;
            pt.y = 6;

            // Закрепить указатель pt на месте, чтобы он не мог быть перемещён или уничтожен сборщиком мусора.
            fixed (int* p = &pt.x)
            {
                // Использовать здесь переменную int*!
            }

            // Указатель pt теперь не закреплён и готов к сборке мусора после завершения метода.
            Console.WriteLine($"Point: {pt}");
        }
    }
}
