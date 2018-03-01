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
            DisplayImageFiles();
            ModifyAppDirectory();
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

        static void DisplayImageFiles()
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Windows\Web\Wallpaper");

            // Получить все файлы с расширением *.jpg.
            FileInfo[] imageFiles = dir.GetFiles("*.jpg", SearchOption.AllDirectories);

            // Сколько файлов найдено?
            Console.WriteLine($"Найдено {imageFiles.Length} *.jpg файлов");
            Console.WriteLine();

            // Вывести информацию о каждом файле.
            foreach (FileInfo f in imageFiles)
            {
                Console.WriteLine($"Имя файла: {f.Name}");
                Console.WriteLine($"Размер: {f.Length}");
                Console.WriteLine($"Время создания: {f.CreationTime}");
                Console.WriteLine($"Атрибуты: {f.Attributes}");
                Console.WriteLine();
            }
        }

        static void ModifyAppDirectory()
        {
            DirectoryInfo dir = new DirectoryInfo(".");

            // Создать \MyFolder в каталоге приложения.
            dir.CreateSubdirectory("MyFolder");

            // Получить возвращённый объект DirectoryInfo.
            DirectoryInfo myDataFolder = dir.CreateSubdirectory(@"MyFolder2\Data");

            // Выводит путь к ..\MyFolder2\Data.
            Console.WriteLine($"Новая папка: {myDataFolder}");
        }
    }
}
