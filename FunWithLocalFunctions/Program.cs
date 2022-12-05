Console.WriteLine("Локальные функции");

// Вызвать оригинальную версию Add().
Console.WriteLine(Add(10, 10));

// Вызвать обновлённую версию Add().
Console.WriteLine(AddWrapper(10, 10));

Console.WriteLine(AddWrapperWithSideEffect(10, 10));

// Now it's all better :-)
Console.WriteLine(AddWrapperWithStatic(10, 10));
Console.ReadLine();

// Выполнить здесь проверку достоверности.
static int Add(int x, int y) => x + y;

static int AddWrapper(int x, int y)
{
    // Выполнить здесь проверку достоверности.
    return Add();
    int Add() => x + y;
}

static int AddWrapperWithSideEffect(int x, int y)
{
    // Здесь должна выполняться какая-то проверка достоверности.
    return Add();

    int Add()
    {
        x += 1;
        return x + y;
    }
}
static int AddWrapperWithStatic(int x, int y)
{
    // Здесь должна выполняться какая-то проверка достоверности.
    return Add(x, y);

    static int Add(int x, int y) => x + y;
}