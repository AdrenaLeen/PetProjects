using static FunWithMethodOverloading.AddOperations;

Console.WriteLine("***** Перегрузка методов *****");

// Вызов int-версии Add().
Console.WriteLine(Add(10, 10));

// Вызов long-версии Add() с использованием нового разделителя групп цифр.
Console.WriteLine(Add(900_000_000_000, 900_000_000_000));

// Вызов double-версии Add().
Console.WriteLine(Add(4.3, 4.4));

Console.ReadLine();