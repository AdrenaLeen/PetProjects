namespace SimpleGC
{
    class Car
    {
        public int CurrentSpeed { get; set; }
        public string PetName { get; set; } = string.Empty;

        public Car() { }
        public Car(string name, int speed)
        {
            PetName = name;
            CurrentSpeed = speed;
        }
        public override string ToString() => $"{PetName} едет со скоростью {CurrentSpeed} км/ч";
    }
}
