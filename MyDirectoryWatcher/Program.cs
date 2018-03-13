using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MyDirectoryWatcher
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** Программное слежение за файлами *****");

            // Установить путь к каталогу, за которым нужно наблюдать.
            FileSystemWatcher watcher = new FileSystemWatcher();
            try
            {
                watcher.Path = @"D:\MyFolder";
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            // Указать цели наблюдения.
            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;

            // Следить только за текстовыми файлами.
            watcher.Filter = "*.txt";

            // Добавить обработчики событий.
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnChanged);
            watcher.Deleted += new FileSystemEventHandler(OnChanged);
            watcher.Renamed += new RenamedEventHandler(OnRenamed);

            // Начать наблюдение за каталогом.
            watcher.EnableRaisingEvents = true;

            // Ожидать команду пользователя на завершение программы.
            Console.WriteLine(@"Нажмите 'q', чтобы завершить программу.");
            while (Console.Read() != 'q') ;
        }

        static void OnChanged(object source, FileSystemEventArgs e)
        {
            // Сообщить о действии изменения, создания или удаления файла.
            Console.WriteLine($"Файл: {e.FullPath} {e.ChangeType}!");
        }

        static void OnRenamed(object source, RenamedEventArgs e)
        {
            // Сообщить о действии переименования файла.
            Console.WriteLine($"Файл: {e.OldFullPath} переименован в {e.FullPath}");
        }
    }
}
