using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp
{
    class Employee
    {
        // Поля данных.
        private string empName;
        private int empID;
        private float currPay;
        // Новое поле и свойство.
        private int empAge;

        // Обновлённые конструкторы.
        public Employee() { }
        public Employee(string name, int id, float pay) : this(name, 0, id, pay) { }
        public Employee(string name, int age, int id, float pay)
        {
            Name = name;
            Age = age;
            ID = id;
            Pay = pay;
        }

        // Методы.
        public void GiveBonus(float amount)
        {
            currPay += amount;
        }

        // Обновлённый метод DisplayStats() теперь учитывает возраст.
        public void DisplayStats()
        {
            // Имя сотрудника
            Console.WriteLine($"Имя: {empName}");
            // Идентификационный номер сотрудника
            Console.WriteLine($"ID: {empID}");
            // Возраст
            Console.WriteLine($"Возраст: {empAge}");
            // Текущая выплата
            Console.WriteLine($"Выплата: {currPay}");
        }

        // Метод доступа (метод get).
        public string GetName()
        {
            return empName;
        }

        // Метод изменения (метод set).
        public void SetName(string name)
        {
            // Перед присваиванием проверить входное значение.
            if (name.Length > 15) Console.WriteLine("Ошибка! Длина имени превышает 15 символов!");
            else empName = name;
        }

        // Свойства.
        public string Name
        {
            get { return empName; }
            set
            {
                // Здесь value на самом деле имеет тип string.
                if (value.Length > 15) Console.WriteLine("Ошибка! Длина имени превышает 15 символов!");
                else empName = value;
            }
        }

        // Можно было бы добавить дополнительные бизнес-правила для установки этих свойств, но в настоящем примере в этом нет необходимости.
        // int представляет тип данных, инкапсулируемых этим свойством. Обратите внимание на отсутствие круглых скобок.
        public int ID
        {
            get { return empID; }
            set { empID = value; }
        }
        public float Pay
        {
            get { return currPay; }
            set { currPay = value; }
        }
        public int Age
        {
            get { return empAge; }
            set { empAge = value; }
        }
    }
}
