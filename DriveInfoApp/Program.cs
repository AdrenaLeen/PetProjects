Console.WriteLine("***** DriveInfo *****");

// Получить информацию обо всех устройствах.
DriveInfo[] myDrives = DriveInfo.GetDrives();

// Вывести сведения об устройствах.
foreach (DriveInfo d in myDrives)
{
    Console.WriteLine($"Имя: {d.Name}");
    Console.WriteLine($"Тип: {d.DriveType}");

    // Проверить, смонтировано ли устройство.
    if (d.IsReady)
    {
        Console.WriteLine($"Свободное пространство: {d.TotalFreeSpace}");
        Console.WriteLine($"Формат устройства: {d.DriveFormat}");
        Console.WriteLine($"Метка тома: {d.VolumeLabel}");
    }
    Console.WriteLine();
}
Console.ReadLine();