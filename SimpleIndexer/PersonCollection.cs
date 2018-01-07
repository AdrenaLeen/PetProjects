using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace SimpleIndexer
{
    // Добавим индексатор к существующему определению класса.
    class PersonCollection : IEnumerable
    {
        private ArrayList arPeople = new ArrayList();

        // Приведение для вызывающего кода.
        public Person GetPerson(int pos)
        {
            return (Person)arPeople[pos];
        }

        // Вставка только объектов Person.
        public void AddPerson(Person p)
        {
            arPeople.Add(p);
        }

        public void ClearPeople()
        {
            arPeople.Clear();
        }

        public int Count { get { return arPeople.Count; } }

        // Поддержка перечисления с помощью foreach.
        IEnumerator IEnumerable.GetEnumerator()
        {
            return arPeople.GetEnumerator();
        }

        // Специальный индексатор для этого класса.
        public Person this[int index]
        {
            get { return (Person)arPeople[index]; }
            set { arPeople.Insert(index, value); }
        }
    }
}
