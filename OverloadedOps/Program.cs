using OverloadedOps;

Console.WriteLine("***** Перегрузка операторов *****");

// Создать две точки.
var ptOne = new Point(100, 100);
var ptTwo = new Point(40, 40);
Console.WriteLine($"ptOne = {ptOne}");
Console.WriteLine($"ptTwo = {ptTwo}");

// Сложить две точки, чтобы получить большую?
Console.WriteLine($"ptOne + ptTwo: {ptOne + ptTwo}");

// Вычесть одну точку из другой, чтобы получить меньшую?
Console.WriteLine("ptOne - ptTwo: {0} ", ptOne - ptTwo);

// Выводит [110, 110]
Point biggerPoint = ptOne + 10;
Console.WriteLine($"ptOne + 10 = {biggerPoint}");

// Выводит [120, 120]
Console.WriteLine($"10 + biggerPoint = {10 + biggerPoint}");
Console.WriteLine();

// Операция += перегружена автоматически.
var ptThree = new Point(90, 5);
Console.WriteLine($"ptThree = {ptThree}");
Console.WriteLine($"ptThree += ptTwo: {ptThree += ptTwo}");

// Операция -= перегружена автоматически.
var ptFour = new Point(0, 500);
Console.WriteLine($"ptFour = {ptFour}");
Console.WriteLine($"ptFour -= ptThree: {ptFour -= ptThree}");
Console.WriteLine();

// Применение унарных операций ++ и -- к объекту Point.
var ptFive = new Point(1, 1);
// [2, 2]
Console.WriteLine($"++ptFive = {++ptFive}");
// [1, 1]
Console.WriteLine($"--ptFive = {--ptFive}");

// Применение тех же операций в виде постфиксного инкремента/декремента.
var ptSix = new Point(20, 20);
// [20, 20]
Console.WriteLine($"ptSix++ = {ptSix++}");
// [21, 21]
Console.WriteLine($"ptSix-- = {ptSix--}");
Console.WriteLine();

// Использование перегруженных операций эквивалентности.
Console.WriteLine($"ptOne == ptTwo: {ptOne == ptTwo}");
Console.WriteLine($"ptOne != ptTwo: {ptOne != ptTwo}");
Console.WriteLine();

// Использование перегруженных операций < и >.
Console.WriteLine($"ptOne < ptTwo: {ptOne < ptTwo}");
Console.WriteLine($"ptOne > ptTwo: {ptOne > ptTwo}");

Console.ReadLine();