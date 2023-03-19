using System.Collections;

namespace ComparableCar
{
    // Итерация по объектам Car может быть упорядочена на основе CarID.
    // Теперь мы поддерживаем специальное свойство для возвращения корректного экземпляра, реализующего интерфейс IComparer.
    class Car : IComparable
    {
        // Константа для представления максимальной скорости.
        public const int MaxSpeed = 100;

        // Свойства автомобиля.
        public int CurrentSpeed { get; set; } = 0;
        public string PetName { get; set; } = "";
        public int CarID { get; set; }

        // Свойство, возвращающее PetNameComparer.
        public static IComparer SortByPetName => new PetNameComparer();

        // Не вышел ли автомобиль из строя?
        private bool carIsDead;

        // В автомобиле имеется радиоприёмник.
        private readonly Radio theMusicBox = new();

        // Конструкторы.
        public Car() { }
        public Car(string name, int speed, int id)
        {
            CurrentSpeed = speed;
            PetName = name;
            CarID = id;
        }

        // Делегировать запрос внутреннему объекту.
        public void CrankTunes(bool state) => theMusicBox.TurnOn(state);

        // Проверить, не перегрелся ли автомобиль.
        // Сгенерировать специальное исключение CarIsDeadException.
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
                    // Предоставить специальные данные, касающиеся ошибки.
                    throw new Exception($"{PetName} перегрет!")
                    {
                        HelpLink = "http://www.CarsRUs.com",
                        Data =
                        {
                            { "TimeStamp", $"Машина вышла из строя {DateTime.Now}" },
                            { "Cause", "Забыли убрать ногу с газа." }
                        }
                    };
                }
                // Вывод текущей скорости.
                else Console.WriteLine($"=> CurrentSpeed = {CurrentSpeed}");
            }
        }

        // Реализация итерфейса IComparable.
        int IComparable.CompareTo(object? obj)
        {
            if (obj is Car temp) return CarID.CompareTo(temp.CarID);
            else throw new ArgumentException("Параметр не является объектом типа Car!");
        }
    }
}
