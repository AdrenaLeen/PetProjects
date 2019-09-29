namespace PublicDelegateProblem
{
    public class Car
    {
        public delegate void CarEngineHandler(string msgForCaller);

        // Теперь это член public!
        public CarEngineHandler listOfHandlers;

        // Просто вызвать уведомление Exploded.
        public void Accelerate() => listOfHandlers?.Invoke("Простите, эта машина умерла...");
    }
}
