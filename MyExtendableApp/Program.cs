using CommonSnappableTypes;
using System.Reflection;

do
{
    Console.Write("Введите оснастку для загрузки или Q для завершения: ");

    // Получить имя типа.
    string typeName = Console.ReadLine() ?? "int";

    // Желает ли пользователь завершить работу?
    if (typeName.Equals("Q", StringComparison.OrdinalIgnoreCase)) break;
    
    // Попытаться отобразить тип.
    try
    {
        LoadExternalModule(typeName);
    }
    catch (Exception ex)
    {
        Console.WriteLine("Sorry, can't find snapin");
    }
}
while (true);

static void LoadExternalModule(string assemblyName)
{
    Assembly? theSnapInAsm = null;

    try
    {
        // Динамически загрузить выбранную сборку.
        theSnapInAsm = Assembly.LoadFrom(assemblyName);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Ошибка при загрузке оснастки: {ex.Message}");
        return;
    }

    // Получить все совместимые с IAppFunctionality классы в сборке.
    var theClassTypes = theSnapInAsm
        .GetTypes()
        .Where(t => t.IsClass && (t.GetInterface("IAppFunctionality") != null))
        .ToList();
    if (theClassTypes.Count == 0)
    {
        Console.WriteLine("Ни один класс не реализует IAppFunctionality!");
    }

    // Создать объект и вызвать метод DoIt().
    foreach (Type t in theClassTypes)
    {
        // Использовать позднее связывание для создания экземпляра типа.
        var itfApp = (IAppFunctionality?)theSnapInAsm.CreateInstance(t.FullName ?? "CSharpModule", true);
        itfApp?.DoIt();

        // Отобразить информацию о компании.
        DisplayCompanyData(t);
    }
}
static void DisplayCompanyData(Type t)
{
    // Получить данные [CompanyInfo].
    var compInfo = t
        .GetCustomAttributes(false)
        .Where(ci => (ci is CompanyInfoAttribute));

    // Отобразить данные.
    foreach (CompanyInfoAttribute c in compInfo.Cast<CompanyInfoAttribute>()) Console.WriteLine($"Больше о {c.CompanyName} можно найти на {c.CompanyUrl}");
}