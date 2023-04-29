using System.Collections;

namespace SimpleIndexer
{
    // Добавим индексатор к существующему определению класса.
    public class PersonCollection : IEnumerable
    {
        private readonly ArrayList arPeople = new();

        // Приведение для вызывающего кода.
        public Person GetPerson(int pos) => arPeople[pos] as Person ?? new Person();

        // Вставка только объектов Person.
        public void AddPerson(Person p) => arPeople.Add(p);

        public void ClearPeople() => arPeople.Clear();

        public int Count => arPeople.Count;

        // Поддержка перечисления с помощью foreach.
        IEnumerator IEnumerable.GetEnumerator() => arPeople.GetEnumerator();

        // Специальный индексатор для этого класса.
        public Person this[int index]
        {
            get => arPeople[index] as Person ?? new Person();
            set => arPeople.Insert(index, value);
        }
    }
}
