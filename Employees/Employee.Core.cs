using System;

namespace Employees
{
    partial class Employee
    {
        protected string empName = string.Empty;
        protected int empID;
        protected float currPay;
        protected int empAge;
        protected string empSSN = string.Empty;
        protected EmployeePayTypeEnum empPayType;
        protected BenefitPackage empBenefits = new();

        public BenefitPackage Benefits
        {
            get => empBenefits;
            set => empBenefits = value;
        }

        public string Name
        {
            get => empName;
            set
            {
                if (value.Length > 15) Console.WriteLine("Ошибка! Длина имени превышает 15 символов!");
                else empName = value;
            }
        }

        public int Id
        {
            get => empID;
            set => empID = value;
        }

        public float Pay
        {
            get => currPay;
            set => currPay = value;
        }

        public int Age
        {
            get => empAge;
            set => empAge = value;
        }

        public EmployeePayTypeEnum PayType
        {
            get => empPayType;
            set => empPayType = value;
        }

        public string SocialSecurityNumber
        {
            get => empSSN;
            private set => empSSN = value;
        }
    }
}
