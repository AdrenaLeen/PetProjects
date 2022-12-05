Console.WriteLine("**** Тип enum *****");

// Создать переменную типа EmpType.
EmpTypeEnum emp = EmpTypeEnum.Contractor;
AskForBonus(emp);
Console.WriteLine();

// Вывести тип хранилища для значений перечисления.
Console.WriteLine($"EmpType использует {Enum.GetUnderlyingType(emp.GetType())} для хранения");
Console.WriteLine();

// На этот раз для получения информации о типе используется операция typeof.
Console.WriteLine($"EmpType использует {Enum.GetUnderlyingType(typeof(EmpTypeEnum))} для хранения");
Console.WriteLine();

// Выводит строку "emp является Contractor".
Console.WriteLine($"emp является {emp}");
Console.WriteLine();

// Выводит строку "Contractor = 100".
Console.WriteLine($"{emp} = {(byte)emp}");
Console.WriteLine();

EmpTypeEnum e2 = EmpTypeEnum.Contractor;
// Эти типы являются перечислениями из пространства имен System.
DayOfWeek day = DayOfWeek.Monday;
ConsoleColor cc = ConsoleColor.Gray;
EvaluateEnum(e2);
EvaluateEnum(day);
EvaluateEnum(cc);

Console.ReadLine();

// Перечисления как параметры
static void AskForBonus(EmpTypeEnum e)
{
    switch (e)
    {
        case EmpTypeEnum.Manager:
            Console.WriteLine("Не желаете ли взамен фондовые опционы?");
            break;
        case EmpTypeEnum.Grunt:
            Console.WriteLine("Вы, должно быть, шутите...");
            break;
        case EmpTypeEnum.Contractor:
            Console.WriteLine("Вы уже получаете вполне достаточно...");
            break;
        case EmpTypeEnum.VicePresident:
            Console.WriteLine("Очень хорошо, сэр!");
            break;
    }
}

// Этот метод выводит детали любого перечисления.
static void EvaluateEnum(Enum e)
{
    Console.WriteLine($"=> Информация о {e.GetType().Name}");
    Console.WriteLine($"Базовый тип хранения: {Enum.GetUnderlyingType(e.GetType())}");

    // Получить все пары "имя-значение" для входного параметра.
    Array enumData = Enum.GetValues(e.GetType());
    Console.WriteLine($"У этого перечисления {enumData.Length} членов.");

    // Вывести строковое имя и ассоциированное значение, используя флаг формата D.
    for (int i = 0; i < enumData.Length; i++) Console.WriteLine("Имя: {0}, значение: {0:D}", enumData.GetValue(i));
    Console.WriteLine();
}

// Специальное перечисление.
enum EmpTypeEnum : byte
{
    Manager = 10,
    Grunt = 1,
    Contractor = 100,
    VicePresident = 9
}