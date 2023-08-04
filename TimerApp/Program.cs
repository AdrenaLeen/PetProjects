Console.WriteLine("***** Работа с типом Timer *****");

// Создать делегат для типа Timer.
var timeCB = new TimerCallback(PrintTime);

// Установить параметры таймера.
var _ = new Timer(
  timeCB, // Объект делегата TimerCallback.
  "Привет из Main", // Информация для передачи в вызванный метод (null, если информация отсутствует).
  0, // Период ожидания перед запуском (в миллисекундах).
  1000); // Интервал между вызовами (в миллисекундах).

Console.WriteLine("Нажмите клавишу для завершения...");
Console.ReadLine();

static void PrintTime(object? state) => Console.WriteLine($"Время: {DateTime.Now.ToLongTimeString()}, параметр: {state?.ToString()}");