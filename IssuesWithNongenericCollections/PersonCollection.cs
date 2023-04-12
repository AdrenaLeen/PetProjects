using System.Collections;

namespace IssuesWithNongenericCollections
{
    class PersonCollection : IEnumerable
    {
        private readonly ArrayList arPeople = new();

        // Приведение для вызывающего кода.
        public Person GetPerson(int pos) => (Person)arPeople[pos];

        // Вставка только объектов Person.
        public void AddPerson(Person p) => arPeople.Add(p);

        public void ClearPeople() => arPeople.Clear();

        public int Count => arPeople.Count;

        // Поддержка перечисления с помощью foreach.
        IEnumerator IEnumerable.GetEnumerator() => arPeople.GetEnumerator();
    }
}
