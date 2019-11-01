using System;

namespace SimpleSerialize
{
    [Serializable]
    public class Car
    {
        public Radio theRadio = new Radio();
        public bool isHatchBack;
    }
}
