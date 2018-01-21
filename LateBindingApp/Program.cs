using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace LateBindingApp
{
    // Это приложение будет загружать внешнюю сборку и создавать объект, используя позднее связывание.
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** Позднее связывание *****");
            // Попробовать загрузить локальную копию CarLibrary.
            Assembly a = null;
            try
            {
                a = Assembly.Load("CarLibrary");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            if (a != null) CreateUsingLateBinding(a);

            Console.ReadLine();
        }

        static void CreateUsingLateBinding(Assembly asm)
        {
            try
            {
                // Получить метаданные для типа Minivan.
                Type miniVan = asm.GetType("CarLibrary.MiniVan");

                // Создать экземпляр Minivan на лету.
                object obj = Activator.CreateInstance(miniVan);
                Console.WriteLine($"Создан {obj}, используя позднее связывание!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
