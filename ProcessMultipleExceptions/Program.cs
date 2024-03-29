﻿using ProcessMultipleExceptions;

Console.WriteLine("***** Обработка множества исключений *****");
var myCar = new Car("Расти", 90);
myCar.CrankTunes(true);

try
{
    // Arg вызовет исключение выхода за пределы диапазона.
    myCar.Accelerate(-10);
}
catch (CarIsDeadException e) when (e.ErrorTimeStamp.DayOfWeek != DayOfWeek.Friday)
{
    try
    {
        // Попытка открытия файла carErrors.txt, расположенного на диске C:.
        FileStream fs = File.Open(@"C:\carErrors.txt", FileMode.Open);
    }
    catch (Exception e2)
    {
        // Сгенерировать исключение, которое записывает новое исключение, а также сообщение из первого исключения.
        throw new CarIsDeadException(e.CauseOfError, e.ErrorTimeStamp, e.Message, e2);
    }

    // Выполнить частичную обработку этой ошибки и передать ответственность.
    // Выводится, только если выражение в конструкции when вычисляется как true.
    Console.WriteLine("Обработка мёртвой машины!");
    Console.WriteLine(e.Message);
    throw;
}
catch (ArgumentOutOfRangeException e)
{
    Console.WriteLine(e.Message);
}
// Этот блок будет перехватывать любые исключения помимо CarIsDeadException и ArgumentOutOfRangeException.
catch (Exception e)
{
    Console.WriteLine(e.Message);
}
finally
{
    // Этот код будет выполняться всегда независимо от того, возникало исключение или нет.
    myCar.CrankTunes(false);
}

Console.ReadLine();