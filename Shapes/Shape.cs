using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    // Абстрактный базовый класс иерархии
    abstract class Shape
    {
        public Shape(string name = "Безымянный")
        {
            PetName = name;
        }

        public string PetName { get; set; }

        // Единственный виртуальный метод
        // Вынудить все дочерние классы определять способ своей визуализации.
        public abstract void Draw();
    }
}
