using SimpleSerialize;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

Console.WriteLine("***** Сериализация объектов *****");

// Создать объект JamesBondCar и установить состояние.
var jbc = new JamesBondCar
{
    canFly = true,
    canSubmerge = false,
    theRadio = new()
    {
        stationPresets = [89.3, 105.1, 97.1],
        hasTweeters = true
    }
};

var p = new Person
{
    FirstName = "James",
    isAlive = true
};

SaveAsXmlFormat(jbc, "CarData.xml");
Console.WriteLine("=> Машина сохранена в формате XML!");

SaveAsXmlFormat(p, "PersonData.xml");
Console.WriteLine("=> Человек сохранен в формате XML!");

SaveListOfCarsAsXml();

JamesBondCar? savedCar = ReadAsXmlFormat<JamesBondCar>("CarData.xml");
Console.WriteLine($"Оригинальная машина: {jbc}");
Console.WriteLine($"Прочитанная машина: {savedCar?.ToString()}");
List<JamesBondCar>? savedCars = ReadAsXmlFormat<List<JamesBondCar>>("CarCollection.xml");
if (savedCars != null)
{
    foreach (var c in savedCars) Console.WriteLine(c.ToString());
}

JsonSerializerOptions options = new()
{
    PropertyNameCaseInsensitive = true,
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    IncludeFields = true,
    WriteIndented = true,
    NumberHandling = JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString
};

SaveAsJsonFormat(options, jbc, "CarData.json");
Console.WriteLine("=> Машина сохранена в формате JSON!");

SaveAsJsonFormat(options, p, "PersonData.json");
Console.WriteLine("=> Человек сохранен в формате JSON!");

SaveListOfCarsAsJson(options, "CarCollection.json");

JamesBondCar? savedJsonCar = ReadAsJsonFormat<JamesBondCar>(options, "CarData.json");
Console.WriteLine($"Прочитанная машина: {savedJsonCar?.ToString()}");

List<JamesBondCar>? savedJsonCars = ReadAsJsonFormat<List<JamesBondCar>>(options, "CarCollection.json");
if (savedJsonCars != null)
{
    foreach (var c in savedJsonCars) Console.WriteLine(c.ToString());
}

Console.ReadLine();

static void SaveAsXmlFormat<T>(T objGraph, string fileName)
{
    // В конструкторе XmlSerializer должен быть объявлен тип.
    var xmlFormat = new XmlSerializer(typeof(T));
    using Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None);
    xmlFormat.Serialize(fStream, objGraph);
}

static void SaveListOfCarsAsXml()
{
    // Сохранить список List<T> объектов JamesBondCars.
    List<JamesBondCar> myCars =
    [
        new JamesBondCar { canFly = true, canSubmerge = true },
        new JamesBondCar { canFly = true, canSubmerge = false },
        new JamesBondCar { canFly = false, canSubmerge = true },
        new JamesBondCar { canFly = false, canSubmerge = false },
    ];

    using (Stream fStream = new FileStream("CarCollection.xml", FileMode.Create, FileAccess.Write, FileShare.None))
    {
        var xmlFormat = new XmlSerializer(typeof(List<JamesBondCar>));
        xmlFormat.Serialize(fStream, myCars);
    }
    Console.WriteLine("=> Список машин сохранён!");
}

static T? ReadAsXmlFormat<T>(string fileName)
{
    // Создать типизированный экземпляр класса XmlSerializer.
    var xmlFormat = new XmlSerializer(typeof(T));

    using Stream fStream = new FileStream(fileName, FileMode.Open);
    T? obj = default;
    obj = (T?)xmlFormat.Deserialize(fStream);
    return obj;
}

static void SaveAsJsonFormat<T>(JsonSerializerOptions options, T objGraph, string fileName)
    => File.WriteAllText(fileName, JsonSerializer.Serialize(objGraph, options));

static void SaveListOfCarsAsJson(JsonSerializerOptions options, string fileName)
{
    // Сохранить список List<T> объектов JamesBondCars.
    List<JamesBondCar> myCars =
    [
        new JamesBondCar { canFly = true, canSubmerge = true },
        new JamesBondCar { canFly = true, canSubmerge = false },
        new JamesBondCar { canFly = false, canSubmerge = true },
        new JamesBondCar { canFly = false, canSubmerge = false },
    ];

    File.WriteAllText(fileName, System.Text.Json.JsonSerializer.Serialize(myCars, options));
    Console.WriteLine("=> Saved list of cars!");
}

static T? ReadAsJsonFormat<T>(JsonSerializerOptions options, string fileName)
    => JsonSerializer.Deserialize<T>(File.ReadAllText(fileName), options);