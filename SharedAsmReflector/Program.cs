using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SharedAsmReflector
{
    class Program
    {
        private static void DisplayInfo(Assembly a)
        {
            Console.WriteLine("***** Информация о сборке *****");
            Console.WriteLine($"Загружена из GAC? {a.GlobalAssemblyCache}");
            Console.WriteLine($"Имя сборки: {a.GetName().Name}");
            Console.WriteLine($"Версия сборки: {a.GetName().Version}");
            Console.WriteLine($"Культура сборки: {a.GetName().CultureInfo.DisplayName}");
            Console.WriteLine("Список открытых перечислений:");

            // Использовать запрос LINQ для нахождения открытых перечислений.
            Type[] types = a.GetTypes();
            IEnumerable<Type> publicEnums = from pe in types where pe.IsEnum && pe.IsPublic select pe;
            foreach (Type pe in types) Console.WriteLine(pe);
        }

        static void Main()
        {
            Console.WriteLine("***** Рефлексия разделяемых сборок *****");
            // Загрузить System.Windows.Forms.dll из GAC.
            string displayName = "System.Windows.Forms,Version=4.0.0.0,PublicKeyToken=b77a5c561934e089,Culture=\"\"";
            Assembly asm = Assembly.Load(displayName);
            DisplayInfo(asm);
            Console.WriteLine("Готово!");
            Console.ReadLine();
        }
    }
}
