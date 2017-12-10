using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoProps
{
    class Car
    {
        // Автоматические свойства! Нет нужды в определении поддерживаемых полей.
        public string PetName { get; set; }
        public int Speed { get; set; }
        public string Color { get; set; }

        // Свойство только для чтения? Допустимо!
        public int MyReadOnlyProp { get; }
    }
}
