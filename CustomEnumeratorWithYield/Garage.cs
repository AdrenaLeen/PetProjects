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
            return actualImplementation();

            // Закрытая функция
            IEnumerator actualImplementation()
            {
                foreach (Car c in carArray) yield return c;
            }
        }

        public IEnumerable GetTheCars(bool returnRevesed)
        {
            // Возвратить элементы в обратном порядке.
            if (returnRevesed)
            {
                for (int i = carArray.Length; i != 0; i--) yield return carArray[i - 1];
            }
            else
            {
                // Возвратить элементы в том порядке, в каком они размещены в массиве.
                foreach (Car c in carArray) yield return c;
            }
        }
    }
}
