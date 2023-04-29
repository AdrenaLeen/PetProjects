namespace ForEachWithExtensionMethods
{
    class Car
    {
        // Свойства класса Car.
        public int CurrentSpeed { get; set; } = 0;
        public string PetName { get; set; } = string.Empty;

        // Конструкторы.
        public Car() { }
        public Car(string name, int speed)
        {
            CurrentSpeed = speed;
            PetName = name;
        }

        // Выяснить, не перегрелся ли двигатель Car.
    }
}
