using System;

namespace CarDelegate
{
    class Car
    {
        // Данные состояния.
        public int CurrentSpeed { get; set; }
        public int MaxSpeed { get; set; } = 100;
        public string PetName { get; set; } = string.Empty;

        // Исправен ли автомобиль?
        private bool carIsDead;

        // Конструкторы класса.
        public Car() { }
        public Car(string name, int maxSp, int currSp)
        {
            CurrentSpeed = currSp;
            MaxSpeed = maxSp;
            PetName = name;
        }

        // 1. Определить тип делегата.
        public delegate void CarEngineHandler(string msgForCaller);

        // 2. Определить переменную-член этого типа делегата.
        private CarEngineHandler? listOfHandlers;

        // 3. Добавить регистрационную функцию для взывающего кода.
        public void RegisterWithCarEngine(CarEngineHandler methodToCall)
        {
            if (listOfHandlers == null) listOfHandlers = methodToCall;
            else listOfHandlers = Delegate.Combine(listOfHandlers, methodToCall) as CarEngineHandler;
        }

        public void UnRegisterWithCarEngine(CarEngineHandler methodToCall)
        {
            if (listOfHandlers != null && listOfHandlers.GetInvocationList().Contains(methodToCall))
            {
                listOfHandlers = Delegate.Remove(listOfHandlers, methodToCall) as CarEngineHandler;
            }
        }

        // 4. Реализовать метод Accelerate() для обращения к списку вызовов делегата в подходящих обстоятельствах.
        public void Accelerate(int delta)
        {
            // Если этот автомобиль сломан, отправить сообщение об этом.
            if (carIsDead) listOfHandlers?.Invoke("Простите, эта машина умерла...");
            else
            {
                CurrentSpeed += delta;

                // Автомобиль почти сломан?
                if ((MaxSpeed - CurrentSpeed) == 10 && listOfHandlers != null) listOfHandlers("Осторожнее, приятель! Скоро взорвется!");
                if (MaxSpeed <= CurrentSpeed) carIsDead = true;
                else Console.WriteLine($"CurrentSpeed = {CurrentSpeed}");
            }
        }
    }
}
