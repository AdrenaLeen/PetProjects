using System.Collections.Generic;

namespace MvcModels.Models
{
    public interface IRepository
    {
        IEnumerable<Person> People { get; }
        Person this[int id] { get; set; }
    }
}
