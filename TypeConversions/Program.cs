using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeConversions
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** Сужающие и расширяющие преобразования типов данных *****");

            // Добавить две переменные типа short и вывести результат
            // Следующий код вызовет ошибку на этапе компиляции
            short numb1 = 30000, numb2 = 30000;

            // Явно привести int к short (и разрешить потерю данных).
            short answer = (short)Add(numb1, numb2);
            Console.WriteLine($"{numb1} + {numb2} = {answer}");

            NarrowingAttempt();
            
            Console.ReadLine();
        }

        static int Add(int x, int y)
        {
            return x + y;
        }

        // Снова ошибка на этапе компиляции
        static void NarrowingAttempt()
        {
            byte myByte = 0;
            int myInt = 200;
            // Явно привести int к byte (без потери данных).
            myByte = (byte)myInt;
            Console.WriteLine($"Значение myByte: {myByte}");
        }
    }
}
