using System;

namespace SimpleClassExample
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** Тип класса *****");

            // Разместить в памяти и сконфигурировать объект Car.
            Car myCar = new Car();
            myCar.petName = "Генри";
            myCar.currSpeed = 10;

            // Увеличить скорость автомобиля в несколько раз и вывести новое состояние.
            for (int i = 0; i <= 10; i++)
            {
                myCar.SpeedUp(5);
                myCar.PrintState();
            }

            Car myCar2 = new Car();
            myCar.petName = "Фред";

            Car myCar3;
            myCar3 = new Car();
            myCar3.petName = "Фред";

            // Вызов стандартного конструктора
            Car chuck = new Car();
            // Выводит строку "Чак едет со скоростью 10 км/ч."
            chuck.PrintState();

            // Создать объект Car по имени Мэри со скоростью 0 км/ч.
            Car mary = new Car("Мэри");
            mary.PrintState();

            // Создать объект Car по имени Дейзи со скоростью 75 км/ч.
            Car daisy = new Car("Дейзи", 75);
            daisy.PrintState();

            Motorcycle mc = new Motorcycle();
            mc.PopAWheely();

            // Создать объект Motorcycle с мотоциклистом по имени Тини?
            Motorcycle c = new Motorcycle(5);
            c.SetDriverName("Тини");
            c.PopAWheely();
            // Выводит пустое значение name!
            // Вывод имени гонщика.
            Console.WriteLine($"Мотоциклиста зовут {c.driverName}");

            MakeSomeBikes();

            Console.ReadLine();
        }

        static void MakeSomeBikes()
        {
            // driverName = "", driverIntensity = 0  
            Motorcycle m1 = new Motorcycle();
            Console.WriteLine($"Название = {m1.driverName}, Мощность = {m1.driverIntensity}");

            // driverName = "Тини", driverIntensity = 0 
            Motorcycle m2 = new Motorcycle(name: "Тини");
            Console.WriteLine($"Название = {m2.driverName}, Мощность = {m2.driverIntensity}");

            // driverName = "", driverIntensity = 7  
            Motorcycle m3 = new Motorcycle(7);
            Console.WriteLine($"Название = {m3.driverName}, Мощность = {m3.driverIntensity}");
        }
    }
}
