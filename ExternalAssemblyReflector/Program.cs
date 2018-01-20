using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace ExternalAssemblyReflector
{
    class Program
    {
        static void DisplayTypesInAsm(Assembly asm)
        {
            Console.WriteLine("***** Типы в сборке *****");
            Console.WriteLine($"->{asm.FullName}");
            Type[] types = asm.GetTypes();
            foreach (Type t in types) Console.WriteLine($"Тип: {t}");
            Console.WriteLine("");
        }

        static void Main()
        {
            Console.WriteLine("***** Динамически загружаемые сборки *****");
            string asmName = "";
            Assembly asm = null;
            do
            {
                Console.Write("Введите имя сборки для оценки или введите Q для выхода: ");

                // Получить имя сборки.
                asmName = Console.ReadLine();

                // Пользователь желает завершить программу?
                if (asmName.ToUpper() == "Q") break;

                // Попробовать загрузить сборку.
                try
                {
                    asm = Assembly.LoadFrom(asmName);
                    DisplayTypesInAsm(asm);
                }
                catch
                {
                    Console.WriteLine("Сборка не найдена.");
                }
            } while (true);
        }
    }
}
