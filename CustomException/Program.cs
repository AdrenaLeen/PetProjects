using CustomException;

Console.WriteLine("***** Настраиваемые исключения *****");
var myCar = new Car("Расти", 90);

try
{
    // Отслеживание исключения.
    myCar.Accelerate(50);
}
catch (CarIsDeadException e)
{
    Console.WriteLine(e.Message);
    Console.WriteLine(e.ErrorTimeStamp);
    Console.WriteLine(e.CauseOfError);
}

Console.ReadLine();