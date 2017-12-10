using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleClassExample
{
    class Motorcycle
    {
        public int driverIntensity;

        // Новые члены для представления имени водителя.
        public string driverName;

        // Вернуть стандартный конструктор, который будет устанавливать все члены данных в стандартные значения.
        public Motorcycle() { }

        // Специальный конструктор
        public Motorcycle(int intensity)
        {
            driverIntensity = intensity;
        }

        public void PopAWheely()
        {
            for (int i = 0; i <= driverIntensity; i++)
            {
                Console.WriteLine("Иииииии хаааааааааа!");
            }
        }

        public void SetDriverName(string name)
        {
            // Эти два оператора функционально эквивалентны.
            driverName = name;
            this.driverName = name;
        }
    }
}
