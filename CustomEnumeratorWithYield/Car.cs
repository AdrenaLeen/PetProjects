using System;

namespace CustomEnumeratorWithYield
{
    class Car
    {
        // Константа для представления максимальной скорости.
        public const int MaxSpeed = 100;

        // Свойства автомобиля.
        public int CurrentSpeed { get; set; } = 0;
        public string PetName { get; set; } = "";

        // Не вышел ли автомобиль из строя?
        private bool carIsDead;

        // В автомобиле имеется радиоприёмник.
        private Radio theMusicBox = new Radio();

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
        public void Accelerate(int delta)
        {
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
                    Exception ex = new Exception($"{PetName} перегрет!");
                    ex.HelpLink = "http://www.CarsRUs.com";
                    // Предоставить специальные данные, касающиеся ошибки.
                    ex.Data.Add("TimeStamp", $"Машина вышла из строя {DateTime.Now}");
                    ex.Data.Add("Cause", "Забыли убрать ногу с газа.");
                    throw ex;
                }
                // Вывод текущей скорости.
                else Console.WriteLine($"=> CurrentSpeed = {CurrentSpeed}");
            }
        }
    }
}
