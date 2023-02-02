using Employees;

Console.WriteLine("***** Иерархия класса Employee *****");
_ = new SalesPerson
{
    Age = 31,
    Name = "Фрэд",
    SalesNumber = 50
};

var chucky = new Manager("Чаки", 50, 92, 100000, "333-23-2322", 9000);
double cost = Employee.GetBenefitCost();

// Определить уровень льгот
Employee.BenefitPackage.BenefitPackageLevel myBenefitLevel = Employee.BenefitPackage.BenefitPackageLevel.Platinum;

// Выдать каждому сотруднику бонус?
chucky.GiveBonus(300);
chucky.DisplayStats();
Console.WriteLine();

SalesPerson fran = new SalesPerson("Фрэн", 43, 93, 3000, "932-32-3232", 31);
fran.GiveBonus(200);
fran.DisplayStats();
Console.WriteLine();

CastingExamples();

Console.ReadLine();

static void GivePromotion(Employee emp)
{
    // Повысить зарплату...
    // Предоставить место на парковке компании...
    Console.WriteLine($"{emp.Name} был продвинут по служебной лестнице!");

    switch (emp)
    {
        case SalesPerson s when s.SalesNumber > 5:
            Console.WriteLine($"{emp.Name} сделал {s.SalesNumber} продаж!");
            break;
        case Manager m:
            Console.WriteLine($"У {emp.Name} {m.StockOptions} опционов...");
            break;
    }
}

static void CastingExamples()
{
    // Manager "является" System.Object, поэтому в переменной типа object можно сохранить ссылку на Manager.
    object frank = new Manager("Фрэнк Цаппа", 9, 3000, 40000, "111-11-1111", 5);
    GivePromotion((Manager)frank);

    // Manager также "является" Employee.
    Employee moonUnit = new Manager("МунЮнит Цаппа", 2, 3001, 20000, "101-11-1321", 1);
    GivePromotion(moonUnit);

    // PTSalesPerson "является" SalesPerson.
    SalesPerson jill = new PTSalesPerson("Jill", 834, 3002, 100000, "111-12-1119", 90);
    GivePromotion(jill);
}