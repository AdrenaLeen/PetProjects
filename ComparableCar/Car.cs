using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public static IComparer SortByPetName { get { return new PetNameComparer(); } }

        // Не вышел ли автомобиль из строя?
        private bool carIsDead;

        // В автомобиле имеется радиоприёмник.
        private Radio theMusicBox = new Radio();

        // Конструкторы.
        public Car() { }
        public Car(string name, int speed, int id)
        {
            CurrentSpeed = speed;
            PetName = name;
            CarID = id;
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
                    CarIsDeadException ex = new CarIsDeadException($"{PetName} перегрет!", "Забыли убрать ногу с газа.", DateTime.Now);
                    ex.HelpLink = "http://www.CarsRUs.com";
                    throw ex;
                }
                // Вывод текущей скорости.
                else Console.WriteLine($"=> CurrentSpeed = {CurrentSpeed}");
            }
        }

        // Реализация итерфейса IComparable.
        int IComparable.CompareTo(object obj)
        {
            Car temp = obj as Car;
            if (temp != null) return CarID.CompareTo(temp.CarID);
            else throw new ArgumentException("Параметр не является объектом типа Car!");
        }
    }
}
