using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace StringIndexer
{
    // Добавим индексатор к существующему определению класса.
    class PersonCollection : IEnumerable
    {
        private Dictionary<string, Person> listPeople = new Dictionary<string, Person>();

        public void ClearPeople()
        {
            listPeople.Clear();
        }

        public int Count { get { return listPeople.Count; } }

        // Поддержка перечисления с помощью foreach.
        IEnumerator IEnumerable.GetEnumerator()
        {
            return listPeople.GetEnumerator();
        }

        // Этот индексатор возвращает объект лица на основе строкового индекса.
        public Person this[string name]
        {
            get { return listPeople[name]; }
            set { listPeople[name] = value; }
        }
    }
}
