using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicDelegateProblem
{
    public class Car
    {
        public delegate void CarEngineHandler(string msgForCaller);

        // Теперь это член public!
        public CarEngineHandler listOfHandlers;

        // Просто вызвать уведомление Exploded.
        public void Accelerate(int delta)
        {
            if (listOfHandlers != null) listOfHandlers("Простите, эта машина умерла...");
        }
    }
}
