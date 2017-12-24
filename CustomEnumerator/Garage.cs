using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CustomEnumerator
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

        public IEnumerator GetEnumerator()
        {
            // Возвратить IEnumerator объекта массива.
            return carArray.GetEnumerator();
        }
    }
}
