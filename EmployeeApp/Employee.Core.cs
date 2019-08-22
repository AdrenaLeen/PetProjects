using System;

namespace EmployeeApp
{
    partial class Employee
    {
        // Поля данных.
        private string empName;
        private int empID;
        private float currPay;
        // Новое поле и свойство.
        private int empAge;
        private string empSSN = "";

        // Обновлённые конструкторы.
        public Employee() { }
        public Employee(string name, int id, float pay) : this(name, 0, id, pay, "") { }
        public Employee(string name, int age, int id, float pay, string ssn)
        {
            // Уже лучше! Используйте свойства для установки данных класса. Это сократит количество дублированных проверок на предмет ошибок.
            Name = name;
            Age = age;
            ID = id;
            Pay = pay;
            // Проверить должным образом входной параметр ssn и затем установить значение.
            empSSN = ssn;
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
            get => empAge;
            set => empAge = value;
        }
        public string SocialSecurityNumber
        {
            get { return empSSN; }
        }
    }
}
