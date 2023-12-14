using System.Reflection;

Console.WriteLine("***** Позднее связывание *****");
// Попробовать загрузить локальную копию CarLibrary.
Assembly a;
try
{
    a = Assembly.LoadFrom("CarLibrary");
}
catch (FileNotFoundException ex)
{
    Console.WriteLine(ex.Message);
    return;
}
if (a != null)
{
    CreateUsingLateBinding(a);
    InvokeMethodWithArgsUsingLateBinding(a);
}

Console.ReadLine();

static void CreateUsingLateBinding(Assembly asm)
{
    try
    {
        // Получить метаданные для типа Minivan.
        Type miniVan = asm.GetType("CarLibrary.MiniVan") ?? typeof(int);

        // Создать экземпляр Minivan на лету.
        object obj = Activator.CreateInstance(miniVan) ?? 0;
        Console.WriteLine($"Создан {obj}, используя позднее связывание!");

        // Получить информацию о TurboBoost.
        MethodInfo? mi = miniVan.GetMethod("TurboBoost");

        // Вызвать метод (null означает отсутствие параметров).
        mi?.Invoke(obj, null);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

static void InvokeMethodWithArgsUsingLateBinding(Assembly asm)
{
    try
    {
        // Получить описание метаданных для типа SportsCar.
        Type sport = asm.GetType("CarLibrary.SportsCar") ?? typeof(int);

        // Создать объект типа SportsCar.
        object obj = Activator.CreateInstance(sport) ?? 0;

        // Вызвать метод TurnOnRadio() с аргументами.
        MethodInfo? mi = sport.GetMethod("TurnOnRadio");
        mi?.Invoke(obj, new object[] { true, 2 });
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}