using StaticDataAndMembers;

Console.WriteLine("***** Статические данные *****");
// Создать объект счёта.
var s1 = new SavingsAccount(50);
// Вывести текущую процентную ставку.
Console.WriteLine($"Процентная ставка: {SavingsAccount.GetInterestRate()}");

// Попытаться изменить процентную ставку через свойство.
SavingsAccount.SetInterestRate(0.08);

// Создать второй объект счёта.
var s2 = new SavingsAccount(100);
// Должно быть выведено 0.08... не так ли?
Console.WriteLine($"Процентная ставка: {SavingsAccount.GetInterestRate()}");

// Создать новый объект; это не 'сбросит' процентную ставку.
var s3 = new SavingsAccount(10000.75);
Console.WriteLine($"Процентная ставка: {SavingsAccount.GetInterestRate()}");

Console.WriteLine("***** Статические классы *****");

// Это работает нормально.
TimeUtilClass.PrintDate();
TimeUtilClass.PrintTime();

Console.ReadLine();