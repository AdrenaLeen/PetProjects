using CarLibrary;

Console.WriteLine("***** Клиентское приложение C# CarLibrary *****");

// Создать объект SportsCar.
var viper = new SportsCar("Вайпер", 240, 40);
viper.TurboBoost();

// Создать объект MiniVan.
var mv = new MiniVan();
mv.TurboBoost();

var _ = new MyInternalClass();

Console.WriteLine("Готово. Нажмите любую клавишу для завершения");
Console.ReadLine();