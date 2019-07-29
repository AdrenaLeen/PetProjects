using System;

namespace RefTypeValTypeParams
{
    class Person
    {
        public string personName;
        public int personAge;

        // Конструкторы.
        public Person(string name, int age)
        {
            personName = name;
            personAge = age;
        }
        public Person() { }

        public void Display() => Console.WriteLine($"Имя: {personName}, Возраст: {personAge}");
    }
}
