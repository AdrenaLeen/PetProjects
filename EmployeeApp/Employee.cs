﻿using System;

namespace EmployeeApp
{
    partial class Employee
    {
        // Методы.
        public void GiveBonus(float amount)
        {
            Pay += amount;
        }

        // Обновлённый метод DisplayStats() теперь учитывает возраст.
        public void DisplayStats()
        {
            // Имя сотрудника
            Console.WriteLine($"Имя: {Name}");
            // Идентификационный номер сотрудника
            Console.WriteLine($"ID: {ID}");
            // Возраст
            Console.WriteLine($"Возраст: {Age}");
            // Текущая выплата
            Console.WriteLine($"Выплата: {Pay}");
        }

        // Метод доступа (метод get).
        public string GetName() => empName;

        // Метод изменения (метод set).
        public void SetName(string name)
        {
            // Перед присваиванием проверить входное значение.
            if (name.Length > 15) Console.WriteLine("Ошибка! Длина имени превышает 15 символов!");
            else empName = name;
        }
    }
}
