using System;

namespace CarEvents
{
    class Car
    {
        public int CurrentSpeed { get; set; }
        public int MaxSpeed { get; set; }
        public string PetName { get; set; }
        private bool carIsDead;

        public Car() { MaxSpeed = 100; }
        public Car(string name, int maxSp, int currSp)
        {
            CurrentSpeed = currSp;
            MaxSpeed = maxSp;
            PetName = name;
        }

        // Этот делегат работает в сочетании с событиями Car.
        public delegate void CarEngineHandler(string msgForCaller);

        // Car может отправлять следующие события.
        public event CarEngineHandler Exploded;
        public event CarEngineHandler AboutToBlow;

        public void Accelerate(int delta)
        {
            // Если автомобиль сломан, инициировать событие Exploded.
            if (carIsDead) Exploded?.Invoke("Простите, эта машина умерла...");
            else
            {
                CurrentSpeed += delta;

                // Почти сломан?
                if (10 == MaxSpeed - CurrentSpeed) AboutToBlow?.Invoke("Осторожнее, приятель! Скоро взорвётся!");

                // Всё ещё в порядке!
                if (CurrentSpeed >= MaxSpeed) carIsDead = true;
                else Console.WriteLine($"CurrentSpeed = {CurrentSpeed}");
            }
        }
    }
}
