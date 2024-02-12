Console.WriteLine("***** Directory(Info) *****");
ShowWindowsDirectoryInfo();
DisplayImageFiles();
ModifyAppDirectory();
FunWithDirectoryType();
Console.ReadLine();

static void ShowWindowsDirectoryInfo()
{
    // Вывести информацию о каталоге.
    var dir = new DirectoryInfo($@"C{Path.VolumeSeparatorChar}{Path.DirectorySeparatorChar}Windows");
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
    var dir = new DirectoryInfo(@"C:\Windows\Web\Wallpaper");

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
    var dir = new DirectoryInfo(".");

    // Создать \MyFolder в каталоге приложения.
    dir.CreateSubdirectory("MyFolder");

    // Получить возвращённый объект DirectoryInfo.
    var myDataFolder = dir.CreateSubdirectory(@"MyFolder2\Data");

    // Выводит путь к ..\MyFolder2\Data.
    Console.WriteLine($"Новая папка: {myDataFolder}");
    Console.WriteLine();
}

static void FunWithDirectoryType()
{
    // Вывести список всех логических устройств на текущем компьютере.
    string[] drives = Directory.GetLogicalDrives();
    Console.WriteLine("Вот ваши устройства:");
    foreach (string s in drives) Console.WriteLine($"--> {s}");
    Console.WriteLine();

    // Удалить ранее созданные подкаталоги.
    Console.WriteLine("Нажмите Enter, чтобы удалить каталоги");
    Console.ReadLine();
    try
    {
        Directory.Delete("MyFolder");

        // Второй параметр указывает, нужно ли удалять внутренние подкаталоги.
        Directory.Delete("MyFolder2", true);
    }
    catch (IOException e)
    {
        Console.WriteLine(e.Message);
    }
}