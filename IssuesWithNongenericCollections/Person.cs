namespace IssuesWithNongenericCollections
{
    class Person
    {
        public int Age { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public Person() { }
        public Person(string firstName, string lastName, int age)
        {
            Age = age;
            FirstName = firstName;
            LastName = lastName;
        }

        public override string ToString() => $"Имя: {FirstName} {LastName}, Возраст: {Age}";
    }
}
