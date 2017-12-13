﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    // Защищённые данные состояния.
    // Теперь сотрудники имеют льготы.
    partial class Employee
    {
        // Производные классы теперь могут иметь прямой доступ к этой информации.
        protected string empName;
        protected int empID;
        protected float currPay;
        protected int empAge;
        protected string empSSN = "";
        // Содержит объект BenefitPackage.
        protected BenefitPackage empBenefits = new BenefitPackage();

        // Обновлённые конструкторы.
        public Employee() { }
        public Employee(string name, int id, float pay) : this(name, 0, id, pay, "") { }
        public Employee(string name, int age, int id, float pay)
        {
            // Уже лучше! Используйте свойства для установки данных класса. Это сократит количество дублированных проверок на предмет ошибок.
            Name = name;
            Age = age;
            ID = id;
            Pay = pay;
        }

        public Employee(string name, int age, int id, float pay, string ssn) : this(name, age, id, pay)
        {
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
            get { return empAge; }
            set { empAge = value; }
        }
        public string SocialSecurityNumber
        {
            get { return empSSN; }
        }
        // Открывает доступ к объекту через специальное свойство.
        public BenefitPackage Benefits
        {
            get { return empBenefits; }
            set { empBenefits = value; }
        }
    }
}