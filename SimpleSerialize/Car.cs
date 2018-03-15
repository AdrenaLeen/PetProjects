using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSerialize
{
    [Serializable]
    public class Car
    {
        public Radio theRadio = new Radio();
        public bool isHatchBack;
    }
}
