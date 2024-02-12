using System.Threading.Channels;

Console.WriteLine("***** Программное слежение за файлами *****");

// Установить путь к каталогу, за которым нужно наблюдать.
var watcher = new FileSystemWatcher();

try
{
    watcher.Path = @".";
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
// Указать, что будет происходить при изменении, создании или удалении файла.
watcher.Changed += (s, e) => Console.WriteLine($"Файл: {e.FullPath} {e.ChangeType}!");
watcher.Created += (s, e) => Console.WriteLine($"Файл: {e.FullPath} {e.ChangeType}!");
watcher.Deleted += (s, e) => Console.WriteLine($"Файл: {e.FullPath} {e.ChangeType}!");

// Указать, что будет происходить при переименовании файла.
watcher.Renamed += (s, e) => Console.WriteLine($"Файл: {e.OldFullPath} переименован в {e.FullPath}");

// Начать наблюдение за каталогом.
watcher.EnableRaisingEvents = true;

// Ожидать команду пользователя на завершение программы.
Console.WriteLine(@"Нажмите 'q', чтобы завершить программу.");

// Сгенерировать несколько событий.
using (var sw = File.CreateText("Test.txt"))
{
    sw.Write("Немного текста");
}
File.Move("Test.txt", "Test2.txt");
File.Delete("Test2.txt");

while (Console.Read() != 'q') ;