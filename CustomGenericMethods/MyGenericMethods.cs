using System;

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

        // BaseType - это метод, используемый в рефлексии.
        public static void DisplayBaseClass<T>() => Console.WriteLine($"Базовый класс {typeof(T)}: {typeof(T).BaseType}.");
    }
}
