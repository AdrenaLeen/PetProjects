using System.Reflection;

AddWithReflection();
AddWithDynamic();
Console.ReadLine();

static void AddWithReflection()
{
    var asm = Assembly.LoadFrom("MathLibrary");
    try
    {
        // Получить метаданные для типа SimpleMath.
        Type math = asm.GetType("MathLibrary.SimpleMath") ?? typeof(int);

        // Создать объект SimpleMath на лету.
        object obj = Activator.CreateInstance(math) ?? 0;

        // Получить информацию о методе Add().
        MethodInfo? mi = math.GetMethod("Add");

        // Вызвать метод (с параметрами).
        object[] args = [10, 70];
        Console.WriteLine($"Результат: {mi?.Invoke(obj, args)}");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

static void AddWithDynamic()
{
    var asm = Assembly.LoadFrom("MathLibrary");
    try
    {
        // Получить метаданные для типа SimpleMath.
        Type math = asm.GetType("MathLibrary.SimpleMath") ?? typeof(int);

        // Создать объект SimpleMath на лету.
        dynamic obj = Activator.CreateInstance(math) ?? 0;
        Console.WriteLine($"Результат: {obj.Add(10, 70)}");
    }
    catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException ex)
    {
        Console.WriteLine(ex.Message);
    }
}