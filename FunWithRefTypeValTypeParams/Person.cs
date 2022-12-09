namespace FunWithRefTypeValTypeParams
{
    class Person
    {
        public string personName;
        public int personAge;

        // Конструктор.
        public Person(string name, int age)
        {
            personName = name;
            personAge = age;
        }

        public void Display() => Console.WriteLine($"Имя: {personName}, Возраст: {personAge}");
    }
}
