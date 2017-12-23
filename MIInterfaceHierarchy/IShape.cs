using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIInterfaceHierarchy
{
    // Множественное наследование интерфейсов. Разрешено!
    interface IShape : IDrawable, IPrintable
    {
        int GetNumberOfSides();
    }
}
