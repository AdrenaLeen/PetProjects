Console.WriteLine("***** Асинхронные вызовы *****");
string message = await DoWorkAsync();
Console.WriteLine(message);

string message1 = await DoWorkAsync().ConfigureAwait(false);
Console.WriteLine(message1);

await MethodReturningTaskOfVoidAsync();
MethodReturningVoidAsync();
await MultipleAwaits();
Console.WriteLine(await ReturnAnInt());
await MethodWithProblems();
await MethodWithProblemsFixed(-5);
Console.WriteLine("Готово");
Console.ReadLine();

static async Task<string> DoWorkAsync()
{
    return await Task.Run(() =>
    {
        Thread.Sleep(5_000);
        return "Готово!";
    });
}

static async Task MethodReturningTaskOfVoidAsync()
{
    // Выполнение какой-то работы...
    await Task.Run(() => { Thread.Sleep(4_000); });
    Console.WriteLine("Пустой метод завершен");
}

static async void MethodReturningVoidAsync()
{
    // Выполнение какой-то работы...
    await Task.Run(() => { Thread.Sleep(4_000); });
    Console.WriteLine("Метод 'запустил и забыл' завершен");
}

static async Task MultipleAwaits()
{
    var task1 = Task.Run(() =>
    {
        Thread.Sleep(2_000);
        Console.WriteLine("Первая задача выполнена!");
    });

    var task2 = Task.Run(() =>
    {
        Thread.Sleep(1_000);
        Console.WriteLine("Вторая задача выполнена!");
    });

    var task3 = Task.Run(() =>
    {
        Thread.Sleep(1_000);
        Console.WriteLine("Третья задача выполнена!");
    });
    await Task.WhenAny(task1, task2, task3);
}

static async ValueTask<int> ReturnAnInt()
{
    await Task.Delay(1_000);
    return 5;
}

static async Task MethodWithProblems()
{
    Console.WriteLine("Вход");
    await Task.Run(() =>
    {
        // Вызвать длительно выполняющийся метод.
        Thread.Sleep(4_000);
        Console.WriteLine("Первый готов");
        
        // Вызвать еще один длительно выполняющийся метод, который терпит неудачу из-за того, что значение второго параметра выходит за пределы допустимого диапазона.
        Console.WriteLine("Случилось что-то плохое");
    });
}

static async Task MethodWithProblemsFixed(int secondParam)
{
    Console.WriteLine("Вход");
    if (secondParam < 0)
    {
        Console.WriteLine("Плохие данные");
        return;
    }

    await actualImplementation();

    static async Task actualImplementation()
    {
        await Task.Run(() =>
        {
            // Вызвать длительно выполняющийся метод.
            Thread.Sleep(4_000);
            Console.WriteLine("Первый готов");

            // Вызвать еще один длительно выполняющийся метод, который терпит неудачу из-за того, что значение второго параметра выходит за пределы допустимого диапазона.
            Console.WriteLine("Случилось что-то плохое");
        });
    }
}