using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoProps
{
    class Garage
    {
        // Скрытое поддерживающее поле int установлено в 0!
        // Скрытое поддерживающее поле установлено в 1.
        public int NumberOfCars { get; set; } = 1;

        // Скрытое поддерживающее поле Car установлено в null!
        // Скрытое поддерживающее поле установлено в новый объект Car.
        public Car MyAuto { get; set; }

        // Для переопределения стандартных значений, присвоенных скрытым поддерживающим полям, должны использоваться конструкторы.
        public Garage()
        {
            MyAuto = new Car();
            NumberOfCars = 1;
        }
        public Garage(Car car, int number)
        {
            MyAuto = car;
            NumberOfCars = number;
        }
    }
}
