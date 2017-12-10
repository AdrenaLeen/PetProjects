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
        // Конструкторы
        // Связывание конструкторов в цепочку
        public Motorcycle()
        {
            Console.WriteLine("Внутри стандартного конструктора");
        }
        // Специальный конструктор
        // Избыточная логика конструктора!
        public Motorcycle(int intensity) : this(intensity, "")
        {
            Console.WriteLine("Внутри конструктора, принимающего int.");
        }
        public Motorcycle(string name) : this(0, name)
        {
            Console.WriteLine("Внутри конструктора, принимающего string.");
        }
        // Это главный конструктор, который выполняет всю реальную работу.
        public Motorcycle(int intensity, string name)
        {
            Console.WriteLine("Внутри главного конструктора.");
            if (intensity > 10) intensity = 10;
            driverIntensity = intensity;
            driverName = name;
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

        public void SetIntensity(int intensity)
        {
            if (intensity > 10) intensity = 10;
            driverIntensity = intensity;
        }
    }
}
