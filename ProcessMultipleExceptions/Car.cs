namespace ProcessMultipleExceptions
{
    class Car
    {
        // Константа для представления максимальной скорости.
        public const int MaxSpeed = 100;

        // Свойства автомобиля.
        public int CurrentSpeed { get; set; } = 0;
        public string PetName { get; set; } = string.Empty;

        // Не вышел ли автомобиль из строя?
        private bool carIsDead;

        // В автомобиле имеется радиоприёмник.
        private readonly Radio theMusicBox = new();

        // Конструкторы.
        public Car() { }
        public Car(string name, int speed)
        {
            CurrentSpeed = speed;
            PetName = name;
        }

        public void CrankTunes(bool state)
        {
            // Делегировать запрос внутреннему объекту.
            theMusicBox.TurnOn(state);
        }

        // Проверить, не перегрелся ли автомобиль.
        // Сгенерировать специальное исключение CarIsDeadException.
        public void Accelerate(int delta)
        {
            if (delta < 0) throw new ArgumentOutOfRangeException("delta", "Значение скорости должно быть больше нуля!");
            if (carIsDead) Console.WriteLine($"{PetName} сломан...");
            else
            {
                CurrentSpeed += delta;
                if (CurrentSpeed > MaxSpeed)
                {
                    carIsDead = true;
                    CurrentSpeed = 0;
                    // Использовать ключевое слово throw для генерации исключения.
                    // Мы хотим обращаться к свойству HelpLink, поэтому необходимо создать локальную переменную перед генерацией объекта Exception.
                    throw new CarIsDeadException("Забыли убрать ногу с газа.", DateTime.Now)
                    {
                        HelpLink = "http://www.CarsRUs.com"
                    };
                }
                // Вывод текущей скорости.
                else Console.WriteLine($"=> CurrentSpeed = {CurrentSpeed}");
            }
        }
    }
}
