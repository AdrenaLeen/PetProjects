namespace BasicInheritance
{
    // Простой базовый класс.
    class Car
    {
        public readonly int maxSpeed;
        private int currSpeed;

        public Car(int max) => maxSpeed = max;

        public Car() => maxSpeed = 55;

        public int Speed
        {
            get => currSpeed;
            set
            {
                currSpeed = value;
                if (currSpeed > maxSpeed) currSpeed = maxSpeed;
            }
        }
    }
}
