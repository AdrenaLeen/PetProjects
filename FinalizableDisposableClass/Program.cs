using FinalizableDisposableClass;

Console.WriteLine("***** Создание финализируемых и освобождаемых типов *****");

// Вызвать метод Dispose() вручную. Это не приведет к вызову финализатора.
var rw = new MyResourceWrapper();
rw.Dispose();

// Не вызывать метод Dispose(). Это запустит финализатор, когда объект будет обрабатываться сборщиком мусора.
var _ = new MyResourceWrapper();

Console.ReadLine();