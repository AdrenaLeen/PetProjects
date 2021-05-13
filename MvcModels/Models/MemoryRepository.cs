using System.Collections.Generic;

namespace MvcModels.Models
{
    public class MemoryRepository : IRepository
    {
        readonly Dictionary<int, Person> people = new Dictionary<int, Person>
        {
            [1] = new Person
            {
                PersonId = 1,
                FirstName = "Боб",
                LastName = "Смит",
                Role = Role.Admin
            },
            [2] = new Person
            {
                PersonId = 2,
                FirstName = "Энн",
                LastName = "Дуглас",
                Role = Role.User
            },
            [3] = new Person
            {
                PersonId = 3,
                FirstName = "Джо",
                LastName = "Эйбл",
                Role = Role.User
            },
            [4] = new Person
            {
                PersonId = 4,
                FirstName = "Мэри",
                LastName = "Питерс",
                Role = Role.Guest
            }
        };

        public IEnumerable<Person> People => people.Values;

        public Person this[int id]
        {
            get
            {
                return people.ContainsKey(id) ? people[id] : null;
            }
            set
            {
                people[id] = value;
            }
        }
    }
}
