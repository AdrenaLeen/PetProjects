namespace ForEachWithExtensionMethods
{
    class Garage
    {
        public Car[] CarsInGarage { get; set; }

        // При запуске заполнить несколькими объектами Car.
        public Garage()
        {
            CarsInGarage = new Car[4];
            CarsInGarage[0] = new Car("Расти", 30);
            CarsInGarage[1] = new Car("Кланкер", 55);
            CarsInGarage[2] = new Car("Молния", 30);
            CarsInGarage[3] = new Car("Фрэд", 30);
        }

    }
}
