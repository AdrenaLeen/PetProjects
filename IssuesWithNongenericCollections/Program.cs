using System;
using System.Collections;
using System.Collections.Generic;

namespace IssuesWithNongenericCollections
{
    class Program
    {
        static void Main()
        {
            SimpleBoxUnboxOperation();
            WorkWithArrayList();
            ArrayListOfRandomObjects();
            UsePersonCollection();
            UseGenericList();
            Console.ReadLine();
        }

        private static void SimpleBoxUnboxOperation()
        {
            // Создать переменную ValueType (типа int).
            int myInt = 25;

            // Упаковать int в ссылку на object.
            object boxedInt = myInt;

            // Распаковать в неподходящий тип данных, чтобы инициировать исключение времени выполнения.
            try
            {
                long unboxedInt = (long)boxedInt;
            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void WorkWithArrayList()
        {
            // Типы значений автоматически упаковываются при передаче методу, который требует экземпляр object.
            ArrayList myInts = new ArrayList();
            myInts.Add(10);
            myInts.Add(20);
            myInts.Add(35);

            // Распаковка происходит, когда объект преобразуется обратно в данные, расположенные в стеке.
            int i = (int)myInts[0];

            // Теперь значение вновь упаковывается, т.к. метод WriteLine() требует типа object!
            Console.WriteLine($"Значение int: {i}");
        }

        static void ArrayListOfRandomObjects()
        {
            // ArrayList может хранить вообще всё что угодно.
            ArrayList allMyObjects = new ArrayList();
            allMyObjects.Add(true);
            allMyObjects.Add(new OperatingSystem(PlatformID.MacOSX, new Version(10, 0)));
            allMyObjects.Add(66);
            allMyObjects.Add(3.14);
        }

        static void UsePersonCollection()
        {
            Console.WriteLine("***** Коллекция людей *****");
            PersonCollection myPeople = new PersonCollection();
            myPeople.AddPerson(new Person("Гомер", "Симпсон", 40));
            myPeople.AddPerson(new Person("Мардж", "Симпсон", 38));
            myPeople.AddPerson(new Person("Лиза", "Симпсон", 9));
            myPeople.AddPerson(new Person("Барт", "Симпсон", 7));
            myPeople.AddPerson(new Person("Мэгги", "Симпсон", 2));

            foreach (Person p in myPeople) Console.WriteLine(p);
        }

        static void UseGenericList()
        {
            Console.WriteLine("***** Обобщённые коллекции *****");
            // Этот объект List<> может хранить только объекты Person.
            List<Person> morePeople = new List<Person>();
            morePeople.Add(new Person("Фрэнк", "Блэк", 50));
            Console.WriteLine(morePeople[0]);

            // Этот объект List<> может хранить только целые числа.
            List<int> moreInts = new List<int>();
            moreInts.Add(10);
            moreInts.Add(2);
            int sum = moreInts[0] + moreInts[1];
        }
    }
}
