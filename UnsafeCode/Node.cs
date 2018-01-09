using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnsafeCode
{
    // Вся эта структура является небезопасной и может использовать только в небезопасном контексте.
    unsafe struct Node
    {
        public int Value;
        public Node* Left;
        public Node* Right;
    }
}
