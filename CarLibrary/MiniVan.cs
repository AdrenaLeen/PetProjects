namespace CarLibrary
{
    public class MiniVan : Car
    {
        public MiniVan() { }
        public MiniVan(string name, int maxSpeed, int currentSpeed) : base(name, maxSpeed, currentSpeed) { }

        public override void TurboBoost()
        {
            // У минивэнов плохие возможности ускорения!
            State = EngineStateEnum.EngineDead;
            Console.WriteLine("Ваш блок двигателя взорвался!");
        }
    }
}
