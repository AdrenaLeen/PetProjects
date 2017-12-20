using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomInterface
{
    // Этот интерфейс определяет поведение "наличия вершин".
    // Поведение "наличия вершин" в виде свойства только для чтения.
    interface IPointy
    {
        byte Points { get; }
    }
}
