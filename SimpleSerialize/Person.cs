namespace SimpleSerialize
{
    public class Person
    {
        // Открытое поле.
        public bool isAlive = true;

        // Закрытое поле.
        private readonly int personAge = 21;

        // Открытое свойство / закрытые данные.
        private string fName = string.Empty;
        public string FirstName
        {
            get { return fName; }
            set { fName = value; }
        }
        public override string ToString() => $"IsAlive:{isAlive} FirstName:{FirstName} Age:{personAge}";
    }
}
