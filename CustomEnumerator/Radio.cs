using System;

namespace CustomEnumerator
{
    class Radio
    {
        public void TurnOn(bool on)
        {
            if (on) Console.WriteLine("Зажигаем...");
            else Console.WriteLine("Время тишины...");
        }
    }
}
