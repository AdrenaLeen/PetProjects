using FunWithRefTypeValTypeParams;

// Передача ссылочных типов по значению
Console.WriteLine("***** Передача объектов Person по значению *****");
var fred = new Person("Фред", 12);
// Перед вызовом
Console.WriteLine("До вызова по значению Person равно:");
fred.Display();
SendAPersonByValue(fred);
// После вызова
Console.WriteLine("После вызова по значению Person равно:");
fred.Display();
Console.WriteLine();

// Передача ссылочных типов по ссылке
Console.WriteLine("***** Передача объектов Person по ссылке *****");
var mel = new Person("Мэл", 23);
// Перед вызовом
Console.WriteLine("До вызова по ссылке Person равно:");
mel.Display();
SendAPersonByReference(ref mel);
// После вызова
Console.WriteLine("После вызова по ссылке Person равно:");
mel.Display();

Console.ReadLine();

static void SendAPersonByValue(Person p)
{
    // Изменить значение возраста в p?
    p.personAge = 99;

    // Увидит ли вызывающий код это изменение?
    p = new Person("Никки", 99);
}

static void SendAPersonByReference(ref Person p)
{
    // Изменить некоторые данные в p.
    p.personAge = 555;

    // p теперь указывает на новый объект в куче!
    p = new Person("Никки", 999);
}