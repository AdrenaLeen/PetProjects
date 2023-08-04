var cancelToken = new CancellationTokenSource();

do
{
    Console.WriteLine("Нажмите любую клавишу, чтобы начать обработку");
    Console.ReadKey();

    Console.WriteLine("Обработка");
    await Task.Factory.StartNew(ProcessIntData);

    Console.Write("Введите Q для выхода: ");
    string answer = Console.ReadLine() ?? string.Empty;

    // Желает ли пользователь выйти?
    if (answer.Equals("Q", StringComparison.OrdinalIgnoreCase))
    {
        cancelToken.Cancel();
        break;
    }
} while (true);
Console.ReadLine();

void ProcessIntData()
{
    // Получить очень большой массив целых чисел.
    int[] source = Enumerable.Range(1, 10000000).ToArray();

    // Найти числа, для которых истинно условие num % 3 == 0, и возвратить их в убывающем порядке.
    int[] modThreeIsZero = Array.Empty<int>();
    try
    {
        modThreeIsZero = (from num in source.AsParallel().WithCancellation(cancelToken.Token)
                          where num % 3 == 0
                          orderby num descending
                          select num).ToArray();
        Console.WriteLine($"Найдено {modThreeIsZero.Length} чисел, которые соответствуют запросу!");
    }
    catch (OperationCanceledException ex)
    {
        Console.WriteLine(ex.Message);
    }
}