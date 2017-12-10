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

        // Единственный конструктор, который использует необязательные аргументы.
        public Motorcycle(int intensity = 0, string name = "")
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
