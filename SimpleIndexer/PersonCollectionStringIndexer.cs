using System.Collections;

namespace SimpleIndexer
{
    public class PersonCollectionStringIndexer : IEnumerable
    {
        readonly Dictionary<string, Person> listPeople = new();

        // Этот индексатор возвращает объект лица на основе строкового индекса.
        public Person this[string name]
        {
            get => listPeople[name];
            set => listPeople[name] = value;
        }

        public void ClearPeople() => listPeople.Clear();

        public int Count => listPeople.Count;

        IEnumerator IEnumerable.GetEnumerator() => listPeople.GetEnumerator();
    }
}
