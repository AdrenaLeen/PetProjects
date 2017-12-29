using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomGenericMethods
{
    public static class MyGenericMethods
    {
        // Этот метод будет менять местами два элемента типа, указанного в параметре <T>.
        public static void Swap<T>(ref T a, ref T b)
        {
            Console.WriteLine($"Вы послали методу Swap() {typeof(T)}");
            T temp;
            temp = a;
            a = b;
            b = temp;
        }

        public static void DisplayBaseClass<T>()
        {
            // BaseType - это метод, используемый в рефлексии.
            Console.WriteLine($"Базовый класс {typeof(T)}: {typeof(T).BaseType}.");
        }
    }
}
