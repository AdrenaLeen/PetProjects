using AttributedCarLibrary;

Console.WriteLine("***** Значение VehicleDescriptionAttribute *****");
ReflectOnAttributesWithEarlyBinding();
Console.ReadLine();

static void ReflectOnAttributesWithEarlyBinding()
{
    // Получить объект Type, который представляет тип Winnebago.
    Type t = typeof(Winnebago);

    // Получить все атрибуты Winnebago.
    object[] customAtts = t.GetCustomAttributes(false);

    // Вывести описание.
    foreach (VehicleDescriptionAttribute v in customAtts.Cast<VehicleDescriptionAttribute>()) Console.WriteLine($"-> {v.Description}");
}