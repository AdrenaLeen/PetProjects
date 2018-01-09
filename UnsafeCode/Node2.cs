using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnsafeCode
{
    // Эта структура безопасна, но члены Node2* - нет. Формально извне небезопасного контекста можно обращаться к Value, но не к Left и Right.
    public struct Node2
    {
        public int Value;

        // Эти члены доступны только в небезопасном контексте!
        public unsafe Node2* Left;
        public unsafe Node2* Right;
    }
}
