namespace AutoProps
{
    class Garage
    {
        // Скрытое поддерживающее поле установлено в 1.
        public int NumberOfCars { get; set; } = 1;

        // Скрытое поддерживающее поле установлено в новый объект Car.
        public Car MyAuto { get; set; } = new Car();

        // Для переопределения стандартных значений, присвоенных скрытым поддерживающим полям, должны использоваться конструкторы.
        public Garage() { }
        public Garage(Car car, int number)
        {
            MyAuto = car;
            NumberOfCars = number;
        }
    }
}
