using AttributedCarLibrary;
using System;

namespace VehicleDescriptionAttributeReader
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** Значение VehicleDescriptionAttribute *****");
            ReflectOnAttributesWithEarlyBinding();
            Console.ReadLine();
        }

        private static void ReflectOnAttributesWithEarlyBinding()
        {
            // Получить объект Type, который представляет тип Winnebago.
            Type t = typeof(Winnebago);

            // Получить все атрибуты Winnebago.
            object[] customAtts = t.GetCustomAttributes(false);

            // Вывести описание.
            foreach (VehicleDescriptionAttribute v in customAtts) Console.WriteLine($"-> {v.Description}");
        }
    }
}
