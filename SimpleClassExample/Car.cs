using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleClassExample
{
    class Car
    {
        // 'Состояние' объекта Car.
        public string petName;
        public int currSpeed;

        // Специальный стандартный конструктор.
        public Car()
        {
            petName = "Чак";
            currSpeed = 10;
        }

        // Здесь currSpeed получает стандартное значение для типа int (0).
        public Car(string pn)
        {
            petName = pn;
        }

        // Позволяет вызывающему коду установить полное состояние объекта Car.
        public Car(string pn, int cs)
        {
            petName = pn;
            currSpeed = cs;
        }

        // Функциональность Car.
        public void PrintState()
        {
            Console.WriteLine($"{petName} едет со скоростью {currSpeed} км/ч.");
        }

        public void SpeedUp(int delta)
        {
            currSpeed += delta;
        }
    }
}
