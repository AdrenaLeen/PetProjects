using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOverrides
{
    // Не забывайте, что класс Person расширяет Object.
    // Предположим, что имеется свойство SSN.
    class Person
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public int Age { get; set; }
        public string SSN { get; set; } = "";

        public Person(string fName, string lName, int personAge)
        {
            FirstName = fName;
            LastName = lName;
            Age = personAge;
        }
        public Person() { }

        public override string ToString()
        {
            return $"[Имя: {FirstName}; Фамилия: {LastName}; Возраст: {Age}]";
        }

        public override bool Equals(object obj)
        {
            // Больше нет необходимости приводить obj с типу Person, т.к. у всех типов имеется метод ToString().
            return obj.ToString() == ToString();
        }

        // Возвратить хеш-код на основе значения, возвращаемого методом ToString() для объекта Person.
        public override int GetHashCode()
        {
            return SSN.GetHashCode();
        }
    }
}
