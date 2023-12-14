using System.Reflection;

Console.WriteLine("***** Значение VehicleDescriptionAttribute *****");
ReflectAttributesUsingLateBinding();
Console.ReadLine();

static void ReflectAttributesUsingLateBinding()
{
    try
    {
        // Загрузить локальную копию сборки AttributedCarLibrary.
        var asm = Assembly.LoadFrom("AttributedCarLibrary");

        // Получить информацию о типе VehicleDescriptionAttribute.
        Type vehicleDesc = asm.GetType("AttributedCarLibrary.VehicleDescriptionAttribute") ?? typeof(int);

        // Получить информацию о типе свойства Description.
        PropertyInfo? propDesc = vehicleDesc.GetProperty("Description");

        // Получить все типы в сборке.
        Type[] types = asm.GetTypes();

        // Пройти по всем типам и получить любые атрибуты VehicleDescriptionAttributes.
        foreach (Type t in types)
        {
            object[] objs = t.GetCustomAttributes(vehicleDesc, false);

            // Пройти по каждому VehicleDescriptionAttribute и вывести описание, используя позднее связывание.
            foreach (object o in objs) Console.WriteLine($"-> {t.Name}: {propDesc?.GetValue(o, null)}");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}