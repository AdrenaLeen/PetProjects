using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            ListAllAssembliesInAppDomain(defaultAD);

            // Создать новый домен приложения.
            MakeNewAppDomain();

            Console.ReadLine();
        }

        static void MakeNewAppDomain()
        {
            // Создать новый домен приложения в текущем процессе и вывести список загруженных сборок.
            AppDomain newAD = AppDomain.CreateDomain("SecondAppDomain");

            ListAllAssembliesInAppDomain(newAD);
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
