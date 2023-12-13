using System.Reflection;

Console.WriteLine("***** Динамически загружаемые сборки *****");
do
{
    Console.Write("Введите имя сборки для оценки или введите Q для выхода: ");

    // Получить имя сборки.
    string asmName = Console.ReadLine() ?? string.Empty;

    // Пользователь желает завершить программу?
    if (asmName.Equals("Q", StringComparison.CurrentCultureIgnoreCase)) break;

    // Попробовать загрузить сборку.
    try
    {
        var asm = Assembly.LoadFrom(asmName);
        DisplayTypesInAsm(asm);
    }
    catch
    {
        Console.WriteLine("Сборка не найдена.");
    }
} while (true);

static void DisplayTypesInAsm(Assembly asm)
{
    Console.WriteLine("***** Типы в сборке *****");
    Console.WriteLine($"->{asm.FullName}");
    Type[] types = asm.GetTypes();
    foreach (Type t in types) Console.WriteLine($"Тип: {t}");
    Console.WriteLine("");
}