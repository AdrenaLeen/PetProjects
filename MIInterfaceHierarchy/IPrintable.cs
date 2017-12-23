using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIInterfaceHierarchy
{
    interface IPrintable
    {
        void Print();
        
        // Возможен конфликт имён!
        void Draw();
    }
}
