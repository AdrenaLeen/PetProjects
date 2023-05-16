using PublicDelegateProblem;

Console.WriteLine("***** Ах! Нет инкапсуляции! *****");

// Создать объект Car.
var myCar = new Car
{
    // Есть прямой доступ к делегату!
    listOfHandlers = CallWhenExploded
};
myCar.Accelerate();

// Теперь можно присвоить полностью новый объект... сбивает с толку в лучшем случае.
myCar.listOfHandlers = CallHereToo;
myCar.Accelerate();

// Вызывающий код может также напрямую вызывать делегат!
myCar.listOfHandlers.Invoke("Хи, хи, хи...");

Console.ReadLine();

static void CallWhenExploded(string msg) => Console.WriteLine(msg);

static void CallHereToo(string msg) => Console.WriteLine(msg);