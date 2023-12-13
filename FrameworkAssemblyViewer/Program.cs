using System.Reflection;

Console.WriteLine("***** Рефлексия сборок инфраструктуры *****");

// Загрузить Microsoft.EntityFrameworkCore.dll.
var displayName = "Microsoft.EntityFrameworkCore, Version=8.0.0.0, Culture=\"\", PublicKeyToken=adb9793829ddae60";
var asm = Assembly.Load(displayName);
DisplayInfo(asm);
Console.WriteLine("Готово!");
Console.ReadLine();

static void DisplayInfo(Assembly a)
{
    Console.WriteLine("***** Информация о сборке *****");
    Console.WriteLine($"Имя сборки: {a.GetName().Name}");
    Console.WriteLine($"Версия сборки: {a.GetName().Version}");
    Console.WriteLine($"Культура сборки: {a.GetName().CultureInfo?.DisplayName}");
    Console.WriteLine("Список открытых перечислений:");

    // Использовать запрос LINQ для нахождения открытых перечислений.
    Type[] types = a.GetTypes();
    var publicEnums = from pe in types where pe.IsEnum && pe.IsPublic select pe;
    foreach (var pe in publicEnums) Console.WriteLine(pe);
}