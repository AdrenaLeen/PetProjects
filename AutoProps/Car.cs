using System;

namespace AutoProps
{
    class Car
    {
        // Автоматические свойства! Нет нужды в определении поддерживаемых полей.
        public string PetName { get; set; }
        public int Speed { get; set; }
        public string Color { get; set; }
        // Свойство только для чтения? Допустимо!
        public int MyReadOnlyProp { get; }

        public void DisplayStats()
        {
            Console.WriteLine($"Имя машины: {PetName}");
            Console.WriteLine($"Скорость: {Speed}");
            Console.WriteLine($"Цвет: {Color}");
        }
    }
}
