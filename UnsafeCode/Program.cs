using UnsafeCode;

Console.WriteLine("***** Вызов методов с небезопасным кодом *****");

unsafe
{
    int myInt = 10;

    // Нормально, мы находимся в небезопасном контексте.
    SquareIntPointer(&myInt);
    Console.WriteLine($"myInt: {myInt}");

    Console.WriteLine("**** Вывести значение и адрес ****");
    PrintValueAndAddress();
}

// Значения, которые подлежат обмену.
int i = 10, j = 20;

// "Безопасный" обмен значений.
Console.WriteLine("***** Безопасный обмен *****");
Console.WriteLine($"Значения до безопасного обмена: i = {i}, j = {j}");
SafeSwap(ref i, ref j);
Console.WriteLine($"Значения после безопасного обмена: i = {i}, j = {j}");

// "Небезопасный" обмен значений
Console.WriteLine("***** Небезопасный обмен *****");
Console.WriteLine($"Значения до небезопасного обмена: i = {i}, j = {j}");
unsafe
{
    UnsafeSwap(&i, &j);
}
Console.WriteLine($"Значения после небезопасного обмена: i = {i}, j = {j}");

UsePointerToPoint();
Console.WriteLine(UnsafeStackAlloc());
UseAndPinPoint();
UseSizeOfOperator();

Console.ReadLine();

// Возвести значение в квадрат просто для тестирования.
unsafe static void SquareIntPointer(int* myIntPointer) => *myIntPointer *= *myIntPointer;

unsafe static void PrintValueAndAddress()
{
    int myInt;

    // Определить указатель на int и присвоить ему адрес myInt.
    int* ptrToMyInt = &myInt;

    // Присвоить значение myInt, используя обращение через указатель.
    *ptrToMyInt = 123;

    // Вывести некоторые значения.
    Console.WriteLine($"Значение myInt: {myInt}");
    Console.WriteLine($"Адрес myInt: {(int)&ptrToMyInt:X}");
}

unsafe static void UnsafeSwap(int* i, int* j) => (*i, *j) = (*j, *i);

static void SafeSwap(ref int i, ref int j) => (i, j) = (j, i);

unsafe static void UsePointerToPoint()
{
    // Доступ к членам через указатель.
    Point point;
    Point* p = &point;
    p->x = 100;
    p->y = 200;
    Console.WriteLine(p->ToString());

    // Доступ к членам через разыменованный указатель.
    Point point2;
    Point* p2 = &point2;
    (*p2).x = 100;
    (*p2).y = 200;
    Console.WriteLine((*p2).ToString());
}

unsafe static string UnsafeStackAlloc()
{
    char* p = stackalloc char[256];
    for (int k = 0; k < 256; k++) p[k] = (char)k;
    return new string(p);
}

unsafe static void UseAndPinPoint()
{
    var pt = new PointRef { x = 5, y = 6 };

    // Закрепить указатель pt на месте, чтобы он не мог быть перемещен или уничтожен сборщиком мусора.
    fixed (int* p = &pt.x)
    {
        // Использовать здесь переменную int*!
    }

    // Указатель pt теперь не закреплен и готов к сборке мусора после завершения метода.
    Console.WriteLine($"Point: {pt}");
}

unsafe static void UseSizeOfOperator()
{
    Console.WriteLine($"Размер short равен {sizeof(short)}.");
    Console.WriteLine($"Размер int равен {sizeof(int)}.");
    Console.WriteLine($"Размер long равен {sizeof(long)}.");
    Console.WriteLine($"Размер Point равен {sizeof(Point)}.");
}