using ObjectOverrides;

Console.WriteLine("***** Тип System.Object *****");
var p1 = new Person();

// Использовать унаследованные члены System.Object.
Console.WriteLine($"ToString: {p1}");
Console.WriteLine($"Хэш: {p1.GetHashCode()}");
Console.WriteLine($"Тип: {p1.GetType()}");

// Создать другие ссылки на p1.
Person p2 = p1;
object o = p2;
// Указывают ли ссылки на один и тот же объект в памяти?
if (o.Equals(p1) && p2.Equals(o)) Console.WriteLine("Одинаковые сущности!");

// ПРИМЕЧАНИЕ: эти объекты идентичны и предназначены для тестирования методов Equals() и GetHashCode().
var p3 = new Person("Гомер", "Симпсон", 50, "111-11-1111");
var p4 = new Person("Гомер", "Симпсон", 50, "111-11-1111");

// Получить строковые версии объектов.
Console.WriteLine($"p3.ToString() = {p3}");
Console.WriteLine($"p4.ToString() = {p4}");

// Протестировать переопределённый метод Equals().
Console.WriteLine($"p3 = p4?: {p3.Equals(p4)}");

// Проверить хеш-коды.
Console.WriteLine($"Одинаковые хеш-коды?: {p3.GetHashCode() == p4.GetHashCode()}");
Console.WriteLine();

// Изменить возраст p4 и протестировать снова.
p4.Age = 45;
Console.WriteLine($"p3.ToString() = {p3}");
Console.WriteLine($"p4.ToString() = {p4}");
Console.WriteLine($"p3 = p4?: {p3.Equals(p4)}");
Console.WriteLine($"Одинаковые хеш-коды?: {p3.GetHashCode() == p4.GetHashCode()}");

StaticMembersOfObject();

Console.ReadLine();

static void StaticMembersOfObject()
{
    // Статические члены System.Object.
    var p3 = new Person("Салли", "Джонс", 4, string.Empty);
    var p4 = new Person("Салли", "Джонс", 4, string.Empty);
    Console.WriteLine($"У P3 и P4 одинаковое состояние: {Equals(p3, p4)}");
    Console.WriteLine($"P3 и P4 указывают на один и тот же объект: {ReferenceEquals(p3, p4)}");
}