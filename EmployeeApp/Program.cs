using EmployeeApp;

Console.WriteLine("***** Инкапсуляция *****");
var emp = new Employee("Марвин", 45, 123, 1000, "111-11-1111", EmployeePayTypeEnum.Salaried);
Console.WriteLine(emp.Pay);
emp.GiveBonus(100);
Console.WriteLine(emp.Pay);

Console.ReadLine();