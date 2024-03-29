﻿Console.WriteLine("***** Сужающие и расширяющие преобразования типов данных *****");

// Добавить две переменные типа short и вывести результат
// Следующий код вызовет ошибку на этапе компиляции
short numb1 = 30000, numb2 = 30000;

// Явно привести int к short (и разрешить потерю данных).
short answer = unchecked((short)Add(numb1, numb2));
Console.WriteLine($"{numb1} + {numb2} = {answer}");

NarrowingAttempt();
ProcessBytes();

Console.ReadLine();

static int Add(int x, int y)
{
    return x + y;
}

// Снова ошибка на этапе компиляции
static void NarrowingAttempt()
{
    byte myByte = 0;
    int myInt = 200;
    // Явно привести int к byte (без потери данных).
    myByte = (byte)myInt;
    Console.WriteLine($"Значение myByte: {myByte}");
}

static void ProcessBytes()
{
    byte b1 = 100;
    byte b2 = 250;

    // На этот раз сообщить компилятору о необходимости добавления кода CIL, необходимого для генерации исключения, если возникает переполнение или потеря значимости.
    try
    {
        checked
        {
            byte sum = (byte)Add(b1, b2);
            Console.WriteLine($"sum = {sum}");
        }
    }
    catch (OverflowException ex)
    {
        Console.WriteLine(ex.Message);
    }

    // Предполагая, что флаг /checked активизирован, этот блок не будет генерировать исключение времени выполнения.
    unchecked
    {
        byte sum = (byte)(b1 + b2);
        Console.WriteLine($"sum = {sum}");
    }
}