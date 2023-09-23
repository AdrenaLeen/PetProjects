namespace CarLibrary
{
    // Абстрактный базовый класс в иерархии.
    public abstract class Car
    {
        public string PetName { get; set; } = string.Empty;
        public int CurrentSpeed { get; set; }
        public int MaxSpeed { get; set; }

        protected EngineStateEnum State = EngineStateEnum.EngineAlive;
        public EngineStateEnum EngineState => State;
        public abstract void TurboBoost();
        protected Car() => Console.WriteLine("CarLibrary версия 2.0!");
        protected Car(string name, int maxSpeed, int currentSpeed)
        {
            Console.WriteLine("CarLibrary версия 2.0!");
            PetName = name;
            MaxSpeed = maxSpeed;
            CurrentSpeed = currentSpeed;
        }

        public static void TurnOnRadio(bool musicOn, MusicMediaEnum mm) => Console.WriteLine(musicOn ? $"Слушаем {mm}" : "Время тишины...");
    }
}
