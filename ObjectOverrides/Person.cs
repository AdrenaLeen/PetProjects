namespace ObjectOverrides
{
    // Класс Person расширяет Object.
    // Предположим, что имеется свойство SSN.
    class Person
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int Age { get; set; }
        public string SSN { get; set; } = string.Empty;

        public Person(string fName, string lName, int personAge, string ssn)
        {
            FirstName = fName;
            LastName = lName;
            Age = personAge;
            SSN = ssn;
        }
        public Person() { }

        public override string ToString() => $"[Имя: {FirstName}; Фамилия: {LastName}; Возраст: {Age}]";

        // Больше нет необходимости приводить obj с типу Person, т.к. у всех типов имеется метод ToString().
        public override bool Equals(object? obj) => obj?.ToString() == ToString();

        // Возвратить хеш-код на основе значения, возвращаемого методом ToString() для объекта Person.
        public override int GetHashCode() => SSN.GetHashCode();
    }
}
