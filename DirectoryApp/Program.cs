using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DirectoryApp
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** Directory(Info) *****\n");
            ShowWindowsDirectoryInfo();
            Console.ReadLine();
        }

        static void ShowWindowsDirectoryInfo()
        {
            // Вывести информацию о каталоге.
            DirectoryInfo dir = new DirectoryInfo(@"C:\Windows");
            Console.WriteLine("***** Информация о каталоге *****");
            Console.WriteLine($"Полное имя: {dir.FullName}");
            Console.WriteLine($"Имя каталога: {dir.Name}");
            Console.WriteLine($"Родительский каталог: {dir.Parent}");
            Console.WriteLine($"Время создания: {dir.CreationTime}");
            Console.WriteLine($"Атрибуты: {dir.Attributes}");
            Console.WriteLine($"Корневой каталог: {dir.Root}");
            Console.WriteLine();
        }
    }
}
