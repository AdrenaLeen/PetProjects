using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDelegateMethodGroupConversion
{
    class Car
    {
        // Данные состояния.
        public int CurrentSpeed { get; set; }
        public int MaxSpeed { get; set; } = 100;
        public string PetName { get; set; }

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
        private CarEngineHandler listOfHandlers;

        // 3. Добавить регистрационную функцию для взывающего кода.
        // Добавление поддержки группового вызова. Обратите внимание на использование операции +=, а не обычной операции присваивания (=).
        public void RegisterWithCarEngine(CarEngineHandler methodToCall)
        {
            if (listOfHandlers == null) listOfHandlers = methodToCall;
            else Delegate.Combine(listOfHandlers, methodToCall);
        }

        public void UnRegisterWithCarEngine(CarEngineHandler methodToCall)
        {
            listOfHandlers -= methodToCall;
        }

        // 4. Реализовать метод Accelerate() для обращения к списку вызовов делегата в подходящих обстоятельствах.
        public void Accelerate(int delta)
        {
            // Если этот автомобиль сломан, отправить сообщение об этом.
            if (carIsDead)
            {
                if (listOfHandlers != null) listOfHandlers("Простите, эта машина умерла...");
            }
            else
            {
                CurrentSpeed += delta;

                // Автомобиль почти сломан?
                if (10 == (MaxSpeed - CurrentSpeed) && listOfHandlers != null) listOfHandlers("Осторожнее, приятель! Скоро взорвётся!");
                if (CurrentSpeed >= MaxSpeed) carIsDead = true;
                else Console.WriteLine($"CurrentSpeed = {CurrentSpeed}");
            }
        }
    }
}
