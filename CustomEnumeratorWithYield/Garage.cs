using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CustomEnumeratorWithYield
{
    // Garage содержит набор объектов Car.
    public class Garage : IEnumerable
    {
        // System.Array уже реализует IEnumerator!
        private Car[] carArray = new Car[4];

        // При запуске заполнить несколькими объектами Car.
        public Garage()
        {
            carArray[0] = new Car("Расти", 30);
            carArray[1] = new Car("Драндулет", 55);
            carArray[2] = new Car("Циппи", 30);
            carArray[3] = new Car("Фред", 30);
        }

        // Метод итератора.
        public IEnumerator GetEnumerator()
        {
            foreach (Car c in carArray) yield return c;
        }
    }
}
