﻿using SimpleException;
using System.Collections;

Console.WriteLine("***** Пример простого исключения *****");
Console.WriteLine("=> Создание автомобиля!");
var myCar = new Car("Циппи", 20);
myCar.CrankTunes(true);
try
{
    for (int i = 0; i < 10; i++) myCar.Accelerate(10);
}
catch (Exception e)
{
    Console.WriteLine("*** Ошибка! ***");
    Console.WriteLine($"Имя члена: {e.TargetSite}");
    Console.WriteLine($"Класс, определяющий член: {e.TargetSite?.DeclaringType}");
    Console.WriteLine($"Тип члена: {e.TargetSite?.MemberType}");
    Console.WriteLine($"Сообщение: {e.Message}");
    Console.WriteLine($"Источник: {e.Source}");
    Console.WriteLine($"Стек: {e.StackTrace}");
    Console.WriteLine($"HelpLink: {e.HelpLink}");
    Console.WriteLine("-> Произвольные данные:");
    foreach (DictionaryEntry de in e.Data) Console.WriteLine($"-> {de.Key}: {de.Value}");
}
// Ошибка была обработана, продолжается выполнение следующего оператора.
Console.WriteLine("***** Вне логики исключения *****");

Console.ReadLine();