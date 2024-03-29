﻿using FunWithValueAndReferenceTypes;

Console.WriteLine("***** Типы значения, ссылочные типы и операции присваивания *****");
ValueTypeAssignment();
Console.WriteLine();

ReferenceTypeAssignment();
Console.WriteLine();

ValueTypeContainingRefType();
Console.ReadLine();

// Присваивание двух внутренних типов значений дает в результате две независимые переменные в стеке.
static void ValueTypeAssignment()
{
    Console.WriteLine("Присваивание типов значений");

    var p1 = new Point(10, 10);
    Point p2 = p1;

    // Вывести значения обеих переменных Point.
    p1.Display();
    p2.Display();

    // Изменить p1.X и снова вывести значения переменных. Значение p2.X не изменилось.
    p1.X = 100;
    Console.WriteLine("=> Изменили p1.X");
    p1.Display();
    p2.Display();
}

static void ReferenceTypeAssignment()
{
    Console.WriteLine("Присваивание ссылочных типов");
    var p1 = new PointRef(10, 10);
    PointRef p2 = p1;

    // Вывести значения обеих переменных PointRef.
    p1.Display();
    p2.Display();

    // Изменить p1.X и снова вывести значения.
    p1.X = 100;
    Console.WriteLine("=> Изменили p1.X");
    p1.Display();
    p2.Display();
}

static void ValueTypeContainingRefType()
{
    // Создать первую переменную Rectangle.
    Console.WriteLine("-> Создание r1");
    var r1 = new Rectangle("Первый прямоугольник", 10, 10, 50, 50);

    // Присвоить новой переменной Rectangle переменную r1.
    Console.WriteLine("-> Присвоить r2 переменную r1");
    Rectangle r2 = r1;

    // Изменить некоторые значения в r2.
    Console.WriteLine("-> Изменение значений r2");
    r2.RectInfo.InfoString = "Это новая информация!";
    r2.RectBottom = 4444;

    // Вывести значения из обеих переменных Rectangle.
    r1.Display();
    r2.Display();
}