using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace CustomAppDomains
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** Специальные домены приложения *****");

            // Вывести все сборки, загруженные в стандартный домен приложения.
            AppDomain defaultAD = AppDomain.CurrentDomain;
            defaultAD.ProcessExit += (o, s) => Console.WriteLine("Стандартный домен приложения выгружен!");
            ListAllAssembliesInAppDomain(defaultAD);

            // Создать новый домен приложения.
            MakeNewAppDomain();

            Console.ReadLine();
        }

        static void MakeNewAppDomain()
        {
            // Создать новый домен приложения в текущем процессе.
            AppDomain newAD = AppDomain.CreateDomain("SecondAppDomain");

            newAD.DomainUnload += (o, s) => Console.WriteLine("Второй домен приложения был загружен!");

            try
            {
                // Загрузить CarLibrary.dll в этот новый домен.
                newAD.Load("CarLibrary");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }

            // Вывести список всех сборок.
            ListAllAssembliesInAppDomain(newAD);

            // Уничтожить этот домен приложения.
            AppDomain.Unload(newAD);
        }

        static void ListAllAssembliesInAppDomain(AppDomain ad)
        {
            // Получить все сборки, загруженные в стандартный домен приложения.
            IOrderedEnumerable<Assembly> loadedAssemblies = from a in ad.GetAssemblies()
                                                            orderby a.GetName().Name
                                                            select a;

            Console.WriteLine($"***** Здесь сборки, загруженные в {ad.FriendlyName} *****");
            foreach (Assembly a in loadedAssemblies)
            {
                Console.WriteLine($"-> Имя: {a.GetName().Name}");
                Console.WriteLine($"-> Версия: {a.GetName().Version}");
                Console.WriteLine();
            }
        }
    }
}
